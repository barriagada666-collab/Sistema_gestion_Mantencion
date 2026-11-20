#!/usr/bin/env bash
# ==============================================================================
# Script para generar el Paquete e Instalador Universal Nativo para macOS
# Sistema de Gestión Departamento Mantención - Cambiaso Hnos. S.A.C.
#
# Arquitectura Dual Nativa (Universal Mach-O: arm64 + x86_64):
#   - Apple Silicon (M1/M2/M3/M4): 100% Nativo ARM64 (sin Rosetta 2)
#     * Compatible con macOS 11+ incluyendo macOS 27 Golden Gate y macOS 28+
#   - Intel (x86_64): Nativo x86_64 con Wine Staging 11.21
# ==============================================================================

set -euo pipefail

SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
ROOT_DIR="$(cd "$SCRIPT_DIR/.." && pwd)"

if [[ -f "$ROOT_DIR/VERSION.txt" ]]; then
    APP_VERSION="$(tr -d '\r\n vV' < "$ROOT_DIR/VERSION.txt")"
else
    APP_VERSION="2026.2.0"
fi
APP_TAG="v${APP_VERSION}"

echo "=========================================================="
echo "  GENERADOR DE INSTALADOR MACOS UNIVERSAL NATIVO"
echo "  Versión: $APP_TAG LTS"
echo "  (Apple Silicon ARM64 sin Rosetta + Intel x86_64)"
echo "  Sistema de Gestión Departamento Mantención"
echo "  Cambiaso Hnos. S.A.C."
echo "=========================================================="
echo ""

PUBLISH_DIR_ARM64="$ROOT_DIR/mantencion/bin/Release/net8-selfcontained-arm64"
PUBLISH_DIR_X64="$ROOT_DIR/mantencion/bin/Release/net8-selfcontained-x64"
DIST_MAC="$ROOT_DIR/dist-mac"
APP_NAME="Sistema de Gestion Mantencion"
APP_BUNDLE="$DIST_MAC/$APP_NAME.app"

export PATH="/home/antigravity/.dotnet:$HOME/.dotnet:/opt/homebrew/bin:/usr/local/bin:$PATH"

# 1. Asegurar publicaciones autocontenidas (.NET 8 win-arm64 y win-x64)
echo "[1/6] Verificando publicaciones autocontenidas (.NET 8 win-arm64 + win-x64)..."
if [[ ! -f "$PUBLISH_DIR_ARM64/Sistema de Gestion Mantencion.exe" ]]; then
    echo "       Publicando versión nativa ARM64 (win-arm64)..."
    dotnet publish "$ROOT_DIR/mantencion/mantencion.vbproj" \
        -c Release -r win-arm64 --self-contained true \
        -o "$PUBLISH_DIR_ARM64" -p:EnableWindowsTargeting=true --nologo -v m
else
    echo "       ✓ Publicación win-arm64 existente verificada."
fi

if [[ ! -f "$PUBLISH_DIR_X64/Sistema de Gestion Mantencion.exe" ]]; then
    echo "       Publicando versión Intel x64 (win-x64)..."
    dotnet publish "$ROOT_DIR/mantencion/mantencion.vbproj" \
        -c Release -r win-x64 --self-contained true \
        -o "$PUBLISH_DIR_X64" -p:EnableWindowsTargeting=true --nologo -v m
else
    echo "       ✓ Publicación win-x64 existente verificada."
fi

# 2. Asegurar icono .icns
ICNS_FILE="$ROOT_DIR/mantencion/icons/app_icon.icns"
if [[ ! -f "$ICNS_FILE" ]]; then
    echo "       Generando app_icon.icns..."
    python3 -c "from PIL import Image; Image.open('$ROOT_DIR/mantencion/icons/app_icon_rounded.png').save('$ICNS_FILE', format='ICNS')"
fi

# 3. Crear estructura del .app bundle Universal
echo "[2/6] Creando estructura del macOS Universal App Bundle..."
rm -rf "$DIST_MAC"
mkdir -p "$APP_BUNDLE/Contents/MacOS"
mkdir -p "$APP_BUNDLE/Contents/Resources/app-arm64"
mkdir -p "$APP_BUNDLE/Contents/Resources/app-x64"
mkdir -p "$APP_BUNDLE/Contents/Resources/Base.lproj"
mkdir -p "$APP_BUNDLE/Contents/Resources/es.lproj"

# Info.plist con prioridad nativa ARM64 (sin Rosetta) y nombre visible localizado
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
    <string>$APP_VERSION</string>
    <key>CFBundleSignature</key>
    <string>????</string>
    <key>CFBundleVersion</key>
    <string>$APP_VERSION</string>
    <key>LSArchitecturePriority</key>
    <array>
        <string>arm64</string>
        <string>x86_64</string>
    </array>
    <key>LSHasLocalizedDisplayName</key>
    <true/>
    <key>LSMinimumSystemVersion</key>
    <string>11.0.0</string>
    <key>NSHighResolutionCapable</key>
    <true/>
    <key>NSSupportsAutomaticGraphicsSwitching</key>
    <true/>
    <key>LSApplicationCategoryType</key>
    <string>public.app-category.business</string>
