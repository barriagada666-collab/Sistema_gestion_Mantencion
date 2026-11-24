<#
.SYNOPSIS
    Actualiza y sincroniza centralizadamente la versión del proyecto en VERSION.txt,
    version.iss (Inno Setup), mantencion.vbproj, InfoSoftware.rtf y las gráficas del instalador.
.EXAMPLE
    .\Actualizar_Version.ps1 -NuevaVersion 2026.2.3
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

# 5. Gráficas del instalador (wizard_banner.bmp 164x314 y wizard_banner_2x.bmp 328x628)
function New-RoundedRectPath {
    param([float]$X, [float]$Y, [float]$W, [float]$H, [float]$R)
    $path = New-Object System.Drawing.Drawing2D.GraphicsPath
    $d = $R * 2.0
    $path.AddArc($X, $Y, $d, $d, 180, 90)
    $path.AddArc($X + $W - $d, $Y, $d, $d, 270, 90)
    $path.AddArc($X + $W - $d, $Y + $H - $d, $d, $d, 0, 90)
    $path.AddArc($X, $Y + $H - $d, $d, $d, 90, 90)
    $path.CloseFigure()
    return $path
}

function New-WizardBannerBitmap {
    param(
        [string]$OutputPath,
        [string]$LogoPath,
        [string]$VersionText,
        [int]$ScaleFactor = 1
    )

    $s = [float]$ScaleFactor
    $w = [int](164 * $s)
    $h = [int](314 * $s)

    $bmp = [System.Drawing.Bitmap]::new($w, $h, [System.Drawing.Imaging.PixelFormat]::Format24bppRgb)
    $g = [System.Drawing.Graphics]::FromImage($bmp)
    try {
        $g.SmoothingMode = [System.Drawing.Drawing2D.SmoothingMode]::AntiAlias
        $g.InterpolationMode = [System.Drawing.Drawing2D.InterpolationMode]::HighQualityBicubic
        $g.PixelOffsetMode = [System.Drawing.Drawing2D.PixelOffsetMode]::HighQuality
        $g.TextRenderingHint = [System.Drawing.Text.TextRenderingHint]::AntiAliasGridFit

        $splitY = [float](212.0 * $s)

        # Fondo degradado corporativo superior
        $topRect = [System.Drawing.RectangleF]::new(0.0, 0.0, [float]$w, [float]($splitY + 2.0 * $s))
        $gradBrush = [System.Drawing.Drawing2D.LinearGradientBrush]::new(
            [System.Drawing.PointF]::new(0.0, 0.0),
            [System.Drawing.PointF]::new(0.0, $splitY),
            [System.Drawing.Color]::FromArgb(2, 94, 135),
            [System.Drawing.Color]::FromArgb(10, 70, 104)
        )
        $g.FillRectangle($gradBrush, $topRect)
        $gradBrush.Dispose()

        # Círculos decorativos suaves de fondo
        $glow1 = [System.Drawing.SolidBrush]::new([System.Drawing.Color]::FromArgb(12, 255, 255, 255))
        $g.FillEllipse($glow1, [float](-24.0 * $s), [float](28.0 * $s), [float](148.0 * $s), [float](148.0 * $s))
        $glow1.Dispose()

        $glow2 = [System.Drawing.SolidBrush]::new([System.Drawing.Color]::FromArgb(14, 78, 195, 224))
        $g.FillEllipse($glow2, [float](72.0 * $s), [float](108.0 * $s), [float](132.0 * $s), [float](132.0 * $s))
        $glow2.Dispose()

        # Tarjeta blanca superior para logotipo corporativo
        $cardX = [float](16.0 * $s)
        $cardY = [float](18.0 * $s)
        $cardW = [float](132.0 * $s)
        $cardH = [float](56.0 * $s)
        $cardR = [float](8.0 * $s)

        $shadowPath = New-RoundedRectPath ($cardX + 1.0 * $s) ($cardY + 2.0 * $s) $cardW $cardH $cardR
        $shadowBrush = [System.Drawing.SolidBrush]::new([System.Drawing.Color]::FromArgb(48, 0, 0, 0))
        $g.FillPath($shadowBrush, $shadowPath)
        $shadowBrush.Dispose()
        $shadowPath.Dispose()

        $cardPath = New-RoundedRectPath $cardX $cardY $cardW $cardH $cardR
        $g.FillPath([System.Drawing.Brushes]::White, $cardPath)
        $cardPath.Dispose()

        if (Test-Path $LogoPath) {
            $logo = [System.Drawing.Image]::FromFile($LogoPath)
            try {
                $padX = 12.0 * $s
                $padY = 6.0 * $s
                $availW = $cardW - (2.0 * $padX)
                $availH = $cardH - (2.0 * $padY)
                $ratio = [Math]::Min($availW / $logo.Width, $availH / $logo.Height)
                $drawW = [float]($logo.Width * $ratio)
                $drawH = [float]($logo.Height * $ratio)
                $drawX = [float]($cardX + (($cardW - $drawW) / 2.0))
                $drawY = [float]($cardY + (($cardH - $drawH) / 2.0))
                $g.DrawImage($logo, [System.Drawing.RectangleF]::new($drawX, $drawY, $drawW, $drawH))
            } finally {
                $logo.Dispose()
            }
        }

        # Emblema central (engranaje con sello de verificación)
        $cx = [float](82.0 * $s)
        $cy = [float](138.0 * $s)
        $haloR = [float](32.0 * $s)
        $haloFill = [System.Drawing.SolidBrush]::new([System.Drawing.Color]::FromArgb(18, 255, 255, 255))
        $g.FillEllipse($haloFill, [float]($cx - $haloR), [float]($cy - $haloR), [float](2.0 * $haloR), [float](2.0 * $haloR))
        $haloFill.Dispose()
        $haloPen = [System.Drawing.Pen]::new([System.Drawing.Color]::FromArgb(95, 78, 195, 224), [float](1.0 * $s))
        $g.DrawEllipse($haloPen, [float]($cx - $haloR), [float]($cy - $haloR), [float](2.0 * $haloR), [float](2.0 * $haloR))
        $haloPen.Dispose()

        # Engranaje de 8 dientes
        $teeth = 8
        $outerR = 23.5 * $s
        $innerR = 17.8 * $s
        $pts = [System.Collections.Generic.List[System.Drawing.PointF]]::new()
        for ($i = 0; $i -lt $teeth; $i++) {
            $baseAngle = ($i * 2.0 * [Math]::PI) / $teeth
            $step = (2.0 * [Math]::PI) / $teeth
            $a1 = $baseAngle - (0.16 * $step)
            $a2 = $baseAngle - (0.13 * $step)
            $a3 = $baseAngle + (0.13 * $step)
            $a4 = $baseAngle + (0.16 * $step)
            $pts.Add([System.Drawing.PointF]::new([float]($cx + $innerR * [Math]::Cos($a1)), [float]($cy + $innerR * [Math]::Sin($a1))))
            $pts.Add([System.Drawing.PointF]::new([float]($cx + $outerR * [Math]::Cos($a2)), [float]($cy + $outerR * [Math]::Sin($a2))))
            $pts.Add([System.Drawing.PointF]::new([float]($cx + $outerR * [Math]::Cos($a3)), [float]($cy + $outerR * [Math]::Sin($a3))))
            $pts.Add([System.Drawing.PointF]::new([float]($cx + $innerR * [Math]::Cos($a4)), [float]($cy + $innerR * [Math]::Sin($a4))))
        }
        $g.FillPolygon([System.Drawing.Brushes]::White, $pts.ToArray())

        # Anillo interior y check blanco
        $ringOuter = [float](13.0 * $s)
        $ringBrush = [System.Drawing.SolidBrush]::new([System.Drawing.Color]::FromArgb(12, 74, 110))
        $g.FillEllipse($ringBrush, [float]($cx - $ringOuter), [float]($cy - $ringOuter), [float](2.0 * $ringOuter), [float](2.0 * $ringOuter))
        $ringBrush.Dispose()

        $ringInner = [float](10.6 * $s)
        $tealBrush = [System.Drawing.SolidBrush]::new([System.Drawing.Color]::FromArgb(1, 145, 179))
        $g.FillEllipse($tealBrush, [float]($cx - $ringInner), [float]($cy - $ringInner), [float](2.0 * $ringInner), [float](2.0 * $ringInner))
        $tealBrush.Dispose()

        $checkPen = [System.Drawing.Pen]::new([System.Drawing.Color]::White, [float](2.2 * $s))
        $checkPen.StartCap = [System.Drawing.Drawing2D.LineCap]::Round
        $checkPen.EndCap = [System.Drawing.Drawing2D.LineCap]::Round
        $checkPen.LineJoin = [System.Drawing.Drawing2D.LineJoin]::Round
        $checkPts = [System.Drawing.PointF[]]@(
            [System.Drawing.PointF]::new([float]($cx - 4.2 * $s), [float]($cy + 0.4 * $s)),
            [System.Drawing.PointF]::new([float]($cx - 1.1 * $s), [float]($cy + 3.5 * $s)),
            [System.Drawing.PointF]::new([float]($cx + 4.8 * $s), [float]($cy - 3.0 * $s))
        )
        $g.DrawLines($checkPen, $checkPts)
        $checkPen.Dispose()

        # Banda inferior oscura corporativa
        $footerBrush = [System.Drawing.SolidBrush]::new([System.Drawing.Color]::FromArgb(15, 45, 68))
        $g.FillRectangle($footerBrush, [System.Drawing.RectangleF]::new(0.0, $splitY, [float]$w, [float]($h - $splitY)))
        $footerBrush.Dispose()

        $divPen = [System.Drawing.Pen]::new([System.Drawing.Color]::FromArgb(78, 195, 224), [float](1.6 * $s))
        $divPen.StartCap = [System.Drawing.Drawing2D.LineCap]::Round
        $divPen.EndCap = [System.Drawing.Drawing2D.LineCap]::Round
        $g.DrawLine($divPen, [float](14.0 * $s), $splitY, [float](150.0 * $s), $splitY)
        $divPen.Dispose()

        # Textos centrados con jerarquía visual nítida
        $sf = [System.Drawing.StringFormat]::new()
        $sf.Alignment = [System.Drawing.StringAlignment]::Center
        $sf.LineAlignment = [System.Drawing.StringAlignment]::Near

        $cSub = [System.Drawing.SolidBrush]::new([System.Drawing.Color]::FromArgb(78, 195, 224))
        $cVer = [System.Drawing.SolidBrush]::new([System.Drawing.Color]::FromArgb(220, 232, 242))
        $cPlat = [System.Drawing.SolidBrush]::new([System.Drawing.Color]::FromArgb(140, 180, 204))

        $fDiv = [System.Drawing.Font]::new("Segoe UI", [float](5.9 * $s), [System.Drawing.FontStyle]::Bold, [System.Drawing.GraphicsUnit]::Point)
        $fTit = [System.Drawing.Font]::new("Segoe UI", [float](9.0 * $s), [System.Drawing.FontStyle]::Bold, [System.Drawing.GraphicsUnit]::Point)
        $fVer = [System.Drawing.Font]::new("Segoe UI", [float](7.5 * $s), [System.Drawing.FontStyle]::Regular, [System.Drawing.GraphicsUnit]::Point)
        $fPlat = [System.Drawing.Font]::new("Segoe UI", [float](6.7 * $s), [System.Drawing.FontStyle]::Regular, [System.Drawing.GraphicsUnit]::Point)

        try {
            $g.DrawString("DIVISIÓN MANTENCIÓN INDUSTRIAL", $fDiv, $cSub, [System.Drawing.RectangleF]::new([float](2.0 * $s), [float](222.0 * $s), [float]($w - 4.0 * $s), [float](14.0 * $s)), $sf)
            $g.DrawString("Sistema de Gestión", $fTit, [System.Drawing.Brushes]::White, [System.Drawing.RectangleF]::new([float](2.0 * $s), [float](238.0 * $s), [float]($w - 4.0 * $s), [float](16.0 * $s)), $sf)
            $g.DrawString("Mantención", $fTit, [System.Drawing.Brushes]::White, [System.Drawing.RectangleF]::new([float](2.0 * $s), [float](253.0 * $s), [float]($w - 4.0 * $s), [float](16.0 * $s)), $sf)
            $g.DrawString("Versión $VersionText LTS", $fVer, $cVer, [System.Drawing.RectangleF]::new([float](2.0 * $s), [float](275.0 * $s), [float]($w - 4.0 * $s), [float](15.0 * $s)), $sf)
            $g.DrawString("Windows 10 / 11 (64 bits)", $fPlat, $cPlat, [System.Drawing.RectangleF]::new([float](2.0 * $s), [float](292.0 * $s), [float]($w - 4.0 * $s), [float](14.0 * $s)), $sf)
        } finally {
            $fDiv.Dispose()
            $fTit.Dispose()
            $fVer.Dispose()
            $fPlat.Dispose()
            $cSub.Dispose()
            $cVer.Dispose()
            $cPlat.Dispose()
            $sf.Dispose()
        }
    } finally {
        $g.Dispose()
    }

    $tmpPath = "$OutputPath.tmp"
    $bmp.Save($tmpPath, [System.Drawing.Imaging.ImageFormat]::Bmp)
    $bmp.Dispose()
    Move-Item -LiteralPath $tmpPath -Destination $OutputPath -Force
}

