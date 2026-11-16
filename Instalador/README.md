# 📦 Instaladores y Paquetes Oficiales — v2026.1 LTS

Todos los binarios de distribución en esta carpeta se sincronizan automáticamente en cada compilación oficial desde GitHub Actions y son **100% autocontenidos (Zero-Dependency)**.

| Archivo | Plataforma | Formato | Tamaño | SHA-256 |
| :--- | :--- | :---: | :---: | :--- |
| `Instalador_Sistema_Mantencion_v2026.1.exe` | **Windows 10 / 11** (`x64`) | Inno Setup (`LZMA2`) | `41.43 MB` | `6FC038CFE26159801D3D0204981C6321E28567EA7FD895D2A3AAC5BCE649593F` |
| `Instalador_Sistema_Mantencion_v2026.1_macOS.dmg` | **macOS Universal** (Apple Silicon ARM64 sin Rosetta 2 + Intel) | Imagen DMG (`ULMO`) | `289.63 MB` | `3b1e56df600a4e0fcbd455665c79df01dd5a7aad525720a364e582b62d099e9a` |
| `Instalador_Sistema_Mantencion_v2026.1_macOS_Universal.zip` | **macOS Universal** (Apple Silicon ARM64 sin Rosetta 2 + Intel) | Archivo ZIP (`-9`) | `365.09 MB` | `72684adfbc8dadc93501153446473f4834e8cf978c69eb2bde72cd5a707a0132` |
| `Sistema.Gestion.Mantencion.2026.1.0.nupkg` | **GitHub Packages / NuGet** | Paquete `.nupkg` | `2.19 MB` | `8ae5de10f85555a9e100e4a4562ad9f9cf140d3bf2093ade6edb8bd637b65f55` |

## 🚀 Instrucciones Rápidas
- **Windows:** Ejecute `Instalador_Sistema_Mantencion_v2026.1.exe`. No requiere .NET Desktop Runtime, Crystal Reports ni Microsoft Office previos.
- **macOS:** Monte el `.dmg` (o descomprima el `.zip`) y ejecute **`Instalar_en_Mac.command`** (1 clic) para copiar a `/Applications`, conservar únicamente el motor nativo de su arquitectura (`arm64` sin Rosetta 2 en M1–M4 o `x86_64` en Intel), eliminar cuarentena Gatekeeper y crear acceso directo en el Escritorio.
- **Conexión SQL:** La pantalla de **Inicio de Sesión** se muestra limpia; si falla la conexión contra `SrvMagicInfo`, el sistema explica la causa en español y ofrece abrir **Configurar Servidor BD** automáticamente (también disponible en **Mantenedores > Configurar Servidor BD...**).

📄 Verificación detallada y capturas de los 40 formularios en el [README principal](../README.md) y en el [Release v2026.1](https://github.com/barriagada666-collab/Sistema_gestion_Mantencion/releases/tag/v2026.1).
