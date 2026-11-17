# 📦 Instaladores y Paquetes Oficiales — v2026.1 LTS

Todos los binarios de distribución en esta carpeta se sincronizan automáticamente en cada compilación oficial desde GitHub Actions y son **100% autocontenidos (Zero-Dependency)**.

| Archivo | Plataforma | Formato | Tamaño | SHA-256 |
| :--- | :--- | :---: | :---: | :--- |
| `Instalador_Sistema_Mantencion_v2026.1.exe` | **Windows 10 / 11** (`x64`) | Inno Setup (`LZMA2`) | `41.41 MB` | `95FE548BCEF70D23CEF50A36DEA9B62D9EC453D3309A1A17E1E14702A2B22B54` |
| `Instalador_Sistema_Mantencion_v2026.1_macOS.dmg` | **macOS Universal** (Apple Silicon ARM64 sin Rosetta 2 + Intel) | Imagen DMG (`ULMO`) | `288.94 MB` | `1640323905448f47ac8e3d17d1f0de515602299810fbf36bdc325446e67fbff5` |
| `Instalador_Sistema_Mantencion_v2026.1_macOS_Universal.zip` | **macOS Universal** (Apple Silicon ARM64 sin Rosetta 2 + Intel) | Archivo ZIP (`-9`) | `365.07 MB` | `abc0f363ad81f2ab14187dea69c5d6f84b23e0d16cea3cbee161dcd4b0812b3d` |
| `Sistema.Gestion.Mantencion.2026.1.0.nupkg` | **GitHub Packages / NuGet** | Paquete `.nupkg` | `2.18 MB` | `77b8ff6525baa461b6b7cb44dbdf3438614d4120df59e47b19c4e0b3f3e3d22b` |

## 🚀 Instrucciones Rápidas
- **Windows:** Ejecute `Instalador_Sistema_Mantencion_v2026.1.exe`. No requiere .NET Desktop Runtime, Crystal Reports ni Microsoft Office previos.
- **macOS:** Monte el `.dmg` (o descomprima el `.zip`) y ejecute **`Instalar_en_Mac.command`** (1 clic) para copiar a `/Applications`, conservar únicamente el motor nativo de su arquitectura (`arm64` sin Rosetta 2 en M1–M4 o `x86_64` en Intel), eliminar cuarentena Gatekeeper y crear acceso directo en el Escritorio.
- **Conexión SQL:** La pantalla de **Inicio de Sesión** se muestra limpia; si falla la conexión contra `SrvMagicInfo`, el sistema explica la causa en español y ofrece abrir **Configurar Servidor BD** automáticamente (también disponible en **Mantenedores > Configurar Servidor BD...**).

📄 Verificación detallada y capturas de los 40 formularios en el [README principal](../README.md) y en el [Release v2026.1](https://github.com/barriagada666-collab/Sistema_gestion_Mantencion/releases/tag/v2026.1).