$artDir = Join-Path $rootDir "mantencion\installer_art"
$logoArt = Join-Path $artDir "cambiaso_logo_nuevo.png"
if (Test-Path $artDir) {
    Add-Type -AssemblyName System.Drawing
    New-WizardBannerBitmap -OutputPath (Join-Path $artDir "wizard_banner.bmp") -LogoPath $logoArt -VersionText $targetVersion -ScaleFactor 1
    New-WizardBannerBitmap -OutputPath (Join-Path $artDir "wizard_banner_2x.bmp") -LogoPath $logoArt -VersionText $targetVersion -ScaleFactor 2
}

Write-Host "[OK] Archivos sincronizados:" -ForegroundColor Green
Write-Host "     - VERSION.txt"
Write-Host "     - version.iss"
Write-Host "     - mantencion\mantencion.vbproj"
Write-Host "     - InfoSoftware.rtf"
Write-Host "     - mantencion\installer_art\wizard_banner.bmp (164x314)"
Write-Host "     - mantencion\installer_art\wizard_banner_2x.bmp (328x628)"
Write-Host ""
Write-Host "Siguientes pasos sugeridos:" -ForegroundColor Yellow
Write-Host "  1. Compilar instaladores: .\automatizadores de instalacion\Compilar_Instalador.ps1" -ForegroundColor Gray
Write-Host "  2. Hacer commit y push a main para disparar la compilación/release $tagVersion en GitHub." -ForegroundColor Gray
