<div align="center">

<img src="mantencion/img/cambiaso_logo_nuevo.png" alt="Cambiaso Hnos. S.A.C." width="280" />
<br />
<img src="mantencion/icons/app_icon_rounded.png" alt="Sistema de Gestión Mantención" width="105" />

# Sistema de Gestión Departamento Mantención
### Plataforma de Administración Técnica, Mantención Preventiva, Control Estadístico y Trazabilidad Operativa

[![CI/CD - Compilación y Empaquetado](https://github.com/barriagada666-collab/Sistema_gestion_Mantencion/actions/workflows/build-and-package.yml/badge.svg)](https://github.com/barriagada666-collab/Sistema_gestion_Mantencion/actions/workflows/build-and-package.yml)
[![Versión](https://img.shields.io/badge/Versi%C3%B3n-2026.1%20LTS-025E87.svg)](https://github.com/barriagada666-collab/Sistema_gestion_Mantencion)
[![Runtime](https://img.shields.io/badge/Runtime-.NET%208.0%20LTS%20(x64)-512BD4.svg?logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![Distribución](https://img.shields.io/badge/Distribuci%C3%B3n-Autocontenida%20(Zero--Dependency)-107850.svg?logo=windows&logoColor=white)](https://github.com/barriagada666-collab/Sistema_gestion_Mantencion)
[![Empresa](https://img.shields.io/badge/Empresa-Cambiaso%20Hnos.%20S.A.C.-B91C1C.svg)](https://www.cambiaso.cl/)

<p align="center">
  <img src="https://img.shields.io/badge/.NET_8.0_LTS-512BD4?style=for-the-badge&logo=dotnet&logoColor=white" alt=".NET 8" />
  <img src="https://img.shields.io/badge/Windows_x64-0078D6?style=for-the-badge&logo=windows&logoColor=white" alt="Windows x64" />
  <img src="https://img.shields.io/badge/SQL_Server-CC292B?style=for-the-badge&logo=microsoftsqlserver&logoColor=white" alt="SQL Server" />
  <img src="https://img.shields.io/badge/Excel_Reports-217346?style=for-the-badge&logo=microsoftexcel&logoColor=white" alt="Excel Reports" />
  <img src="https://img.shields.io/badge/PDF_Vectorial-EC1C24?style=for-the-badge&logo=adobeacrobatreader&logoColor=white" alt="PDF Vectorial" />
  <img src="https://img.shields.io/badge/Inno_Setup_6-025E87?style=for-the-badge&logo=windows&logoColor=white" alt="Inno Setup" />
</p>

</div>

---

## 📋 Descripción General

El **Sistema de Gestión Mantención** es una solución corporativa cliente-servidor de alta disponibilidad desarrollada para centralizar, coordinar y auditar la totalidad de las actividades de mantenimiento de maquinaria, líneas de producción e infraestructura fabril en **Cambiaso Hnos. S.A.C.**

Completamente modernizado a **Microsoft .NET 8 LTS (Windows x64)** en arquitectura **Autocontenida (Self-Contained / Zero-Dependency)**:
- **Cero dependencias externas:** No requiere la preinstalación del SDK ni runtime de .NET en el sistema operativo cliente.
- **Independiente de internet:** El instalador empaqueta el CoreCLR, librerías gráficas, drivers nativos y dependencias para funcionar de forma 100% aislada.
- **Rendimiento Industrial:** Arranque instantáneo, dibujo de controles con doble búfer (`DoubleBuffered`), gestión óptima de memoria RAM y liberación garantizada de recursos COM.

---

## 🚀 Módulos Funcionales

```
                      ┌────────────────────────────────────────┐
                      │    SISTEMA DE GESTIÓN MANTENCIÓN       │
                      │        (Cambiaso Hnos. S.A.C.)         │
                      └──────────────────┬─────────────────────┘
                                         │
     ┌──────────────────┬────────────────┼────────────────┬──────────────────┐
     ▼                  ▼                ▼                ▼                  ▼
┌──────────────┐ ┌──────────────┐ ┌──────────────┐ ┌──────────────┐ ┌────────────────┐
│  ÓRDENES DE  │ │ MANTENCIÓN   │ │ INFORMES Y   │ │ CARTA GANTT  │ │ AUDITORÍA Y    │
│ TRABAJO (OT) │ │ PREVENTIVA   │ │ ESTADÍSTICAS │ │ OPERATIVA    │ │ CONFIGURACIÓN  │
└──────────────┘ └──────────────┘ └──────────────┘ └──────────────┘ └────────────────┘
```

### 1. 📋 Gestión Integral de Órdenes de Trabajo (OT)
* Emisión, clasificación técnica (correctivas, programadas, preventivas) y asignación de técnicos y turnos.
* Control detallado de síntomas de falla, causas de parada, horas de detención y registro de insumos consumidos.
* Exportación con doble motor: Planilla Excel automatizada y reportes vectoriales en PDF de alta fidelidad.

### 2. 🔄 Planificación de Mantenimiento Preventivo (MP)
* Control por ciclos de operación, horómetros y calendarios de maquinaria.
* Ejecución y verificación sistemática de pautas técnicas preventivas.
* Trazabilidad completa de tareas realizadas vs. pendientes por activo.

### 3. 📊 Analítica y Cuadros de Mando Estadísticos
* Análisis recursivo multinivel de incidentes por **Planta**, **Sección**, **Máquina** y **Componente**.
* Cálculo automático de horas de detención, tasas de falla más recurrentes y ranking de personal técnico.
* Tableros dinámicos de cumplimiento operativo.

### 4. 📅 Carta Gantt y Cronogramas Operativos
* Vista temporal interactiva de intervenciones y paradas de planta.
* Visualización gráfica en código de colores corporativos con exclusión de fines de semana.
* Exportación sincronizada hacia plantillas institucionales de Microsoft Excel.

### 5. 🛡️ Auditoría de Operaciones con KPIs y Drill-Down
* Trazabilidad en tiempo real de operaciones de base de datos (`INSERCION`, `ACTUALIZACION`, `ELIMINACION`).
* Filtros dinámicos en memoria por **Sesión**, **Tipo de Operación**, **Estación PC** y **Tabla de BD**.
* Panel superior con 6 tarjetas KPI porcentuales y cuantitativas.
* Navegación interactiva (*drill-down*): doble clic en cualquier métrica para auto-filtrar el detalle.
* Exportación inteligente a Excel (filas seleccionadas o registros filtrados) con pestaña complementaria **Resumen Estadístico**.

### 6. ⚙️ Mantenedores de Activos y Configuración de Servidor
* Jerarquía visual de activos fabriles con búsqueda en vivo y resaltado cromático suave.
* **Configurador de Servidor en Caliente:** Permite modificar servidor SQL, base de datos y credenciales en caliente con test de enlace previo y respaldo automático inmutable de la configuración.

---

## 🖨️ Motores de Exportación de Reportes

El sistema cuenta con una arquitectura de exportación robusta diseñada para operar en cualquier entorno:

```
                  ┌──────────────────────────────────────────────┐
                  │         SOLICITUD DE EXPORTACIÓN             │
                  └──────────────────────┬───────────────────────┘
                                         │
                 ┌───────────────────────┴───────────────────────┐
                 ▼                                               ▼
     ┌───────────────────────┐                       ┌───────────────────────┐
     │  EXPORTACIÓN A EXCEL  │                       │   EXPORTACIÓN A PDF   │
     │   (Formatos .xls)     │                       │    (Formatos .pdf)    │
     └───────────┬───────────┘                       └───────────┬───────────┘
                 │                                               │
     ┌───────────▼───────────┐                       ┌───────────▼───────────┐
     │ Inserción Matricial   │                       │ ¿Microsoft Office     │
     │ 2D en Bloque          │                       │ instalado en cliente? │
     │ • Cero latencia celda │                       └─────┬───────────┬─────┘
     │ • Modo Rápido Excel   │                             │           │
     │ • office.dll v15      │                        [Sí] │           │ [No]
     │ • Cierre seguro COM   │                             ▼           ▼
     └───────────────────────┘                    ┌─────────────┐ ┌─────────────┐
                                                  │ Motor Excel │ │ Motor       │
                                                  │ / Print PDF │ │ iTextSharp  │
                                                  │ Nativo Win  │ │ Vectorial   │
                                                  └─────────────┘ └─────────────┘
```

### Características de Exportación:
- **`office.dll` PIA Embebido:** Incluye ensamblado v15.0.0.0 (`71e9bce111e9429c`) en la raíz del programa, evitando dependencias en la GAC de Windows.
- **Resolución Determinista de Plantillas:** La clase `Utilitarios.CrearLibroDesdePlantilla` localiza automáticamente las plantillas en `{app}` o `{app}\plantillas` sin importar el directorio de trabajo activo.
- **Modo Rápido de Excel:** Desactiva refresco de pantalla, alertas y eventos, forzando cálculo manual durante el vaciado de datos.
- **Cero Procesos Huérfanos:** Cierre forzado y liberación de COM (`Marshal.FinalReleaseComObject`) con compactación de memoria RAM al finalizar.
- **Plantillas Oficiales Soportadas:**
  - `inf_ot.xls` (Informe de Órdenes de Trabajo)
  - `inf_MP.xls` (Informe de Mantención Preventiva)
  - `inf_auditoria.xls` (Control de Eventos y Auditoría)
  - `inf_estadistico.xls` (Estadísticas y Resúmenes)
  - `inf_datos_tecnicos.xls` (Fichas Técnicas de Equipos)
  - `inf_listado_ciclo_mp.xls` (Listado de Ciclos de MP)
  - `InfGantt.xls` y `inf_gantt.xls` (Planificación en Carta Gantt)

---

## 🛠️ Stack Tecnológico

| Componente | Tecnología | Versión | Rol en el Sistema |
| :--- | :--- | :--- | :--- |
| **Lenguaje** | Visual Basic .NET | 16.0+ | Sintaxis orientada a objetos moderna y tipado estricto. |
| **Plataforma** | Microsoft .NET | **8.0 LTS** | Runtime CoreCLR para aplicaciones Windows Desktop. |
| **UI Framework** | Windows Forms | 8.0 Desktop | Interfaz nativa de alto rendimiento con temas ejecutivos. |
| **Base de Datos** | Microsoft SQL Server | 2012 - 2022 | Almacén transaccional corporativo (`SrvMagicInfo`). |
| **Acceso a Datos** | `System.Data.SqlClient` | 4.8.6 | Driver SQL nativo de alta velocidad con `sni.dll` x64. |
| **Configuración** | `System.Configuration` | 8.0.1 | Gestión y respaldo dinámico de cadenas de conexión. |
| **Automatización Office** | `MicrosoftOfficeCore` | 15.0.0 | Ensamblado PIA `office.dll` para compatibilidad universal. |
| **Librería Excel** | `Interop.Excel` | 15.0.4795 | Manipulación nativa de libros, celdas y gráficos. |
| **Generación PDF** | `iTextSharp.LGPLv2.Core` | 3.4.22 | Motor vectorial independiente de generación de documentos. |
| **Empaquetado** | Inno Setup | 6.7.3 | Compilador de instalador autocontenido con compresión LZMA2. |
| **CI/CD** | GitHub Actions | Ubuntu/Windows | Compilación, validación y empaquetado continuo. |

---

## 📂 Estructura del Repositorio

```text
Sistema_gestion_Mantencion/
├── .github/
│   └── workflows/
│       └── build-and-package.yml    # Pipeline CI/CD automatizado en GitHub Actions
├── Instalador/
│   ├── Instalador_Sistema_Mantencion_v2026.1.exe   # Instalador autónomo x64 listo para producción
│   └── checksums_sha256.txt                        # Verificación de integridad SHA-256
├── mantencion/
│   ├── class/                       # Lógica de negocio, acceso a datos y utilidades
│   │   ├── Auditoria.vb             # Consultas y agregaciones de auditoría
│   │   ├── Conexion.vb              # Gestión de conexiones SQL Server
│   │   ├── FormatoGrillas.vb        # Estilos y comportamiento de DataGridViews
│   │   ├── Informes.vb              # Motor de reportes Excel y exportaciones
│   │   ├── MantPreventiva.vb        # Gestión de ciclos y pautas preventivas
│   │   ├── MenuCorporativoRenderer.vb # Renderizador personalizado del Menú Principal
│   │   ├── Nodo.vb                  # Jerarquía del árbol de activos y búsqueda
│   │   ├── OT.vb                    # Lógica de Órdenes de Trabajo y exportación PDF
│   │   └── Utilitarios.vb           # Funciones auxiliares, COM cleanup y temas
│   ├── forms/                       # Vistas y formularios WinForms
│   │   ├── FrmAdminAuditoria.vb     # Módulo de auditoría con KPIs y drill-down
│   │   ├── FrmCartaGantt.vb         # Planificador gráfico Gantt
│   │   ├── FrmConfiguracionServidor.vb # Configurador de servidor en caliente
│   │   ├── FrmInfOT.vb              # Filtro y generación de informes de OT
│   │   ├── FrmInfOtCR.vb            # Visor e impresión vectorial de OT
│   │   ├── FrmResumenes.vb          # Cuadros de mando y estadísticas
│   │   └── principal.vb             # Contenedor MDI y navegación global
│   ├── icons/                       # Iconos institucionales (.ico y .png)
│   ├── img/                         # Logos corporativos de Cambiaso Hnos.
│   ├── installer_art/               # Gráficos y banners del instalador
│   ├── lib/                         # Librerías nativas y PIAs (office.dll v15)
│   ├── plantillas/                  # Plantillas oficiales Excel (.xls)
│   ├── ApplicationEvents.vb         # Manejador global de excepciones no controladas
│   └── mantencion.vbproj            # Proyecto SDK-Style .NET 8
├── scripts/                         # Scripts de validación y automatización
├── Setup_Mantencion.iss             # Script oficial de compilación Inno Setup
├── Compilar_Instalador.ps1          # Automatizador PowerShell de compilación
├── Compilar_Instalador.bat          # Acceso rápido en terminal para compilación
└── README.md                        # Documentación ejecutiva del proyecto
```

---

## ⚡ Guía de Compilación e Instalación

### Requisitos Previos para Desarrollo:
- **Sistema Operativo:** Windows 10 (1809+) o Windows 11 de 64 bits.
- **SDK:** [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) (x64).
- **Compilador de Instalador:** [Inno Setup 6.x](https://jrsoftware.org/isdl.php) (opcional, para compilar el instalador).

### 1. Compilación de la Solución (Modo Release):
```powershell
dotnet build mantencion/mantencion.vbproj -c Release
```
> Resultado esperado: **0 Errores, 0 Advertencias.**

### 2. Generación Automatizada del Instalador (.exe):
Ejecuta el script PowerShell integrado en la raíz del proyecto:
```powershell
pwsh -ExecutionPolicy Bypass -File .\Compilar_Instalador.ps1
```
O simplemente haciendo doble clic en:
```cmd
Compilar_Instalador.bat
```
El script realizará automáticamente:
1. Publicación autocontenida de .NET 8 (`win-x64 --self-contained true`).
2. Depuración de ensamblados satélites internacionales innecesarios para optimizar peso.
3. Compilación del instalador ejecutable con Inno Setup y compresión sólida LZMA2.
4. Generación del instalador final en `Instalador\Instalador_Sistema_Mantencion_v2026.1.exe` (~55.7 MB).

---

## 🔒 Verificación de Integridad del Instalador

| Archivo | Plataforma | Tamaño | Algoritmo | Checksum |
| :--- | :--- | :--- | :--- | :--- |
| `Instalador_Sistema_Mantencion_v2026.1.exe` | Windows x64 | ~55.7 MB | SHA-256 | Ver [checksums_sha256.txt](Instalador/checksums_sha256.txt) |

Para verificar la integridad del instalador descargado en PowerShell:
```powershell
Get-FileHash -Path ".\Instalador\Instalador_Sistema_Mantencion_v2026.1.exe" -Algorithm SHA256
```

---

<div align="center">

**Cambiaso Hnos. S.A.C.** — *División de Mantención Industrial*  
Av. El Salto 5000, Huechuraba, Santiago, Chile.

</div>
