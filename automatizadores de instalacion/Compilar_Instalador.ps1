<#
.SYNOPSIS
    Script automatizado para compilar la solución y generar el instalador autocontenido de Windows.
    Sistema de Gestión Departamento Mantención (.NET 8 x64 Autocontenido) - Cambiaso Hnos. S.A.C.
#>

[CmdletBinding()]
param(
    [string]$NuevaVersion,
    [switch]$IncrementarPatch,
    [switch]$IncrementarMinor
)

$ErrorActionPreference = "Stop"
$scriptDir = if ($PSScriptRoot) { $PSScriptRoot } else { (Get-Location).Path }
$rootDir = $scriptDir
if (-not (Test-Path (Join-Path $rootDir "mantencion\mantencion.vbproj"))) {
    $parent = Split-Path $scriptDir -Parent
    if (Test-Path (Join-Path $parent "mantencion\mantencion.vbproj")) {
        $rootDir = $parent
    }
}

# Sincronizar / resolver versión centralizada desde VERSION.txt
$syncScript = Join-Path $scriptDir "Actualizar_Version.ps1"
if (Test-Path $syncScript) {
    $syncParams = @{}
    if (-not [string]::IsNullOrWhiteSpace($NuevaVersion)) { $syncParams["NuevaVersion"] = $NuevaVersion }
    if ($IncrementarPatch) { $syncParams["IncrementarPatch"] = $true }
    if ($IncrementarMinor) { $syncParams["IncrementarMinor"] = $true }
    & $syncScript @syncParams | Out-Null
}

$versionFile = Join-Path $rootDir "VERSION.txt"
$appVersion = if (Test-Path $versionFile) { (Get-Content -Path $versionFile -Raw).Trim().TrimStart('v', 'V') } else { "2026.2.0" }
$fileVersion = "$appVersion.0"
$tagVersion = "v$appVersion"

Write-Host "==========================================================" -ForegroundColor Cyan
Write-Host "  COMPILADOR DE INSTALADOR - SISTEMA DE GESTION MANTENCION" -ForegroundColor Cyan
Write-Host "  Versión: $tagVersion LTS ($fileVersion)" -ForegroundColor Green
Write-Host "  Microsoft .NET 8 (x64 Autocontenido - Zero Dependency)  " -ForegroundColor Cyan
Write-Host "  Cambiaso Hnos. S.A.C." -ForegroundColor Cyan
Write-Host "==========================================================" -ForegroundColor Cyan
Write-Host ""

# 1. Compilación Debug/Release y Publicación Autocontenida con .NET 8 SDK
Write-Host "[1/4] Restaurando y compilando soluciones Debug y Release (.NET 8)..." -ForegroundColor Yellow
$slnPath = Join-Path $rootDir "mantencion.sln"
$projectPath = Join-Path $rootDir "mantencion\mantencion.vbproj"
$publishDir = Join-Path $rootDir "mantencion\bin\Release\net8-selfcontained-x64"

& dotnet restore $slnPath --nologo
if ($LASTEXITCODE -ne 0) {
    Write-Host "[ERROR] dotnet restore fallo con codigo $LASTEXITCODE." -ForegroundColor Red
    exit $LASTEXITCODE
}

foreach ($cfg in @("Debug", "Release")) {
    & dotnet build $slnPath -c $cfg --no-restore --no-incremental --nologo -v m
    if ($LASTEXITCODE -ne 0) {
        Write-Host "[ERROR] La compilacion ($cfg) fallo con codigo $LASTEXITCODE." -ForegroundColor Red
        exit $LASTEXITCODE
    }
}

Write-Host "[2/4] Publicando y depurando aplicacion autocontenida (Self-Contained win-x64)..." -ForegroundColor Yellow

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

# Depurar ensamblados WPF, símbolos de depuración e idiomas extranjeros (conservando 'es') y sincronizar deps.json
$pruneScript = Join-Path $rootDir "automatizadores de instalacion\depurar_publicacion.py"
$pythonCmd = Get-Command python -ErrorAction SilentlyContinue
if (-not $pythonCmd) { $pythonCmd = Get-Command python3 -ErrorAction SilentlyContinue }
if ($pythonCmd -and (Test-Path $pruneScript)) {
    & $pythonCmd.Source $pruneScript $publishDir
    if ($LASTEXITCODE -ne 0) {
        Write-Host "[ERROR] depurar_publicacion.py fallo con codigo $LASTEXITCODE." -ForegroundColor Red
        exit $LASTEXITCODE
    }
} else {
    $foreignLocales = @("cs", "de", "en", "fr", "it", "ja", "ko", "pl", "pt-BR", "ru", "tr", "zh-Hans", "zh-Hant")
    foreach ($locale in $foreignLocales) {
        $localePath = Join-Path $publishDir $locale
        if (Test-Path $localePath) {
            Remove-Item $localePath -Recurse -Force
        }
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

# 3. Empaquetar NuGet (.nupkg) y compilar el Instalador
Write-Host "[3/4] Generando paquete NuGet (.nupkg) e instalador ejecutable con Inno Setup..." -ForegroundColor Yellow
$installerDir = Join-Path $rootDir "Instalador"
if (-not (Test-Path $installerDir)) {
    New-Item -ItemType Directory -Path $installerDir -Force | Out-Null
}
& dotnet pack $projectPath -c Release --no-build -o $installerDir --nologo
if ($LASTEXITCODE -ne 0) {
    Write-Host "[ERROR] Fallo la generacion del paquete NuGet con codigo $LASTEXITCODE." -ForegroundColor Red
    exit $LASTEXITCODE
}

$issScript = Join-Path $rootDir "Setup_Mantencion.iss"

& $iscc $issScript
if ($LASTEXITCODE -ne 0) {
    Write-Host "[ERROR] Fallo la creacion del instalador con codigo $LASTEXITCODE." -ForegroundColor Red
    exit $LASTEXITCODE
}

# 4. Verificacion final y checksums SHA-256
$outputExe = Join-Path $rootDir "Instalador\Instalador_Sistema_Mantencion_$tagVersion.exe"
if (Test-Path $outputExe) {
    $item = Get-Item $outputExe
    $hash = (Get-FileHash $outputExe -Algorithm SHA256).Hash
    $sizeMb = [Math]::Round($item.Length / 1MB, 2)

    $checksumsPath = Join-Path $rootDir "Instalador\checksums_sha256.txt"
    $info = @"
Archivo: $($item.Name)
Versión: $appVersion
Tamaño: $sizeMb MB ($($item.Length) bytes)
Fecha Generación: $(Get-Date -Format 'yyyy-MM-dd HH:mm:ss')
Plataforma: Microsoft .NET 8 LTS (Windows x64 - Autocontenido)
Algoritmo: SHA-256
Hash: $hash
"@
    Set-Content -Path $checksumsPath -Value $info -Encoding UTF8

    Write-Host ""
    Write-Host "[4/4] Instalador y paquete NuGet generados exitosamente!" -ForegroundColor Green
    Write-Host "       Versión : $tagVersion ($fileVersion)" -ForegroundColor White
    Write-Host "       Archivo : $($item.FullName)" -ForegroundColor White
    Write-Host "       Tamano  : $sizeMb MB ($($item.Length) bytes)" -ForegroundColor White
    Write-Host "       SHA256  : $hash" -ForegroundColor Yellow
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
