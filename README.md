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

El **Sistema de Gestión Departamento Mantención** es una plataforma CMMS / EAM de grado industrial desarrollada sobre **.NET 8 LTS**, diseñada específicamente para la administración, programación cíclica, control operativo, auditoría y análisis estadístico del mantenimiento mecánico y eléctrico en las plantas productivas de **Cambiaso Hnos. S.A.C.**

Digitaliza de extremo a extremo el ciclo de vida de cada intervención técnica a través de **40 formularios unificados** bajo una identidad visual corporativa homogénea (`#025E87`, `#0191B3`, `#66C9D3`, `#0F2D44`, `#DDE7E8`, `#F2F6F6`): desde la detección de fallas imprevistas o la planificación preventiva en Carta Gantt, hasta el control de repuestos, horas de detención, dotación técnica, **filtrado obligatorio por rango de fechas (`Desde` / `Hasta`)** y exportación nativa a Excel (XML SpreadsheetML) y PDF vectorial (`iTextSharp`) sin dependencias de Office ni Crystal Reports en Windows 10/11 y macOS Universal (Apple Silicon ARM64 sin Rosetta 2 + Intel).

---

## 🖼️ Galería Visual (Carrusel Dinámico de los 40 Formularios)

<p align="center">
  <img src="docs/screenshots/carrusel_mockups.gif" alt="Carrusel dinámico completo de los 40 formularios del Sistema de Gestión Mantención v2026.1 LTS" width="900" />
</p>

<details>
<summary>📸 <strong>Ver las 40 capturas individuales en alta resolución (Windows 11 &amp; macOS Universal)</strong></summary>

<br/>

