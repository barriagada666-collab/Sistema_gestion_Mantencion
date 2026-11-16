# 📦 Instaladores y Paquetes Oficiales — v2026.1 LTS

Todos los binarios de distribución en esta carpeta se sincronizan automáticamente en cada compilación oficial desde GitHub Actions y son **100% autocontenidos (Zero-Dependency)**.

| Archivo | Plataforma | Formato | Tamaño | SHA-256 |
| :--- | :--- | :---: | :---: | :--- |
| `Instalador_Sistema_Mantencion_v2026.1.exe` | **Windows 10 / 11** (`x64`) | Inno Setup (`LZMA2`) | `41.42 MB` | `996035501C3A9B73A38AF29A8FBEF35B8E576D3CBF09DB41702C17096E669080` |
| `Instalador_Sistema_Mantencion_v2026.1_macOS.dmg` | **macOS Universal** (Apple Silicon ARM64 sin Rosetta 2 + Intel) | Imagen DMG (`ULMO`) | `284.46 MB` | `79632e17d51e903775b33dbcaf8a89ae635f18cc30358da84e34392675d275da` |
| `Instalador_Sistema_Mantencion_v2026.1_macOS_Universal.zip` | **macOS Universal** (Apple Silicon ARM64 sin Rosetta 2 + Intel) | Archivo ZIP (`-9`) | `365.06 MB` | `59fd18f35a0485163ffc4eadb8cebbbd862e011faefcbf397943410358b42c17` |
| `Sistema.Gestion.Mantencion.2026.1.0.nupkg` | **GitHub Packages / NuGet** | Paquete `.nupkg` | `2.18 MB` | `fbbb59c558a9cd14de8a432327e9a6c23ddddbfceb1ea6d7fd4768423ea2c468` |

## 🚀 Instrucciones Rápidas
- **Windows:** Ejecute `Instalador_Sistema_Mantencion_v2026.1.exe`. No requiere .NET Desktop Runtime, Crystal Reports ni Microsoft Office previos.
- **macOS:** Monte el `.dmg` (o descomprima el `.zip`) y ejecute **`Instalar_en_Mac.command`** (1 clic) para copiar a `/Applications`, conservar únicamente el motor nativo de su arquitectura (`arm64` sin Rosetta 2 en M1–M4 o `x86_64` en Intel), eliminar cuarentena Gatekeeper y crear acceso directo en el Escritorio.
- **Conexión SQL:** La pantalla de **Inicio de Sesión** se muestra limpia; si falla la conexión contra `SrvMagicInfo`, el sistema explica la causa en español y ofrece abrir **Configurar Servidor BD** automáticamente (también disponible en **Mantenedores > Configurar Servidor BD...**).

📄 Verificación detallada y capturas de los 40 formularios en el [README principal](../README.md) y en el [Release v2026.1](https://github.com/barriagada666-collab/Sistema_gestion_Mantencion/releases/tag/v2026.1).