</dict>
</plist>
EOF

cat << 'EOF' > "$APP_BUNDLE/Contents/Resources/Base.lproj/InfoPlist.strings"
"CFBundleDisplayName" = "Sistema de Gestión Mantención";
"CFBundleName" = "Sistema de Gestión Mantención";
EOF
cp "$APP_BUNDLE/Contents/Resources/Base.lproj/InfoPlist.strings" "$APP_BUNDLE/Contents/Resources/es.lproj/InfoPlist.strings"

# PkgInfo
printf "APPL????" > "$APP_BUNDLE/Contents/PkgInfo"

# Icono ICNS
cp "$ICNS_FILE" "$APP_BUNDLE/Contents/Resources/app_icon.icns"

# Copiar binarios .NET 8 ARM64 y x64 depurando WPF/símbolos/idiomas (conservando 'es')
echo "       Copiando y compactando binarios .NET 8 (win-arm64 + win-x64) y plantillas..."
cp -R "$PUBLISH_DIR_ARM64"/* "$APP_BUNDLE/Contents/Resources/app-arm64/"
cp -R "$PUBLISH_DIR_X64"/* "$APP_BUNDLE/Contents/Resources/app-x64/"

for target_app in "$APP_BUNDLE/Contents/Resources/app-arm64" "$APP_BUNDLE/Contents/Resources/app-x64"; do
    python3 "$SCRIPT_DIR/depurar_publicacion.py" "$target_app"
    mkdir -p "$target_app/plantillas"
    cp "$ROOT_DIR/mantencion/plantillas"/*.xls "$target_app/plantillas/" 2>/dev/null || true
done

# 4. Compilar Launcher Mach-O Universal Nativo (arm64 + x86_64)
echo "[3/6] Compilando Launcher Mach-O Universal (arm64 + x86_64)..."
LAUNCHER_SRC="$SCRIPT_DIR/mac_launcher.c"
LAUNCHER_OUT="$APP_BUNDLE/Contents/MacOS/launcher"

if [[ "$(uname -s)" == "Darwin" ]]; then
    clang -arch arm64 -arch x86_64 -mmacosx-version-min=11.0 -O2 -Wall -Wextra -Werror \
        "$LAUNCHER_SRC" -o "$LAUNCHER_OUT"
    chmod +x "$LAUNCHER_OUT"
    echo "       ✓ Binario Universal compilado: $(lipo -info "$LAUNCHER_OUT")"
else
    echo "       [AVISO] Entorno no-macOS detectado ($(uname -s)); generando script fallback temporal."
    cat << 'FALLBACK_EOF' > "$LAUNCHER_OUT"
#!/bin/bash
RESOURCES_DIR="$(cd "$(dirname "$0")/../Resources" && pwd)"
exec /bin/bash "$RESOURCES_DIR/launch_wine.sh" "$(uname -m)" "$@"
FALLBACK_EOF
    chmod +x "$LAUNCHER_OUT"
fi

# 5. Integrar Motor Wine Nativo ARM64 (Apple Silicon sin Rosetta 2) + Wine x64 (Intel)
echo "[4/6] Integrando motores Wine (ARM64 nativo + Intel x86_64)..."

# Detectar llvm-strip para optimizar tamaño de DLLs ARM64
LLVM_STRIP=""
for cand in "$(command -v llvm-strip 2>/dev/null || true)" "/opt/homebrew/opt/llvm/bin/llvm-strip" "/usr/local/opt/llvm/bin/llvm-strip"; do
    if [[ -n "$cand" && -x "$cand" ]]; then
        LLVM_STRIP="$cand"
        break
    fi
done

# 5a. Motor ARM64 Nativo (MetalSharp-Wine v7.0 - 100% arm64 Mach-O, CERO Rosetta 2)
WINE_ARM64_DIR="$APP_BUNDLE/Contents/Resources/wine-arm64"
WINE_ARM64_URL="https://github.com/metalsharp/MetalSharp-Wine/releases/download/v7.0/metalsharp-wine-7.0-arm64.tar.xz"
TMP_ARM64_DL="/tmp/wine-arm64-dl-$$"
mkdir -p "$TMP_ARM64_DL"
WINE_CACHE_DIR="${WINE_CACHE_DIR:-}"
if [[ -n "$WINE_CACHE_DIR" ]]; then
    mkdir -p "$WINE_CACHE_DIR"
    ARM64_TARBALL="$WINE_CACHE_DIR/metalsharp-wine-7.0-arm64.tar.xz"
else
    ARM64_TARBALL="$TMP_ARM64_DL/wine-arm64.tar.xz"
fi

echo "       Obteniendo motor nativo ARM64 (MetalSharp-Wine v7.0)..."
if [[ -s "$ARM64_TARBALL" ]] || curl -fSL --retry 3 "$WINE_ARM64_URL" -o "$ARM64_TARBALL"; then
    mkdir -p "$TMP_ARM64_DL/extracted"
    tar -xJf "$ARM64_TARBALL" \
        --exclude="*/include" \
        --exclude="*/lib/gstreamer-1.0" \
        --exclude="*/lib/mullion" \
        --exclude="*/lib/vkd3d-proton" \
        --exclude="*/lib/wfdxcompat" \
        --exclude="*/lib/wine/i386-windows" \
        --exclude="*/lib/wine/aarch64-windows/*.a" \
        --exclude="*/share/metalsharp" \
        --exclude="*/share/wine/gecko" \
        --exclude="*/share/wine/mono" \
        --exclude="*/share/wine/shadercompilers" \
        --exclude="*/share/wine/webview2" \
        --exclude="*/._*" \
        -C "$TMP_ARM64_DL/extracted" 2>/dev/null || true

    SRC_ARM64="$(dirname "$(find "$TMP_ARM64_DL/extracted" -name "wine-launcher" -type f | head -n 1)")/.."
    SRC_ARM64="$(cd "$SRC_ARM64" && pwd)"

    if [[ -x "$SRC_ARM64/bin/wine-launcher" ]]; then
        mkdir -p "$WINE_ARM64_DIR/bin" "$WINE_ARM64_DIR/lib/wine/aarch64-unix" "$WINE_ARM64_DIR/lib/wine/aarch64-windows" "$WINE_ARM64_DIR/share/wine"

        # Binarios esenciales ARM64
        for binf in wine wine-launcher wineserver wineboot winecfg wineconsole winepath regedit regsvr32 msiexec; do
            if [[ -e "$SRC_ARM64/bin/$binf" ]]; then
                cp -a "$SRC_ARM64/bin/$binf" "$WINE_ARM64_DIR/bin/"
            fi
        done

        # Dylibs requeridas por binarios y módulos aarch64-unix (FreeType, GnuTLS/Nettle/GMP, MoltenVK, Vulkan, SDL2, etc.)
        # Se copian las dylibs del motor excluyendo multimedia/GStreamer y adelgazando universal binaries a arm64 puro
        mkdir -p "$WINE_ARM64_DIR/lib"
        for dylib in "$SRC_ARM64/lib/"*.dylib; do
            [[ -e "$dylib" ]] || continue
            bname="$(basename "$dylib")"
            case "$bname" in
                libgst*|libav*|libsw*|libx26*|libvpx*|libaom*|libdav1d*) continue ;;
            esac
            dest="$WINE_ARM64_DIR/lib/$bname"
            cp -a "$dylib" "$dest"
            if [[ "$(uname -s)" == "Darwin" ]] && [[ ! -L "$dest" ]]; then
                arch_info="$(lipo -info "$dest" 2>/dev/null || true)"
                if echo "$arch_info" | grep -q "x86_64"; then
                    if echo "$arch_info" | grep -q "arm64"; then
                        lipo "$dest" -thin arm64 -output "$dest.arm64" && mv "$dest.arm64" "$dest"
                    else
                        rm -f "$dest"
                    fi
                fi
            fi
        done

        # Módulos UNIX ARM64 (sin GStreamer/Steam/DMO)
        cp -a "$SRC_ARM64/lib/wine/aarch64-unix/"* "$WINE_ARM64_DIR/lib/wine/aarch64-unix/"
        rm -f "$WINE_ARM64_DIR/lib/wine/aarch64-unix/winegstreamer.so" \
              "$WINE_ARM64_DIR/lib/wine/aarch64-unix/winedmo.so" \
              "$WINE_ARM64_DIR/lib/wine/aarch64-unix/lsteamclient.so" 2>/dev/null || true

        # DLLs Windows ARM64 (sin *.a ni lsteamclient.dll)
        cp -a "$SRC_ARM64/lib/wine/aarch64-windows/"* "$WINE_ARM64_DIR/lib/wine/aarch64-windows/"
        rm -f "$WINE_ARM64_DIR/lib/wine/aarch64-windows/"*.a \
              "$WINE_ARM64_DIR/lib/wine/aarch64-windows/lsteamclient.dll" 2>/dev/null || true

        # Recursos compartidos de Wine y licencias
        for rel in share/wine/fonts share/wine/nls share/vulkan share/licenses; do
            if [[ -d "$SRC_ARM64/$rel" ]]; then
                mkdir -p "$WINE_ARM64_DIR/$(dirname "$rel")"
                cp -a "$SRC_ARM64/$rel" "$WINE_ARM64_DIR/$rel"
            fi
        done
        cp -a "$SRC_ARM64/share/wine/wine.inf" "$WINE_ARM64_DIR/share/wine/"

        # Limpiar archivos AppleDouble (._*)
        find "$WINE_ARM64_DIR" -name '._*' -delete 2>/dev/null || true

        # Depurar símbolos DWARF en DLLs Windows ARM64 para reducir ~1 GB (preservando DLLs núcleo del sistema/crypto)
        if [[ -n "$LLVM_STRIP" ]]; then
            echo "       Optimizando binarios PE ARM64 con llvm-strip..."
            find "$WINE_ARM64_DIR/lib/wine/aarch64-windows" -type f \
                \( -name "*.dll" -o -name "*.exe" -o -name "*.drv" -o -name "*.cpl" -o -name "*.sys" -o -name "*.ocx" \) \
                ! -name "ntdll.dll" ! -name "kernel32.dll" ! -name "kernelbase.dll" ! -name "advapi32.dll" \
                ! -name "sechost.dll" ! -name "cryptbase.dll" ! -name "bcrypt*.dll" ! -name "ucrtbase.dll" \
                -print0 | xargs -0 -P 4 "$LLVM_STRIP" --strip-debug 2>/dev/null || true
        else
            echo "       [AVISO] llvm-strip no encontrado; se conservan DLLs ARM64 sin strip."
        fi

        chmod +x "$WINE_ARM64_DIR/bin/"* 2>/dev/null || true
        echo "       ✓ Motor Wine ARM64 nativo integrado ($(du -sh "$WINE_ARM64_DIR" | cut -f1))."
    else
        echo "       [ERROR] No se encontró bin/wine-launcher dentro de MetalSharp-Wine."
        rm -rf "$TMP_ARM64_DL"
        exit 1
    fi
