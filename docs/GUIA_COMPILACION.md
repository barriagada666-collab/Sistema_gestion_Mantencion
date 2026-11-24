# Guía de Compilación, Versionado y Pruebas

**Sistema de Gestión Departamento Mantención** — Entorno de Desarrollo `.NET 8 LTS` (Windows `x64`)

---

## 1. Requisitos del Entorno de Desarrollo

- **Sistema Operativo:** Windows 10 u 11 (`64 bits`).
- **SDK:** Microsoft .NET 8 SDK (`8.0.x`).
- **Empaquetador Windows:** Inno Setup 6 (`ISCC.exe`).
- **Python 3:** Utilizado por el optimizador de publicación autocontenida para depurar binarios y recursos no utilizados.

---

## 2. Control Centralizado de Versionado

La versión del sistema se administra desde una única fuente en `VERSION.txt` (formato `YYYY.M.P`).

### Actualizar versión y gráficas antes de compilar
Utilice el script de versionamiento en la carpeta de automatizadores:

```powershell
# Incrementar parche (ej. 2026.2.2 -> 2026.2.3)
.\automatizadores de instalacion\Actualizar_Version.ps1 -IncrementarPatch

# Incrementar versión menor (ej. 2026.2.3 -> 2026.3.0)
.\automatizadores de instalacion\Actualizar_Version.ps1 -IncrementarMinor

# Establecer una versión específica con notas de paquete
.\automatizadores de instalacion\Actualizar_Version.ps1 -NuevaVersion 2026.3.0 -NotasVersion "Descripción de mejoras"
```

Este comando sincroniza automáticamente `VERSION.txt`, `version.iss` (Inno Setup), los metadatos de proyecto, la reseña del asistente de instalación (`InfoSoftware.rtf`) y regenera las gráficas del asistente (`wizard_banner.bmp` y `wizard_banner_2x.bmp`).

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

La compilación lee automáticamente `VERSION.txt` y estampa `ProductVersion` y `FileVersion` en el binario resultante sin supresiones de advertencias.

---

## 4. Generación de Paquete NuGet e Instalador Windows (`x64`)

```powershell
.\automatizadores de instalacion\Compilar_Instalador.ps1
```

El script ejecuta de forma automatizada:
1. Sincronización de versión y gráficas desde `VERSION.txt` (acepta `-IncrementarPatch`, `-IncrementarMinor` o `-NuevaVersion`).
2. Compilación limpia en **Debug** y **Release** (`0` errores, `0` advertencias).
3. Publicación autocontenida `win-x64` y depuración de ensamblados/idiomas no requeridos.
4. Empaquetado NuGet (`.nupkg`) y compilación de `Instalador_Sistema_Mantencion_v<VERSION>.exe` con Inno Setup 6.
5. Generación del archivo de verificación `Instalador\checksums_sha256.txt`.

---

## 5. Pruebas de Validación

Ejecute cada script en una sesión independiente de PowerShell (`pwsh -NoProfile -File`):
- `automatizadores de instalacion\diagnostico_entorno.ps1`: conectividad de datos, verificación libre de librerías heredadas y generación PDF nativa.
- `automatizadores de instalacion\test_forms.ps1`: validación de carga e estado inicial de los formularios del escritorio MDI.
- `automatizadores de instalacion\test_mdi_simulation.ps1`: validación de acoplamiento, tamaño y maximización dentro del escritorio MDI.

---

## 6. Flujo Automático CI/CD (GitHub Actions)

Cada push a la rama `main` (con cambios de código, scripts o `VERSION.txt`) ejecuta automáticamente el pipeline Windows en `.github/workflows/build-and-package.yml`:
1. Resuelve la versión oficial desde `VERSION.txt`.
2. Compila **Debug** y **Release** sin advertencias, publica el ejecutable autocontenido `win-x64`, verifica el arranque, genera el paquete NuGet y compila el instalador Windows con Inno Setup 6.
3. Publica los artefactos en el Release `v<VERSION>` y sincroniza la carpeta `/Instalador` junto al tag oficial en `main`.
