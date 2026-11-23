# Guía de Despliegue e Instalación

**Sistema de Gestión Departamento Mantención** — Cambiaso Hnos. S.A.C.

---

## 1. Requisitos del Equipo Cliente

| Componente | Windows | macOS |
| :--- | :--- | :--- |
| **Sistema Operativo** | Windows 10 / Windows 11 (`64 bits`) | macOS 11+ (Apple Silicon `ARM64` o `Intel`) |
| **Dependencias Previas** | Ninguna (paquete `.NET 8` autocontenido) | Ninguna (paquete universal autocontenido) |
| **Microsoft Office / Crystal Reports** | Opcional (exportación PDF/Excel nativa integrada) | No requerido |
| **Conectividad** | Acceso a la red corporativa para SQL Server | Acceso a la red corporativa para SQL Server |

---

## 2. Verificación de Integridad (SHA-256)

Antes de desplegar en equipos productivos, valide la integridad del instalador descargado comparando su hash con la tabla oficial del Release o `Instalador/checksums_sha256.txt`:

```powershell
# Windows (PowerShell)
Get-FileHash .\Instalador_Sistema_Mantencion_v2026.2.1.exe -Algorithm SHA256
```

```bash
# macOS (Terminal)
shasum -a 256 Instalador_Sistema_Mantencion_v2026.2.1_macOS.dmg
```

---

## 3. Instalación y Actualización en Windows (`x64`)

### 3.1 Instalación Interactiva (Asistente en Español)
1. Ejecute `Instalador_Sistema_Mantencion_v<VERSION>.exe`.
2. Revise la información del producto y seleccione la ruta de destino (por defecto una carpeta escribible sin requerir privilegios de administrador).
3. Opcionalmente marque la creación de acceso directo en el Escritorio y finalice el asistente.

### 3.2 Instalación Desatendida / Despliegue Masivo
```powershell
.\Instalador_Sistema_Mantencion_v<VERSION>.exe /VERYSILENT /SUPPRESSMSGBOXES /NORESTART
```
Para especificar un directorio personalizado:
```powershell
.\Instalador_Sistema_Mantencion_v<VERSION>.exe /VERYSILENT /SUPPRESSMSGBOXES /NORESTART /DIR="C:\Ruta\Destino"
```

### 3.3 Actualización In-Place (Upgrade)
- Ejecute directamente el instalador de la nueva versión sobre el equipo cliente.
- La configuración personalizada de conexión del usuario (almacenada fuera de la carpeta de instalación) se conserva intacta.
- El instalador actualiza automáticamente la versión y la nueva **fecha y hora exacta de instalación** visibles desde **Acerca de**.

### 3.4 Desinstalación Limpia
- Desde **Aplicaciones instaladas** de Windows, Menú Inicio (*Desinstalar*) o mediante comando silencioso:
```powershell
"<RutaInstalacion>\unins000.exe" /VERYSILENT /SUPPRESSMSGBOXES /NORESTART
```
- La desinstalación elimina binarios, accesos directos y las claves de registro creadas por el instalador.

---

## 4. Instalación en macOS Universal (`ARM64` + `Intel`)

1. Monte la imagen `Instalador_Sistema_Mantencion_v<VERSION>_macOS.dmg` (o descomprima el archivo `.zip` universal).
2. Ejecute `Instalar_en_Mac.command` para copiar la aplicación a `/Applications`, optimizarla para su procesador y crear el acceso directo en el Escritorio.

---

## 5. Configuración Post-Despliegue y Diagnóstico

- **Verificación de Versión:** Al abrir la aplicación, confirme la versión en la esquina inferior derecha y abra **Acerca de** en el menú superior para validar versión y marca temporal de instalación.
- **Ajuste de Servidor de Datos:** Exclusivo para usuarios con perfil **Administrador** desde **Mantenedores → Configurar Servidor BD...** (genera respaldo automático de la configuración previa).
- **Registros de Diagnóstico:** En caso de incidencias de red o permisos, los registros locales se guardan automáticamente por día en `%LOCALAPPDATA%\SistemaMantencion\logs\` (accesibles desde **Mantenedores → Ver Registro de Errores**).
