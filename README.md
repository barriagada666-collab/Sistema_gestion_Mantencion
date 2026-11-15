<div align="center">

<p align="center">
  <img src="https://raw.githubusercontent.com/barriagada666-collab/Sistema_gestion_Mantencion/main/mantencion/img/cambiaso_logo_nuevo.png" alt="Cambiaso Hnos. S.A.C." width="290" />
</p>

# Sistema de Gestión Departamento Mantención
### Cambiaso Hnos. S.A.C. — División de Mantención Industrial
**Plataforma Integral de Órdenes de Trabajo (OT), Mantención Preventiva (MP) y Control Técnico**

[![CI/CD](https://github.com/barriagada666-collab/Sistema_gestion_Mantencion/actions/workflows/build-and-package.yml/badge.svg)](https://github.com/barriagada666-collab/Sistema_gestion_Mantencion/actions/workflows/build-and-package.yml)
[![Versión](https://img.shields.io/badge/Versi%C3%B3n-2026.1%20LTS-025E87.svg)](https://github.com/barriagada666-collab/Sistema_gestion_Mantencion/releases)
[![Plataformas](https://img.shields.io/badge/Plataformas-Windows%20%7C%20macOS-0e705b.svg)](https://github.com/barriagada666-collab/Sistema_gestion_Mantencion/releases)
[![.NET](https://img.shields.io/badge/.NET-8.0%20LTS-512BD4.svg?logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![Base de Datos](https://img.shields.io/badge/SQL_Server-2008--2022-CC292B.svg?logo=microsoftsqlserver&logoColor=white)](https://www.microsoft.com/sql-server)
[![Autor](https://img.shields.io/badge/Desarrollado%20por-Boris%20Arriagada-025E87.svg?logo=github&logoColor=white)](https://github.com/barriagada666-collab)

<p align="center">
  <a href="https://github.com/barriagada666-collab/Sistema_gestion_Mantencion/releases/download/v2026.1/Instalador_Sistema_Mantencion_v2026.1.exe"><img src="https://img.shields.io/badge/%E2%AC%87%EF%B8%8F_DESCARGAR_WINDOWS-v2026.1_LTS_(55.5_MB)-025E87?style=for-the-badge&logo=windows&logoColor=white" alt="Descargar Windows" /></a>&nbsp;
  <a href="https://github.com/barriagada666-collab/Sistema_gestion_Mantencion/releases/download/v2026.1/Instalador_Sistema_Mantencion_v2026.1_macOS.dmg"><img src="https://img.shields.io/badge/%E2%AC%87%EF%B8%8F_DESCARGAR_MAC_(DMG)-v2026.1_Universal_(92_MB)-0e705b?style=for-the-badge&logo=apple&logoColor=white" alt="Descargar Mac DMG" /></a>
</p>

</div>

---

## 📌 Descripción del Proyecto

El **Sistema de Gestión Departamento Mantención** es una solución informática de clase industrial (CMMS / ERP de Mantenimiento) diseñada específicamente para la administración, programación, control operativo y análisis estadístico del mantenimiento mecánico y eléctrico en las plantas productivas de **Cambiaso Hnos. S.A.C.**

Permite digitalizar el ciclo de vida completo de las intervenciones técnicas en planta: desde la detección de una falla imprevista o la planificación cíclica de mantenciones preventivas, hasta el registro de repuestos, tiempos de detención, personal técnico asignado y reportabilidad ejecutiva para la toma de decisiones.

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
* **Carta Gantt Interactiva:** Visualización gráfica temporal de las intervenciones preventivas programadas por línea y equipo.
* **Planificador de Ciclos:** Despliegue de ciclos futuros con reprogramación automática.

### 🏭 3. Estructura Jerárquica de Activos (Nodos de Planta)
* **Árbol de Equipos:** Navegación arbórea multinivel estructurada en `Empresa > Planta > Sección > Máquina > Módulo > Componente`.
* **Fichas Técnicas:** Catálogo de especificaciones técnicas (potencias, rodamientos, voltajes, presiones y manuales asociados).

### 👥 4. Dotación de Personal y Calendario de Turnos
* **Ficha del Personal:** Administración de técnicos mecánicos, electricistas y supervisores con sus especialidades.
* **Programación de Turnos:** Generación dinámica de calendarios de turnos rotativos para control de dotación disponible en planta.

### 📊 5. Estadísticas, Informes y Exportación
* **Tableros de Control:** Resúmenes estadísticos interactivos de OTs por técnico, por tipo de falla, por turno y por día.
* **Exportación Nativa a Excel:** Informes directos en formato `.xls` utilizando las plantillas institucionales de Cambiaso Hnos.
* **Visor Nativo de Informes y PDF:** Generación y previsualización de informes con exportación directa a PDF (mediante iTextSharp, sin requerir Crystal Reports ni software de terceros).

### 🔐 6. Auditoría Integral y Seguridad
* **Trazabilidad en Tiempo Real:** Registro detallado de cada operación (altas, bajas, modificaciones) con usuario, fecha, hora, equipo (PC) y tabla afectada.
* **Matriz de Permisos:** Control de acceso granular por perfiles de usuario a cada módulo del sistema.

### ⚡ 7. Asistente de Configuración de Servidor SQL
* **Módulo Integrado:** Permite cambiar el servidor SQL Server, base de datos, credenciales y timeout en tiempo de ejecución.
* **Diagnóstico y Respaldo:** Prueba de conexión instantánea con un clic y respaldo automático de la configuración anterior.

---

## 💻 ¿Qué se necesita para ejecutar el Sistema? (Requisitos)

### 🪟 Para Usuarios en Windows:
* **Sistema Operativo:** Windows 10 o Windows 11 (ediciones de 64 bits).
* **Dependencias:** **Ninguna.** La aplicación está publicada en modo **autocontenido** (.NET 8 Runtime integrado). No requiere instalar runtimes ni software adicional.
* **Red:** Conexión a la red local de la empresa o VPN corporativa para comunicarse con el servidor SQL Server.

### 🍏 Para Usuarios en macOS:
* **Sistema Operativo:** macOS 11 Big Sur hasta macOS 15 Sequoia, **macOS 27 Golden Gate** y **macOS 28+** (futuras versiones sin Rosetta).
* **Hardware:** Binario **Universal Nativo (`arm64` + `x86_64`)** compatible con procesadores **Apple Silicon** (M1, M2, M3, M4 — ejecución **100% nativa ARM64 sin Rosetta 2**) y procesadores **Intel**.
* **Entorno de Ejecución:** **Autocontenido (Cero Dependencias)**. Incluye motor nativo ARM64 (`MetalSharp-Wine v7.0` + `.NET 8 win-arm64`) para Apple Silicon sin alertas de apps Intel, y motor Wine Staging 11.21 + `.NET 8 win-x64` para Macs Intel.
* **Instalación:** Se incluye imagen `.dmg` y paquete `.zip` con instalador automático en un clic (`Instalar_en_Mac.command`) y acceso directo en el Escritorio.

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

> **Nota:** Todos los instaladores son **autocontenidos** (.NET 8 LTS integrado) y listos para ejecutar.

| Plataforma | Formato | Tamaño | Enlace Directo |
| :--- | :---: | :---: | :--- |
| 🪟 **Windows 10 / 11** (64-bit) | `.exe` | 55.5 MB | [⬇️ **Descargar Instalador Windows**](https://github.com/barriagada666-collab/Sistema_gestion_Mantencion/releases/download/v2026.1/Instalador_Sistema_Mantencion_v2026.1.exe) |
| 🍏 **macOS Universal** (M1–M4 / Intel) | `.dmg` | 192 MB | [⬇️ **Descargar Imagen DMG para Mac**](https://github.com/barriagada666-collab/Sistema_gestion_Mantencion/releases/download/v2026.1/Instalador_Sistema_Mantencion_v2026.1_macOS.dmg) |
| 🍏 **macOS Universal** (M1–M4 / Intel) | `.zip` | 169 MB | [⬇️ **Descargar Paquete ZIP para Mac**](https://github.com/barriagada666-collab/Sistema_gestion_Mantencion/releases/download/v2026.1/Instalador_Sistema_Mantencion_v2026.1_macOS_Universal.zip) |
| 📦 **GitHub Packages** | `.nupkg` | 2.4 MB | [⬇️ **Descargar Paquete NuGet**](https://github.com/barriagada666-collab/Sistema_gestion_Mantencion/releases/download/v2026.1/Sistema.Gestion.Mantencion.2026.1.0.nupkg) |

> 📁 *Todos los archivos binarios de instalación también se encuentran permanentemente archivados en la carpeta [`/Instalador`](https://github.com/barriagada666-collab/Sistema_gestion_Mantencion/tree/main/Instalador) del repositorio.*

<details>
<summary>🔐 <b>Verificación de Integridad (Hashes SHA-256)</b></summary>
<br>

```text
BB8A88FB5FFA051DB6E1294A246EAAAA3377AF8E0E3F91672A81ADB1FAAEB953  Instalador_Sistema_Mantencion_v2026.1.exe
bb9d9bfa0013d66968aa72330b12ac2205fd8a04c18427fc0c88dcf4a7094ef5  Instalador_Sistema_Mantencion_v2026.1_macOS.dmg
c7679ad6dcda6c2691ce8ea434b938d01b7b18029091fd51f5878d2eab9d5348  Instalador_Sistema_Mantencion_v2026.1_macOS_Universal.zip
b47b134a88f7fc8ea4b26d3b6ab0612f865cd6f9e2d33dfaafb1a328c773ff37  Sistema.Gestion.Mantencion.2026.1.0.nupkg
```

</details>

---

## 🚀 Guía de Instalación Rápida

### En Windows:
1. Descargue el archivo `Instalador_Sistema_Mantencion_v2026.1.exe`.
2. Ejecute el instalador y siga el asistente estándar.
3. La aplicación creará automáticamente accesos directos en el **Escritorio** y en el **Menú Inicio**.

### En Mac (macOS):
1. Descargue `Instalador_Sistema_Mantencion_v2026.1_macOS.dmg` (o el paquete `.zip`).
2. **Instalación recomendada:** Haga doble clic en `Instalar_en_Mac.command` para instalar en `/Applications`, optimizar únicamente el motor nativo de su procesador (Apple Silicon ARM64 o Intel), quitar restricciones de Gatekeeper y crear acceso directo en el Escritorio.
3. También puede arrastrar **Sistema de Gestión Mantención** directamente a **Aplicaciones** (ejecuta como **Aplicación Universal** nativa sin Rosetta 2 en Apple Silicon M1–M4 y compatible con macOS 27 Golden Gate y 28+).

### Conexión a Base de Datos en el Primer Inicio:
1. Al iniciar la aplicación, si el servidor SQL de su empresa tiene un nombre o IP diferente al predeterminado (`SrvMagicInfo`), vaya al menú superior:  
   **Herramientas > Configurar Servidor de Base de Datos**.
2. Ingrese el Host, Nombre de Base de Datos y Credenciales.
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

* **🚀 Migración Integral a Microsoft .NET 8 LTS:** Modernización de plataforma con arquitectura de 64 bits (`win-x64` y `win-arm64`), eliminando dependencias obsoletas.
* **🎨 Iconografía Moderna Lucide:** Reemplazo total de la iconografía clásica por gráficos vectoriales de alta resolución de 32 bits con fondo transparente.
* **⚡ Alto Rendimiento y Conexiones SQL:** Precalentamiento de connection pool, consultas indexadas y eliminación de latencias de carga de formularios.
* **📑 Reportabilidad sin Crystal Reports:** Motor nativo de informes con exportación directa a PDF (iTextSharp) y hojas Excel estructuradas.
* **🍏 Soporte Nativo Universal para macOS (Sin Rosetta 2):** Binario Mach-O Universal (`arm64` + `x86_64`) con ejecución 100% nativa en Apple Silicon (M1–M4), eliminando avisos de apps Intel en macOS 27 Golden Gate y garantizando compatibilidad futura con macOS 28+.
* **🛡️ Cero Advertencias y Cero Errores:** Código fuente 100% verificado y validado bajo estándares modernos de compilación.

---

<div align="center">

### Cambiaso Hnos. S.A.C. — División de Mantención Industrial
📍 *Virginia Bravo Letelier 777, Placilla de Peñuelas, Valparaíso, Chile*  
👨‍💻 **Desarrollado y mantenido por Boris Arriagada**

</div>
