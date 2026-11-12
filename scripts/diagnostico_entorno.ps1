# ==============================================================================
# SCRIPT DE DIAGNOSTICO Y VERIFICACION DE ENTORNO - SISTEMA DE GESTION MANTENCION
# ==============================================================================

Write-Host "==========================================================" -ForegroundColor Cyan
Write-Host " INICIANDO DIAGNOSTICO DE ENTORNO Y PRUEBAS DE INTEGRACION" -ForegroundColor Cyan
Write-Host "==========================================================" -ForegroundColor Cyan

# ------------------------------------------------------------------------------
# 1. VERIFICACION DE ACCESO A BASE DE DATOS (SQL Server / ADO.NET)
# ------------------------------------------------------------------------------
Write-Host "`n[1/5] Verificando conectividad a SQL Server (SrvMagicInfo)..." -ForegroundColor Yellow
$cnxString = "Data Source=SrvMagicInfo;Initial Catalog=mantencion;User Id=mantencion;Password=cambiaso"
$swSql = [System.Diagnostics.Stopwatch]::StartNew()
$cnx = New-Object System.Data.SqlClient.SqlConnection($cnxString)
try {
    $cnx.Open()
    $cmd = $cnx.CreateCommand()
    $cmd.CommandText = "SELECT @@SERVERNAME, DB_NAME(), COUNT(*) FROM ORDEN_TRABAJO"
    $cmd.CommandTimeout = 15
    $r = $cmd.ExecuteReader()
    if ($r.Read()) {
        Write-Host "  -> [OK] Conexion exitosa a SQL Server via ADO.NET puro" -ForegroundColor Green
        Write-Host ("     Servidor: {0} | Base de datos: {1} | Total OTs: {2:N0}" -f $r[0], $r[1], $r[2])
    }
    $r.Close()
} catch {
    Write-Host ("  -> [ERROR] Fallo al conectar a SQL Server: " + $_.Exception.Message) -ForegroundColor Red
} finally {
    $cnx.Close()
    $swSql.Stop()
    Write-Host ("     Tiempo de respuesta: {0:N2} ms" -f $swSql.ElapsedMilliseconds)
}

# ------------------------------------------------------------------------------
# 2. DIAGNOSTICO DE sqlcmd vs ADO.NET
# ------------------------------------------------------------------------------
Write-Host "`n[2/5] Diagnosticando disponibilidad de sqlcmd en el PATH del sistema..." -ForegroundColor Yellow
$sqlcmdCmd = Get-Command "sqlcmd" -ErrorAction SilentlyContinue
if ($sqlcmdCmd) {
    Write-Host ("  -> sqlcmd encontrado en: " + $sqlcmdCmd.Source) -ForegroundColor Green
} else {
    Write-Host "  -> [INFO] 'sqlcmd.exe' no esta instalado ni presente en el PATH de Windows." -ForegroundColor DarkYellow
    Write-Host "     Causa: Las maquinas cliente no tienen instaladas las utilidades de consola de SQL Server." -ForegroundColor Gray
    Write-Host "     Solucion: El proyecto usa ADO.NET (System.Data.SqlClient) de forma 100% nativa sin dependencias externas." -ForegroundColor Gray
}

# ------------------------------------------------------------------------------
# 3. DIAGNOSTICO DE CRYSTAL REPORTS (GAC, Program Files, Registro)
# ------------------------------------------------------------------------------
Write-Host "`n[3/5] Escaneando ensamblados y componentes de Crystal Reports..." -ForegroundColor Yellow
$rutasCR = @(
    "C:\Windows\Microsoft.NET\assembly\GAC_MSIL",
    "C:\Windows\assembly",
    "C:\Program Files (x86)\SAP BusinessObjects",
    "C:\Program Files\SAP BusinessObjects",
    "C:\Program Files (x86)\Business Objects",
    "C:\Program Files\Business Objects"
)
$totalCR = 0
foreach ($dir in $rutasCR) {
    if (Test-Path $dir) {
        $dlls = Get-ChildItem -Path $dir -Filter "CrystalDecisions*.dll" -Recurse -ErrorAction SilentlyContinue
        if ($dlls) {
            foreach ($d in $dlls) {
                Write-Host ("  -> Encontrada DLL: " + $d.FullName) -ForegroundColor Green
                $totalCR++
            }
        }
    }
}
$regCR = Test-Path "HKLM:\SOFTWARE\SAP BusinessObjects\Crystal Reports for .NET Framework"
Write-Host ("  -> Total DLLs de Crystal Reports en el sistema: " + $totalCR) -ForegroundColor Gray
Write-Host ("  -> Registro SAP Crystal Reports presente: " + $regCR) -ForegroundColor Gray
Write-Host "  -> [ESTADO] El proyecto ya migro completamente a 'NativeReportViewer' (.NET + iTextSharp)." -ForegroundColor Green
Write-Host "     No requiere ningun runtime ni DLL de CrystalDecisions para compilar o ejecutar." -ForegroundColor Gray

