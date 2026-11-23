<div align="center">

<p align="center">
  <img src="https://raw.githubusercontent.com/barriagada666-collab/Sistema_gestion_Mantencion/main/mantencion/installer_art/cambiaso_logo_nuevo.png" alt="Cambiaso Hnos. S.A.C." width="260" />
</p>

# Sistema de Gestión Departamento Mantención
### Cambiaso Hnos. S.A.C. — División de Mantención Industrial
**Plataforma corporativa para Órdenes de Trabajo (OT), Mantención Preventiva (MP), Carta Gantt y Control de Activos**

[![CI/CD](https://github.com/barriagada666-collab/Sistema_gestion_Mantencion/actions/workflows/build-and-package.yml/badge.svg)](https://github.com/barriagada666-collab/Sistema_gestion_Mantencion/actions/workflows/build-and-package.yml)
[![Versión](https://img.shields.io/badge/Versi%C3%B3n-2026.2.1%20LTS-025E87.svg)](https://github.com/barriagada666-collab/Sistema_gestion_Mantencion/releases/tag/v2026.2.1)
[![Plataformas](https://img.shields.io/badge/Plataformas-Windows%2010%2F11%20%7C%20macOS%20Universal-0191B3.svg)](https://github.com/barriagada666-collab/Sistema_gestion_Mantencion/releases/tag/v2026.2.1)

<p align="center">
  <a href="https://github.com/barriagada666-collab/Sistema_gestion_Mantencion/releases/download/v2026.2.1/Instalador_Sistema_Mantencion_v2026.2.1.exe"><img src="https://img.shields.io/badge/%E2%AC%87%EF%B8%8F_DESCARGAR_WINDOWS-v2026.2.1_LTS-025E87?style=for-the-badge&logo=windows&logoColor=white" alt="Descargar Windows" /></a>&nbsp;
  <a href="https://github.com/barriagada666-collab/Sistema_gestion_Mantencion/releases/download/v2026.2.1/Instalador_Sistema_Mantencion_v2026.2.1_macOS.dmg"><img src="https://img.shields.io/badge/%E2%AC%87%EF%B8%8F_DESCARGAR_MAC_(DMG)-v2026.2.1_Universal-0191B3?style=for-the-badge&logo=apple&logoColor=white" alt="Descargar Mac DMG" /></a>
</p>

</div>

---

## 📌 Descripción del Proyecto

El **Sistema de Gestión Departamento Mantención** es una plataforma corporativa de escritorio desarrollada sobre **Microsoft .NET 8 LTS** para planificar, registrar, ejecutar y controlar las operaciones de mantenimiento correctivo y preventivo de activos industriales en **Cambiaso Hnos. S.A.C.**

---

## ⚙️ Características Principales

- **Órdenes de Trabajo (OT):** Creación, edición, asignación técnica, tiempos de detención, control de insumos/repuestos, OT externas y cierre/anulación controlada por permisos.
- **Mantención Preventiva y Carta Gantt:** Pautas periódicas, programación cíclica masiva, selección por casillas de uno o múltiples ciclos (`Solo Marcados`), búsqueda por **N° Mantención (`N° MP`)**, **ID de Ciclo**, máquina, estado o fecha de inicio, ordenamiento por plan más reciente, vista multi-año con barras en color sólido puro y panel inferior de tareas.
- **Activos, Personal y Turnos:** Catálogo jerárquico de plantas, secciones y equipos con carga acelerada en un único recorrido, fichas técnicas por máquina, gestión de dotación y calendario de turnos.
- **Informes y Exportación Integrada:** Selectores inicializados por defecto al rango **ayer – hoy**, reportes individuales y multi-máquina (incluyendo tareas realizadas y pendientes) y exportación coherente a **Excel** y **PDF horizontal completo** sin dependencias externas.
- **Seguridad, Trazabilidad y Versionado:** Control granular de **21 permisos** por perfil, bitácora de auditoría operativa, configuración de conectividad restringida a administradores, menú **Acerca de** con fecha/hora exacta de instalación, indicador permanente de versión en la esquina inferior derecha y versionado centralizado desde `VERSION.txt`.

---

## 🖼️ Capturas del Sistema

<p align="center">
  <img src="docs/screenshots/carrusel_mockups.gif" alt="Vista general de módulos del Sistema de Gestión Mantención v2026.2.1 LTS" width="880" />
</p>

<details>
<summary>📸 <strong>Ver las 41 capturas individuales (incluyendo Acerca de)</strong></summary>

<br/>

| Vista (Impar) | Vista (Par) |
| :---: | :---: |
| **01.** Pantalla de Arranque Corporativa<br/>[<img src="docs/screenshots/01_Inicio.png" width="400" alt="01"/>](docs/screenshots/01_Inicio.png) | **02.** Inicio de Sesión Corporativo<br/>[<img src="docs/screenshots/02_Login.png" width="400" alt="02"/>](docs/screenshots/02_Login.png) |
| **03.** Escritorio Principal MDI<br/>[<img src="docs/screenshots/03_principal.png" width="400" alt="03"/>](docs/screenshots/03_principal.png) | **04.** Configuración de Servidor BD<br/>[<img src="docs/screenshots/04_FrmConfiguracionServidor.png" width="400" alt="04"/>](docs/screenshots/04_FrmConfiguracionServidor.png) |
| **05.** Gestión de Órdenes de Trabajo<br/>[<img src="docs/screenshots/05_frm_OT.png" width="400" alt="05"/>](docs/screenshots/05_frm_OT.png) | **06.** Detalle Completo de OT<br/>[<img src="docs/screenshots/06_FrmDetalleOt.png" width="400" alt="06"/>](docs/screenshots/06_FrmDetalleOt.png) |
| **07.** Gestión de Mantención Preventiva<br/>[<img src="docs/screenshots/07_FrmMp.png" width="400" alt="07"/>](docs/screenshots/07_FrmMp.png) | **08.** Tareas Preventivas por Máquina<br/>[<img src="docs/screenshots/08_FrmAdminTareasNodo.png" width="400" alt="08"/>](docs/screenshots/08_FrmAdminTareasNodo.png) |
| **09.** Planificador Masivo de Ciclos<br/>[<img src="docs/screenshots/09_FrmPlanificarCiclos.png" width="400" alt="09"/>](docs/screenshots/09_FrmPlanificarCiclos.png) | **10.** Informe de Órdenes de Trabajo<br/>[<img src="docs/screenshots/10_FrmInfOT.png" width="400" alt="10"/>](docs/screenshots/10_FrmInfOT.png) |
| **11.** Visor Nativo y Exportación PDF<br/>[<img src="docs/screenshots/11_FrmInfOtCR.png" width="400" alt="11"/>](docs/screenshots/11_FrmInfOtCR.png) | **12.** Informe de Mantención Preventiva<br/>[<img src="docs/screenshots/12_FrmInfMantPrev.png" width="400" alt="12"/>](docs/screenshots/12_FrmInfMantPrev.png) |
| **13.** Comparativo de Ciclos Multi-Máquina<br/>[<img src="docs/screenshots/13_FrmInfMantPrevCiclosMaq.png" width="400" alt="13"/>](docs/screenshots/13_FrmInfMantPrevCiclosMaq.png) | **14.** Carta Gantt Preventiva<br/>[<img src="docs/screenshots/14_FrmCartaGantt.png" width="400" alt="14"/>](docs/screenshots/14_FrmCartaGantt.png) |
| **15.** Resúmenes y KPIs Estadísticos<br/>[<img src="docs/screenshots/15_FrmResumenes.png" width="400" alt="15"/>](docs/screenshots/15_FrmResumenes.png) | **16.** Detalle OT Por Día<br/>[<img src="docs/screenshots/16_FrmDetalleOTDia.png" width="400" alt="16"/>](docs/screenshots/16_FrmDetalleOTDia.png) |
| **17.** Detalle OT Por Técnico<br/>[<img src="docs/screenshots/17_FrmDetalleOTPorTecnico.png" width="400" alt="17"/>](docs/screenshots/17_FrmDetalleOTPorTecnico.png) | **18.** Detalle OT Por Estado<br/>[<img src="docs/screenshots/18_FrmDetalleOtEstado.png" width="400" alt="18"/>](docs/screenshots/18_FrmDetalleOtEstado.png) |
| **19.** Detalle OTs Pendientes<br/>[<img src="docs/screenshots/19_FrmDetalleOtPendientes.png" width="400" alt="19"/>](docs/screenshots/19_FrmDetalleOtPendientes.png) | **20.** Detalle OT Por Falla<br/>[<img src="docs/screenshots/20_FrmDetalleOtTipoFalla.png" width="400" alt="20"/>](docs/screenshots/20_FrmDetalleOtTipoFalla.png) |
| **21.** Detalle OT Por Turno<br/>[<img src="docs/screenshots/21_FrmDetalleOtTurno.png" width="400" alt="21"/>](docs/screenshots/21_FrmDetalleOtTurno.png) | **22.** Estructura Jerárquica de Activos<br/>[<img src="docs/screenshots/22_FrmAdminNodos.png" width="400" alt="22"/>](docs/screenshots/22_FrmAdminNodos.png) |
| **23.** Catálogo de Datos Técnicos<br/>[<img src="docs/screenshots/23_FrmDatosTecnicos.png" width="400" alt="23"/>](docs/screenshots/23_FrmDatosTecnicos.png) | **24.** Fichas Técnicas por Máquina<br/>[<img src="docs/screenshots/24_FrmDatosTecnicosNodo.png" width="400" alt="24"/>](docs/screenshots/24_FrmDatosTecnicosNodo.png) |
| **25.** Consulta de Ficha Técnica<br/>[<img src="docs/screenshots/25_FrmVerDatosTecnicos.png" width="400" alt="25"/>](docs/screenshots/25_FrmVerDatosTecnicos.png) | **26.** Gestión de Personal Técnico<br/>[<img src="docs/screenshots/26_FrmPersonal.png" width="400" alt="26"/>](docs/screenshots/26_FrmPersonal.png) |
| **27.** Calendario de Turnos<br/>[<img src="docs/screenshots/27_FrmCalendarioTurno.png" width="400" alt="27"/>](docs/screenshots/27_FrmCalendarioTurno.png) | **28.** Administración de Cargos<br/>[<img src="docs/screenshots/28_FrmCargo.png" width="400" alt="28"/>](docs/screenshots/28_FrmCargo.png) |
| **29.** Mantenedor de Plantas<br/>[<img src="docs/screenshots/29_FrmPlantas.png" width="400" alt="29"/>](docs/screenshots/29_FrmPlantas.png) | **30.** Mantenedor de Secciones<br/>[<img src="docs/screenshots/30_FrmSeccion.png" width="400" alt="30"/>](docs/screenshots/30_FrmSeccion.png) |
| **31.** Usuarios, Perfiles y Permisos<br/>[<img src="docs/screenshots/31_FrmAdminUsuarios.png" width="400" alt="31"/>](docs/screenshots/31_FrmAdminUsuarios.png) | **32.** Auditoría de Operaciones<br/>[<img src="docs/screenshots/32_FrmAdminAuditoria.png" width="400" alt="32"/>](docs/screenshots/32_FrmAdminAuditoria.png) |
| **33.** Selector de Mantención Preventiva<br/>[<img src="docs/screenshots/33_FrmBuscarMp.png" width="400" alt="33"/>](docs/screenshots/33_FrmBuscarMp.png) | **34.** Selector de Ciclos MP<br/>[<img src="docs/screenshots/34_FrmBuscarCiclo.png" width="400" alt="34"/>](docs/screenshots/34_FrmBuscarCiclo.png) |
| **35.** Selector de Tareas Preventivas<br/>[<img src="docs/screenshots/35_FrmBuscarTareasMp.png" width="400" alt="35"/>](docs/screenshots/35_FrmBuscarTareasMp.png) | **36.** Selector de Personal<br/>[<img src="docs/screenshots/36_FrmBuscarPersonal.png" width="400" alt="36"/>](docs/screenshots/36_FrmBuscarPersonal.png) |
| **37.** Búsqueda de Insumos y Repuestos<br/>[<img src="docs/screenshots/37_FrmBuscarInsumo.png" width="400" alt="37"/>](docs/screenshots/37_FrmBuscarInsumo.png) | **38.** Selector de Datos Técnicos<br/>[<img src="docs/screenshots/38_FrmBuscarDatosTecnicos.png" width="400" alt="38"/>](docs/screenshots/38_FrmBuscarDatosTecnicos.png) |
| **39.** Selector de Plantas<br/>[<img src="docs/screenshots/39_FrmBuscarPlanta.png" width="400" alt="39"/>](docs/screenshots/39_FrmBuscarPlanta.png) | **40.** Selector de Secciones<br/>[<img src="docs/screenshots/40_FrmBuscarSeccion.png" width="400" alt="40"/>](docs/screenshots/40_FrmBuscarSeccion.png) |
| **41.** Acerca de (Versión y Fecha de Instalación)<br/>[<img src="docs/screenshots/41_FrmAcercaDe.png" width="400" alt="41"/>](docs/screenshots/41_FrmAcercaDe.png) | — |

</details>

---

## 📦 Descargas Oficiales (v2026.2.1 LTS)

> **Autocontenido (Zero-Dependency):** No requiere instalar previamente .NET Runtime, Crystal Reports ni Microsoft Office.

| Plataforma | Instalador | Tamaño | Descarga |
| :--- | :--- | :---: | :--- |
| 🪟 **Windows 10 / 11** (`x64`) | Instalador estándar (`.exe`) | `41.46 MB` | [⬇️ **Descargar Windows (.exe)**](https://github.com/barriagada666-collab/Sistema_gestion_Mantencion/releases/download/v2026.2.1/Instalador_Sistema_Mantencion_v2026.2.1.exe) |
| 🍏 **macOS Universal** (`ARM64` + `Intel`) | Imagen de disco (`.dmg`) | `293.26 MB` | [⬇️ **Descargar macOS (.dmg)**](https://github.com/barriagada666-collab/Sistema_gestion_Mantencion/releases/download/v2026.2.1/Instalador_Sistema_Mantencion_v2026.2.1_macOS.dmg) |
| 🍏 **macOS Universal** (`ARM64` + `Intel`) | Archivo comprimido (`.zip`) | `365.17 MB` | [⬇️ **Descargar macOS (.zip)**](https://github.com/barriagada666-collab/Sistema_gestion_Mantencion/releases/download/v2026.2.1/Instalador_Sistema_Mantencion_v2026.2.1_macOS_Universal.zip) |
| 📦 **NuGet** | Paquete de distribución (`.nupkg`) | `2.23 MB` | [⬇️ **Descargar Paquete (.nupkg)**](https://github.com/barriagada666-collab/Sistema_gestion_Mantencion/releases/download/v2026.2.1/Sistema.Gestion.Mantencion.2026.2.1.nupkg) |

<details>
<summary>🔐 Verificación de Integridad (SHA-256)</summary>

| Archivo | SHA-256 |
| :--- | :--- |
| `Instalador_Sistema_Mantencion_v2026.2.1.exe` | `3460AC839E227C024B9D939512760EA272664B0979E8BCAF8E641225FE79ED2C` |
| `Instalador_Sistema_Mantencion_v2026.2.1_macOS.dmg` | `F25D07531681577FD67B42472A7D5E76029ECD563F44497B9CAE300E29513064` |
| `Instalador_Sistema_Mantencion_v2026.2.1_macOS_Universal.zip` | `042890420F56C3875FC968B3F3899797A910B90B2B8144B5F9BE066FF8B0E9CF` |
| `Sistema.Gestion.Mantencion.2026.2.1.nupkg` | `2BB42980D0110FF95E2F442BFA691426C09DCBE7273D0E627857B3E2A3EB2CE7` |

</details>

---

## 💻 Requisitos e Instalación

### Requisitos
- **Windows:** Windows 10 u 11 de 64 bits (`x64` o compatible).
- **macOS:** macOS 11+ con procesador Apple Silicon (`ARM64`) o `Intel` (`x86_64`).
- **Red:** Acceso a la red corporativa para conectarse al servidor de datos de la organización.

### Instalación
- **Windows:** Descargue y ejecute `Instalador_Sistema_Mantencion_v2026.2.1.exe` y siga el asistente en español (soporta instalación silenciosa `/VERYSILENT /SUPPRESSMSGBOXES /NORESTART` y actualización directa conservando la configuración del usuario).
- **macOS:** Monte `Instalador_Sistema_Mantencion_v2026.2.1_macOS.dmg` (o descomprima el `.zip`) y ejecute `Instalar_en_Mac.command`.

---

## 🛠️ Configuración y Uso

1. Inicie sesión con sus credenciales corporativas habilitadas.
2. Navegue por los módulos desde la barra superior (**Órdenes de Trabajo**, **Mant. Preventiva**, **Informes**, **Mantenedores**, **Control de Eventos**, **Acerca de**).
3. En los filtros por fecha de informes, auditoría y turnos, las fechas se inicializan automáticamente entre **ayer y hoy**.
4. En **Carta Gantt**, marque uno o varios ciclos mediante casillas para enfocar o exportar exactamente su selección, o busque por **N° MP**, **ID Ciclo**, texto o **Estado**.
5. La barra inferior muestra el estado de conexión a la izquierda y la versión activa en la esquina inferior derecha (`v2026.2.1`, clic para abrir **Acerca de** con la fecha y hora exacta de instalación). Los usuarios **Administrador** pueden ajustar la conectividad desde **Mantenedores**.

---

## 📚 Documentación Completa

- 🏗️ [Documentación Técnica y Arquitectura](docs/ARQUITECTURA_TECNICA.md)
- 📘 [Manual Funcional del Usuario](docs/MANUAL_FUNCIONAL.md)
- 🛠️ [Guía de Compilación, Versionado y Pruebas](docs/GUIA_COMPILACION.md)
- 🚀 [Guía de Despliegue e Instalación](docs/GUIA_DESPLIEGUE.md)
- 📦 [Paquetes e Instaladores Oficiales](Instalador/README.md)

---

## 🏷️ Versionado e Historial de Cambios

El proyecto sigue el esquema corporativo `YYYY.M.P LTS` (`v2026.2.1 LTS`), gestionado de forma centralizada desde `VERSION.txt`.  
Consulte el historial completo de versiones, mejoras y correcciones en [CHANGELOG.md](CHANGELOG.md).

---

<div align="center">

## 👷 Créditos

**Cambiaso Hnos. S.A.C. — División de Mantención Industrial**  
Desarrollado y mantenido por **Boris Arriagada**

</div>
