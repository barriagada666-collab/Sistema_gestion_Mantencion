# 📦 Instaladores y Paquetes Oficiales — v2026.1 LTS

Todos los binarios de distribución en esta carpeta se sincronizan automáticamente en cada compilación oficial desde GitHub Actions y son **100% autocontenidos (Zero-Dependency)**.

| Archivo | Plataforma | Formato | Tamaño | SHA-256 |
| :--- | :--- | :---: | :---: | :--- |
| `Instalador_Sistema_Mantencion_v2026.1.exe` | **Windows 10 / 11** (`x64`) | Inno Setup (`LZMA2`) | `41.33 MB` | `CEA22FA82F282B9DD581EF44EF9AB818FC8D8BA2CB059C6A1C3F7FD1CB35A1FE` |
| `Instalador_Sistema_Mantencion_v2026.1_macOS.dmg` | **macOS Universal** (Apple Silicon ARM64 sin Rosetta 2 + Intel) | Imagen DMG (`ULMO`) | `293.72 MB` | `184dbecde1fee1de90378ef1f5d87142b4250fc372b127567fc58d0733b30d8b` |
| `Instalador_Sistema_Mantencion_v2026.1_macOS_Universal.zip` | **macOS Universal** (Apple Silicon ARM64 sin Rosetta 2 + Intel) | Archivo ZIP (`-9`) | `364.88 MB` | `bdf3e6de140e9bdf4d491fa3a4406fab2c6b0856460deb2bb51995c3106a4a7c` |
| `Sistema.Gestion.Mantencion.2026.1.0.nupkg` | **GitHub Packages / NuGet** | Paquete `.nupkg` | `2.09 MB` | `0ecd26c95c0f9b3fb0a6205c3329220a1ee00f9d3c6cd0ea59b8f4d7ac0f2342` |

## 🚀 Instrucciones Rápidas
- **Windows:** Ejecute `Instalador_Sistema_Mantencion_v2026.1.exe`. No requiere .NET Desktop Runtime, Crystal Reports ni Microsoft Office previos.
- **macOS:** Monte el `.dmg` (o descomprima el `.zip`) y ejecute **`Instalar_en_Mac.command`** (1 clic) para copiar a `/Applications`, conservar únicamente el motor nativo de su arquitectura (`arm64` sin Rosetta 2 en M1–M4 o `x86_64` en Intel), eliminar cuarentena Gatekeeper y crear acceso directo en el Escritorio.
- **Conexión SQL:** La pantalla de **Inicio de Sesión** se muestra limpia; si falla la conexión contra `SrvMagicInfo`, el sistema explica la causa en español y ofrece abrir **Configurar Servidor BD** automáticamente (también disponible en **Mantenedores > Configurar Servidor BD...**).

📄 Verificación detallada y capturas de los 40 formularios en el [README principal](../README.md) y en el [Release v2026.1](https://github.com/barriagada666-collab/Sistema_gestion_Mantencion/releases/tag/v2026.1).
