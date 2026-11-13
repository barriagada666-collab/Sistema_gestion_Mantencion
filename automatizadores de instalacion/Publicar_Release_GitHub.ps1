<#
.SYNOPSIS
    Script automatizado para publicar o actualizar el instalador oficial en GitHub Releases.
    Sistema de Gestión Departamento Mantención - Cambiaso Hnos. S.A.C.
#>

[CmdletBinding()]
param(
    [string]$Token = $env:GITHUB_TOKEN,
    [string]$TagName = "v2026.1",
    [string]$ReleaseName = "Sistema de Gestión Mantención v2026.1 LTS",
    [string]$Repo = "barriagada666-collab/Sistema_gestion_Mantencion"
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

# Si no se pasó por parámetro o variable de entorno, buscar en archivo local no versionado .github_token
if ([string]::IsNullOrWhiteSpace($Token)) {
    $tokenFile = Join-Path $rootDir ".github_token"
    if (Test-Path $tokenFile) {
        $Token = (Get-Content -Path $tokenFile -Raw).Trim()
    }
}

if ([string]::IsNullOrWhiteSpace($Token)) {
    Write-Host "[ERROR] Se requiere un token de acceso de GitHub (PAT) con permisos de 'repo'." -ForegroundColor Red
    Write-Host "        Configúralo mediante `$env:GITHUB_TOKEN o en el archivo .github_token" -ForegroundColor Yellow
    exit 1
}

Write-Host "==========================================================" -ForegroundColor Cyan
Write-Host "  PUBLICADOR EN GITHUB RELEASES - SISTEMA DE MANTENCION" -ForegroundColor Cyan
Write-Host "  Repositorio: $Repo" -ForegroundColor Cyan
Write-Host "  Versión Tag: $TagName" -ForegroundColor Cyan
Write-Host "==========================================================" -ForegroundColor Cyan
Write-Host ""

$installerPath = Join-Path $rootDir "Instalador\Instalador_Sistema_Mantencion_v2026.1.exe"
if (-not (Test-Path $installerPath)) {
    Write-Host "[INFO] El instalador no existe localmente. Compilándolo primero..." -ForegroundColor Yellow
    $compilerScript = Join-Path $scriptDir "Compilar_Instalador.ps1"
    & pwsh -ExecutionPolicy Bypass -File $compilerScript
    if (-not (Test-Path $installerPath)) {
        Write-Host "[ERROR] No se pudo generar el instalador en: $installerPath" -ForegroundColor Red
        exit 1
    }
}

$item = Get-Item $installerPath
$hash = (Get-FileHash $installerPath -Algorithm SHA256).Hash
$sizeMb = [Math]::Round($item.Length / 1MB, 2)

# Generar archivo de checksums si no existe
$checksumsPath = Join-Path $rootDir "Instalador\checksums_sha256.txt"
$checksumInfo = @"
Archivo: $($item.Name)
Tamaño: $sizeMb MB ($($item.Length) bytes)
Fecha Generación: $(Get-Date -Format 'yyyy-MM-dd HH:mm:ss')
Plataforma: Microsoft .NET 8 LTS (Windows x64 - Autocontenido)
Algoritmo: SHA-256
Hash: $hash
"@
Set-Content -Path $checksumsPath -Value $checksumInfo

$headers = @{
    "Authorization" = "token $Token"
    "Accept" = "application/vnd.github.v3+json"
    "User-Agent" = "PowerShell-GitHub-Release-Publisher"
}

# 1. Verificar si el Release ya existe
Write-Host "[1/3] Verificando estado del Release '$TagName' en GitHub..." -ForegroundColor Yellow
$release = $null
try {
    $release = Invoke-RestMethod -Uri "https://api.github.com/repos/$Repo/releases/tags/$TagName" -Headers $headers -Method Get
    Write-Host "       Release existente detectado (ID: $($release.id))." -ForegroundColor Green
} catch {
    # No existe, proceder a crearlo
}

$releaseBody = @"
# 🚀 Sistema de Gestión Departamento Mantención v2026.1 LTS
**Cambiaso Hnos. S.A.C. — División de Mantención Industrial**  
📍 *Virginia Bravo Letelier 777, Placilla de Peñuelas, Valparaíso, Chile*  
👨‍💻 *Creado por Boris Arriagada*

---

### 📦 Características Principales de esta Versión:
- **Instalador Autocontenido (Zero-Dependency):** Empaqueta Microsoft .NET 8 (CoreCLR), librerías WinForms x64, dependencias nativas y plantillas Excel institucionales. No requiere conexión a internet ni runtimes previos de Windows.
- **Gestión Integral de Órdenes de Trabajo (OT):** Emisión, seguimiento, control de tiempos de detención de línea y generación autónoma de reportes vectoriales en PDF de alta resolución.
- **Planificación de Mantenimiento Preventivo (MP):** Control por ciclos operativos, horómetros y calendarios de maquinaria.
- **Analítica y Cuadros de Mando Estadísticos:** Cálculo automático de indicadores, ranking de fallas y gráficos recursivos por Planta, Sección, Máquina y Componente.
- **Carta Gantt y Cronogramas Operativos:** Visualización de intervenciones y exportación interactiva a planillas Microsoft Excel.
- **Auditoría de Operaciones con KPIs y Drill-Down:** Trazabilidad de eventos de BD, panel de KPIs en tiempo real y exportación avanzada a Excel.
- **Exportación Excel y PDF Reparada y Optimizada:** Ensamblado office.dll v15 embebido, resolución determinista de plantillas e inserción matricial 2D en bloque ultrarrápida.
- **Configurador de Servidor BD en Caliente:** Alternancia segura de servidores SQL Server con test de enlace previo y respaldo inmutable.

---

### ⬇️ Descarga del Instalador Oficial:
Descargue el archivo ejecutable adjunto en los **Assets**:

- 💾 **Archivo:** $($item.Name)
- 🖥️ **Plataforma:** Windows 10 / Windows 11 (64 bits - x64)
- ⚖️ **Tamaño:** $sizeMb MB ($($item.Length) bytes)
- 🔒 **Checksum SHA-256:** $hash
"@

if ($null -eq $release) {
    Write-Host "[2/3] Creando nuevo Release '$TagName' en GitHub..." -ForegroundColor Yellow
    $createData = @{
        tag_name = $TagName
        target_commitish = "main"
        name = $ReleaseName
        body = $releaseBody
        draft = $false
        prerelease = $false
    } | ConvertTo-Json

    $release = Invoke-RestMethod -Uri "https://api.github.com/repos/$Repo/releases" -Headers $headers -Method Post -Body $createData -ContentType "application/json; charset=utf-8"
    Write-Host "       Release creado exitosamente (ID: $($release.id))." -ForegroundColor Green
} else {
    Write-Host "[2/3] Actualizando descripción del Release '$TagName'..." -ForegroundColor Yellow
    $updateData = @{
        name = $ReleaseName
        body = $releaseBody
    } | ConvertTo-Json
    $release = Invoke-RestMethod -Uri "https://api.github.com/repos/$Repo/releases/$($release.id)" -Headers $headers -Method Patch -Body $updateData -ContentType "application/json; charset=utf-8"
    Write-Host "       Release actualizado exitosamente." -ForegroundColor Green
}

# 2. Eliminar assets previos con el mismo nombre si existen
if ($release.assets -and $release.assets.Count -gt 0) {
    foreach ($asset in $release.assets) {
        if ($asset.name -eq $item.Name -or $asset.name -eq "checksums_sha256.txt") {
            Write-Host "       Eliminando versión anterior del asset: $($asset.name)..." -ForegroundColor Gray
            Invoke-RestMethod -Uri $asset.url -Headers $headers -Method Delete | Out-Null
        }
    }
}

# 3. Subir el Instalador ejecutable
Write-Host "[3/3] Subiendo instalador ejecutable ($sizeMb MB) hacia GitHub Releases..." -ForegroundColor Yellow
$uploadUri = "https://uploads.github.com/repos/$Repo/releases/$($release.id)/assets?name=$($item.Name)"
$uploadHeaders = @{
    "Authorization" = "token $Token"
    "Accept" = "application/vnd.github.v3+json"
    "Content-Type" = "application/octet-stream"
    "User-Agent" = "PowerShell-GitHub-Release-Publisher"
}

$uploadedExe = Invoke-RestMethod -Uri $uploadUri -Headers $uploadHeaders -Method Post -InFile $installerPath -TimeoutSec 1200

# Subir checksums_sha256.txt
$uploadUriTxt = "https://uploads.github.com/repos/$Repo/releases/$($release.id)/assets?name=checksums_sha256.txt"
$uploadHeadersTxt = @{
    "Authorization" = "token $Token"
    "Accept" = "application/vnd.github.v3+json"
    "Content-Type" = "text/plain"
    "User-Agent" = "PowerShell-GitHub-Release-Publisher"
}
$uploadedTxt = Invoke-RestMethod -Uri $uploadUriTxt -Headers $uploadHeadersTxt -Method Post -InFile $checksumsPath -TimeoutSec 120

Write-Host ""
Write-Host "==========================================================" -ForegroundColor Green
Write-Host "  PUBLICACIÓN EXITOSA EN GITHUB RELEASES!" -ForegroundColor Green
Write-Host "  Release URL : $($release.html_url)" -ForegroundColor White
Write-Host "  Instalador  : $($uploadedExe.browser_download_url)" -ForegroundColor Yellow
Write-Host "  Tamaño      : $sizeMb MB ($($item.Length) bytes)" -ForegroundColor White
Write-Host "  Checksum    : $hash" -ForegroundColor White
Write-Host "==========================================================" -ForegroundColor Green