else
    echo "       [ERROR] No se pudo descargar MetalSharp-Wine ARM64."
    rm -rf "$TMP_ARM64_DL"
    exit 1
fi
rm -rf "$TMP_ARM64_DL"

# 5b. Motor Intel x86_64 (Wine Staging 11.21 osx64 - solo usado en Macs Intel)
WINE_X64_DIR="$APP_BUNDLE/Contents/Resources/wine-x64"
WINE_X64_URL="https://github.com/Gcenx/macOS_Wine_builds/releases/download/11.21/wine-staging-11.21-osx64.tar.xz"
TMP_X64_DL="/tmp/wine-x64-dl-$$"
mkdir -p "$TMP_X64_DL"
if [[ -n "$WINE_CACHE_DIR" ]]; then
    X64_TARBALL="$WINE_CACHE_DIR/wine-staging-11.21-osx64.tar.xz"
else
    X64_TARBALL="$TMP_X64_DL/wine-x64.tar.xz"
fi

echo "       Obteniendo motor Intel x86_64 (Wine Staging 11.21)..."
if [[ -s "$X64_TARBALL" ]] || curl -fSL --retry 3 "$WINE_X64_URL" -o "$X64_TARBALL"; then
    tar -xJf "$X64_TARBALL" \
        --exclude="Wine Staging.app/Contents/Resources/wine/include" \
        --exclude="Wine Staging.app/Contents/Resources/wine/share/man" \
        --exclude="Wine Staging.app/Contents/Resources/wine/share/doc" \
        --exclude="Wine Staging.app/Contents/Resources/wine/lib/GStreamer.framework" \
        --exclude="Wine Staging.app/Contents/Resources/wine/share/wine/gecko" \
        --exclude="Wine Staging.app/Contents/Resources/wine/share/wine/mono" \
        --exclude="Wine Staging.app/Contents/Resources/wine/lib/wine/i386-windows" \
        --exclude="Wine Staging.app/Contents/Resources/wine/lib/wine/x86_64-windows/*.a" \
        -C "$TMP_X64_DL" 2>/dev/null || true
    if [[ -d "$TMP_X64_DL/Wine Staging.app/Contents/Resources/wine" ]]; then
        mv "$TMP_X64_DL/Wine Staging.app/Contents/Resources/wine" "$WINE_X64_DIR"
        rm -f "$WINE_X64_DIR/lib/wine/x86_64-unix/winegstreamer.so" \
              "$WINE_X64_DIR/lib/wine/x86_64-unix/winedmo.so" \
              "$WINE_X64_DIR/lib/wine/x86_64-unix/lsteamclient.so" \
              "$WINE_X64_DIR/lib/wine/x86_64-windows/lsteamclient.dll" 2>/dev/null || true
        if [[ -n "$LLVM_STRIP" ]]; then
            find "$WINE_X64_DIR/lib/wine/x86_64-windows" -type f \
                \( -name "*.dll" -o -name "*.exe" -o -name "*.drv" -o -name "*.cpl" -o -name "*.sys" -o -name "*.ocx" \) \
                -print0 | xargs -0 -P 4 "$LLVM_STRIP" --strip-debug 2>/dev/null || true
        fi
        find "$WINE_X64_DIR" -name '._*' -delete 2>/dev/null || true
        chmod +x "$WINE_X64_DIR/bin/"* 2>/dev/null || true
        echo "       ✓ Motor Wine Intel x86_64 integrado ($(du -sh "$WINE_X64_DIR" | cut -f1))."
    fi
