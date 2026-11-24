# Guía de Despliegue e Instalación

**Sistema de Gestión Departamento Mantención** — Cambiaso Hnos. S.A.C.

---

## 1. Requisitos del Equipo Cliente

| Componente | Requisito (Windows) |
| :--- | :--- |
| **Sistema Operativo** | Windows 10 o Windows 11 (`64 bits`) |
| **Dependencias Previas** | Ninguna (instalador autocontenido con todo lo necesario incluido) |
| **Microsoft Office** | Opcional (exportación Excel y PDF horizontal integrada sin dependencias) |
| **Conectividad** | Acceso a la red corporativa para consultar y registrar datos de la organización |

---

## 2. Verificación de Integridad (SHA-256)

Antes de desplegar en equipos productivos, valide la integridad del instalador descargado comparando su hash con la tabla oficial del Release o `Instalador/checksums_sha256.txt`:

```powershell
# Windows (PowerShell)
Get-FileHash .\Instalador_Sistema_Mantencion_v2026.2.3.exe -Algorithm SHA256
```

---

## 3. Instalación y Actualización en Windows (`64 bits`)

### 3.1 Instalación Interactiva (Asistente en Español)
1. Ejecute `Instalador_Sistema_Mantencion_v<VERSION>.exe`.
2. Revise la reseña de bienvenida e información general del sistema y seleccione la carpeta de destino (por defecto una ruta escribible sin requerir privilegios de administrador).
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
- La configuración personalizada del usuario (almacenada fuera de la carpeta de instalación) se conserva intacta.
- El instalador actualiza automáticamente la versión y registra la nueva **fecha y hora exacta de instalación** visibles desde **Acerca de**.

### 3.4 Desinstalación Limpia
- Desde **Aplicaciones instaladas** de Windows, Menú Inicio (*Desinstalar*) o mediante comando silencioso:
```powershell
"<RutaInstalacion>\unins000.exe" /VERYSILENT /SUPPRESSMSGBOXES /NORESTART
```
- La desinstalación elimina binarios, accesos directos y las claves de registro creadas por el instalador.

---

## 4. Verificación Posterior y Diagnóstico

- **Verificación de Versión:** Al abrir la aplicación, confirme la versión en la esquina inferior derecha (`v2026.2.3`) y abra **Acerca de** en el menú superior para validar versión, arquitectura y marca temporal de instalación.
- **Ajuste de Conexión Corporativa:** Reservado exclusivamente a usuarios con perfil **Administrador** desde **Mantenedores** (genera respaldo automático de la configuración previa).
- **Registros de Diagnóstico:** En caso de incidencias de red o permisos, los registros locales se guardan automáticamente por día dentro del perfil de usuario en `%LOCALAPPDATA%\SistemaMantencion\logs\`.
