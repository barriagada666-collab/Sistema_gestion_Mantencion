#!/usr/bin/env bash
# ==============================================================================
# Script para generar el Paquete e Instalador Universal para macOS
# Sistema de Gestión Departamento Mantención - Cambiaso Hnos. S.A.C.
# Compatible con Apple Silicon (M1/M2/M3/M4) e Intel (x86_64)
# ==============================================================================

set -euo pipefail

SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
ROOT_DIR="$(cd "$SCRIPT_DIR/.." && pwd)"

echo "=========================================================="
echo "  GENERADOR DE INSTALADOR MACOS UNIVERSAL"
echo "  Sistema de Gestión Departamento Mantención"
echo "  Cambiaso Hnos. S.A.C."
echo "=========================================================="
echo ""

PUBLISH_DIR="$ROOT_DIR/mantencion/bin/Release/net8-selfcontained-x64"
DIST_MAC="$ROOT_DIR/dist-mac"
APP_NAME="Sistema de Gestión Mantención"
APP_BUNDLE="$DIST_MAC/$APP_NAME.app"

# 1. Asegurar publicación autocontenida previa
if [[ ! -f "$PUBLISH_DIR/Sistema de Gestion Mantencion.exe" ]]; then
    echo "[1/4] Compilando aplicación autocontenida (.NET 8 x64)..."
    export PATH="/home/antigravity/.dotnet:$PATH"
    dotnet publish "$ROOT_DIR/mantencion/mantencion.vbproj" \
        -c Release -r win-x64 --self-contained true \
        -o "$PUBLISH_DIR" -p:EnableWindowsTargeting=true --nologo -v m
else
    echo "[1/4] Publicación autocontenida existente verificada."
fi

# 2. Asegurar icono .icns
ICNS_FILE="$ROOT_DIR/mantencion/icons/app_icon.icns"
if [[ ! -f "$ICNS_FILE" ]]; then
    echo "       Generando app_icon.icns..."
    python3 -c "from PIL import Image; Image.open('$ROOT_DIR/mantencion/icons/app_icon_rounded.png').save('$ICNS_FILE', format='ICNS')"
fi

# 3. Crear estructura del .app bundle
echo "[2/4] Creando estructura del macOS App Bundle..."
rm -rf "$DIST_MAC"
mkdir -p "$APP_BUNDLE/Contents/MacOS"
mkdir -p "$APP_BUNDLE/Contents/Resources/app"

# Info.plist
cat << 'EOF' > "$APP_BUNDLE/Contents/Info.plist"
<?xml version="1.0" encoding="UTF-8"?>
<!DOCTYPE plist PUBLIC "-//Apple//DTD PLIST 1.0//EN" "http://www.apple.com/DTDs/PropertyList-1.0.dtd">
<plist version="1.0">
<dict>
    <key>CFBundleDevelopmentRegion</key>
    <string>es</string>
    <key>CFBundleDisplayName</key>
    <string>Sistema de Gestión Mantención</string>
    <key>CFBundleExecutable</key>
    <string>launcher</string>
    <key>CFBundleIconFile</key>
    <string>app_icon.icns</string>
    <key>CFBundleIdentifier</key>
    <string>cl.cambiaso.mantencion</string>
    <key>CFBundleInfoDictionaryVersion</key>
    <string>6.0</string>
    <key>CFBundleName</key>
    <string>Sistema de Gestión Mantención</string>
    <key>CFBundlePackageType</key>
    <string>APPL</string>
    <key>CFBundleShortVersionString</key>
    <string>2026.1</string>
    <key>CFBundleSignature</key>
    <string>????</string>
    <key>CFBundleVersion</key>
    <string>2026.1.0</string>
    <key>LSMinimumSystemVersion</key>
    <string>10.15.0</string>
    <key>NSHighResolutionCapable</key>
    <true/>
    <key>NSSupportsAutomaticGraphicsSwitching</key>
    <true/>
    <key>LSApplicationCategoryType</key>
    <string>public.app-category.business</string>
</dict>
</plist>
EOF

# PkgInfo
printf "APPL????" > "$APP_BUNDLE/Contents/PkgInfo"

# Icono ICNS
cp "$ICNS_FILE" "$APP_BUNDLE/Contents/Resources/app_icon.icns"