else
    echo "       [AVISO] No se pudo descargar Wine Staging x64 en este momento."
fi
rm -rf "$TMP_X64_DL"

# 6. Script interno de arranque (invocado de forma nativa por el binario Universal)
cat << 'EOF' > "$APP_BUNDLE/Contents/Resources/launch_wine.sh"
#!/bin/bash
# ==============================================================================
# Arranque Nativo Multi-Arquitectura (Apple Silicon ARM64 sin Rosetta + Intel x64)
# Sistema de Gestión Departamento Mantención - Cambiaso Hnos. S.A.C.
# ==============================================================================

set -u

# Finder/launchd arranca apps sin LANG ni LC_ALL; forzar UTF-8 evita que Wine corrompa rutas Unicode
if [[ -z "${LANG:-}" || "${LANG:-}" == "C" || "${LANG:-}" == "POSIX" ]]; then
    export LANG="en_US.UTF-8"
fi
if [[ -z "${LC_ALL:-}" || "${LC_ALL:-}" == "C" || "${LC_ALL:-}" == "POSIX" ]]; then
    export LC_ALL="en_US.UTF-8"
fi

ARCH_SLICE="${1:-$(uname -m)}"
if [[ $# -gt 0 ]]; then
    shift
fi

RESOURCES_DIR="$(cd "$(dirname "$0")" && pwd)"
LOG_DIR="$HOME/Library/Logs/SistemaMantencion"
mkdir -p "$LOG_DIR"
LOG_FILE="$LOG_DIR/launcher.log"

{
    echo "=== Iniciando Sistema de Gestión Mantención ==="
    echo "Fecha: $(date)"
    echo "Host uname -m: $(uname -m)"
    echo "Slice compilado activo: $ARCH_SLICE"
    echo "Locale: LANG=$LANG LC_ALL=$LC_ALL"
    echo "macOS: $(sw_vers -productVersion 2>/dev/null || echo 'Desconocido')"
} > "$LOG_FILE"

export PATH="/opt/homebrew/bin:/opt/homebrew/sbin:/usr/local/bin:/usr/local/sbin:$HOME/bin:$HOME/.local/bin:$PATH"

WINE_CMD=""
WINE_DIR=""
APP_DIR=""

if [[ "$ARCH_SLICE" == "arm64" || "$ARCH_SLICE" == "aarch64" ]]; then
    # RUTA 100% NATIVA APPLE SILICON (ZERO ROSETTA 2)
    APP_DIR="$RESOURCES_DIR/app-arm64"
    [[ ! -d "$APP_DIR" ]] && APP_DIR="$RESOURCES_DIR/app"

    if [[ -x "$RESOURCES_DIR/wine-arm64/bin/wine-launcher" ]]; then
        WINE_DIR="$RESOURCES_DIR/wine-arm64"
        WINE_CMD="$WINE_DIR/bin/wine-launcher"
    elif [[ -x "$RESOURCES_DIR/wine-arm64/bin/wine" ]]; then
        WINE_DIR="$RESOURCES_DIR/wine-arm64"
        WINE_CMD="$WINE_DIR/bin/wine"
    else
        # Fallback estricto solo a Wine ARM64 nativo (nunca Rosetta x86_64)
        for cand in "/opt/homebrew/bin/wine" "/opt/homebrew/bin/wine64" "/Applications/Wine Staging.app/Contents/Resources/wine/bin/wine"; do
            if [[ -x "$cand" ]] && file "$cand" 2>/dev/null | grep -q "arm64"; then
                WINE_CMD="$cand"
                WINE_DIR="$(cd "$(dirname "$cand")/.." && pwd)"
                break
            fi
        done
    fi

    if [[ -z "$WINE_CMD" ]]; then
        echo "[ERROR] No se encontró el motor ARM64 nativo." >> "$LOG_FILE"
        osascript -e 'display alert "Sistema de Gestión Mantención" message "No se encontró el motor nativo Apple Silicon (wine-arm64) dentro de la aplicación. Por favor reinstale la versión oficial." as critical' 2>/dev/null || true
        exit 1
    fi

    export WINEPREFIX="$HOME/Library/Application Support/SistemaMantencion/wineprefix-arm64"
else
    # RUTA NATIVA INTEL x86_64
    APP_DIR="$RESOURCES_DIR/app-x64"
    [[ ! -d "$APP_DIR" ]] && APP_DIR="$RESOURCES_DIR/app"

    if [[ -x "$RESOURCES_DIR/wine-x64/bin/wine" ]]; then
        WINE_DIR="$RESOURCES_DIR/wine-x64"
        WINE_CMD="$WINE_DIR/bin/wine"
    elif [[ -x "$RESOURCES_DIR/wine/bin/wine" ]]; then
        WINE_DIR="$RESOURCES_DIR/wine"
        WINE_CMD="$WINE_DIR/bin/wine"
    else
        for cand in \
            "/Applications/Wine Crossover.app/Contents/Resources/wine/bin/wine" \
            "/Applications/Wine Stable.app/Contents/Resources/wine/bin/wine" \
            "/Applications/Wine Staging.app/Contents/Resources/wine/bin/wine" \
            "/usr/local/bin/wine64" \
            "/usr/local/bin/wine" \
            "$HOME/Library/Application Support/com.isaacmarovitz.Whisky/Libraries/Wine/bin/wine"; do
            if [[ -x "$cand" ]]; then
                WINE_CMD="$cand"
                WINE_DIR="$(cd "$(dirname "$cand")/.." && pwd)"
                break
            fi
        done
    fi

    if [[ -z "$WINE_CMD" ]]; then
        echo "[ERROR] No se encontró motor Wine Intel x86_64." >> "$LOG_FILE"
        osascript -e 'display alert "Sistema de Gestión Mantención" message "No se encontró el motor Wine compatible para Intel. Por favor reinstale el paquete oficial." as critical' 2>/dev/null || true
        exit 1
    fi

    export WINEPREFIX="$HOME/Library/Application Support/SistemaMantencion/wineprefix-x86_64"
fi

APP_EXE="$APP_DIR/Sistema de Gestion Mantencion.exe"
if [[ ! -f "$APP_EXE" ]]; then
    echo "[ERROR] No existe el ejecutable: $APP_EXE" >> "$LOG_FILE"
    osascript -e 'display alert "Sistema de Gestión Mantención" message "No se encontró el archivo ejecutable principal dentro del paquete." as critical' 2>/dev/null || true
    exit 1
fi

echo "Motor Wine seleccionado: $WINE_CMD" >> "$LOG_FILE"
echo "Aplicación objetivo: $APP_EXE" >> "$LOG_FILE"
echo "WINEPREFIX: $WINEPREFIX" >> "$LOG_FILE"

mkdir -p "$WINEPREFIX"
export WINEARCH=win64
export WINEDEBUG=-all
export WINEFSYNC=1
export WINEESYNC=1
# Desactiva diálogos de descarga de Wine Mono y Wine Gecko durante inicialización de prefijo
export WINEDLLOVERRIDES="mscoree,mshtml="
# Usa tablas NLS nativas de Wine en lugar de icu.dll (evita "Could not load ICU data. UErrorCode: 2")
export DOTNET_SYSTEM_GLOBALIZATION_USENLS=1
# Evita fallos 0x80131506 de mapeo dual W^X en CoreCLR ARM64 bajo Wine/Apple Silicon (páginas 16K)
export DOTNET_EnableWriteXorExecute=0
export COMPlus_EnableWriteXorExecute=0

if [[ -d "$WINE_DIR/lib" ]]; then
    export DYLD_FALLBACK_LIBRARY_PATH="$WINE_DIR/lib:${DYLD_FALLBACK_LIBRARY_PATH:-}"
fi
if [[ -d "$WINE_DIR/lib/wine" ]]; then
    export WINEDLLPATH="$WINE_DIR/lib/wine"
fi
if [[ -x "$WINE_DIR/bin/wineserver" ]]; then
    export WINESERVER="$WINE_DIR/bin/wineserver"
fi
export WINELOADER="$WINE_CMD"

if [[ -f "$WINE_DIR/share/vulkan/icd.d/MoltenVK_icd.json" ]]; then
    export VK_DRIVER_FILES="$WINE_DIR/share/vulkan/icd.d/MoltenVK_icd.json"
fi

# Primer inicio: inicializar Wineprefix limpio (sin prompts de Mono/Gecko)
if [[ ! -d "$WINEPREFIX/drive_c/windows" ]]; then
    echo "[INFO] Primer inicio detectado. Inicializando Wineprefix ($ARCH_SLICE)..." >> "$LOG_FILE"
    osascript -e 'display notification "Configurando entorno nativo por primera vez... Espere unos segundos." with title "Sistema de Gestión Mantención"' 2>/dev/null || true
    "$WINE_CMD" wineboot --init >> "$LOG_FILE" 2>&1 || true
fi

# CRÍTICO para .NET 8 autocontenido en Wine:
# Wine ntdll (fixup_imports_ilonly) requiere mscoree.dll builtin presente para mapear ensamblados IL-only (como System.Runtime.dll).
# Si mscoree se deja vacío ("mscoree="), Wine falla con "mscoree.dll not found, IL-only binary cannot be loaded".
export WINEDLLOVERRIDES="mshtml=;mscoree=b"

echo "[INFO] Lanzando Sistema de Gestion Mantencion.exe desde $APP_DIR..." >> "$LOG_FILE"
cd "$APP_DIR"
exec "$WINE_CMD" "Sistema de Gestion Mantencion.exe" "$@" >> "$LOG_FILE" 2>&1
EOF

chmod +x "$APP_BUNDLE/Contents/Resources/launch_wine.sh"

# Firmar ad-hoc el bundle en macOS para Gatekeeper / Apple Silicon (sin depender de --deep sobre scripts/PE)
if [[ "$(uname -s)" == "Darwin" ]]; then
    echo "[5/6] Firmando App Bundle Universal (ad-hoc codesign)..."
    xattr -cr "$APP_BUNDLE" 2>/dev/null || true
    while IFS= read -r -d '' macho_file; do
        if file "$macho_file" 2>/dev/null | grep -q "Mach-O"; then
            codesign --force --sign - "$macho_file" >/dev/null 2>&1 || true
        fi
    done < <(find "$APP_BUNDLE/Contents/Resources" -type f \( -perm -0100 -o -name "*.dylib" -o -name "*.so" \) -print0)
    codesign --force --sign - "$APP_BUNDLE"
    codesign --verify --strict "$APP_BUNDLE"
    echo "       ✓ Firma digital local verificada correctamente."
else
    echo "[5/6] Firma macOS omitida (entorno no-Darwin)."
fi

# 7. Script de instalación de 1-clic para macOS: Instalar_en_Mac.command
echo "[6/6] Creando scripts auxiliares y empaquetando ZIP Universal..."
cat << 'EOF' > "$DIST_MAC/Instalar_en_Mac.command"
#!/bin/bash
# ==============================================================================
# Script de Instalación de 1-Clic para macOS Universal Nativo
# Sistema de Gestión Departamento Mantención - Cambiaso Hnos. S.A.C.
# Apple Silicon (M1-M4 sin Rosetta 2) & Intel (x86_64)
# ==============================================================================

set -e
cd "$(dirname "$0")"

ARCH="$(uname -m)"

clear
echo "=========================================================="
echo "  INSTALADOR DE SISTEMA DE GESTIÓN MANTENCIÓN PARA MACOS"
echo "  Cambiaso Hnos. S.A.C. - División de Mantención Industrial"
echo "  Arquitectura detectada: $ARCH"
echo "  macOS: $(sw_vers -productVersion 2>/dev/null || echo 'macOS')"
echo "=========================================================="
echo ""

APP_SRC="Sistema de Gestion Mantencion.app"
APP_DEST="/Applications/Sistema de Gestion Mantencion.app"
OLD_APP_DEST="/Applications/Sistema de Gestión Mantención.app"

if [[ ! -d "$APP_SRC" ]]; then
    echo "[ERROR] No se encontró '$APP_SRC' en el directorio actual."
    read -p "Presione Enter para salir..."
    exit 1
fi

echo "[1/4] Copiando aplicación hacia /Applications..."
rm -rf "$OLD_APP_DEST" "$APP_DEST"
cp -R "$APP_SRC" "$APP_DEST"
echo "       ✓ Aplicación copiada exitosamente."

echo "[2/4] Optimizando paquete para su arquitectura ($ARCH)..."
if [[ "$ARCH" == "arm64" ]]; then
    # Eliminar payload Intel x86_64 para ahorrar espacio y garantizar cero componentes Intel
    rm -rf "$APP_DEST/Contents/Resources/wine-x64" "$APP_DEST/Contents/Resources/app-x64"
    echo "       ✓ Chip Apple Silicon (ARM64) — Ejecución 100% nativa SIN Rosetta 2."
    echo "       ✓ Compatible con macOS 15+, macOS 27 Golden Gate y macOS 28+."
else
    # Eliminar payload ARM64 en Macs Intel
    rm -rf "$APP_DEST/Contents/Resources/wine-arm64" "$APP_DEST/Contents/Resources/app-arm64"
    echo "       ✓ Procesador Intel x86_64 — Motor Wine Staging x64 configurado."
fi

echo "[3/4] Removiendo cuarentena Gatekeeper y aplicando firma local..."
xattr -cr "$APP_DEST" 2>/dev/null || true
chmod +x "$APP_DEST/Contents/MacOS/launcher" "$APP_DEST/Contents/Resources/launch_wine.sh" 2>/dev/null || true
if [[ -d "$APP_DEST/Contents/Resources/wine-arm64/bin" ]]; then
    chmod +x "$APP_DEST/Contents/Resources/wine-arm64/bin/"* 2>/dev/null || true
fi
if [[ -d "$APP_DEST/Contents/Resources/wine-x64/bin" ]]; then
    chmod +x "$APP_DEST/Contents/Resources/wine-x64/bin/"* 2>/dev/null || true
fi
while IFS= read -r -d '' macho_file; do
    if file "$macho_file" 2>/dev/null | grep -q "Mach-O"; then
        codesign --force --sign - "$macho_file" >/dev/null 2>&1 || true
    fi
done < <(find "$APP_DEST/Contents/Resources" -type f \( -perm -0100 -o -name "*.dylib" -o -name "*.so" \) -print0)
codesign --force --sign - "$APP_DEST" >/dev/null 2>&1 || true
echo "       ✓ Permisos y firma configurados."

echo "[4/4] Creando acceso directo en el Escritorio..."
DESKTOP_DIR="$HOME/Desktop"
if [[ -d "$DESKTOP_DIR" ]]; then
    cat << 'LAUNCH_SCRIPT' > "$DESKTOP_DIR/Sistema de Mantención.command"
#!/bin/bash
open -a "/Applications/Sistema de Gestion Mantencion.app"
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

# Lanzador de diagnóstico directo
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
echo "  Arquitectura: $(uname -m) (Nativo sin Rosetta en Apple Silicon)"
echo "=========================================================="
echo ""

DIR="$(cd "$(dirname "$0")" && pwd)"
APP_PATH="$DIR/Sistema de Gestion Mantencion.app"
if [[ ! -d "$APP_PATH" ]]; then
    APP_PATH="/Applications/Sistema de Gestion Mantencion.app"
fi
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
echo "Registro de ejecución disponible en:"
echo "  $HOME/Library/Logs/SistemaMantencion/launcher.log"
echo ""
read -p "Presione Enter para cerrar esta ventana..."
EOF

chmod +x "$DIST_MAC/Iniciar_con_Whisky.command"

# Guía HTML interactiva LEAME_MAC.html (Paleta Corporativa Oficial)
cat << 'EOF' > "$DIST_MAC/LEAME_MAC.html"
<!DOCTYPE html>
<html lang="es">
<head>
  <meta charset="UTF-8">
  <title>Instalación en macOS - Sistema de Mantención Cambiaso Hnos.</title>
  <style>
    body { font-family: "Segoe UI", -apple-system, BlinkMacSystemFont, Roboto, Helvetica, Arial, sans-serif; margin: 40px; background: #0F2D44; color: #F2F6F6; line-height: 1.6; }
    .card { max-width: 780px; margin: 0 auto; background: #0F172A; border-radius: 16px; padding: 32px; border: 1px solid #025E87; box-shadow: 0 12px 30px rgba(0,0,0,0.45); }
    h1 { color: #66C9D3; font-size: 24px; margin-top: 0; display: flex; align-items: center; gap: 12px; }
    .step { background: #0B2235; border-radius: 12px; padding: 18px; margin-bottom: 16px; border-left: 4px solid #0191B3; }
    .step h3 { margin: 0 0 8px 0; color: #66C9D3; font-size: 16px; }
    code { background: #163A54; padding: 3px 8px; border-radius: 6px; font-family: monospace; color: #E5EBEB; }
    .badge { display: inline-block; padding: 4px 12px; border-radius: 20px; font-size: 12px; font-weight: bold; background: #025E87; color: white; margin-bottom: 20px; }
    .badge-native { background: #0191B3; margin-left: 8px; }
    .footer { margin-top: 24px; text-align: center; color: #A0C5CF; font-size: 12px; }
  </style>
</head>
<body>
  <div class="card">
    <span class="badge">Aplicación Universal (Apple Silicon &amp; Intel)</span>
    <span class="badge badge-native">Ejecución Nativa macOS</span>
    <h1>Sistema de Gestión Departamento Mantención $APP_TAG LTS</h1>
    <p>Plataforma corporativa de gestión de mantención industrial de Cambiaso Hnos. S.A.C. para equipos Mac.</p>

    <div class="step">
      <h3>Paso 1: Instalación Automática en 1 Clic (Recomendado)</h3>
      <p>Haga doble clic en <code>Instalar_en_Mac.command</code>. Copiará la aplicación a <code>/Applications</code>, optimizará el paquete para su procesador y creará un acceso directo en el Escritorio.</p>
    </div>

    <div class="step">
      <h3>Paso 2: Ejecución Multiplataforma sin Dependencias</h3>
      <p>Incluye todo el entorno necesario para abrir órdenes de trabajo, planificación preventiva, Carta Gantt, gestión de activos y exportación directa a Excel y PDF.</p>
    </div>

    <div class="step">
      <h3>Paso 3: Conexión de Base de Datos</h3>
      <p>Requiere acceso a la red corporativa. Si necesita ajustar los parámetros del servidor, un usuario con perfil administrador puede configurarlos directamente desde la aplicación.</p>
    </div>

    <div class="footer">
      Cambiaso Hnos. S.A.C. — División de Mantención Industrial &copy; 2026
    </div>
  </div>
</body>
</html>
EOF

# Comprimir paquete Universal ZIP con máxima compresión (-9)
mkdir -p "$ROOT_DIR/Instalador"
ZIP_OUTPUT="$ROOT_DIR/Instalador/Instalador_Sistema_Mantencion_${APP_TAG}_macOS_Universal.zip"
rm -f "$ZIP_OUTPUT"

if [[ "${SKIP_ARCHIVE:-0}" == "1" ]]; then
    echo ""
    echo "=========================================================="
    echo "  APP BUNDLE GENERADO (SKIP_ARCHIVE=1 -> se comprimirá tras pruebas)"
    echo "  Bundle: $APP_BUNDLE"
    echo "=========================================================="
else
    cd "$DIST_MAC"
    zip -9 -r -y "$ZIP_OUTPUT" "$APP_NAME.app" "Instalar_en_Mac.command" "Iniciar_con_Whisky.command" "LEAME_MAC.html"

    ZIP_HASH=$( (command -v sha256sum >/dev/null && sha256sum "$ZIP_OUTPUT" || shasum -a 256 "$ZIP_OUTPUT") | awk '{print $1}' )
    ZIP_SIZE_MB=$(du -m "$ZIP_OUTPUT" | awk '{print $1}')

    echo ""
    echo "=========================================================="
    echo "  PAQUETE MACOS UNIVERSAL NATIVO GENERADO EXITOSAMENTE"
    echo "  Archivo: $ZIP_OUTPUT"
    echo "  Tamaño : ~$ZIP_SIZE_MB MB"
    echo "  SHA256 : $ZIP_HASH"
    echo "=========================================================="
fi