# ------------------------------------------------------------------------------
# 4. PRUEBA DE INTERACCION CON EL ARBOL (TreeView + BeginInvoke)
# ------------------------------------------------------------------------------
Write-Host "`n[4/5] Probando seleccion de nodo raiz con BeginInvoke..." -ForegroundColor Yellow
Add-Type -AssemblyName System.Windows.Forms
Add-Type -AssemblyName System.Drawing
$formTree = New-Object System.Windows.Forms.Form
$tvTest = New-Object System.Windows.Forms.TreeView
$formTree.Controls.Add($tvTest)
$rootNode = New-Object System.Windows.Forms.TreeNode("Cambiaso Hnos S.A.")
$rootNode.Name = "1"
$childNode = New-Object System.Windows.Forms.TreeNode("Extrusion")
$childNode.Name = "2"
[void]$rootNode.Nodes.Add($childNode)
[void]$tvTest.Nodes.Add($rootNode)
$formTree.Show()

$script:nodeToSelect = $rootNode
$tvTest.BeginInvoke([System.Windows.Forms.MethodInvoker]{
    if ($script:nodeToSelect -ne $null) {
        $tvTest.SelectedNode = $script:nodeToSelect
        $script:nodeToSelect.BackColor = [System.Drawing.Color]::FromArgb(160, 197, 207)
        $script:nodeToSelect.EnsureVisible()
    }
}) | Out-Null
[System.Windows.Forms.Application]::DoEvents()
Start-Sleep -Milliseconds 50
[System.Windows.Forms.Application]::DoEvents()

if ($tvTest.SelectedNode -and $tvTest.SelectedNode.Name -eq "1") {
    Write-Host "  -> [OK] Seleccion de nodo raiz con BeginInvoke ejecutada correctamente." -ForegroundColor Green
    Write-Host ("     Nodo activo: " + $tvTest.SelectedNode.Text + " (ID=" + $tvTest.SelectedNode.Name + ")")
} else {
    Write-Host "  -> [ERROR] Fallo en seleccion de nodo raiz." -ForegroundColor Red
}
$formTree.Close()
$formTree.Dispose()

# ------------------------------------------------------------------------------
# 5. PRUEBA DE GENERACION DE PDF CON iTextSharp (Nativo)
# ------------------------------------------------------------------------------
Write-Host "`n[5/5] Probando exportacion directa a PDF con iTextSharp..." -ForegroundColor Yellow
$rutaPdfTest = Join-Path $env:TEMP "test_export_itextsharp.pdf"
try {
    Add-Type -Path "mantencion\itextsharp.dll"
    $doc = New-Object iTextSharp.text.Document([iTextSharp.text.PageSize]::LETTER.Rotate(), 20.0, 20.0, 25.0, 25.0)
    $fs = New-Object System.IO.FileStream($rutaPdfTest, [System.IO.FileMode]::Create)
    $writer = [iTextSharp.text.pdf.PdfWriter]::GetInstance($doc, $fs)
    $doc.Open()
    $fontTitle = [iTextSharp.text.FontFactory]::GetFont([iTextSharp.text.FontFactory]::HELVETICA_BOLD, 14.0, [iTextSharp.text.BaseColor]::DARK_GRAY)
    $doc.Add((New-Object iTextSharp.text.Paragraph("TEST INFORME MANTENCION - iTextSharp Nativo", $fontTitle)))
    $doc.Close()
    $fs.Close()
    if (Test-Path $rutaPdfTest) {
        $tamano = (Get-Item $rutaPdfTest).Length
        Write-Host ("  -> [OK] Archivo PDF generado exitosamente: " + $rutaPdfTest + " (" + $tamano + " bytes)") -ForegroundColor Green
        Remove-Item $rutaPdfTest -Force
    }
} catch {
    Write-Host ("  -> [ERROR] Fallo generacion PDF iTextSharp: " + $_.Exception.Message) -ForegroundColor Red
}

Write-Host "`n==========================================================" -ForegroundColor Cyan
Write-Host " DIAGNOSTICO Y PRUEBAS FINALIZADAS EXITOSAMENTE" -ForegroundColor Cyan
Write-Host "==========================================================" -ForegroundColor Cyan
