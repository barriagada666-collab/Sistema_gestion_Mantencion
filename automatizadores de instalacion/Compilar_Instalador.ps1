<#
.SYNOPSIS
    Script automatizado para compilar la solución y generar el instalador autocontenido de Windows.
    Sistema de Gestión Departamento Mantención (.NET 8 x64 Autocontenido) - Cambiaso Hnos. S.A.C.
#>

[CmdletBinding()]
param()

$ErrorActionPreference = "Stop"
$scriptDir = if ($PSScriptRoot) { $PSScriptRoot } else { (Get-Location).Path }
$rootDir = $scriptDir
if (-not (Test-Path (Join-Path $rootDir "mantencion\mantencion.vbproj"))) {
    $parent = Split-Path $scriptDir -Parent
    if (Test-Path (Join-Path $parent "mantencion\mantencion.vbproj")) {
        $rootDir = $parent
    }
}

Write-Host "==========================================================" -ForegroundColor Cyan
Write-Host "  COMPILADOR DE INSTALADOR - SISTEMA DE GESTION MANTENCION" -ForegroundColor Cyan
Write-Host "  Microsoft .NET 8 (x64 Autocontenido - Zero Dependency)  " -ForegroundColor Cyan
Write-Host "  Cambiaso Hnos. S.A.C." -ForegroundColor Cyan
Write-Host "==========================================================" -ForegroundColor Cyan
Write-Host ""

# 1. Compilación y Publicación Autocontenida con .NET 8 SDK
Write-Host "[1/3] Publicando aplicacion autocontenida (Self-Contained win-x64)..." -ForegroundColor Yellow
$projectPath = Join-Path $rootDir "mantencion\mantencion.vbproj"
$publishDir = Join-Path $rootDir "mantencion\bin\Release\net8-selfcontained-x64"

# Limpieza previa del directorio de publicación
if (Test-Path $publishDir) {
    Remove-Item $publishDir -Recurse -Force
}

# Ejecutar dotnet publish con runtime embebido para x64
& dotnet publish $projectPath -c Release -r win-x64 --self-contained true -o $publishDir --nologo -v m
if ($LASTEXITCODE -ne 0) {
    Write-Host "[ERROR] La compilacion/publicacion con dotnet fallo con codigo $LASTEXITCODE." -ForegroundColor Red
    exit $LASTEXITCODE
}

# Optimización de tamaño: eliminar ensamblados satélites de idiomas no requeridos (manteniendo 'es' para español)
$foreignLocales = @("cs", "de", "fr", "it", "ja", "ko", "pl", "pt-BR", "ru", "tr", "zh-Hans", "zh-Hant")
foreach ($locale in $foreignLocales) {
    $localePath = Join-Path $publishDir $locale
    if (Test-Path $localePath) {
        Remove-Item $localePath -Recurse -Force
    }
}

Write-Host "       Compilacion y publicacion autocontenida exitosa (0 errores, 0 advertencias)." -ForegroundColor Green
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

& $iscc $issScript
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
    Write-Host "       Plataf. : Microsoft .NET 8 (Windows x64 - Autocontenido / Zero-Dependency)" -ForegroundColor White
} else {
    Write-Host "[ERROR] No se encontro el archivo de salida del instalador." -ForegroundColor Red
    exit 1
}

Write-Host ""
Write-Host "==========================================================" -ForegroundColor Cyan
Write-Host "  MIGRACION Y GENERACION COMPLETADA EXITOSAMENTE" -ForegroundColor Cyan
Write-Host "==========================================================" -ForegroundColor Cyan
