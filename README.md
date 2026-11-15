<div align="center">

<p align="center">
  <img src="https://raw.githubusercontent.com/barriagada666-collab/Sistema_gestion_Mantencion/main/mantencion/installer_art/cambiaso_logo_nuevo.png" alt="Cambiaso Hnos. S.A.C." width="290" />
</p>

# Sistema de Gestión Departamento Mantención
### Cambiaso Hnos. S.A.C. — División de Mantención Industrial
**Plataforma Integral de Órdenes de Trabajo (OT), Mantención Preventiva (MP) y Control Técnico**

[![CI/CD](https://github.com/barriagada666-collab/Sistema_gestion_Mantencion/actions/workflows/build-and-package.yml/badge.svg)](https://github.com/barriagada666-collab/Sistema_gestion_Mantencion/actions/workflows/build-and-package.yml)
[![Versión](https://img.shields.io/badge/Versi%C3%B3n-2026.1%20LTS-025E87.svg)](https://github.com/barriagada666-collab/Sistema_gestion_Mantencion/releases)
[![Plataformas](https://img.shields.io/badge/Plataformas-Windows%2010%2F11%20%7C%20macOS%20Universal-0191B3.svg)](https://github.com/barriagada666-collab/Sistema_gestion_Mantencion/releases)
[![.NET](https://img.shields.io/badge/.NET-8.0%20LTS-512BD4.svg?logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![Base de Datos](https://img.shields.io/badge/SQL_Server-2008--2022-CC292B.svg?logo=microsoftsqlserver&logoColor=white)](https://www.microsoft.com/sql-server)
[![Autor](https://img.shields.io/badge/Desarrollado%20por-Boris%20Arriagada-025E87.svg?logo=github&logoColor=white)](https://github.com/barriagada666-collab)

<p align="center">
  <a href="https://github.com/barriagada666-collab/Sistema_gestion_Mantencion/releases/download/v2026.1/Instalador_Sistema_Mantencion_v2026.1.exe"><img src="https://img.shields.io/badge/%E2%AC%87%EF%B8%8F_DESCARGAR_WINDOWS-v2026.1_LTS-025E87?style=for-the-badge&logo=windows&logoColor=white" alt="Descargar Windows" /></a>&nbsp;
  <a href="https://github.com/barriagada666-collab/Sistema_gestion_Mantencion/releases/download/v2026.1/Instalador_Sistema_Mantencion_v2026.1_macOS.dmg"><img src="https://img.shields.io/badge/%E2%AC%87%EF%B8%8F_DESCARGAR_MAC_(DMG)-v2026.1_Universal-0191B3?style=for-the-badge&logo=apple&logoColor=white" alt="Descargar Mac DMG" /></a>
</p>

</div>

---

## 📌 Descripción del Proyecto

El **Sistema de Gestión Departamento Mantención** es una solución informática de clase industrial (CMMS / ERP de Mantenimiento) diseñada específicamente para la administración, programación, control operativo y análisis estadístico del mantenimiento mecánico y eléctrico en las plantas productivas de **Cambiaso Hnos. S.A.C.**

Permite digitalizar el ciclo de vida completo de las intervenciones técnicas en planta: desde la detección de una falla imprevista o la planificación cíclica de mantenciones preventivas, hasta el registro de repuestos, tiempos de detención, personal técnico asignado y reportabilidad ejecutiva con **filtrado universal por rango de fechas** para la toma de decisiones.

---

## ⚙️ ¿Qué hace el Sistema? (Módulos Principales)

### 📋 1. Gestión de Órdenes de Trabajo (OT)
* **Registro y Emisión:** Apertura ágil de órdenes correctivas y programadas asociadas a plantas, secciones y máquinas.
* **Control Operativo:** Tipificación de fallas (mecánicas, eléctricas, operacionales), causas raíz y síntomas detectados.
* **Tiempos y Dotación:** Registro exacto de horas de detención de maquinaria, técnicos asignados y horas-hombre invertidas.
* **Insumos y Repuestos:** Detalle de repuestos utilizados con control de costos y proveedores.

### 🛠️ 2. Mantención Preventiva (MP) y Planificación Cíclica
* **Pautas Preventivas:** Configuración de rutinas preventivas por frecuencia en días o por horas acumuladas de operación.
* **Listas de Chequeo Dinámicas:** Checklists diferenciados para tareas mecánicas y eléctricas con tiempos estándar.
* **Carta Gantt Interactiva:** Visualización gráfica temporal de las intervenciones preventivas programadas por línea, equipo y rango de fechas, con exportación directa a Excel y PDF.
* **Planificador de Ciclos:** Despliegue de ciclos futuros con reprogramación automática.

### 🏭 3. Estructura Jerárquica de Activos (Nodos de Planta)
* **Árbol de Equipos:** Navegación arbórea multinivel estructurada en `Empresa > Planta > Sección > Máquina > Módulo > Componente`.
* **Fichas Técnicas:** Catálogo de especificaciones técnicas (potencias, rodamientos, voltajes, presiones y manuales asociados).

### 👥 4. Dotación de Personal y Calendario de Turnos
* **Ficha del Personal:** Administración de técnicos mecánicos, electricistas y supervisores con sus especialidades.
* **Programación de Turnos:** Generación dinámica de calendarios de turnos rotativos para control de dotación disponible en planta.

### 📊 5. Estadísticas, Informes y Exportación (Cero Dependencias)
* **Filtro Obligatorio por Rango de Fechas (`Desde` / `Hasta`):** Todos los módulos de informes (`Informe OT`, `Mantención Preventiva`, `Ciclos por Máquina`, `Carta Gantt`, `Resúmenes Estadísticos` y `Auditoría`) mantienen siempre activos y validados (`Desde <= Hasta`) los selectores de fecha con inicialización automática del mes en curso.
* **Tableros de Control:** Resúmenes estadísticos interactivos de OTs por técnico, por tipo de falla, por turno y por día.
* **Exportación Dual a Excel (COM + Respaldo Nativo):** Usa plantillas institucionales `.xls` cuando Microsoft Excel está instalado, e incluye un **motor nativo XML SpreadsheetML** para exportar sin depender de Office/Excel en Windows o macOS.
* **Exportación Autónoma a PDF (iTextSharp):** Generación vectorial directa a PDF en todos los módulos de reportes (OT, MP, Ciclos, Carta Gantt, Resúmenes Estadísticos y Auditoría), sin Crystal Reports ni software de terceros.

### 🔐 6. Auditoría Integral y Seguridad
* **Trazabilidad en Tiempo Real:** Registro detallado de cada operación (altas, bajas, modificaciones) con usuario, fecha, hora, equipo (PC) y tabla afectada.
* **Matriz de Permisos:** Control de acceso granular por perfiles de usuario a cada módulo y menú del sistema.

### ⚡ 7. Asistente de Configuración SQL y Diagnóstico de Errores
* **Acceso Directo desde Login y Menú:** Permite ajustar servidor/IP SQL, base de datos, credenciales y timeout desde la pantalla **Inicio de Sesión** (`⚙ Servidor SQL`) o desde **Mantenedores > Configurar Servidor BD...**.
* **Mensajes Comprensibles en Español:** Captura automática de excepciones UI/dominio y fallos SQL (p. ej. error 40, red/VPN desconectada, credenciales o permisos), explicando la causa y ofreciendo abrir la configuración SQL en un clic.
* **Registro Persistente para Depuración:** Guarda automáticamente el detalle técnico completo (`errores_yyyyMMdd.log` con depuración a 30 días) en `%LOCALAPPDATA%\SistemaMantencion\logs\`, accesible desde **Mantenedores > Ver Registro de Errores (Logs)...** o desde el botón **📋 Logs**.

---

## 💻 ¿Qué se necesita para ejecutar el Sistema? (Requisitos)

### 🪟 Para Usuarios en Windows:
* **Sistema Operativo:** Windows 10 o Windows 11 (ediciones de 64 bits).
* **Dependencias:** **Ninguna (Zero-Dependency).** La aplicación está publicada en modo **autocontenido y depurado** (.NET 8 Runtime integrado). No requiere instalar .NET, SQL Client, Crystal Reports ni Microsoft Office.
* **Red:** Conexión a la red local de la empresa o VPN corporativa para comunicarse con el servidor SQL Server.

### 🍏 Para Usuarios en macOS:
* **Sistema Operativo:** macOS 15 Sequoia o superior en Apple Silicon (incluyendo **macOS 27 Golden Gate** y **macOS 28+** sin Rosetta 2), y macOS 11+ en equipos Intel.
* **Hardware:** Binario **Universal Nativo (`arm64` + `x86_64`)** compatible con procesadores **Apple Silicon** (M1, M2, M3, M4 — ejecución **100% nativa ARM64 sin Rosetta 2**) y procesadores **Intel**.
* **Entorno de Ejecución:** **Autocontenido (Cero Dependencias)**. Incluye motor nativo ARM64 (`MetalSharp-Wine v7.0` + `.NET 8 win-arm64`) para Apple Silicon sin alertas de apps Intel, y motor Wine Staging 11.21 + `.NET 8 win-x64` para Macs Intel.
* **Instalación:** Se incluye imagen `.dmg` (compresión LZMA) y paquete `.zip` con instalador automático en un clic (`Instalar_en_Mac.command`), que deja en `/Applications` únicamente el motor nativo de su procesador y crea acceso directo en el Escritorio.

### 🗄️ Para el Servidor de Base de Datos:
* **Motor:** Microsoft SQL Server 2008, 2012, 2014, 2016, 2019, 2022 o Azure SQL Database.
* **Base de Datos:** Instancia con la base de datos `mantencion`.
* **Configuración por defecto:**
  * Host / Servidor: `SrvMagicInfo` (o la IP/nombre configurada en tu red).
  * Catálogo: `mantencion`
  * Usuario: `mantencion`
  * Autenticación: SQL Server Authentication o Windows Integrated Security.

### 🛠️ Para Desarrolladores y Compilación:
* **SDK:** Microsoft .NET 8.0 SDK (`8.0.x` o superior).
* **IDE Recomendado:** Visual Studio 2022 (con carga de trabajo *.NET Desktop Development*) o Visual Studio Code en Linux/macOS.
* **Compilación por consola:**
  ```bash
  dotnet build mantencion.sln -c Release
  ```

---

## 📦 Descargas Oficiales (v2026.1 LTS)

> **Nota:** Todos los instaladores son **autocontenidos, compactados y libres de dependencias externas**.

| Plataforma | Formato | Tamaño | Enlace Directo |
| :--- | :---: | :---: | :--- |
| 🪟 **Windows 10 / 11** (64-bit) | `.exe` | `41.36 MB` | [⬇️ **Descargar Instalador Windows**](https://github.com/barriagada666-collab/Sistema_gestion_Mantencion/releases/download/v2026.1/Instalador_Sistema_Mantencion_v2026.1.exe) |
| 🍏 **macOS Universal Nativo** (M1–M4 sin Rosetta / Intel) | `.dmg` | `272.13 MB` | [⬇️ **Descargar Imagen DMG para Mac**](https://github.com/barriagada666-collab/Sistema_gestion_Mantencion/releases/download/v2026.1/Instalador_Sistema_Mantencion_v2026.1_macOS.dmg) |
| 🍏 **macOS Universal Nativo** (M1–M4 sin Rosetta / Intel) | `.zip` | `344.73 MB` | [⬇️ **Descargar Paquete ZIP para Mac**](https://github.com/barriagada666-collab/Sistema_gestion_Mantencion/releases/download/v2026.1/Instalador_Sistema_Mantencion_v2026.1_macOS_Universal.zip) |
| 📦 **GitHub Packages** | `.nupkg` | `2.00 MB` | [⬇️ **Descargar Paquete NuGet**](https://github.com/barriagada666-collab/Sistema_gestion_Mantencion/releases/download/v2026.1/Sistema.Gestion.Mantencion.2026.1.0.nupkg) |

<details>
<summary>🔐 Verificación de Integridad (SHA-256 oficial en <code>/Instalador</code>)</summary>

| Archivo | SHA-256 |
| :--- | :--- |
| `Instalador_Sistema_Mantencion_v2026.1.exe` | `64A95D53F20BB9ABB61B0BE124A98674C709F291F2D0C143D71B27B6EC68D8A4` |
| `Instalador_Sistema_Mantencion_v2026.1_macOS.dmg` | `f935d84c9846106ce18844ae4e58b457aeb206ee0cd28885e7e8867d099717ce` |
| `Instalador_Sistema_Mantencion_v2026.1_macOS_Universal.zip` | `8d9c510003ab59390e9ab4cb7740ac046b128d0c458be54bc0833a76b9844d6b` |
| `Sistema.Gestion.Mantencion.2026.1.0.nupkg` | `6980ffe58c5d7dca3907f8c36bb5e4e46aa205b17f2bd3da48873c864e509396` |

</details>

> 📁 *Todos los archivos binarios de instalación y sus checksums SHA-256 (`checksums_sha256.txt` y `checksums_mac_sha256.txt`) se sincronizan automáticamente en la carpeta [`/Instalador`](https://github.com/barriagada666-collab/Sistema_gestion_Mantencion/tree/main/Instalador) del repositorio en cada compilación.*

---

## 🚀 Guía de Instalación Rápida

### En Windows:
1. Descargue el archivo `Instalador_Sistema_Mantencion_v2026.1.exe`.
2. Ejecute el instalador y siga el asistente estándar.
3. La aplicación creará automáticamente accesos directos en el **Escritorio** y en el **Menú Inicio**.

### En Mac (macOS):
1. Descargue `Instalador_Sistema_Mantencion_v2026.1_macOS.dmg` (o el paquete `.zip`).
2. **Instalación recomendada:** Haga doble clic en `Instalar_en_Mac.command` para instalar en `/Applications`, conservar únicamente el motor nativo de su procesador (Apple Silicon ARM64 o Intel), quitar restricciones de Gatekeeper y crear acceso directo en el Escritorio.
3. También puede arrastrar la aplicación directamente a **Aplicaciones** (ejecuta como **Aplicación Universal** nativa sin Rosetta 2 en Apple Silicon M1–M4 y es compatible con macOS 27 Golden Gate y 28+).

### Conexión a Base de Datos en el Primer Inicio:
1. Al iniciar la aplicación, si el servidor SQL de su empresa tiene un nombre o IP diferente al predeterminado (`SrvMagicInfo`, frecuente fuera de la red LAN corporativa o en macOS), presione **⚙ Servidor SQL** directamente en la pantalla de **Inicio de Sesión**, o una vez dentro vaya a **Mantenedores > Configurar Servidor BD...**.
2. Ingrese el Host/IP, Base de Datos y Credenciales.
3. Presione **⚡ Probar Conexión** y luego **💾 Guardar y Aplicar**.

---

## 📦 Paquete de Desarrollo (GitHub Packages / NuGet)

Para consumir la biblioteca y componentes del sistema en otros proyectos .NET:

```bash
dotnet add package Sistema.Gestion.Mantencion --version 2026.1.0
```

*Registro oficial:* [GitHub Packages - Sistema.Gestion.Mantencion](https://github.com/users/barriagada666-collab/packages/nuget/package/Sistema.Gestion.Mantencion)

---

## 🌟 Novedades de la Versión 2026.1 LTS

* **🎨 Identidad Visual Corporativa Unificada (`Segoe UI`):** Paleta corporativa oficial (`#025E87`, `#0191B3`, `#66C9D3`, `#E5EBEB`, `#F2F6F6`, `#0F2D44`), renderizador moderno de menús/barras, ajuste automático a pantalla, selectores de fecha ampliados (`106x23`) y botones corregidos en `Inicio de Sesión`.
* **🛡️ Captura Global y Diagnóstico Claro de Errores:** Todos los errores de red SQL Server, consultas y UI se traducen a explicaciones claras en español, ofrecen abrir **Configurar Servidor BD** en un clic y se guardan en `%LOCALAPPDATA%\SistemaMantencion\logs\errores_yyyyMMdd.log` para depuración.
* **📅 Filtrado Obligatorio por Rango de Fechas en Todos los Informes:** Selección `Desde` / `Hasta` siempre visible, habilitada y validada en OT, Mantención Preventiva, Ciclos por Máquina, Carta Gantt, Resúmenes Estadísticos y Auditoría.
* **📑 Exportación Excel y PDF Sin Dependencias:** Motor nativo SpreadsheetML (`.xls`) y motor vectorial iTextSharp (`.pdf`) integrados en todos los informes cuando Microsoft Excel no está presente.
* **⚡ Transiciones MDI y Consultas Optimizadas:** `DoubleBuffered`, `SuspendLayout`/`ResumeLayout`, caché de catálogos, precalentamiento de pool SQL y búsquedas `O(1)` en generación de Carta Gantt.
* **📦 Instaladores Ultra-Compactos:** Depuración automática de ensamblados WPF no utilizados, símbolos de depuración, duplicados de plantillas y satélites de idiomas extranjeros; compresión LZMA2 (`Windows`) y ULMO LZMA (`macOS`).
* **🍏 Soporte Nativo Universal para macOS (Sin Rosetta 2):** Binario Mach-O Universal (`arm64` + `x86_64`) con entorno UTF-8 forzado desde el launcher nativo, ejecución 100% nativa en Apple Silicon (M1–M4), eliminando avisos de apps Intel en macOS 27 Golden Gate y garantizando compatibilidad futura con macOS 28+.
* **🛡️ Cero Advertencias y Cero Errores:** Código fuente 100% verificado, sin archivos huérfanos y validado bajo estándares modernos de compilación.

---

<div align="center">

### Cambiaso Hnos. S.A.C. — División de Mantención Industrial
📍 *Virginia Bravo Letelier 777, Placilla de Peñuelas, Valparaíso, Chile*  
👨‍💻 **Desarrollado y mantenido por Boris Arriagada**

</div>
