<#
.SYNOPSIS
    Actualiza y sincroniza centralizadamente la versión del proyecto en VERSION.txt,
    version.iss (Inno Setup), mantencion.vbproj e InfoSoftware.rtf.
.EXAMPLE
    .\Actualizar_Version.ps1 -NuevaVersion 2026.2.1
    .\Actualizar_Version.ps1 -IncrementarPatch
    .\Actualizar_Version.ps1 -IncrementarMinor -NotasVersion "Mejoras en Carta Gantt"
#>

[CmdletBinding()]
param(
    [string]$NuevaVersion,
    [switch]$IncrementarPatch,
    [switch]$IncrementarMinor,
    [string]$NotasVersion
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

$versionFile = Join-Path $rootDir "VERSION.txt"
$currentVersion = "2026.2.0"
if (Test-Path $versionFile) {
    $raw = (Get-Content -Path $versionFile -Raw).Trim()
    if (-not [string]::IsNullOrWhiteSpace($raw)) {
        $currentVersion = $raw.TrimStart('v', 'V')
    }
}

if (-not ($currentVersion -match '^(\d+)\.(\d+)\.(\d+)$')) {
    throw "Formato inválido en VERSION.txt ('$currentVersion'). Se esperaba MAYOR.MENOR.PARCHE (ejemplo: 2026.2.0)."
}

$major = [int]$Matches[1]
$minor = [int]$Matches[2]
$patch = [int]$Matches[3]

if (-not [string]::IsNullOrWhiteSpace($NuevaVersion)) {
    $clean = $NuevaVersion.Trim().TrimStart('v', 'V')
    if (-not ($clean -match '^(\d+)\.(\d+)\.(\d+)$')) {
        throw "La versión especificada '$NuevaVersion' no cumple MAYOR.MENOR.PARCHE (ejemplo: 2026.2.1)."
    }
    $targetVersion = $clean
} elseif ($IncrementarMinor) {
    $targetVersion = "$major.$($minor + 1).0"
} elseif ($IncrementarPatch) {
    $targetVersion = "$major.$minor.$($patch + 1)"
} else {
    $targetVersion = $currentVersion
}

$fileVersion = "$targetVersion.0"
$tagVersion = "v$targetVersion"

Write-Host "==========================================================" -ForegroundColor Cyan
Write-Host "  CONTROL DE VERSIONADO — SISTEMA DE MANTENCIÓN" -ForegroundColor Cyan
Write-Host "  Versión anterior : $currentVersion" -ForegroundColor Gray
Write-Host "  Versión objetivo : $targetVersion ($tagVersion / $fileVersion)" -ForegroundColor Green
Write-Host "==========================================================" -ForegroundColor Cyan

# 1. VERSION.txt
[System.IO.File]::WriteAllText($versionFile, "$targetVersion`r`n", [System.Text.UTF8Encoding]::new($false))

# 2. version.iss (Inno Setup)
$versionIssPath = Join-Path $rootDir "version.iss"
$versionIssContent = @"
; Archivo centralizado de versión para Inno Setup (sincronizado automáticamente con VERSION.txt)
#define MyAppVersion "$targetVersion"
#define MyAppFileVersion "$fileVersion"
#define MyAppTagVersion "$tagVersion"
"@
[System.IO.File]::WriteAllText($versionIssPath, $versionIssContent, [System.Text.UTF8Encoding]::new($false))

# 3. mantencion\mantencion.vbproj (respaldo estático y PackageReleaseNotes opcional)
$vbprojPath = Join-Path $rootDir "mantencion\mantencion.vbproj"
if (Test-Path $vbprojPath) {
    $vbprojText = [System.IO.File]::ReadAllText($vbprojPath, [System.Text.Encoding]::UTF8)
    $vbprojText = [regex]::Replace(
        $vbprojText,
        '<Version Condition="''\$\(Version\)'' == ''''">[^<]+</Version>',
        "<Version Condition=""'`$(Version)' == ''"">$targetVersion</Version>"
    )
    if (-not [string]::IsNullOrWhiteSpace($NotasVersion)) {
        $notasLimpias = [System.Security.SecurityElement]::Escape($NotasVersion.Trim())
        $vbprojText = [regex]::Replace(
            $vbprojText,
            '<PackageReleaseNotes>[^<]*</PackageReleaseNotes>',
            "<PackageReleaseNotes>Versión $targetVersion LTS: $notasLimpias</PackageReleaseNotes>"
        )
    }
    [System.IO.File]::WriteAllText($vbprojPath, $vbprojText, [System.Text.Encoding]::UTF8)
}

# 4. InfoSoftware.rtf
$rtfPath = Join-Path $rootDir "InfoSoftware.rtf"
if (Test-Path $rtfPath) {
    $rtfText = [System.IO.File]::ReadAllText($rtfPath, [System.Text.Encoding]::ASCII)
    $rtfUpdated = [regex]::Replace($rtfText, "Versi\\'f3n\s+[0-9]+\.[0-9]+(?:\.[0-9]+)?\s+LTS", "Versi\'f3n $targetVersion LTS")
    [System.IO.File]::WriteAllText($rtfPath, $rtfUpdated, [System.Text.Encoding]::ASCII)
}

Write-Host "[OK] Archivos sincronizados:" -ForegroundColor Green
Write-Host "     - VERSION.txt"
Write-Host "     - version.iss"
Write-Host "     - mantencion\mantencion.vbproj"
Write-Host "     - InfoSoftware.rtf"
Write-Host ""
Write-Host "Siguientes pasos sugeridos:" -ForegroundColor Yellow
Write-Host "  1. Compilar instaladores: .\automatizadores de instalacion\Compilar_Instalador.ps1" -ForegroundColor Gray
Write-Host "  2. Hacer commit y push a main para disparar la compilación/release $tagVersion en GitHub." -ForegroundColor Gray