# Copiar archivos de la aplicación autocontenida
echo "       Copiando binarios y plantillas..."
cp -r "$PUBLISH_DIR"/* "$APP_BUNDLE/Contents/Resources/app/"

# Asegurar plantillas Excel
mkdir -p "$APP_BUNDLE/Contents/Resources/app/plantillas"
cp -r "$ROOT_DIR/mantencion/plantillas"/*.xls "$APP_BUNDLE/Contents/Resources/app/plantillas/" 2>/dev/null || true
cp -r "$ROOT_DIR/mantencion/plantillas"/*.xls "$APP_BUNDLE/Contents/Resources/app/" 2>/dev/null || true

# Launcher script universal macOS
cat << 'EOF' > "$APP_BUNDLE/Contents/MacOS/launcher"
#!/bin/bash
# Launcher Universal para macOS (Apple Silicon M1-M4 & Intel x86_64)
# Sistema de Gestión Departamento Mantención - Cambiaso Hnos. S.A.C.

DIR="$(cd "$(dirname "$0")/../Resources/app" && pwd)"
APP_EXE="$DIR/Sistema de Gestion Mantencion.exe"
ARCH="$(uname -m)"

# Prefijo WINE aislado y dedicado para el sistema de mantención
export WINEPREFIX="$HOME/Library/Application Support/SistemaMantencion/wineprefix"
export WINEARCH=win64
export WINEDEBUG=-all
export WINEFSYNC=1
export WINEESYNC=1

mkdir -p "$WINEPREFIX"

# Búsqueda de Wine / Whisky / CrossOver en rutas estándar de macOS
WINE_CMD=""

POSSIBLE_PATHS=(
    "/Applications/Whisky.app/Contents/Resources/Libraries/Wine/bin/wine64"
    "/opt/homebrew/bin/wine64"
    "/opt/homebrew/bin/wine"
    "/usr/local/bin/wine64"
    "/usr/local/bin/wine"
    "$HOME/.whisky/Libraries/Wine/bin/wine64"
    "/Applications/CrossOver.app/Contents/SharedSupport/CrossOver/bin/wine"
)

for p in "${POSSIBLE_PATHS[@]}"; do
    if [[ -x "$p" ]]; then
        WINE_CMD="$p"
        break
    fi
done

if [[ -z "$WINE_CMD" ]]; then
    WINE_CMD="$(command -v wine64 2>/dev/null || command -v wine 2>/dev/null || true)"
fi

# Si no está instalado Wine, guiar amigablemente al usuario con UI nativa
if [[ -z "$WINE_CMD" ]]; then
    osascript << 'APPLESCRIPT'
    display alert "Sistema de Gestión Departamento Mantención" message "Para ejecutar este software en macOS (compatible con Apple Silicon e Intel), se requiere el motor Wine o Whisky.\n\n¿Desea abrir la guía de instalación rápida o instalarlo automáticamente?" buttons {"Cancelar", "Instalar Automáticamente"} default button "Instalar Automáticamente" as informational
    if button returned of result is "Instalar Automáticamente" then
        tell application "Terminal"
            activate
            do script "echo '=== Instalando Wine para macOS (Homebrew) ===' && brew install --cask wine-stable || brew install --cask whisky"
        end tell
    end if
APPLESCRIPT
    exit 1
fi

# Ejecutar el sistema de mantención
cd "$DIR"
exec "$WINE_CMD" "$APP_EXE" "$@"
EOF

chmod +x "$APP_BUNDLE/Contents/MacOS/launcher"

# 4. Script de instalación de 1-clic para macOS: Instalar_en_Mac.command
echo "[3/4] Creando instalador interactivo Instalar_en_Mac.command..."
cat << 'EOF' > "$DIST_MAC/Instalar_en_Mac.command"
#!/bin/bash
# Script de Instalación de 1-Clic para macOS
# Sistema de Gestión Departamento Mantención - Cambiaso Hnos. S.A.C.

set -e
cd "$(dirname "$0")"

clear
echo "=========================================================="
echo "  INSTALADOR DE SISTEMA DE GESTIÓN MANTENCIÓN PARA MACOS"
echo "  Cambiaso Hnos. S.A.C. - División de Mantención Industrial"
echo "  Arquitectura: $(uname -m) (Universal Apple Silicon / Intel)"
echo "=========================================================="
echo ""

APP_SRC="Sistema de Gestión Mantención.app"
APP_DEST="/Applications/Sistema de Gestión Mantención.app"

if [[ ! -d "$APP_SRC" ]]; then
    echo "[ERROR] No se encontró '$APP_SRC' en el directorio actual."
    exit 1
fi

echo "[1/3] Copiando aplicación hacia la carpeta /Applications..."
rm -rf "$APP_DEST"
cp -R "$APP_SRC" "$APP_DEST"

echo "[2/3] Configurando permisos y removiendo cuarentena de macOS Gatekeeper..."
xattr -dr com.apple.quarantine "$APP_DEST" 2>/dev/null || true
chmod -R 755 "$APP_DEST"

echo "[3/3] Verificando motor Wine / Whisky..."
if command -v wine &>/dev/null || command -v wine64 &>/dev/null || [[ -d "/Applications/Whisky.app" ]] || [[ -x "/opt/homebrew/bin/wine" ]]; then
    echo "       Motor de compatibilidad detectado correctamente."
else
    echo ""
    echo "       [AVISO] No se detectó Wine ni Whisky en su sistema."
    echo "       Para instalarlo automáticamente con Homebrew, ejecute:"
    echo "       brew install --cask wine-stable"
    echo ""
fi

echo ""
echo "=========================================================="
echo "  ¡INSTALACIÓN COMPLETADA EXITOSAMENTE!"
echo "  Puede abrir la aplicación desde Launchpad o /Applications"
echo "=========================================================="
echo ""
read -p "Presione Enter para salir o abrir la aplicación... " -n 1 -r
open "$APP_DEST" || true
EOF

chmod +x "$DIST_MAC/Instalar_en_Mac.command"

# 5. Guía HTML interactiva LEAME_MAC.html
cat << 'EOF' > "$DIST_MAC/LEAME_MAC.html"
<!DOCTYPE html>
<html lang="es">
<head>
  <meta charset="UTF-8">
  <title>Instalación en macOS - Sistema de Mantención Cambiaso Hnos.</title>
  <style>
    body { font-family: -apple-system, BlinkMacSystemFont, "Segoe UI", Roboto, Helvetica, Arial, sans-serif; margin: 40px; background: #0f172a; color: #f8fafc; line-height: 1.6; }
    .card { max-width: 750px; margin: 0 auto; background: #1e293b; border-radius: 16px; padding: 32px; border: 1px solid #334155; box-shadow: 0 10px 25px rgba(0,0,0,0.4); }
    h1 { color: #38bdf8; font-size: 24px; margin-top: 0; display: flex; align-items: center; gap: 12px; }
    .step { background: #0f172a; border-radius: 12px; padding: 18px; margin-bottom: 16px; border-left: 4px solid #10b981; }
    .step h3 { margin: 0 0 8px 0; color: #10b981; font-size: 16px; }
    code { background: #334155; padding: 3px 8px; border-radius: 6px; font-family: monospace; color: #fcd34d; }
    .badge { display: inline-block; padding: 4px 10px; border-radius: 20px; font-size: 12px; font-weight: bold; background: #0284c7; color: white; margin-bottom: 20px; }
    .footer { margin-top: 24px; text-align: center; color: #64748b; font-size: 12px; }
  </style>
</head>
<body>
  <div class="card">
    <span class="badge">macOS Universal (Apple Silicon M1-M4 &amp; Intel)</span>
    <h1>⚙️ Sistema de Gestión Departamento Mantención</h1>
    <p>Guía de instalación rápida para usuarios de computadores Mac (MacBook, iMac, Mac mini, Mac Studio, Mac Pro).</p>

    <div class="step">
      <h3>Paso 1: Instalación con 1 Clic</h3>
      <p>Haga doble clic en el archivo <code>Instalar_en_Mac.command</code> incluido en esta carpeta. Copiará automáticamente la aplicación a su carpeta <code>/Applications</code> y removerá la restricción de Gatekeeper.</p>
    </div>

    <div class="step">
      <h3>Paso 2: Motor de Compatibilidad Wine / Whisky</h3>
      <p>Si aún no tiene Wine o Whisky instalado, abra la aplicación <strong>Terminal</strong> y pegue el siguiente comando:</p>
      <p><code>brew install --cask wine-stable</code></p>
      <p><em>O si prefiere interfaz gráfica moderna, puede instalar Whisky:</em> <code>brew install --cask whisky</code></p>
    </div>

    <div class="step">
      <h3>Paso 3: ¡Listo para Trabajar!</h3>
      <p>Abra <strong>Sistema de Gestión Mantención</strong> directamente desde Launchpad o la carpeta Aplicaciones de su Mac.</p>
    </div>

    <div class="footer">
      Cambiaso Hnos. S.A.C. — División de Mantención Industrial &copy; 2026
    </div>
  </div>
</body>
</html>
EOF

# 6. Comprimir paquete universal para Mac
echo "[4/4] Empaquetando Instalador_Sistema_Mantencion_v2026.1_macOS_Universal.zip..."
mkdir -p "$ROOT_DIR/Instalador"
ZIP_OUTPUT="$ROOT_DIR/Instalador/Instalador_Sistema_Mantencion_v2026.1_macOS_Universal.zip"
rm -f "$ZIP_OUTPUT"

cd "$DIST_MAC"
zip -r -y "$ZIP_OUTPUT" "$APP_NAME.app" "Instalar_en_Mac.command" "LEAME_MAC.html"

# Calcular hash
ZIP_HASH=$(sha256sum "$ZIP_OUTPUT" | awk '{print $1}')
ZIP_SIZE_MB=$(du -m "$ZIP_OUTPUT" | awk '{print $1}')

echo ""
echo "=========================================================="
echo "  PAQUETE MACOS GENERADO EXITOSAMENTE"
echo "  Archivo: $ZIP_OUTPUT"
echo "  Tamaño : ~$ZIP_SIZE_MB MB"
echo "  SHA256 : $ZIP_HASH"
echo "=========================================================="
