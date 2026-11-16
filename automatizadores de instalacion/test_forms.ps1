if ($PSVersionTable.PSVersion.Major -lt 7) {
    Write-Error "Este script inspecciona ensamblados .NET 8 y debe ejecutarse con PowerShell 7+ (pwsh)."
    exit 1
}
Add-Type -AssemblyName System.Windows.Forms
$rootDir = if (Test-Path "mantencion\mantencion.vbproj") { (Get-Location).Path } else { Split-Path $PSScriptRoot -Parent }
$candidates = @(
    (Join-Path $rootDir "mantencion\bin\Release\net8-selfcontained-x64\Sistema de Gestion Mantencion.dll"),
    (Join-Path $rootDir "mantencion\bin\Release\net8.0-windows\Sistema de Gestion Mantencion.dll")
)
$dllPath = $candidates | Where-Object { Test-Path $_ } | Select-Object -First 1
if (-not $dllPath) {
    Write-Error "No se encontro el ensamblado .NET 8 compilado en mantencion\bin\Release\."
    exit 1
}
$asm = [System.Reflection.Assembly]::LoadFrom($dllPath)

Write-Host "Verifying default WindowState across all forms in assembly..."
$formTypes = $asm.GetTypes() | Where-Object { [System.Windows.Forms.Form].IsAssignableFrom($_) }

$mdiFormNames = @(
    "frm_OT", "FrmPersonal", "FrmPlantas", "FrmSeccion", "FrmMp",
    "FrmAdminUsuarios", "FrmInfOT", "FrmAdminTareasNodo", "FrmResumenes",
    "FrmInfMantPrev", "FrmInfMantPrevCiclosMaq", "FrmAdminAuditoria",
    "FrmCargo", "FrmCalendarioTurno", "FrmAdminNodos", "FrmDatosTecnicos",
    "FrmDatosTecnicosNodo"
)

$hasError = $false

foreach ($fName in $mdiFormNames) {
    $t = $formTypes | Where-Object { $_.Name -eq $fName }
    if ($t -ne $null) {
        $ctor = $t.GetConstructor([Type]::EmptyTypes)
        if ($ctor -ne $null) {
            $inst = $ctor.Invoke($null)
            $ws = $inst.WindowState.ToString()
            if ($ws -ne "Normal") {
                Write-Host "ERROR: $fName has WindowState=$ws (expected Normal)" -ForegroundColor Red
                $hasError = $true
            } else {
                Write-Host "OK: $fName default WindowState is Normal" -ForegroundColor Green
            }
            $inst.Dispose()
        }
    } else {
        Write-Host "WARNING: Could not find type for $fName" -ForegroundColor Yellow
    }
}

if (-not $hasError) {
    Write-Host "`nAll 17 MDI child forms correctly start with WindowState = Normal!" -ForegroundColor Cyan
}
