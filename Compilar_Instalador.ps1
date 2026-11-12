<#
.SYNOPSIS
    Script automatizado para compilar la solución y generar el instalador de Windows.
    Sistema de Gestión Departamento Mantención - Cambiaso Hnos. S.A.C.
#>

[CmdletBinding()]
param()

$ErrorActionPreference = "Stop"
$rootDir = if ($PSScriptRoot) { $PSScriptRoot } else { (Get-Location).Path }

Write-Host "==========================================================" -ForegroundColor Cyan
Write-Host "  COMPILADOR DE INSTALADOR - SISTEMA DE GESTION MANTENCION" -ForegroundColor Cyan
Write-Host "  Cambiaso Hnos. S.A.C." -ForegroundColor Cyan
Write-Host "==========================================================" -ForegroundColor Cyan
Write-Host ""

# 1. Localizar MSBuild
$msbuildPaths = @(
    "C:\Program Files\Microsoft Visual Studio\2022\Community\MSBuild\Current\Bin\MSBuild.exe",
    "C:\Program Files\Microsoft Visual Studio\2022\Enterprise\MSBuild\Current\Bin\MSBuild.exe",
    "C:\Program Files\Microsoft Visual Studio\2022\Professional\MSBuild\Current\Bin\MSBuild.exe",
    "C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\MSBuild\Current\Bin\MSBuild.exe",
    "C:\Windows\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe"
)

$msbuild = $null
foreach ($path in $msbuildPaths) {
    if (Test-Path $path) {
        $msbuild = $path
        break
    }
}

if (-not $msbuild) {
    Write-Host "[ERROR] No se encontro MSBuild.exe en el sistema." -ForegroundColor Red
    exit 1
}

Write-Host "[1/3] Compilando solucion en modo Release..." -ForegroundColor Yellow
$solutionPath = Join-Path $rootDir "mantencion.sln"
$buildArgs = @(
    "`"$solutionPath`"",
    "/p:Configuration=Release",
    "/p:Platform=`"Any CPU`"",
    "/t:Rebuild",
    "/v:m",
    "/nologo"
)

& $msbuild $buildArgs
if ($LASTEXITCODE -ne 0) {
    Write-Host "[ERROR] La compilacion de la solucion fallo con codigo $LASTEXITCODE." -ForegroundColor Red
    exit $LASTEXITCODE
}
Write-Host "       Compilacion exitosa (0 errores)." -ForegroundColor Green
Write-Host ""

# 2. Localizar Inno Setup Compiler (ISCC.exe)
$isccPaths = @(
    "$env:LOCALAPPDATA\Programs\Inno Setup 6\ISCC.exe",
    "C:\Program Files (x86)\Inno Setup 6\ISCC.exe",
    "C:\Program Files\Inno Setup 6\ISCC.exe",
    "C:\Program Files (x86)\Inno Setup 5\ISCC.exe"
)

$iscc = $null
foreach ($path in $isccPaths) {
    if (Test-Path $path) {
        $iscc = $path
        break
    }
}

if (-not $iscc) {
    $cmd = Get-Command iscc -ErrorAction SilentlyContinue
    if ($cmd) {
        $iscc = $cmd.Source
    }
}

if (-not $iscc) {
    Write-Host "[ERROR] No se encontro Inno Setup (ISCC.exe)." -ForegroundColor Red
    Write-Host "       Puede instalarlo ejecutando: winget install JRSoftware.InnoSetup" -ForegroundColor Yellow
    exit 1
}

# 3. Compilar el Instalador
Write-Host "[2/3] Generando instalador ejecutable con Inno Setup..." -ForegroundColor Yellow
$issScript = Join-Path $rootDir "Setup_Mantencion.iss"

& $iscc "`"$issScript`""
if ($LASTEXITCODE -ne 0) {
    Write-Host "[ERROR] Fallo la creacion del instalador con codigo $LASTEXITCODE." -ForegroundColor Red
    exit $LASTEXITCODE
}

# 4. Verificacion final
$outputExe = Join-Path $rootDir "Instalador\Instalador_Sistema_Mantencion_v2026.1.exe"
if (Test-Path $outputExe) {
    $item = Get-Item $outputExe
    $sizeMb = [Math]::Round($item.Length / 1MB, 2)
    Write-Host ""
    Write-Host "[3/3] Instalador generado exitosamente!" -ForegroundColor Green
    Write-Host "       Archivo : $($item.FullName)" -ForegroundColor White
    Write-Host "       Tamano  : $sizeMb MB ($($item.Length) bytes)" -ForegroundColor White
    Write-Host "       Fecha   : $($item.LastWriteTime)" -ForegroundColor White
} else {
    Write-Host "[ERROR] No se encontro el archivo de salida del instalador." -ForegroundColor Red
    exit 1
}

Write-Host ""
Write-Host "==========================================================" -ForegroundColor Cyan
Write-Host "  PROCESO COMPLETADO EXITOSAMENTE" -ForegroundColor Cyan
Write-Host "==========================================================" -ForegroundColor Cyan
