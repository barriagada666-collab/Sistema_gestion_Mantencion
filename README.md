# Sistema de Gestión Departamento Mantención

> **Plataforma integral de escritorio para la administración técnica, planificación preventiva, control estadístico y trazabilidad de operaciones de mantenimiento industrial en las plantas productivas de Cambiaso Hnos. S.A.C.**

[![CI/CD - Compilación y Empaquetado](https://github.com/barriagada666-collab/Sistema_gestion_Mantencion/actions/workflows/build-and-package.yml/badge.svg)](https://github.com/barriagada666-collab/Sistema_gestion_Mantencion/actions/workflows/build-and-package.yml)
[![Versión](https://img.shields.io/badge/Versi%C3%B3n-2026.1%20LTS-025E87.svg)](https://github.com/barriagada666-collab/Sistema_gestion_Mantencion)
[![Runtime](https://img.shields.io/badge/Runtime-.NET%208.0%20LTS%20(x64)-0191B3.svg)](https://dotnet.microsoft.com/)
[![Arquitectura](https://img.shields.io/badge/Distribuci%C3%B3n-Autocontenida%20(Zero--Dependency)-107850.svg)](https://github.com/barriagada666-collab/Sistema_gestion_Mantencion)
[![Empresa](https://img.shields.io/badge/Empresa-Cambiaso%20Hnos.%20S.A.C.-B91C1C.svg)](https://www.cambiaso.cl/)

---

## 📋 Descripción General

El **Sistema de Gestión Mantención** es una aplicación cliente-servidor de alto rendimiento diseñada específicamente para coordinar y supervisar todas las actividades de mantenimiento de maquinaria e infraestructura fabril en **Cambiaso Hnos. S.A.C.**

Migrada y optimizada a **Microsoft .NET 8 LTS (Windows x64)** en modalidad **Autocontenida (Self-Contained)**, la aplicación no depende de componentes externos, runtimes previos de Windows ni descargas de internet en los equipos cliente, ofreciendo máxima estabilidad operativa en entornos industriales.

---

## 🚀 Módulos del Sistema

1. **Gestión de Órdenes de Trabajo (OT):**
   - Emisión, clasificación técnica (correctivas, programadas, preventivas) y asignación de personal técnico.
   - Registro de síntomas de falla, causas de detención de línea, horas de parada y control de insumos/repuestos.
   - Generación autónoma de informes técnicos vectoriales de alta resolución en formato PDF.

2. **Mantenimiento Preventivo (MP):**
   - Planificación periódica por ciclos de operación y horómetros de maquinaria.
   - Seguimiento riguroso de pautas técnicas preventivas y programación automática por equipo.

3. **Informes Estadísticos y Gráficos Jerárquicos:**
   - Análisis recursivo multinivel de incidentes por Planta, Sección, Máquina y Componente.
   - Cálculo automático de MTBF, MTTR, ranking de fallas más comunes y rendimiento de técnicos.

4. **Carta Gantt y Planificación Operativa:**
   - Visualización cronológica de intervenciones y cronogramas de mantenimiento preventivo.
   - Exportación interactiva y directa a planillas institucionales de Microsoft Excel.

5. **Auditoría de Operaciones y Seguridad:**
   - Registro exhaustivo y trazabilidad de eventos por sesión, fecha, estación de trabajo (PC) y tabla de BD.
   - Filtrado dinámico en memoria en tiempo real, barra ejecutiva de KPIs y desglose estadístico interactivo.
   - Exportación personalizada a Excel (por registros filtrados o selección de filas) con hoja anexa de resumen estadístico.

6. **Mantenedores Centralizados de Activos y Configuración:**
   - Estructuración jerárquica de activos, secciones, máquinas, componentes y turnos.
   - **Módulo de Configuración de Servidor en Caliente:** Permite alternar la conexión a SQL Server en tiempo de ejecución con validación en vivo y doble respaldo inmutable de configuración.

---

## 🛠️ Stack Tecnológico

| Capa / Componente | Tecnología | Detalle |
| :--- | :--- | :--- |
| **Lenguaje** | Visual Basic .NET 16+ | Sintaxis moderna orientada a objetos en .NET 8. |
| **Framework / SDK** | Microsoft .NET 8.0 LTS (`net8.0-windows`) | SDK-Style (`Microsoft.NET.Sdk`) con soporte Windows Forms. |
| **Arquitectura de Ejecución** | Windows x64 (AMD64 / ARM64 compatible) | Compilación nativa de 64 bits con CoreCLR embebido. |
| **Base de Datos** | Microsoft SQL Server | Servidor corporativo `SrvMagicInfo` (configurable dinámicamente). |
| **Acceso a Datos** | `System.Data.SqlClient` v4.8.6 | Conexión optimizada con biblioteca nativa `sni.dll` x64. |
| **Configuración** | `System.Configuration.ConfigurationManager` v8.0.1 | Lectura y actualización segura de cadenas de conexión en caliente. |
| **Automatización Excel** | `Microsoft.Office.Interop.Excel` v15.0.4795.1001 | Escritura matricial 2D en bloque ultrarrápida y cierre seguro de procesos COM. |
| **Generación PDF** | `iTextSharp.LGPLv2.Core` v3.4.22 + `SkiaSharp` | Renderizado vectorial sin dependencias de Acrobat. |
| **Empaquetado e Instalador** | Inno Setup 6.7.3 | Compresión sólida Ultra LZMA2, Zero-Dependency. |
| **Pipeline CI/CD** | GitHub Actions (`windows-latest`) | Compilación limpia, tests, empaquetado y publicación de artefactos. |

---

## 📂 Estructura del Proyecto

```text
Sistema_gestion_Mantencion/
├── .github/
│   └── workflows/
│       └── build-and-package.yml   # Pipeline CI/CD GitHub Actions
├── Instalador/
│   ├── Instalador_Sistema_Mantencion_v2026.1.exe  # Instalador distribuible autocontenido
│   └── checksums_sha256.txt                       # Verificación criptográfica SHA-256
├── mantencion/
│   ├── class/                      # Capa de negocio, datos y utilidades
│   │   ├── Auditoria.vb            # Lógica de auditoría y consultas
│   │   ├── Conexion.vb             # Conexión centralizada a SQL Server
│   │   ├── FormatoGrillas.vb       # Estilo corporativo y configuración de DataGridViews
│   │   ├── Informes.vb             # Motor de reportes Excel y exportación
│   │   ├── MenuCorporativoRenderer.vb # Renderizador personalizado de MenuStrip
│   │   ├── OT.vb, Nodo.vb, ...     # Entidades de dominio
│   │   └── Utilitarios.vb          # Métodos globales, temas y optimización COM
│   ├── forms/                      # Formularios de interfaz de usuario (WinForms)
│   │   ├── FrmAdminAuditoria.vb    # Módulo de auditoría con filtros y KPIs
│   │   ├── FrmConfiguracionServidor.vb # Configurador de servidor BD en caliente
│   │   ├── frm_OT.vb               # Gestión de Órdenes de Trabajo
│   │   ├── FrmResumenes.vb         # Tableros estadísticos y de cumplimiento
│   │   └── principal.vb            # Ventana contenedora MDI principal
│   ├── icons/                      # Iconos corporativos (.ico)
│   ├── installer_art/              # Arte y banners para el asistente de instalación
│   ├── plantillas/                 # Plantillas institucionales Excel (.xls)
│   ├── ApplicationEvents.vb        # Manejador global de excepciones no controladas
│   └── mantencion.vbproj           # Archivo de proyecto SDK-Style .NET 8
├── scripts/                        # Scripts auxiliares de desarrollo y pruebas
├── .gitignore                      # Exclusión de artefactos temporales y binarios
├── Compilar_Instalador.bat         # Acceso rápido en terminal para compilación
├── Compilar_Instalador.ps1         # Script de automatización PowerShell
├── InfoSoftware.rtf                # Información y especificaciones del instalador
├── mantencion.sln                  # Archivo de solución Visual Studio
├── README.md                       # Documentación principal del repositorio
└── Setup_Mantencion.iss            # Script de empaquetado para Inno Setup 6
```

---

## ⚙️ Requisitos del Entorno

### Para Estaciones de Producción (Usuarios Finales):
- **Sistema Operativo:** Microsoft Windows 10 (versión 1809 o superior) o Windows 11 de 64 bits (x64).
- **Procesador (CPU):** Procesador de 64 bits a 1.6 GHz o superior (2 núcleos mínimo; recomendado 4 núcleos).
- **Memoria RAM:** 4 GB mínimo (8 GB recomendado).
- **Espacio en Disco:** 350 MB disponibles en unidad `C:\`.
- **Runtimes de Windows:** **Ninguno requerido.** El paquete es 100% autocontenido (incluye .NET 8 LTS CoreCLR y bibliotecas nativas).
- **Conectividad:** Acceso de red local Ethernet / VPN corporativa hacia el servidor SQL `SrvMagicInfo` (puerto TCP 1433).
- **Software Opcional:** Microsoft Office Excel (2013+) para abrir planillas `.xls` exportadas.

### Para Estaciones de Desarrollo:
- **SDK:** Microsoft .NET 8.0 SDK (versión 8.0.100 o superior).
- **IDE:** Visual Studio 2022 (con carga de trabajo *.NET Desktop Development*) o Visual Studio Code con extensión C#/DevKit.
- **Compilador de Instalador:** Inno Setup 6 (`winget install JRSoftware.InnoSetup` o `choco install innosetup`).
- **Shell:** PowerShell 7.0+ (`pwsh`) o Windows PowerShell 5.1 con política de ejecución `RemoteSigned` o `Bypass`.

---

## 🔨 Instrucciones de Compilación

### 1. Compilación Local de la Solución:
```powershell
# Restaurar dependencias NuGet
dotnet restore mantencion.sln

# Compilar en modo Release con 0 errores y 0 advertencias
dotnet build mantencion.sln -c Release --no-restore
```

### 2. Generación del Instalador Autocontenido (Pipeline Local):
Ejecute el script de automatización que compila, publica en modo autocontenido x64, limpia ensamblados satélites innecesarios y empaqueta con Inno Setup:
```powershell
pwsh -ExecutionPolicy Bypass -File .\Compilar_Instalador.ps1
```
*O alternativamente, haga doble clic en `Compilar_Instalador.bat`.*

El instalador final se generará en:
`Instalador\Instalador_Sistema_Mantencion_v2026.1.exe`

---

## ☁️ Integración Continua (CI/CD)

El repositorio cuenta con un flujo de integración continua automatizado mediante **GitHub Actions** en `.github/workflows/build-and-package.yml`.

Por cada `push` o `pull request` en las ramas principales:
1. Provee un runner limpio de `windows-latest`.
2. Restaura paquetes NuGet cacheados.
3. Compila la solución con `TreatWarningsAsErrors`.
4. Publica la versión autocontenida para `win-x64`.
5. Ejecuta Inno Setup 6 en modo headless.
6. Valida la integridad del instalador y calcula su firma criptográfica **SHA-256**.
7. Publica el instalador oficial como artefacto descargable del pipeline.

---

## 🔧 Configuración y Base de Datos

La cadena de conexión base predeterminada hacia SQL Server es:
```text
Data Source=SrvMagicInfo;Initial Catalog=mantencion;User Id=mantencion;Password=cambiaso
```

### Cambio Dinámico de Servidor:
Si requiere conectar la aplicación a un servidor de pruebas, contingencia o dirección IP específica:
1. Inicie la aplicación.
2. Ingrese al menú **Mantenedores -> Configurar Servidor BD...**
3. Ingrese el nuevo Servidor / IP, Catálogo y Credenciales.
4. Presione **Probar Conexión** para validar conectividad en vivo.
5. Al guardar, el sistema realiza un respaldo inmutable automático (`.original.bak`) y un respaldo fechado antes de aplicar los cambios en el archivo `.config`.
6. En caso necesario, presione **Restaurar Predeterminado** para volver a la configuración original de fábrica.

---

## ❓ Solución de Problemas Frecuentes (Troubleshooting)

| Síntoma / Error | Causa Probable | Solución |
| :--- | :--- | :--- |
| **Error al conectar a SQL Server en inicio** | Falta de visibilidad de red hacia `SrvMagicInfo` o puerto 1433 bloqueado. | Verifique conexión a la VPN corporativa o configure la IP del servidor en *Mantenedores -> Configurar Servidor BD...*. |
| **Error al abrir reportes exportados en Excel** | Equipo sin Microsoft Office instalado. | Instale Microsoft Excel o use un visor compatible de archivos `.xls`. La exportación no requiere Excel para crearse, solo para visualizarse. |
| **El instalador no compila localmente** | Falta Inno Setup en el sistema o fuera del PATH. | Instale Inno Setup con `winget install JRSoftware.InnoSetup` o descargue la versión 6 desde [jrsoftware.org](https://jrsoftware.org/). |
| **Advertencias de plataforma CA1416** | Llamadas a APIs específicas de Windows en .NET Core. | El proyecto ya está configurado con `<SupportedOSPlatformVersion>7.0</SupportedOSPlatformVersion>` en el `.vbproj`. |

---

## 📄 Licencia y Derechos de Autor

Software corporativo desarrollado para **Cambiaso Hnos. S.A.C.**  
Todos los derechos reservados © 2026. Prohibida su copia, distribución o reproducción no autorizada.