| Formulario (Impar) | Formulario (Par) |
| :---: | :---: |
| **01. `Inicio`** — Splash Corporativo<br/>[<img src="docs/screenshots/01_Inicio.png" width="400" alt="01 Inicio"/>](docs/screenshots/01_Inicio.png) | **02. `Login`** — Inicio de Sesión Limpio<br/>[<img src="docs/screenshots/02_Login.png" width="400" alt="02 Login"/>](docs/screenshots/02_Login.png) |
| **03. `principal`** — Escritorio MDI (Logo y Título)<br/>[<img src="docs/screenshots/03_principal.png" width="400" alt="03 principal"/>](docs/screenshots/03_principal.png) | **04. `FrmConfiguracionServidor`** — Asistente SQL<br/>[<img src="docs/screenshots/04_FrmConfiguracionServidor.png" width="400" alt="04 FrmConfiguracionServidor"/>](docs/screenshots/04_FrmConfiguracionServidor.png) |
| **05. `frm_OT`** — Gestión Órdenes de Trabajo<br/>[<img src="docs/screenshots/05_frm_OT.png" width="400" alt="05 frm_OT"/>](docs/screenshots/05_frm_OT.png) | **06. `FrmDetalleOt`** — Detalle Completo de OT<br/>[<img src="docs/screenshots/06_FrmDetalleOt.png" width="400" alt="06 FrmDetalleOt"/>](docs/screenshots/06_FrmDetalleOt.png) |
| **07. `FrmMp`** — Gestión Mantención Preventiva<br/>[<img src="docs/screenshots/07_FrmMp.png" width="400" alt="07 FrmMp"/>](docs/screenshots/07_FrmMp.png) | **08. `FrmAdminTareasNodo`** — Tareas por Máquina<br/>[<img src="docs/screenshots/08_FrmAdminTareasNodo.png" width="400" alt="08 FrmAdminTareasNodo"/>](docs/screenshots/08_FrmAdminTareasNodo.png) |
| **09. `FrmPlanificarCiclos`** — Planificador Masivo<br/>[<img src="docs/screenshots/09_FrmPlanificarCiclos.png" width="400" alt="09 FrmPlanificarCiclos"/>](docs/screenshots/09_FrmPlanificarCiclos.png) | **10. `FrmInfOT`** — Informe Órdenes de Trabajo<br/>[<img src="docs/screenshots/10_FrmInfOT.png" width="400" alt="10 FrmInfOT"/>](docs/screenshots/10_FrmInfOT.png) |
| **11. `FrmInfOtCR`** — Visor Nativo PDF/Impresión<br/>[<img src="docs/screenshots/11_FrmInfOtCR.png" width="400" alt="11 FrmInfOtCR"/>](docs/screenshots/11_FrmInfOtCR.png) | **12. `FrmInfMantPrev`** — Informe MP Individual<br/>[<img src="docs/screenshots/12_FrmInfMantPrev.png" width="400" alt="12 FrmInfMantPrev"/>](docs/screenshots/12_FrmInfMantPrev.png) |
| **13. `FrmInfMantPrevCiclosMaq`** — Ciclos Varias Máquinas<br/>[<img src="docs/screenshots/13_FrmInfMantPrevCiclosMaq.png" width="400" alt="13 FrmInfMantPrevCiclosMaq"/>](docs/screenshots/13_FrmInfMantPrevCiclosMaq.png) | **14. `FrmCartaGantt`** — Carta Gantt Preventiva<br/>[<img src="docs/screenshots/14_FrmCartaGantt.png" width="400" alt="14 FrmCartaGantt"/>](docs/screenshots/14_FrmCartaGantt.png) |
| **15. `FrmResumenes`** — Estadísticas &amp; 6 KPIs<br/>[<img src="docs/screenshots/15_FrmResumenes.png" width="400" alt="15 FrmResumenes"/>](docs/screenshots/15_FrmResumenes.png) | **16. `FrmDetalleOTDia`** — Detalle OT Por Día<br/>[<img src="docs/screenshots/16_FrmDetalleOTDia.png" width="400" alt="16 FrmDetalleOTDia"/>](docs/screenshots/16_FrmDetalleOTDia.png) |
| **17. `FrmDetalleOTPorTecnico`** — Detalle Por Técnico<br/>[<img src="docs/screenshots/17_FrmDetalleOTPorTecnico.png" width="400" alt="17 FrmDetalleOTPorTecnico"/>](docs/screenshots/17_FrmDetalleOTPorTecnico.png) | **18. `FrmDetalleOtEstado`** — Detalle Por Estado<br/>[<img src="docs/screenshots/18_FrmDetalleOtEstado.png" width="400" alt="18 FrmDetalleOtEstado"/>](docs/screenshots/18_FrmDetalleOtEstado.png) |
| **19. `FrmDetalleOtPendientes`** — Detalle Pendientes<br/>[<img src="docs/screenshots/19_FrmDetalleOtPendientes.png" width="400" alt="19 FrmDetalleOtPendientes"/>](docs/screenshots/19_FrmDetalleOtPendientes.png) | **20. `FrmDetalleOtTipoFalla`** — Detalle Por Falla<br/>[<img src="docs/screenshots/20_FrmDetalleOtTipoFalla.png" width="400" alt="20 FrmDetalleOtTipoFalla"/>](docs/screenshots/20_FrmDetalleOtTipoFalla.png) |
| **21. `FrmDetalleOtTurno`** — Detalle Por Turno<br/>[<img src="docs/screenshots/21_FrmDetalleOtTurno.png" width="400" alt="21 FrmDetalleOtTurno"/>](docs/screenshots/21_FrmDetalleOtTurno.png) | **22. `FrmAdminNodos`** — Mantenedor de Nodos<br/>[<img src="docs/screenshots/22_FrmAdminNodos.png" width="400" alt="22 FrmAdminNodos"/>](docs/screenshots/22_FrmAdminNodos.png) |
| **23. `FrmDatosTecnicos`** — Catálogo Datos Técnicos<br/>[<img src="docs/screenshots/23_FrmDatosTecnicos.png" width="400" alt="23 FrmDatosTecnicos"/>](docs/screenshots/23_FrmDatosTecnicos.png) | **24. `FrmDatosTecnicosNodo`** — Fichas por Máquina<br/>[<img src="docs/screenshots/24_FrmDatosTecnicosNodo.png" width="400" alt="24 FrmDatosTecnicosNodo"/>](docs/screenshots/24_FrmDatosTecnicosNodo.png) |
| **25. `FrmVerDatosTecnicos`** — Modal Ficha Técnica<br/>[<img src="docs/screenshots/25_FrmVerDatosTecnicos.png" width="400" alt="25 FrmVerDatosTecnicos"/>](docs/screenshots/25_FrmVerDatosTecnicos.png) | **26. `FrmPersonal`** — Gestión de Personal<br/>[<img src="docs/screenshots/26_FrmPersonal.png" width="400" alt="26 FrmPersonal"/>](docs/screenshots/26_FrmPersonal.png) |
| **27. `FrmCalendarioTurno`** — Calendario de Turnos<br/>[<img src="docs/screenshots/27_FrmCalendarioTurno.png" width="400" alt="27 FrmCalendarioTurno"/>](docs/screenshots/27_FrmCalendarioTurno.png) | **28. `FrmCargo`** — Administración de Cargos<br/>[<img src="docs/screenshots/28_FrmCargo.png" width="400" alt="28 FrmCargo"/>](docs/screenshots/28_FrmCargo.png) |
| **29. `FrmPlantas`** — Mantenedor de Plantas<br/>[<img src="docs/screenshots/29_FrmPlantas.png" width="400" alt="29 FrmPlantas"/>](docs/screenshots/29_FrmPlantas.png) | **30. `FrmSeccion`** — Mantenedor de Secciones<br/>[<img src="docs/screenshots/30_FrmSeccion.png" width="400" alt="30 FrmSeccion"/>](docs/screenshots/30_FrmSeccion.png) |
| **31. `FrmAdminUsuarios`** — Usuarios y Permisos<br/>[<img src="docs/screenshots/31_FrmAdminUsuarios.png" width="400" alt="31 FrmAdminUsuarios"/>](docs/screenshots/31_FrmAdminUsuarios.png) | **32. `FrmAdminAuditoria`** — Auditoría BD y KPIs<br/>[<img src="docs/screenshots/32_FrmAdminAuditoria.png" width="400" alt="32 FrmAdminAuditoria"/>](docs/screenshots/32_FrmAdminAuditoria.png) |
| **33. `FrmBuscarMp`** — Buscar Mant. Preventiva<br/>[<img src="docs/screenshots/33_FrmBuscarMp.png" width="400" alt="33 FrmBuscarMp"/>](docs/screenshots/33_FrmBuscarMp.png) | **34. `FrmBuscarCiclo`** — Buscar Ciclos MP<br/>[<img src="docs/screenshots/34_FrmBuscarCiclo.png" width="400" alt="34 FrmBuscarCiclo"/>](docs/screenshots/34_FrmBuscarCiclo.png) |
| **35. `FrmBuscarTareasMp`** — Buscar Tareas MP<br/>[<img src="docs/screenshots/35_FrmBuscarTareasMp.png" width="400" alt="35 FrmBuscarTareasMp"/>](docs/screenshots/35_FrmBuscarTareasMp.png) | **36. `FrmBuscarPersonal`** — Buscar Personal<br/>[<img src="docs/screenshots/36_FrmBuscarPersonal.png" width="400" alt="36 FrmBuscarPersonal"/>](docs/screenshots/36_FrmBuscarPersonal.png) |
| **37. `FrmBuscarInsumo`** — Buscar Insumos SAP<br/>[<img src="docs/screenshots/37_FrmBuscarInsumo.png" width="400" alt="37 FrmBuscarInsumo"/>](docs/screenshots/37_FrmBuscarInsumo.png) | **38. `FrmBuscarDatosTecnicos`** — Buscar Datos Técnicos<br/>[<img src="docs/screenshots/38_FrmBuscarDatosTecnicos.png" width="400" alt="38 FrmBuscarDatosTecnicos"/>](docs/screenshots/38_FrmBuscarDatosTecnicos.png) |
| **39. `FrmBuscarPlanta`** — Buscar Planta<br/>[<img src="docs/screenshots/39_FrmBuscarPlanta.png" width="400" alt="39 FrmBuscarPlanta"/>](docs/screenshots/39_FrmBuscarPlanta.png) | **40. `FrmBuscarSeccion`** — Buscar Sección<br/>[<img src="docs/screenshots/40_FrmBuscarSeccion.png" width="400" alt="40 FrmBuscarSeccion"/>](docs/screenshots/40_FrmBuscarSeccion.png) |

