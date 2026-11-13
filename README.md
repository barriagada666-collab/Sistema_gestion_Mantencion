<div align="center">

<p align="center">
  <img src="https://raw.githubusercontent.com/barriagada666-collab/Sistema_gestion_Mantencion/main/mantencion/img/cambiaso_logo_nuevo.png" alt="Cambiaso Hnos. S.A.C." width="290" />
</p>

<p align="center">
  <img src="https://raw.githubusercontent.com/barriagada666-collab/Sistema_gestion_Mantencion/main/mantencion/icons/app_icon_rounded.png" alt="Sistema de Gestión Mantención" width="96" />
</p>

# Sistema de Gestión Departamento Mantención
### Plataforma de Administración Técnica, Mantención Preventiva, Control Estadístico y Trazabilidad Operativa

[![CI/CD - Compilación y Empaquetado](https://github.com/barriagada666-collab/Sistema_gestion_Mantencion/actions/workflows/build-and-package.yml/badge.svg)](https://github.com/barriagada666-collab/Sistema_gestion_Mantencion/actions/workflows/build-and-package.yml)
[![Versión](https://img.shields.io/badge/Versi%C3%B3n-2026.1%20LTS-025E87.svg)](https://github.com/barriagada666-collab/Sistema_gestion_Mantencion/releases)
[![Creado por](https://img.shields.io/badge/Creado%20por-Boris%20Arriagada-025E87.svg?logo=github&logoColor=white)](https://github.com/barriagada666-collab)
[![Runtime](https://img.shields.io/badge/Runtime-.NET%208.0%20LTS%20(x64)-512BD4.svg?logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![Distribución](https://img.shields.io/badge/Distribuci%C3%B3n-Autocontenida%20(Zero--Dependency)-107850.svg?logo=windows&logoColor=white)](https://github.com/barriagada666-collab/Sistema_gestion_Mantencion/releases)
[![Empresa](https://img.shields.io/badge/Empresa-Cambiaso%20Hnos.%20S.A.C.-B91C1C.svg)](https://www.cambiaso.cl/)
[![Planta](https://img.shields.io/badge/Planta-Placilla%20de%20Pe%C3%B1uelas%2C%20Valpara%C3%ADso-107850.svg?logo=googlemaps&logoColor=white)](https://maps.google.com/?q=Virginia+Bravo+Letelier+777+Placilla+de+Penuelas+Valparaiso)

<p align="center">
  <a href="https://github.com/barriagada666-collab/Sistema_gestion_Mantencion/releases/download/v2026.1/Instalador_Sistema_Mantencion_v2026.1.exe"><img src="https://img.shields.io/badge/%E2%AC%87%EF%B8%8F_DESCARGAR_INSTALADOR-v2026.1_LTS_(55.8_MB)-025E87?style=for-the-badge&logo=windows&logoColor=white" alt="Descargar Instalador" /></a>&nbsp;
  <a href="https://github.com/barriagada666-collab/Sistema_gestion_Mantencion/releases/tag/v2026.1"><img src="https://img.shields.io/badge/GITHUB_RELEASES-v2026.1-107850?style=for-the-badge&logo=github&logoColor=white" alt="GitHub Releases" /></a>
</p>

</div>

---

## 📋 Descripción Ejecutiva

El **Sistema de Gestión Mantención** es una plataforma corporativa cliente-servidor de alta disponibilidad desarrollada a la medida para centralizar, planificar, auditar y controlar la totalidad de las actividades de mantenimiento industrial de maquinaria, líneas de producción e infraestructura técnica en las plantas de **Cambiaso Hnos. S.A.C.**

Totalmente modernizado a **Microsoft .NET 8 LTS (Windows x64)** en arquitectura **Autocontenida (Self-Contained / Zero-Dependency)**:
* 🚀 **Zero-Dependency:** No requiere la preinstalación del SDK ni de paquetes Runtime de .NET en las estaciones de trabajo cliente.
* 📦 **Independencia Operativa:** El instalador empaqueta el CoreCLR x64, librerías gráficas vectoriales, drivers nativos y dependencias para operar de forma 100% aislada y segura en entornos de planta.
* ⚡ **Alto Rendimiento Industrial:** Arranque instantáneo, dibujo de controles con doble búfer (`DoubleBuffered`) anti-parpadeo, liberación determinista de recursos COM de Office y recolección activa de memoria RAM.
* 🏢 **Identidad Corporativa Unificada:** Incorporación del nuevo logo institucional oficial de Cambiaso Hnos. S.A.C. en la interfaz y en la totalidad de las plantillas de reporte de Microsoft Excel (.xls).

---

## 🧭 Mapa de Arquitectura del Sistema

```
                      ┌─────────────────────────────────────────────────────────┐
                      │        SISTEMA DE GESTIÓN MANTENCIÓN v2026.1            │
                      │                 Cambiaso Hnos. S.A.C.                   │
                      └────────────────────────────┬────────────────────────────┘
                                                   │
         ┌──────────────────────┬──────────────────┴────────────────┬──────────────────────┐
         ▼                      ▼                                   ▼                      ▼
┌──────────────────┐   ┌──────────────────┐               ┌──────────────────┐   ┌──────────────────┐
│ ÓRDENES TRABAJO  │   │   MANTENCIÓN     │               │   INFORMES Y     │   │ ADMINISTRACIÓN Y │
│       (OT)       │   │ PREVENTIVA (MP)  │               │   ESTADÍSTICA    │   │    AUDITORÍA     │
├──────────────────┤   ├──────────────────┤               ├──────────────────┤   ├──────────────────┤
│• Correctivas     │   │• Pautas cíclicas │               │• Cuadro de mando │   │• Matriz permisos │
│• Programadas     │   │• Control horómet.│               │• Tasa de fallas  │   │• KPIs en tiempo  │
│• Asignación pers.│   │• Fichas técnicas │               │• Ranking técnico │   │  real y filtros  │
│• Tiempos parada  │   │• Pendientes vs.  │               │• Carta Gantt     │   │• Servidor en     │
│• Insumos y rep.  │   │  Realizadas      │               │  operativa       │   │  caliente        │
└────────┬─────────┘   └────────┬─────────┘               └────────┬─────────┘   └────────┬─────────┘
         │                      │                                  │                      │
         └──────────────────────┴─────────────────┬────────────────┴──────────────────────┘
                                                  │
                                                  ▼
                      ┌─────────────────────────────────────────────────────────┐
                      │              MOTORES DE SALIDA Y REPORTES               │
                      ├────────────────────────────┬────────────────────────────┤
                      │  Excel (.xls) Matricial 2D │  PDF Vectorial Nativo      │
                      │  • Inserción en bloque     │  • Microsoft Print to PDF  │
                      │  • Cero latencia de celda  │  • ExportAsFixedFormat     │
                      │  • Nuevo logo Cambiaso     │  • Motor iTextSharp        │
                      └────────────────────────────┴────────────────────────────┘
```

---

## 🚀 Módulos Funcionales Detallados

### 1. 📋 Gestión Integral de Órdenes de Trabajo (OT)
* **Emisión y Seguimiento:** Registro estructurado de órdenes correctivas, preventivas y programadas.
* **Trazabilidad de Paradas:** Diagnóstico preciso de síntomas de falla, causas raíz de detención y cronometraje de horas de parada de máquina.
* **Gestión de Recursos:** Asignación de personal técnico calificado, turnos (Mañana, Tarde, Noche) y control de insumos y repuestos utilizados.
* **Doble Motor de Exportación:** Emisión instantánea de reportes en planilla Excel oficial (`inf_ot.xls`) y generación de documentos PDF vectoriales de alta fidelidad.

### 2. 🔄 Planificación de Mantención Preventiva (MP)
* **Programación Sistemática:** Creación y seguimiento de planes de mantenimiento por ciclos operativos, fechas calendario y horómetros.
* **Ejecución y Verificación:** Control estricto de tareas pendientes vs. realizadas por máquina y componente.
* **Fichas Técnicas:** Acceso directo a especificaciones de lubricación, ajustes mecánicos, neumáticos y eléctricos.
* **Plantillas Dedicadas:** Exportación sincronizada a `inf_MP.xls`, `inf_listado_ciclo_mp.xls` e `inf_datos_tecnicos.xls`.

### 3. 📊 Analítica y Cuadros de Mando Estadísticos
* **Desglose Recursivo Multinivel:** Análisis jerárquico de incidentes por **Planta** ➔ **Sección** ➔ **Máquina** ➔ **Nodo / Componente**.
* **Indicadores Operativos:** Cálculo automático de horas de detención, tasa de fallas recurrentes y ranking de rendimiento de personal técnico.
* **Visualización Dinámica:** Tableros de control con alternancia cromática ejecutiva y exportación a `inf_estadistico.xls`.

### 4. 📅 Carta Gantt y Cronogramas Operativos
* **Planificación Visual:** Vista temporal gráfica e interactiva de intervenciones mayores y paradas de planta programadas.
* **Cálculo Inteligente de Días:** Exclusión automática de fines de semana y días no laborables para cálculos de duración real.
* **Exportación Institucional:** Generación automática de cartas Gantt formateadas hacia `InfGantt.xls` e `inf_gantt.xls`.

### 5. 🛡️ Auditoría de Eventos con Métricas en Vivo y Drill-Down
* **Trazabilidad Transaccional Inmutable:** Registro pormenorizado en tiempo real de operaciones críticas (`INSERCIÓN`, `ACTUALIZACIÓN`, `ELIMINACIÓN`).
* **Filtros Dinámicos Multidimensionales:** Búsqueda instantánea en memoria por **Sesión**, **Tipo de Operación**, **Estación PC** y **Tabla de Base de Datos**.
* **6 Tarjetas KPI Interactivas:** Panel de indicadores superiores con cálculo porcentual cuantitativo de operaciones.
* **Navegación Interactiva (*Drill-Down*):** Doble clic en cualquier métrica o resumen para auto-filtrar la grilla al instante.
* **Exportación Avanzada:** Generación a `inf_auditoria.xls` de filas seleccionadas o datos filtrados, con pestaña complementaria **Resumen Estadístico**.

### 6. 👤 Administración de Usuarios y Matriz de Permisos (Rediseño Responsivo v2026.1)
* **Diseño Responsivo Inteligente:** Interfaz reestructurada mediante `TableLayoutPanel` maestro, adaptándose fluidamente tanto a pantallas estándar como a monitores panorámicos de alta resolución (1080p, 2K, 4K) sin dejar espacios vacíos.
* **Grilla Completa de Usuarios:** Expansión al 100% del ancho con anchos óptimos configurados:
  * `RUT`: 95 px (centrado)
  * `Nombre de Usuario`: Columna elástica autoajustable
  * `Contraseña`: 110 px
  * `Perfil`: Columna elástica autoajustable
  * `Estado`: 70 px (centrado)
* **Matriz de Permisos en 4 Columnas Simultáneas:**
  * **Acceso a Módulos** (5 permisos)
  * **Módulo Orden de Trabajo** (5 permisos)
  * **Módulo Mantención Preventiva** (7 permisos)
  * **Módulo Mantenedores** (4 permisos)
  * ✅ **Visualización total sin barras de desplazamiento ni cortes de texto:** Los 7 permisos de Mantención Preventiva y los módulos restantes se muestran completos a simple vista.
  * ✅ **Casillas de verificación centradas** en columnas de 55 px con encabezado capitalizado.
* **Doble Clic Global (`CellDoubleClick`):** Selección completa de fila (`FullRowSelect`) para cargar de inmediato los datos del usuario y sus permisos específicos.

### 7. ⚙️ Jerarquía de Activos Fabriles y Configuración de Servidor
* **Árbol de Nodos:** Jerarquía visual de activos con motor de filtrado en vivo y resaltado suave `#FFE8E8`.
* **Configurador de Servidor en Caliente:** Permite ajustar el servidor SQL, la base de datos y credenciales en caliente sin reiniciar la aplicación, con validación previa de conectividad y respaldo automático inmutable.

---

## 🖨️ Arquitectura de Motores de Exportación

El sistema cuenta con un motor dual de exportación robustecido para trabajar sin fallas en cualquier estación de trabajo:

```
                      ┌──────────────────────────────────────────────┐
                      │          SOLICITUD DE EXPORTACIÓN            │
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
         │ • Nuevo logo Cambiaso │                    ┌─────────────┐ ┌─────────────┐
         └───────────────────────┘                    │ Motor Excel │ │ Motor       │
                                                      │ / Print PDF │ │ iTextSharp  │
                                                      │ Nativo Win  │ │ Vectorial   │
                                                      └─────────────┘ └─────────────┘
```

### Plantillas Oficiales de Reporte (.xls) con Nuevo Logo Institucional:
Todas las plantillas incorporan el logo corporativo oficial de Cambiaso Hnos. S.A.C. y fueron optimizadas con **inserción matricial en bloque 2D** (`Range.Value2 = arrDatos`), reduciendo tiempos de generación de minutos a menos de 1 segundo:

| Plantilla | Descripción Técnica | Dimensiones del Logo | Tipo de Reporte |
| :--- | :--- | :--- | :--- |
| **`inf_ot.xls`** | Detalle de Orden de Trabajo, actividades y repuestos | 118 × 34 pt | Técnico Operativo |
| **`inf_MP.xls`** | Pautas y verificaciones de Mantención Preventiva | 126 × 36 pt (gap 6 pt) | Preventivo Calibrado |
| **`inf_auditoria.xls`** | Registro de auditoría, operaciones y resumen KPI | 136 × 39 pt | Auditoría y Control |
| **`inf_estadistico.xls`** | Horas de parada, fallas recurrentes y personal | 126 × 36 pt | Gerencial Estadístico |
| **`inf_datos_tecnicos.xls`**| Fichas técnicas, lubricación y ajustes de máquina | 126 × 36 pt | Ficha de Activo |
| **`inf_listado_ciclo_mp.xls`**| Matriz de ciclos programados de mantenimiento | 126 × 36 pt | Planificación Cíclica |
| **`InfGantt.xls`** | Carta Gantt operativa principal | 126 × 36 pt | Cronograma Gráfico |
| **`inf_gantt.xls`** | Cronograma Gantt complementario | 126 × 36 pt | Cronograma de Planta |

---

## 🛠️ Stack Tecnológico y Dependencias

| Componente | Tecnología | Versión | Rol en el Sistema |
| :--- | :--- | :--- | :--- |
| **Lenguaje** | Visual Basic .NET | 16.0+ | Sintaxis orientada a objetos moderna y tipado estricto. |
| **Plataforma** | Microsoft .NET | **8.0 LTS** | Runtime CoreCLR x64 de alto rendimiento para Windows Desktop. |
| **UI Framework** | Windows Forms | 8.0 Desktop | Interfaz nativa MDI con renderizado en doble búfer. |
| **Base de Datos** | Microsoft SQL Server | 2012 - 2022 | Motor transaccional relacional corporativo (`SrvMagicInfo`). |
| **Acceso a Datos** | `System.Data.SqlClient` | 4.8.6 | Driver SQL nativo de alta velocidad con `sni.dll` x64 embebido. |
| **Configuración** | `System.Configuration` | 8.0.1 | Gestión y respaldo dinámico de cadenas de conexión. |
| **Automatización Office** | `MicrosoftOfficeCore` | 15.0.0 | Ensamblado PIA `office.dll` para compatibilidad universal con Office 2013-2024 y M365. |
| **Librería Excel** | `Interop.Excel` | 15.0.4795 | Manipulación nativa de hojas de cálculo, celdas y estilos. |
| **Generación PDF** | `iTextSharp.LGPLv2.Core` | 3.4.22 | Motor vectorial independiente para exportar PDF sin depender de Office. |
| **Empaquetado** | Inno Setup | 6.7.3 | Compilador de instalador autocontenido x64 con compresión LZMA2. |
| **CI/CD** | GitHub Actions | Ubuntu / Windows | Pipeline automatizado de compilación, verificación y empaquetado. |

---

## 📂 Estructura del Repositorio

```text
Sistema_gestion_Mantencion/
├── .github/
│   └── workflows/
│       └── build-and-package.yml        # Pipeline CI/CD automatizado en GitHub Actions
├── Instalador/
│   ├── Instalador_Sistema_Mantencion_v2026.1.exe   # Instalador autónomo x64 listo para producción
│   └── checksums_sha256.txt            # Verificación de integridad SHA-256
├── mantencion/
│   ├── class/                           # Lógica de negocio, acceso a datos y utilidades
│   │   ├── Auditoria.vb                 # Consultas, agrupaciones y KPIs de auditoría
│   │   ├── Conexion.vb                  # Conexión SQL Server con desconexión determinista
│   │   ├── FormatoGrillas.vb            # Estilos corporativos y formato de DataGridViews
│   │   ├── Informes.vb                  # Motor de exportación Excel en bloque 2D y PDF
│   │   ├── MantPreventiva.vb            # Gestión de ciclos y pautas preventivas
│   │   ├── MenuCorporativoRenderer.vb   # Renderizador personalizado de Menú Principal
│   │   ├── Nodo.vb                      # Jerarquía de activos fabriles y búsqueda
│   │   ├── OT.vb                        # Lógica de Órdenes de Trabajo y reportes
│   │   ├── Usuario.vb                   # Gestión de usuarios, perfiles y matriz de permisos
│   │   └── Utilitarios.vb               # Autoajuste de columnas, COM cleanup y temas
│   ├── forms/                           # Vistas y formularios WinForms
│   │   ├── FrmAdminAuditoria.vb         # Módulo de auditoría con KPIs y drill-down
│   │   ├── FrmAdminUsuarios.vb          # Administración de usuarios responsiva
│   │   ├── FrmAdminUsuarios.Designer.vb # Layout TableLayoutPanel 4 columnas
│   │   ├── FrmCartaGantt.vb             # Planificador gráfico Gantt
│   │   ├── FrmConfiguracionServidor.vb  # Configurador de servidor en caliente
│   │   ├── FrmInfOT.vb                  # Generación y filtro de informes OT
│   │   ├── FrmInfOtCR.vb                # Visor e impresión vectorial de OT
│   │   ├── FrmResumenes.vb              # Cuadros de mando y estadísticas
│   │   └── principal.vb                 # Contenedor MDI y navegación global
│   ├── icons/                           # Iconos institucionales (.ico y .png)
│   ├── img/                             # Logos corporativos de Cambiaso Hnos. S.A.C.
│   ├── installer_art/                   # Gráficos y banners de Inno Setup
│   ├── lib/                             # Librerías nativas y PIAs (office.dll v15)
│   ├── plantillas/                      # 8 Plantillas oficiales Excel (.xls)
│   ├── ApplicationEvents.vb             # Manejo global de excepciones no controladas
│   └── mantencion.vbproj                # Proyecto SDK-Style .NET 8 LTS
├── automatizadores de instalacion/      # Scripts de compilación, diagnóstico y publicación
│   ├── Compilar_Instalador.bat          # Lanzador directo de compilación (.bat)
│   ├── Compilar_Instalador.ps1          # Automatizador PowerShell .NET 8 + Inno Setup
│   ├── Compilar_Instalador.vbs          # Lanzador VBScript sin consola negra
│   ├── Publicar_Release_GitHub.ps1      # Publicador de instalador en GitHub Releases (API REST)
│   ├── Subir_a_GitHub.ps1               # Sincronización y empuje rápido a GitHub
│   ├── Subir_a_GitHub.vbs               # Lanzador VBScript de sincronización
│   ├── diagnostico_entorno.ps1          # Diagnóstico de conectividad SQL y librerías
│   ├── test_forms.ps1                   # Validación de estados de formularios MDI
│   └── test_mdi_simulation.ps1          # Simulación de arranque de interfaz
├── Setup_Mantencion.iss                 # Script oficial de compilación Inno Setup
├── checksums_sha256.txt                 # Checksums SHA-256 de versiones
└── README.md                            # Documentación técnica y ejecutiva oficial
```

---

## ⚡ Guía de Compilación y Publicación

### Requisitos para el Entorno de Desarrollo:
* **Sistema Operativo:** Windows 10 (1809+) o Windows 11 de 64 bits.
* **SDK:** [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) (x64).
* **Compilador de Instaladores:** [Inno Setup 6.7+](https://jrsoftware.org/isdl.php).

### 1. Compilación de la Solución (Modo Release):
```powershell
dotnet build mantencion/mantencion.vbproj -c Release
```
> Resultado garantizado: **0 Errores, 0 Advertencias.**

### 2. Generación Automatizada del Instalador (.exe):
Ejecuta el automatizador integrado:
```powershell
pwsh -ExecutionPolicy Bypass -File ".\automatizadores de instalacion\Compilar_Instalador.ps1"
```
*O haz doble clic en `automatizadores de instalacion\Compilar_Instalador.bat`.*

El proceso realiza de forma autónoma:
1. Publicación autocontenida de .NET 8 (`win-x64 --self-contained true`).
2. Depuración de ensamblados satélites internacionales para optimizar tamaño.
3. Compilación del instalador ejecutable con Inno Setup y compresión sólida LZMA2.
4. Generación del instalador final en `Instalador\Instalador_Sistema_Mantencion_v2026.1.exe` (`55.8 MB`).

### 3. Publicación Directa a GitHub Releases:
Para actualizar el release oficial y publicar el ejecutable binario en GitHub sin contaminar el repositorio Git:
```powershell
pwsh -ExecutionPolicy Bypass -File ".\automatizadores de instalacion\Publicar_Release_GitHub.ps1"
```

---

## 🔒 Descarga y Verificación de Integridad

| Archivo | Plataforma | Tamaño | Descarga Oficial | Algoritmo | Checksum Oficial (SHA-256) |
| :--- | :--- | :--- | :--- | :--- | :--- |
| **`Instalador_Sistema_Mantencion_v2026.1.exe`** | Windows x64 | **55.8 MB** (58.513.029 bytes) | [⬇️ Descargar Instalador v2026.1 LTS](https://github.com/barriagada666-collab/Sistema_gestion_Mantencion/releases/download/v2026.1/Instalador_Sistema_Mantencion_v2026.1.exe) | SHA-256 | `94E66E46F9BCA4CAF3E4186546BC3BE9BD345E050211034C7BF761D3942319BF` |
| **`checksums_sha256.txt`** | Texto | < 1 KB | [⬇️ Descargar Firma SHA-256](https://github.com/barriagada666-collab/Sistema_gestion_Mantencion/releases/download/v2026.1/checksums_sha256.txt) | SHA-256 | `94E66E46F9BCA4CAF3E4186546BC3BE9BD345E050211034C7BF761D3942319BF` |

### Verificación de Integridad en PowerShell:
```powershell
Get-FileHash -Path ".\Instalador\Instalador_Sistema_Mantencion_v2026.1.exe" -Algorithm SHA256
```
> Valor de coincidencia esperado:  
> `94E66E46F9BCA4CAF3E4186546BC3BE9BD345E050211034C7BF761D3942319BF`

---

<div align="center">

### Cambiaso Hnos. S.A.C. — División de Mantención Industrial
📍 **Virginia Bravo Letelier 777, Placilla de Peñuelas, Valparaíso, Chile**  
👨‍💻 **Creado por Boris Arriagada**

</div>
