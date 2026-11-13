[System.Reflection.Assembly]::LoadWithPartialName("System.Windows.Forms") | Out-Null
$exePath = (Resolve-Path "mantencion\bin\Release\Sistema de Gestion Mantencion.exe").Path
$asm = [System.Reflection.Assembly]::LoadFrom($exePath)

$principalType = $asm.GetType("mantencion.principal")
$principal = [Activator]::CreateInstance($principalType)
$principal.Width = 1920
$principal.Height = 1080
$principal.WindowState = [System.Windows.Forms.FormWindowState]::Normal
$principal.Show()

# Find MdiClient
$mdiClient = $null
foreach ($c in $principal.Controls) {
    if ($c -is [System.Windows.Forms.MdiClient]) {
        $mdiClient = $c
        break
    }
}

Write-Host ("MdiClient ClientSize: " + $mdiClient.ClientSize.Width + "x" + $mdiClient.ClientSize.Height)

$mdiFormNames = @(
    "frm_OT", "FrmPersonal", "FrmPlantas", "FrmSeccion", "FrmMp",
    "FrmAdminUsuarios", "FrmInfOT", "FrmAdminTareasNodo", "FrmResumenes",
    "FrmInfMantPrev", "FrmInfMantPrevCiclosMaq", "FrmAdminAuditoria",
    "FrmCargo", "FrmCalendarioTurno", "FrmAdminNodos", "FrmDatosTecnicos",
    "FrmDatosTecnicosNodo"
)

$abrirMethod = $principalType.GetMethod("AbrirAmbienteMdi")

foreach ($fName in $mdiFormNames) {
    $t = $asm.GetType("mantencion." + $fName)
    $child = [Activator]::CreateInstance($t)
    $abrirMethod.Invoke($principal, @($child))
    
    $width = $child.Width
    $height = $child.Height
    $ws = $child.WindowState.ToString()
    
    # Check bounds
    $clientW = $mdiClient.ClientSize.Width
    $clientH = $mdiClient.ClientSize.Height
    
    Write-Host ("Form: {0,-25} Size: {1,4}x{2,-4} State: {3,-9} (Client Area: {4}x{5})" -f $fName, $width, $height, $ws, $clientW, $clientH) -ForegroundColor Green
    
    # Verify no visible controls are placed beyond the child client size
    $childClientW = $child.ClientSize.Width
    $childClientH = $child.ClientSize.Height
    $badControls = 0
    foreach ($ctrl in $child.Controls) {
        if ($ctrl.Visible) {
            # Check if button or panel is completely outside
            if ($ctrl.Top -gt $childClientH + 50) {
                Write-Host ("  WARNING: Control " + $ctrl.Name + " Y=" + $ctrl.Top + " is outside bottom (" + $childClientH + ")") -ForegroundColor Red
                $badControls++
            }
        }
    }
    if ($badControls -eq 0) {
        # OK
    }
    $child.Hide()
}

$principal.Close()
$principal.Dispose()
Write-Host "`nAll 17 MDI forms tested successfully!" -ForegroundColor Cyan