</details>

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
* **Configuración Bajo Demanda y desde Menú:** La pantalla **Inicio de Sesión** se mantiene limpia; si ocurre un fallo de conexión SQL, el sistema explica la causa y pregunta automáticamente si desea abrir **Configurar Servidor BD**. También puede ajustarse manualmente una vez dentro desde **Mantenedores > Configurar Servidor BD...**.
* **Mensajes Comprensibles en Español:** Captura automática de excepciones UI/dominio y fallos SQL (p. ej. error 40, red/VPN desconectada, credenciales o permisos), explicando la causa y ofreciendo abrir la configuración SQL en un clic.
* **Registro Persistente para Depuración:** Guarda automáticamente el detalle técnico completo (`errores_yyyyMMdd.log` con depuración a 30 días) en `%LOCALAPPDATA%\SistemaMantencion\logs\`, accesible desde **Mantenedores > Ver Registro de Errores (Logs)...** o desde el botón **Ver Logs**.

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
* **Compilación y generación de compilados/instaladores:**
  ```bash
  # Compilar solución (0 advertencias, 0 errores)
  dotnet build mantencion.sln -c Release

  # Publicar paquete autocontenido Windows x64 / macOS ARM64
  dotnet publish mantencion/mantencion.vbproj -c Release -r win-x64 --self-contained true

  # Empaquetar NuGet (.nupkg)
  dotnet pack mantencion/mantencion.vbproj -c Release -o nupkg
  ```
* **Automatizadores oficiales:**
  * Windows (Inno Setup `LZMA2` ultra): [`automatizadores de instalacion/Compilar_Instalador.ps1`](automatizadores%20de%20instalacion/Compilar_Instalador.ps1)
  * macOS Universal (`.dmg` `ULMO` + `.zip` `-9`, ARM64 sin Rosetta 2 + Intel): [`automatizadores de instalacion/Generar_Instalador_Mac.sh`](automatizadores%20de%20instalacion/Generar_Instalador_Mac.sh)

---

## 📦 Descargas Oficiales e Instaladores (v2026.1 LTS)

> **Nota:** Todos los instaladores y compilaciones son **100% autocontenidos, compactados y libres de dependencias externas (Zero-Dependency)**.

| Plataforma / Compilación | Formato y Descripción del Instalador | Tamaño | Enlace Directo |
| :--- | :--- | :---: | :--- |
| 🪟 **Windows 10 / 11** (`win-x64`) | **`.exe` (Inno Setup `LZMA2`)** — Instalador autocontenido con .NET 8 Desktop, SQL nativo, Excel XML e `iTextSharp` PDF | `41.42 MB` | [⬇️ **Descargar Instalador Windows**](https://github.com/barriagada666-collab/Sistema_gestion_Mantencion/releases/download/v2026.1/Instalador_Sistema_Mantencion_v2026.1.exe) |
| 🍏 **macOS Universal Nativo** (Apple Silicon M1–M4 sin Rosetta 2 + Intel) | **`.dmg` (`ULMO LZMA`)** — Imagen macOS con binario Universal (`arm64` + `x86_64`), motores nativos depurados e instalador en 1 clic (`Instalar_en_Mac.command`) | `284.46 MB` | [⬇️ **Descargar Imagen DMG para Mac**](https://github.com/barriagada666-collab/Sistema_gestion_Mantencion/releases/download/v2026.1/Instalador_Sistema_Mantencion_v2026.1_macOS.dmg) |
| 🍏 **macOS Universal Nativo** (Apple Silicon M1–M4 sin Rosetta 2 + Intel) | **`.zip` (`-9`)** — Paquete portátil con `.app` Universal nativo, script instalador y guía HTML | `365.06 MB` | [⬇️ **Descargar Paquete ZIP para Mac**](https://github.com/barriagada666-collab/Sistema_gestion_Mantencion/releases/download/v2026.1/Instalador_Sistema_Mantencion_v2026.1_macOS_Universal.zip) |
| 📦 **GitHub Packages / NuGet** | **`.nupkg`** — Paquete compilado .NET 8 con documentación, ícono y metadatos del ensamblado | `2.18 MB` | [⬇️ **Descargar Paquete NuGet**](https://github.com/barriagada666-collab/Sistema_gestion_Mantencion/releases/download/v2026.1/Sistema.Gestion.Mantencion.2026.1.0.nupkg) |

<details>
<summary>🔐 Verificación de Integridad (SHA-256 oficial en <code>/Instalador</code>)</summary>

| Archivo | SHA-256 |
| :--- | :--- |
| `Instalador_Sistema_Mantencion_v2026.1.exe` | `996035501C3A9B73A38AF29A8FBEF35B8E576D3CBF09DB41702C17096E669080` |
| `Instalador_Sistema_Mantencion_v2026.1_macOS.dmg` | `79632e17d51e903775b33dbcaf8a89ae635f18cc30358da84e34392675d275da` |
| `Instalador_Sistema_Mantencion_v2026.1_macOS_Universal.zip` | `59fd18f35a0485163ffc4eadb8cebbbd862e011faefcbf397943410358b42c17` |
| `Sistema.Gestion.Mantencion.2026.1.0.nupkg` | `fbbb59c558a9cd14de8a432327e9a6c23ddddbfceb1ea6d7fd4768423ea2c468` |

</details>

> 📁 *Todos los binarios, checksums SHA-256 (`checksums_sha256.txt` / `checksums_mac_sha256.txt`) y guía rápida de distribución se sincronizan en [`/Instalador/README.md`](Instalador/README.md).*

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
1. Al iniciar sesión, si ocurre un fallo de conexión o el servidor SQL de su empresa usa otro nombre o IP distinto a `SrvMagicInfo` (frecuente fuera de la red LAN corporativa o en macOS), el sistema explicará la causa y le ofrecerá abrir automáticamente **Configurar Servidor BD**. Una vez dentro del sistema también puede acceder desde **Mantenedores > Configurar Servidor BD...**.
2. Ingrese el Host/IP, Base de Datos y Credenciales.
3. Presione **Probar Conexión** y luego **Guardar y Aplicar**.

---

## 📦 Paquete de Desarrollo (GitHub Packages / NuGet)

Para consumir la biblioteca y componentes del sistema en otros proyectos .NET:

```bash
dotnet add package Sistema.Gestion.Mantencion --version 2026.1.0
```

*Registro oficial:* [GitHub Packages - Sistema.Gestion.Mantencion](https://github.com/users/barriagada666-collab/packages/nuget/package/Sistema.Gestion.Mantencion)

---

## 🌟 Novedades de la Versión 2026.1 LTS

* **🎨 Identidad Visual Corporativa Unificada (`Segoe UI`):** Paleta corporativa oficial (`#025E87`, `#0191B3`, `#66C9D3`, `#0F2D44`, `#DDE7E8`, `#F2F6F6`) aplicada globalmente en los 40 formularios, grillas, menús/barras, botones primarios/secundarios/destructivos y escritorio MDI renovado con logotipo institucional y título centrado.
* **🧩 Iconografía de Botones Normalizada (`16x16`):** Depuración de fotogramas `.ico` sobredimensionados y ajuste automático por código (`NormalizarIconoBoton`) para evitar recortes o superposiciones de iconos sobre textos en formularios y buscadores.
* **🛡️ Configuración SQL Bajo Demanda y Diagnóstico Claro de Errores:** Pantalla de **Inicio de Sesión** limpia; ante fallos SQL, de red/VPN o permisos, explica la causa en español, ofrece abrir **Configurar Servidor BD** en un clic (también disponible desde **Mantenedores > Configurar Servidor BD...**) y registra la bitácora en `%LOCALAPPDATA%\SistemaMantencion\logs\errores_yyyyMMdd.log`.
* **📅 Filtrado Obligatorio por Rango de Fechas en Todos los Informes:** Selección `Desde` / `Hasta` siempre visible, habilitada y validada en OT, Mantención Preventiva, Ciclos por Máquina, Carta Gantt, Resúmenes Estadísticos y Auditoría.
* **📑 Exportación Excel y PDF Sin Dependencias:** Motor nativo SpreadsheetML (`.xls`) y motor vectorial `iTextSharp` (`.pdf`) integrados en todos los informes cuando Microsoft Excel no está presente.
* **⚡ Transiciones MDI y Consultas Optimizadas:** `DoubleBuffered`, `SuspendLayout`/`ResumeLayout`, caché de catálogos, precalentamiento de pool SQL y búsquedas `O(1)` en generación de Carta Gantt.
* **📦 Instaladores Ultra-Compactos y Pipeline CI/CD Node 24:** Depuración automática de ensamblados WPF no utilizados, símbolos `.pdb` y satélites de idiomas extranjeros; compresión `LZMA2` (`Windows`) y `ULMO LZMA` (`macOS`), con compilación y empaquetado verificados con `0` advertencias, `0` errores y `0` annotations.
* **🍏 Soporte Nativo Universal para macOS (Sin Rosetta 2):** Binario Mach-O Universal (`arm64` + `x86_64`) generado en runner `macos-15-intel` con entorno UTF-8 desde el launcher nativo, ejecución 100% nativa ARM64 en Apple Silicon (M1–M4) y motor Intel `x86_64` integrado.

---

<div align="center">

### Cambiaso Hnos. S.A.C. — División de Mantención Industrial
📍 *Virginia Bravo Letelier 777, Placilla de Peñuelas, Valparaíso, Chile*  
👨‍💻 **Desarrollado y mantenido por Boris Arriagada**

</div>
