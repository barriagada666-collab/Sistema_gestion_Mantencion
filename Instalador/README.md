# 📦 Instaladores y Paquetes Oficiales — v2026.1 LTS

Todos los binarios de distribución en esta carpeta se sincronizan automáticamente en cada compilación oficial desde GitHub Actions y son **100% autocontenidos (Zero-Dependency)**.

| Archivo | Plataforma | Formato | Tamaño | SHA-256 |
| :--- | :--- | :---: | :---: | :--- |
| `Instalador_Sistema_Mantencion_v2026.1.exe` | **Windows 10 / 11** (`x64`) | Inno Setup (`LZMA2`) | `41.36 MB` | `23BBDE2A606501DF814F854BAABF60A8E96F9EA3B6FAC82E1A1DB4201DAB2B5C` |
| `Instalador_Sistema_Mantencion_v2026.1_macOS.dmg` | **macOS Universal** (Apple Silicon ARM64 sin Rosetta 2 + Intel) | Imagen DMG (`ULMO`) | `292.92 MB` | `747cf1d62c32286daaff936292e66f7b507e77cbbccffa6c251e1ff9db525da9` |
| `Instalador_Sistema_Mantencion_v2026.1_macOS_Universal.zip` | **macOS Universal** (Apple Silicon ARM64 sin Rosetta 2 + Intel) | Archivo ZIP (`-9`) | `364.88 MB` | `e56c054b637b77d657b8d38e1552b524ccbdd7124b44bd36b8a0422b8aa055c5` |
| `Sistema.Gestion.Mantencion.2026.1.0.nupkg` | **GitHub Packages / NuGet** | Paquete `.nupkg` | `2.09 MB` | `c7c5e7eccea872bc69d380a12ee238c9cc0647b9b36048c376e96f8c2b12a679` |

## 🚀 Instrucciones Rápidas
- **Windows:** Ejecute `Instalador_Sistema_Mantencion_v2026.1.exe`. No requiere .NET Desktop Runtime, Crystal Reports ni Microsoft Office previos.
- **macOS:** Monte el `.dmg` (o descomprima el `.zip`) y ejecute **`Instalar_en_Mac.command`** (1 clic) para copiar a `/Applications`, conservar únicamente el motor nativo de su arquitectura (`arm64` sin Rosetta 2 en M1–M4 o `x86_64` en Intel), eliminar cuarentena Gatekeeper y crear acceso directo en el Escritorio.
- **Conexión SQL:** La pantalla de **Inicio de Sesión** se muestra limpia; si falla la conexión contra `SrvMagicInfo`, el sistema explica la causa en español y ofrece abrir **Configurar Servidor BD** automáticamente (también disponible en **Mantenedores > Configurar Servidor BD...**).

📄 Verificación detallada y capturas de los 40 formularios en el [README principal](../README.md) y en el [Release v2026.1](https://github.com/barriagada666-collab/Sistema_gestion_Mantencion/releases/tag/v2026.1).
