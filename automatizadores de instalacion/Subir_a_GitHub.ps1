<#
.SYNOPSIS
    Script automatizado para subir el proyecto completo a GitHub:
    https://github.com/barriagada666-collab/Sistema_gestion_Mantencion
#>

param(
    [string]$Token
)

$gitExe = "$env:LOCALAPPDATA\Programs\MinGit\cmd\git.exe"
if (-not (Test-Path $gitExe)) {
    $cmd = Get-Command git -ErrorAction SilentlyContinue
    if ($cmd) { $gitExe = $cmd.Source }
}

if (-not (Test-Path $gitExe)) {
    Write-Host "[ERROR] No se encontro git.exe en el sistema." -ForegroundColor Red
    exit 1
}

$scriptDir = if ($PSScriptRoot) { $PSScriptRoot } else { (Get-Location).Path }
$repoDir = $scriptDir
if (-not (Test-Path (Join-Path $repoDir ".git"))) {
    $parent = Split-Path $scriptDir -Parent
    if (Test-Path (Join-Path $parent ".git")) {
        $repoDir = $parent
    }
}
Set-Location $repoDir

$repoUrl = "https://github.com/barriagada666-collab/Sistema_gestion_Mantencion.git"

Write-Host "==========================================================" -ForegroundColor Cyan
Write-Host "  SUBIR PROYECTO A GITHUB" -ForegroundColor Cyan
Write-Host "  Repositorio: $repoUrl" -ForegroundColor Cyan
Write-Host "==========================================================" -ForegroundColor Cyan
Write-Host ""

# Verificar estado local
& $gitExe status --short
Write-Host ""

$currentBranch = (& $gitExe branch --show-current).Trim()
if (-not $currentBranch) { $currentBranch = "main" }

if ($Token) {
    $authUrl = "https://$($Token)@github.com/barriagada666-collab/Sistema_gestion_Mantencion.git"
    Write-Host "Subiendo rama '$currentBranch' con Personal Access Token (PAT)..." -ForegroundColor Yellow
    & $gitExe push -u $authUrl $currentBranch
} else {
    Write-Host "Iniciando Git Push en rama '$currentBranch'..." -ForegroundColor Yellow
    Write-Host "Si se solicita autenticacion, autorice el acceso en la ventana de su navegador." -ForegroundColor Gray
    & $gitExe push -u origin $currentBranch
}

if ($LASTEXITCODE -eq 0) {
    Write-Host ""
    Write-Host "[EXITO] Proyecto subido exitosamente a GitHub!" -ForegroundColor Green
    Write-Host "        Repositorio: https://github.com/barriagada666-collab/Sistema_gestion_Mantencion" -ForegroundColor White
} else {
    Write-Host ""
    Write-Host "[INFO DE AUTENTICACION]" -ForegroundColor Yellow
    Write-Host "Para autenticar automaticamente sin abrir navegador, puede proporcionar un Token:" -ForegroundColor White
    Write-Host "  1. Genere un token en: https://github.com/settings/tokens (permiso: repo)" -ForegroundColor Gray
    Write-Host "  2. Ejecute: .\Subir_a_GitHub.ps1 -Token 'ghp_tu_token_aqui'" -ForegroundColor Gray
}
