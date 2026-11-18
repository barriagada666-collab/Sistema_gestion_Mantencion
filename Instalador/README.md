# 📦 Instaladores y Paquetes Oficiales — v2026.1 LTS

Todos los binarios de distribución en esta carpeta se sincronizan automáticamente en cada compilación oficial desde GitHub Actions y son **100% autocontenidos (Zero-Dependency)**, compilados con **0 errores y 0 advertencias**.

| Archivo | Plataforma | Formato / Compilación | Tamaño | SHA-256 |
| :--- | :--- | :---: | :---: | :--- |
| `Instalador_Sistema_Mantencion_v2026.1.exe` | **Windows 10 / 11** (`win-x64` autocontenido `.NET 8`, depurado a `130.40 MB`) | Inno Setup (`LZMA2`) | `41.44 MB` | `FCD9463BC1966967D2FB27E42999FAC9BBFF165DB9218FAB6030ACA3CF9AA5BA` |
| `Instalador_Sistema_Mantencion_v2026.1_macOS.dmg` | **macOS Universal** (Apple Silicon `arm64` sin Rosetta 2 + Intel `x86_64`) | Imagen DMG (`ULMO`) | `289.51 MB` | `BBA12DCEBBAD28C702124230290C35411297E1461EBA4216287F5DAEE373B500` |
| `Instalador_Sistema_Mantencion_v2026.1_macOS_Universal.zip` | **macOS Universal** (Apple Silicon `arm64` sin Rosetta 2 + Intel `x86_64`) | Archivo ZIP (`-9`) | `365.12 MB` | `16995E0DBCE5E31D59525FA59A32198C6CDBA90F0662F1428096B1A301612A3D` |
| `Sistema.Gestion.Mantencion.2026.1.0.nupkg` | **GitHub Packages / NuGet** | Paquete `.nupkg` | `2.21 MB` | `2FED38C630DEDA93BC6AAC92E5B80AF76C8815D5009634403E40DEFCDDCDA125` |

## 🚀 Instrucciones Rápidas
- **Windows:** Ejecute `Instalador_Sistema_Mantencion_v2026.1.exe`. No requiere .NET Desktop Runtime, Crystal Reports ni Microsoft Office previos. Incluye las **7 plantillas `.xls`** renovadas con la paleta corporativa y configuración de exportación **PDF horizontal completa** (`FitWidth = 1`, `FitHeight = Automático`).
- **macOS:** Monte el `.dmg` (o descomprima el `.zip`) y ejecute **`Instalar_en_Mac.command`** (1 clic) para copiar a `/Applications`, conservar únicamente el motor nativo de su arquitectura (`arm64` sin Rosetta 2 en M1–M4 o `x86_64` en Intel), eliminar cuarentena Gatekeeper y crear acceso directo en el Escritorio.
- **Conexión SQL y Gestión de Usuarios:** La pantalla de **Inicio de Sesión** se muestra limpia; si falla la conexión contra `SrvMagicInfo`, el sistema explica la causa en español y ofrece abrir **Configurar Servidor BD** automáticamente. Dentro del sistema, la barra inferior muestra el servidor/BD activos con farol verde, el menú **Mantenedores > Configurar Servidor BD...** es exclusivo para perfil **`Administrador`**, y **FrmAdminUsuarios** permite gestionar usuarios, perfiles y los **21 permisos** por módulo.
- **Compilaciones Verificadas (`Debug`, `Release`, `win-x64` y `win-arm64`):** Generadas sin errores ni advertencias, con carga de árbol jerárquico en 1 consulta (`2.780` nodos en `24 ms`) y checksums oficiales en `checksums_sha256.txt` y `checksums_mac_sha256.txt`.

📄 Verificación detallada y capturas de los 40 formularios en el [README principal](../README.md) y en el [Release v2026.1](https://github.com/barriagada666-collab/Sistema_gestion_Mantencion/releases/tag/v2026.1).
