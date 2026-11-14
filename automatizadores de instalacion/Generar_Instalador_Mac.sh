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
# ==============================================================================
# Launcher Universal para macOS (Apple Silicon M1-M4 & Intel x86_64)
# Sistema de Gestión Departamento Mantención - Cambiaso Hnos. S.A.C.
# ==============================================================================

DIR="$(cd "$(dirname "$0")/../Resources/app" && pwd)"
APP_EXE="$DIR/Sistema de Gestion Mantencion.exe"
ARCH="$(uname -m)"

# 1. Detectar si Whisky está instalado (Frontend preferido para macOS Apple Silicon e Intel)
WHISKY_APP=""
if [[ -d "/Applications/Whisky.app" ]]; then
    WHISKY_APP="/Applications/Whisky.app"
elif [[ -d "$HOME/Applications/Whisky.app" ]]; then
    WHISKY_APP="$HOME/Applications/Whisky.app"
fi

# 2. Búsqueda de binarios de Wine CLI en rutas estándar de macOS
WINE_CMD=""
POSSIBLE_PATHS=(
    "/opt/homebrew/bin/wine64"
    "/opt/homebrew/bin/wine"
    "/usr/local/bin/wine64"
    "/usr/local/bin/wine"
    "$HOME/Library/Application Support/com.isaacmarovitz.Whisky/Libraries/Wine/bin/wine64"
    "$HOME/Library/Application Support/com.isaacmarovitz.Whisky/Libraries/Wine/bin/wine"
    "$HOME/Library/Containers/com.isaacmarovitz.Whisky/Data/Library/Application Support/com.isaacmarovitz.Whisky/Libraries/Wine/bin/wine64"
    "$HOME/Library/Application Support/Whisky/Libraries/Wine/bin/wine64"
    "/Applications/Wine Crossover.app/Contents/Resources/wine/bin/wine64"
    "/Applications/Wine Crossover.app/Contents/Resources/wine/bin/wine"
    "/Applications/CrossOver.app/Contents/SharedSupport/CrossOver/bin/wine64"
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

# 3. Si Whisky está instalado, priorizar ejecución directa a través de Whisky
if [[ -n "$WHISKY_APP" ]]; then
    if command -v whisky &>/dev/null; then
        whisky run "$APP_EXE" "$@" 2>/dev/null && exit 0
    fi
    open -a "$WHISKY_APP" "$APP_EXE"
    exit 0
fi

# 4. Si se encontró un binario Wine CLI funcional (ej: wine-crossover o CrossOver)
if [[ -n "$WINE_CMD" ]]; then
    export WINEPREFIX="$HOME/Library/Application Support/SistemaMantencion/wineprefix"
    export WINEARCH=win64
    export WINEDEBUG=-all
    export WINEFSYNC=1
    export WINEESYNC=1
    mkdir -p "$WINEPREFIX"

    WINE_DIR="$(dirname "$WINE_CMD")"
    if [[ -d "$WINE_DIR/../lib" ]]; then
        export DYLD_FALLBACK_LIBRARY_PATH="$WINE_DIR/../lib:${DYLD_FALLBACK_LIBRARY_PATH:-}"
    fi

    cd "$DIR"
    exec "$WINE_CMD" "$APP_EXE" "$@"
fi

# 5. Si CrossOver está instalado en /Applications
if [[ -d "/Applications/CrossOver.app" ]]; then
    open -a "/Applications/CrossOver.app" "$APP_EXE"
    exit 0
fi

# 6. Si no hay ningún motor de compatibilidad, guiar amigablemente al usuario con UI nativa
osascript << 'APPLESCRIPT'
display alert "Sistema de Gestión Departamento Mantención" message "Para ejecutar este software en macOS (compatible con Apple Silicon e Intel), se requiere Whisky o Wine.\n\nWhisky es la aplicación recomendada, moderna y gratuita para macOS.\n\n¿Desea instalar Whisky automáticamente ahora con Homebrew?" buttons {"Cancelar", "Instalar Whisky"} default button "Instalar Whisky" as informational
if button returned of result is "Instalar Whisky" then
    tell application "Terminal"
        activate
        do script "echo '=== Instalando Whisky para macOS ===' && brew install --cask whisky"
    end tell
end if
APPLESCRIPT
exit 1
EOF

chmod +x "$APP_BUNDLE/Contents/MacOS/launcher"

# 4. Script de instalación de 1-clic para macOS: Instalar_en_Mac.command
echo "[3/4] Creando instalador interactivo Instalar_en_Mac.command..."
cat << 'EOF' > "$DIST_MAC/Instalar_en_Mac.command"
#!/bin/bash
# ==============================================================================
# Script de Instalación de 1-Clic para macOS
# Sistema de Gestión Departamento Mantención - Cambiaso Hnos. S.A.C.
# ==============================================================================

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

echo "[3/3] Verificando motor de compatibilidad Whisky / Wine..."
MOTOR_ENCONTRADO=0

if [[ -d "/Applications/Whisky.app" ]] || [[ -d "$HOME/Applications/Whisky.app" ]]; then
    echo "       ✓ [OK] Whisky detectado en Aplicaciones."
    MOTOR_ENCONTRADO=1
fi

if command -v wine &>/dev/null || command -v wine64 &>/dev/null || [[ -x "/opt/homebrew/bin/wine" ]]; then
    echo "       ✓ [OK] Motor Wine detectado en el sistema."
    MOTOR_ENCONTRADO=1
fi

if [[ $MOTOR_ENCONTRADO -eq 0 ]]; then
    echo ""
    echo "       [AVISO] Se recomienda instalar Whisky para macOS:"
    echo "       brew install --cask whisky"
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

# Lanzador directo de Whisky: Iniciar_con_Whisky.command
cat << 'EOF' > "$DIST_MAC/Iniciar_con_Whisky.command"
#!/bin/bash
# ==============================================================================
# Lanzador directo con Whisky para macOS
# Sistema de Gestión Departamento Mantención - Cambiaso Hnos. S.A.C.
# ==============================================================================

DIR="$(cd "$(dirname "$0")" && pwd)"
APP_EXE="$DIR/Sistema de Gestión Mantención.app/Contents/Resources/app/Sistema de Gestion Mantencion.exe"
if [[ ! -f "$APP_EXE" ]]; then
    APP_EXE="/Applications/Sistema de Gestión Mantención.app/Contents/Resources/app/Sistema de Gestion Mantencion.exe"
fi

clear
echo "=========================================================="
echo "  SISTEMA DE GESTIÓN MANTENCIÓN - LANZADOR WHISKY"
echo "  Cambiaso Hnos. S.A.C. - División Mantención Industrial"
echo "=========================================================="
echo ""

WHISKY_PATH=""
if [[ -d "/Applications/Whisky.app" ]]; then
    WHISKY_PATH="/Applications/Whisky.app"
elif [[ -d "$HOME/Applications/Whisky.app" ]]; then
    WHISKY_PATH="$HOME/Applications/Whisky.app"
fi

if [[ -n "$WHISKY_PATH" ]]; then
    echo "✓ Whisky detectado en: $WHISKY_PATH"
    echo "Iniciando Sistema de Gestión Mantención en Whisky..."
    open -a "$WHISKY_PATH" "$APP_EXE"
    echo ""
    echo "¡Listo! La aplicación se está ejecutando a través de Whisky."
    sleep 2
    exit 0
else
    echo "[AVISO] Whisky no fue detectado en /Applications."
    echo "Puede instalar Whisky con Homebrew ejecutando:"
    echo "brew install --cask whisky"
    echo ""
    read -p "Presione Enter para salir..."
    exit 1
fi
EOF

chmod +x "$DIST_MAC/Iniciar_con_Whisky.command"

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
    <p>Guía de instalación rápida para usuarios de computadores Mac (MacBook Air, MacBook Pro, iMac, Mac mini, Mac Studio, Mac Pro).</p>

    <div class="step">
      <h3>Paso 1: Instalación con 1 Clic</h3>
      <p>Haga doble clic en el archivo <code>Instalar_en_Mac.command</code> incluido en esta carpeta. Copiará automáticamente la aplicación a su carpeta <code>/Applications</code> y removerá la restricción de Gatekeeper.</p>
    </div>

    <div class="step">
      <h3>Paso 2: Motor de Compatibilidad Whisky (Recomendado)</h3>
      <p>Si aún no tiene Whisky instalado, puede instalarlo en 1 minuto con Homebrew pegando en <strong>Terminal</strong>:</p>
      <p><code>brew install --cask whisky</code></p>
      <p><em>O descargándolo directamente desde <a href="https://getwhisky.app" target="_blank" style="color: #38bdf8; text-decoration: underline;">getwhisky.app</a>.</em></p>
    </div>

    <div class="step">
      <h3>Paso 3: ¡Listo para Trabajar!</h3>
      <p>Abra <strong>Sistema de Gestión Mantención</strong> directamente desde Launchpad o la carpeta Aplicaciones de su Mac. También puede usar <code>Iniciar_con_Whisky.command</code>.</p>
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
zip -r -y "$ZIP_OUTPUT" "$APP_NAME.app" "Instalar_en_Mac.command" "Iniciar_con_Whisky.command" "LEAME_MAC.html"

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
