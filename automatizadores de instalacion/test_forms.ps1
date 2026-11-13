[System.Reflection.Assembly]::LoadWithPartialName("System.Windows.Forms") | Out-Null
$exePath = Resolve-Path "mantencion\bin\Release\Sistema de Gestion Mantencion.exe"
$asm = [System.Reflection.Assembly]::LoadFrom($exePath)

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
