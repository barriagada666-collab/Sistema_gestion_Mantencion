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
    echo "[1/5] Compilando aplicación autocontenida (.NET 8 x64)..."
    export PATH="/home/antigravity/.dotnet:$PATH"
    dotnet publish "$ROOT_DIR/mantencion/mantencion.vbproj" \
        -c Release -r win-x64 --self-contained true \
        -o "$PUBLISH_DIR" -p:EnableWindowsTargeting=true --nologo -v m
else
    echo "[1/5] Publicación autocontenida existente verificada."
fi

# 2. Asegurar icono .icns
ICNS_FILE="$ROOT_DIR/mantencion/icons/app_icon.icns"
if [[ ! -f "$ICNS_FILE" ]]; then
    echo "       Generando app_icon.icns..."
    python3 -c "from PIL import Image; Image.open('$ROOT_DIR/mantencion/icons/app_icon_rounded.png').save('$ICNS_FILE', format='ICNS')"
fi

# 3. Crear estructura del .app bundle
echo "[2/5] Creando estructura del macOS App Bundle..."
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
echo "       Copiando binarios de .NET 8 y plantillas..."
cp -r "$PUBLISH_DIR"/* "$APP_BUNDLE/Contents/Resources/app/"
for loc in cs de fr it ja ko pl pt-BR ru tr zh-Hans zh-Hant; do
    rm -rf "$APP_BUNDLE/Contents/Resources/app/$loc" 2>/dev/null || true
done

# Asegurar plantillas Excel
mkdir -p "$APP_BUNDLE/Contents/Resources/app/plantillas"
cp -r "$ROOT_DIR/mantencion/plantillas"/*.xls "$APP_BUNDLE/Contents/Resources/app/plantillas/" 2>/dev/null || true
cp -r "$ROOT_DIR/mantencion/plantillas"/*.xls "$APP_BUNDLE/Contents/Resources/app/" 2>/dev/null || true

# 4. Integrar Motor Wine Universal Ligero en Contents/Resources/wine
echo "[3/5] Integrando motor Wine Staging Universal en App Bundle..."
WINE_BUNDLE_DIR="$APP_BUNDLE/Contents/Resources/wine"
WINE_TAR_URL="https://github.com/Gcenx/macOS_Wine_builds/releases/download/11.21/wine-staging-11.21-osx64.tar.xz"
TMP_WINE_DL="/tmp/wine-download-$$"

if [[ ! -f "$WINE_BUNDLE_DIR/bin/wine" ]]; then
    echo "       Descargando Wine Staging (descartando dependencias no requeridas: Mono, Gecko, GStreamer, 32-bit)..."
    mkdir -p "$TMP_WINE_DL"
    if curl -sL "$WINE_TAR_URL" | tar -xJf - \
            --exclude="Wine Staging.app/Contents/Resources/wine/lib/GStreamer.framework" \
            --exclude="Wine Staging.app/Contents/Resources/wine/share/wine/gecko" \
            --exclude="Wine Staging.app/Contents/Resources/wine/share/wine/mono" \
            --exclude="Wine Staging.app/Contents/Resources/wine/lib/wine/i386-windows" \
            -C "$TMP_WINE_DL" 2>/dev/null; then
        if [[ -d "$TMP_WINE_DL/Wine Staging.app/Contents/Resources/wine" ]]; then
            mv "$TMP_WINE_DL/Wine Staging.app/Contents/Resources/wine" "$WINE_BUNDLE_DIR"
            chmod +x "$WINE_BUNDLE_DIR/bin/"* 2>/dev/null || true
            echo "       ✓ Motor Wine integrado exitosamente en el bundle ($(du -sh "$WINE_BUNDLE_DIR" | cut -f1))."
        fi
    else
        echo "       [AVISO] No se pudo descargar Wine en este momento. El launcher usará detección dinámica en tiempo de ejecución."
    fi
    rm -rf "$TMP_WINE_DL"
else
    echo "       ✓ Motor Wine integrado ya existente."
fi

# Launcher script universal macOS
cat << 'EOF' > "$APP_BUNDLE/Contents/MacOS/launcher"
#!/bin/bash
# ==============================================================================
# Launcher Universal para macOS (Apple Silicon M1-M4 & Intel x86_64)
# Sistema de Gestión Departamento Mantención - Cambiaso Hnos. S.A.C.
# ==============================================================================

set -u

DIR="$(cd "$(dirname "$0")/../Resources/app" && pwd)"
APP_EXE="$DIR/Sistema de Gestion Mantencion.exe"
RESOURCES_DIR="$(cd "$(dirname "$0")/../Resources" && pwd)"
LOG_DIR="$HOME/Library/Logs/SistemaMantencion"
mkdir -p "$LOG_DIR"
LOG_FILE="$LOG_DIR/launcher.log"

echo "=== Iniciando Sistema de Gestión Mantención ===" > "$LOG_FILE"
echo "Fecha: $(date)" >> "$LOG_FILE"
echo "Arquitectura: $(uname -m)" >> "$LOG_FILE"
echo "macOS: $(sw_vers -productVersion 2>/dev/null || echo 'Desconocido')" >> "$LOG_FILE"

# 1. Asegurar PATH completo en entorno GUI de macOS
export PATH="/opt/homebrew/bin:/opt/homebrew/sbin:/usr/local/bin:/usr/local/sbin:$HOME/bin:$HOME/.local/bin:$PATH"

# 2. Configurar arquitectura y soporte Rosetta 2 en Apple Silicon
ARCH="$(uname -m)"
RUN_CMD=()
if [[ "$ARCH" == "arm64" ]]; then
    # Verificar si Rosetta 2 está disponible en Apple Silicon
    if ! /usr/bin/pgrep oahd &>/dev/null && ! /usr/bin/arch -x86_64 /usr/bin/true &>/dev/null; then
        echo "[INFO] Rosetta 2 no detectado. Solicitando instalación..." >> "$LOG_FILE"
        osascript -e 'display alert "Sistema de Gestión Mantención" message "Para ejecutar en Mac con procesador Apple Silicon (M1/M2/M3/M4), macOS requiere instalar el componente Rosetta 2.\n\nPresione Instalar para continuar." buttons {"Cancelar", "Instalar"} default button "Instalar"' 2>/dev/null || true
        /usr/sbin/softwareupdate --install-rosetta --agree-to-license >> "$LOG_FILE" 2>&1 || true
    fi
    RUN_CMD=("/usr/bin/arch" "-x86_64")
fi

# 3. Detección Inteligente del Motor Wine (Prioridades)
WINE_CMD=""
WINE_TYPE=""

# Prioridad 1: Motor Wine integrado en el propio App Bundle
if [[ -x "$RESOURCES_DIR/wine/bin/wine" ]]; then
    WINE_CMD="$RESOURCES_DIR/wine/bin/wine"
    WINE_TYPE="bundled"
elif [[ -x "$RESOURCES_DIR/wine/bin/wine64" ]]; then
    WINE_CMD="$RESOURCES_DIR/wine/bin/wine64"
    WINE_TYPE="bundled"
fi

# Prioridad 2: Motores Wine instalados en /Applications (Wine Crossover, Wine Stable, etc.)
if [[ -z "$WINE_CMD" ]]; then
    APP_WINE_PATHS=(
        "/Applications/Wine Crossover.app/Contents/Resources/wine/bin/wine"
        "/Applications/Wine Crossover.app/Contents/Resources/wine/bin/wine64"
        "/Applications/Wine Stable.app/Contents/Resources/wine/bin/wine"
        "/Applications/Wine Stable.app/Contents/Resources/wine/bin/wine64"
        "/Applications/Wine Devel.app/Contents/Resources/wine/bin/wine"
        "/Applications/Wine Staging.app/Contents/Resources/wine/bin/wine"
        "/Applications/CrossOver.app/Contents/SharedSupport/CrossOver/bin/wine"
    )
    for p in "${APP_WINE_PATHS[@]}"; do
        if [[ -x "$p" ]]; then
            WINE_CMD="$p"
            WINE_TYPE="app_wine"
            break
        fi
    done
fi

# Prioridad 3: Wine en PATH del sistema (Homebrew /opt/homebrew o /usr/local)
if [[ -z "$WINE_CMD" ]]; then
    CLI_WINE_PATHS=(
        "/opt/homebrew/bin/wine64"
        "/opt/homebrew/bin/wine"
        "/usr/local/bin/wine64"
        "/usr/local/bin/wine"
    )
    for p in "${CLI_WINE_PATHS[@]}"; do
        if [[ -x "$p" ]]; then
            WINE_CMD="$p"
            WINE_TYPE="system_cli"
            break
        fi
    done
fi

# Prioridad 4: Motor Wine instalado por Whisky
if [[ -z "$WINE_CMD" ]]; then
    WHISKY_WINE_PATHS=(
        "$HOME/Library/Application Support/com.isaacmarovitz.Whisky/Libraries/Wine/bin/wine"
        "$HOME/Library/Application Support/com.isaacmarovitz.Whisky/Libraries/Wine/bin/wine64"
        "$HOME/Library/Application Support/Whisky/Libraries/Wine/bin/wine"
        "$HOME/Library/Application Support/Whisky/Libraries/Wine/bin/wine64"
        "/Applications/Whisky.app/Contents/Resources/Wine/bin/wine"
        "/Applications/Whisky.app/Contents/SharedSupport/wine/bin/wine"
    )
    for p in "${WHISKY_WINE_PATHS[@]}"; do
        if [[ -x "$p" ]]; then
            WINE_CMD="$p"
            WINE_TYPE="whisky_wine"
            break
        fi
    done
fi

# Prioridad 5: Si Whisky está instalado pero aún no ha bajado su motor
if [[ -z "$WINE_CMD" ]] && ([[ -d "/Applications/Whisky.app" ]] || [[ -d "$HOME/Applications/Whisky.app" ]]); then
    echo "[AVISO] Whisky detectado pero motor Wine aún no descargado por Whisky." >> "$LOG_FILE"
    osascript << 'APPLESCRIPT'
    display alert "Sistema de Gestión Mantención" message "Se detectó Whisky en su Mac, pero sus componentes de Wine aún no han sido descargados o inicializados.\n\nAbra Whisky una vez y acepte la descarga de dependencias (GPTK/Wine), o instale Wine Crossover para ejecución automática." buttons {"Cerrar", "Instalar Wine Crossover", "Abrir Whisky"} default button "Instalar Wine Crossover" as critical
    if button returned of result is "Instalar Wine Crossover" then
        tell application "Terminal"
            activate
            do script "echo '=== Instalando Wine Crossover para macOS ===' && brew install --cask --no-quarantine gcenx/wine/wine-crossover"
        end tell
    else if button returned of result is "Abrir Whisky" then
        tell application "Finder" to open application file id "com.isaacmarovitz.Whisky"
    end if
APPLESCRIPT
    exit 1
fi

# Prioridad 6: Si ningún motor fue encontrado, guiar al usuario amigablemente
if [[ -z "$WINE_CMD" ]]; then
    echo "[ERROR] No se encontró ningún motor Wine compatible." >> "$LOG_FILE"
    osascript << 'APPLESCRIPT'
    display alert "Sistema de Gestión Mantención" message "Para ejecutar este software en macOS (compatible con Apple Silicon e Intel), se requiere un motor de compatibilidad.\n\n¿Desea instalar Wine Crossover automáticamente a través de Homebrew?" buttons {"Cancelar", "Instalar Wine"} default button "Instalar Wine" as informational
    if button returned of result is "Instalar Wine" then
        tell application "Terminal"
            activate
            do script "echo '=== Instalando Wine Crossover para macOS ===' && brew install --cask --no-quarantine gcenx/wine/wine-crossover"
        end tell
    end if
APPLESCRIPT
    exit 1
fi

echo "Motor Wine seleccionado: $WINE_CMD (tipo: $WINE_TYPE)" >> "$LOG_FILE"

# 4. Configurar Entorno Wineprefix Dedicado
export WINEPREFIX="$HOME/Library/Application Support/SistemaMantencion/wineprefix"
export WINEARCH=win64
export WINEDEBUG=-all
export WINEFSYNC=1
export WINEESYNC=1
mkdir -p "$WINEPREFIX"

# Configurar variables de bibliotecas para Wine
WINE_DIR="$(cd "$(dirname "$WINE_CMD")/.." && pwd)"
if [[ -d "$WINE_DIR/lib" ]]; then
    export DYLD_FALLBACK_LIBRARY_PATH="$WINE_DIR/lib:${DYLD_FALLBACK_LIBRARY_PATH:-}"
fi
if [[ -d "$WINE_DIR/lib/wine" ]]; then
    export WINEDLLPATH="$WINE_DIR/lib/wine"
fi
if [[ -x "$WINE_DIR/bin/wineserver" ]]; then
    export WINESERVER="$WINE_DIR/bin/wineserver"
fi
if [[ -x "$WINE_DIR/bin/wine" ]]; then
    export WINELOADER="$WINE_DIR/bin/wine"
fi

# 5. Pre-inicializar Wineprefix en el primer inicio con notificación nativa
if [[ ! -d "$WINEPREFIX/drive_c/windows" ]]; then
    echo "[INFO] Primer inicio detectado. Inicializando Wineprefix..." >> "$LOG_FILE"
    osascript -e 'display notification "Configurando entorno de ejecución por primera vez... Espere unos segundos." with title "Sistema de Gestión Mantención"' 2>/dev/null || true
    "${RUN_CMD[@]}" "$WINE_CMD" wineboot --init >> "$LOG_FILE" 2>&1 || true
fi

# 6. Ejecutar Aplicación
echo "[INFO] Ejecutando: $APP_EXE" >> "$LOG_FILE"
cd "$DIR"
exec "${RUN_CMD[@]}" "$WINE_CMD" "$APP_EXE" "$@" >> "$LOG_FILE" 2>&1
EOF

chmod +x "$APP_BUNDLE/Contents/MacOS/launcher"

# 5. Script de instalación de 1-clic para macOS: Instalar_en_Mac.command
echo "[4/5] Creando instalador interactivo Instalar_en_Mac.command..."
cat << 'EOF' > "$DIST_MAC/Instalar_en_Mac.command"
#!/bin/bash
# ==============================================================================
# Script de Instalación de 1-Clic para macOS
# Sistema de Gestión Departamento Mantención - Cambiaso Hnos. S.A.C.
# Compatible con Apple Silicon (M1-M4) e Intel (x86_64)
# ==============================================================================

set -e
cd "$(dirname "$0")"

clear
echo "=========================================================="
echo "  INSTALADOR DE SISTEMA DE GESTIÓN MANTENCIÓN PARA MACOS"
echo "  Cambiaso Hnos. S.A.C. - División de Mantención Industrial"
echo "  Arquitectura: $(uname -m) (Universal Apple Silicon / Intel)"
echo "  macOS: $(sw_vers -productVersion 2>/dev/null || echo 'macOS')"
echo "=========================================================="
echo ""

APP_SRC="Sistema de Gestión Mantención.app"
APP_DEST="/Applications/Sistema de Gestión Mantención.app"

if [[ ! -d "$APP_SRC" ]]; then
    echo "[ERROR] No se encontró '$APP_SRC' en el directorio actual."
    read -p "Presione Enter para salir..."
    exit 1
fi

echo "[1/4] Copiando aplicación hacia /Applications..."
rm -rf "$APP_DEST"
cp -R "$APP_SRC" "$APP_DEST"
echo "       ✓ Aplicación copiada exitosamente."

echo "[2/4] Removiendo restricciones de macOS Gatekeeper y configurando permisos..."
xattr -dr com.apple.quarantine "$APP_DEST" 2>/dev/null || true
chmod -R 755 "$APP_DEST"
chmod +x "$APP_DEST/Contents/MacOS/launcher" 2>/dev/null || true
if [[ -d "$APP_DEST/Contents/Resources/wine/bin" ]]; then
    chmod +x "$APP_DEST/Contents/Resources/wine/bin/"* 2>/dev/null || true
fi
echo "       ✓ Permisos configurados y cuarentena removida."

echo "[3/4] Verificando compatibilidad de hardware y arquitectura..."
if [[ "$(uname -m)" == "arm64" ]]; then
    if ! /usr/bin/pgrep oahd &>/dev/null && ! /usr/bin/arch -x86_64 /usr/bin/true &>/dev/null; then
        echo "       Instalando componente Rosetta 2 para Apple Silicon..."
        softwareupdate --install-rosetta --agree-to-license || true
    else
        echo "       ✓ Rosetta 2 activo para Apple Silicon."
    fi
else
    echo "       ✓ Procesador Intel x86_64 detectado."
fi

echo "[4/4] Creando acceso directo en el Escritorio..."
DESKTOP_DIR="$HOME/Desktop"
if [[ -d "$DESKTOP_DIR" ]]; then
    cat << 'LAUNCH_SCRIPT' > "$DESKTOP_DIR/Sistema de Mantención.command"
#!/bin/bash
open -a "/Applications/Sistema de Gestión Mantención.app"
LAUNCH_SCRIPT
    chmod +x "$DESKTOP_DIR/Sistema de Mantención.command"
    echo "       ✓ Acceso directo creado en el Escritorio."
fi

echo ""
echo "=========================================================="
echo "  ¡INSTALACIÓN COMPLETADA EXITOSAMENTE!"
echo "  Puede abrir la aplicación desde:"
echo "    - Launchpad"
echo "    - Carpeta Aplicaciones (/Applications)"
echo "    - Acceso directo en el Escritorio"
echo "=========================================================="
echo ""
read -p "¿Desea iniciar la aplicación ahora? [S/n]: " -n 1 -r
echo ""
if [[ $REPLY =~ ^[Ss]$ ]] || [[ -z $REPLY ]]; then
    echo "Iniciando Sistema de Gestión Mantención..."
    open "$APP_DEST" || true
fi
EOF

chmod +x "$DIST_MAC/Instalar_en_Mac.command"

# Lanzador de diagnóstico: Iniciar_con_Whisky.command
cat << 'EOF' > "$DIST_MAC/Iniciar_con_Whisky.command"
#!/bin/bash
# ==============================================================================
# Lanzador de Diagnóstico y Ejecución Directa para macOS
# Sistema de Gestión Departamento Mantención - Cambiaso Hnos. S.A.C.
# ==============================================================================

set -u
clear
echo "=========================================================="
echo "  SISTEMA DE GESTIÓN MANTENCIÓN - LANZADOR DIRECTO"
echo "  Cambiaso Hnos. S.A.C. - División Mantención Industrial"
echo "  Arquitectura: $(uname -m)"
echo "=========================================================="
echo ""

DIR="$(cd "$(dirname "$0")" && pwd)"
APP_PATH="$DIR/Sistema de Gestión Mantención.app"
if [[ ! -d "$APP_PATH" ]]; then
    APP_PATH="/Applications/Sistema de Gestión Mantención.app"
fi

if [[ ! -d "$APP_PATH" ]]; then
    echo "[ERROR] No se encontró la aplicación en el directorio actual ni en /Applications."
    read -p "Presione Enter para salir..."
    exit 1
fi

echo "Iniciando aplicación: $APP_PATH"
open "$APP_PATH" 2>/dev/null || "$APP_PATH/Contents/MacOS/launcher"

echo ""
echo "Si la aplicación no abrió, revise el registro detallado en:"
echo "  $HOME/Library/Logs/SistemaMantencion/launcher.log"
echo ""
read -p "Presione Enter para cerrar esta ventana..."
EOF

chmod +x "$DIST_MAC/Iniciar_con_Whisky.command"

# Guía HTML interactiva LEAME_MAC.html
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
      <p>Haga doble clic en el archivo <code>Instalar_en_Mac.command</code> incluido en esta carpeta. Copiará automáticamente la aplicación a su carpeta <code>/Applications</code>, configurará permisos y creará un acceso directo en su Escritorio.</p>
    </div>

    <div class="step">
      <h3>Paso 2: ¡Listo para Trabajar!</h3>
      <p>Abra <strong>Sistema de Gestión Mantención</strong> directamente desde Launchpad, la carpeta Aplicaciones o el Escritorio. La aplicación cuenta con su propio motor integrado y es compatible con procesadores Apple Silicon (M1 a M4) e Intel.</p>
    </div>

    <div class="step">
      <h3>Soporte con Whisky / Wine (Opcional)</h3>
      <p>Si desea utilizar Whisky o Wine externo, la aplicación detectará automáticamente sus configuraciones existentes sin necesidad de pasos adicionales.</p>
    </div>

    <div class="footer">
      Cambiaso Hnos. S.A.C. — División de Mantención Industrial &copy; 2026
    </div>
  </div>
</body>
</html>
EOF

# 6. Comprimir paquete universal para Mac
echo "[5/5] Empaquetando Instalador_Sistema_Mantencion_v2026.1_macOS_Universal.zip..."
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
