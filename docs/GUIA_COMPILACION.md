# Guía de Compilación, Versionado y Pruebas

**Sistema de Gestión Departamento Mantención** — Entorno de Desarrollo `.NET 8 LTS`

---

## 1. Requisitos del Entorno de Desarrollo

- **Sistema Operativo:** Windows 10 u 11 (`64 bits`) para compilación nativa y empaquetado de instalador Windows; macOS (`11+`) para generación de imagen `.dmg` Universal.
- **SDK:** Microsoft .NET 8 SDK (`8.0.x`).
- **Empaquetador Windows:** Inno Setup 6 (`ISCC.exe`).
- **Python 3:** Utilizado por el optimizador de publicación autocontenida para depurar binarios y recursos no utilizados.

---

## 2. Control Centralizado de Versionado

La versión del sistema se administra desde una única fuente en `VERSION.txt` (formato `YYYY.M.P`).

### Actualizar versión antes de compilar
Utilice el script de versionamiento en la carpeta de automatizadores:

```powershell
# Incrementar parche (ej. 2026.2.1 -> 2026.2.2)
.\automatizadores de instalacion\Actualizar_Version.ps1 -IncrementarPatch

# Incrementar versión menor (ej. 2026.2.2 -> 2026.3.0)
.\automatizadores de instalacion\Actualizar_Version.ps1 -IncrementarMinor

# Establecer una versión específica con notas de paquete
.\automatizadores de instalacion\Actualizar_Version.ps1 -NuevaVersion 2026.3.0 -NotasVersion "Descripción de mejoras"
```

Este comando sincroniza automáticamente `VERSION.txt`, `version.iss` (Inno Setup), los metadatos de proyecto `.vbproj` y la reseña del asistente de instalación (`InfoSoftware.rtf`).

---

## 3. Compilación de la Solución (Debug y Release)

```powershell
# Restaurar dependencias NuGet
dotnet restore mantencion.sln

# Compilar Debug sin compilación incremental (objetivo: 0 errores, 0 advertencias)
dotnet build mantencion.sln -c Debug --no-restore --no-incremental

# Compilar Release sin compilación incremental (objetivo: 0 errores, 0 advertencias)
dotnet build mantencion.sln -c Release --no-restore --no-incremental
```

La compilación lee automáticamente `VERSION.txt` y estampa `ProductVersion` y `FileVersion` en el binario resultante.

---

## 4. Generación de Paquetes e Instaladores

### 4.1 Windows (`x64` Autocontenido + NuGet)
```powershell
.\automatizadores de instalacion\Compilar_Instalador.ps1
```
El script ejecuta de forma automatizada:
1. Sincronización de versión desde `VERSION.txt` (también acepta `-IncrementarPatch`, `-IncrementarMinor` o `-NuevaVersion`).
2. Compilación limpia en **Debug** y **Release**.
3. Publicación autocontenida `win-x64` y depuración de ensamblados/idiomas no requeridos.
4. Empaquetado NuGet (`.nupkg`) y compilación de `Instalador_Sistema_Mantencion_v<VERSION>.exe` con Inno Setup 6.
5. Generación del archivo de verificación `Instalador\checksums_sha256.txt`.

### 4.2 Publicación Windows `ARM64`
```powershell
dotnet publish mantencion\mantencion.vbproj -c Release -r win-arm64 --self-contained true -o mantencion\bin\Release\net8-selfcontained-arm64
python "automatizadores de instalacion\depurar_publicacion.py" mantencion\bin\Release\net8-selfcontained-arm64
```

### 4.3 macOS Universal (`ARM64` + `Intel`)
En un equipo macOS con .NET 8 SDK:
```bash
bash "automatizadores de instalacion/Generar_Instalador_Mac.sh"
```

---

## 5. Pruebas de Validación

Ejecute cada script en una sesión independiente de PowerShell (`pwsh -NoProfile -File`):
- `automatizadores de instalacion\diagnostico_entorno.ps1`: conectividad de datos, verificación libre de librerías heredadas y generación PDF nativa.
- `automatizadores de instalacion\test_forms.ps1`: validación de estado inicial de los 17 formularios MDI hijos.
- `automatizadores de instalacion\test_mdi_simulation.ps1`: validación de acoplamiento y maximización dentro del escritorio MDI.

---

## 6. Flujo Automático CI/CD (GitHub Actions)

Cada push a la rama `main` (con cambios de código, scripts o `VERSION.txt`) ejecuta automáticamente el pipeline `.github/workflows/build-and-package.yml`:
1. Resuelve la versión oficial desde `VERSION.txt`.
2. Compila, publica, prueba arranque, empaqueta y genera el instalador Windows (`x64`) + NuGet.
3. Compila, valida y empaqueta el instalador macOS Universal (`.dmg` + `.zip`).
4. Publica los artefactos en el Release `v<VERSION>` y sincroniza la carpeta `/Instalador` junto al tag oficial.
