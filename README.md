# Sistema de Gestión Departamento Mantención

> **El Sistema de Gestión Mantención es la plataforma integral desarrollada para la administración, planificación, registro y control estadístico de todas las actividades de mantenimiento industrial de Cambiaso Hnos. S.A.C.**

[![Versión](https://img.shields.io/badge/Versi%C3%B3n-2026.1-blue.svg)](https://github.com/barriagada666-collab/Sistema_gestion_Mantencion)
[![Plataforma](https://img.shields.io/badge/Plataforma-.NET%20Framework%204.0%20WinForms-success.svg)](https://github.com/barriagada666-collab/Sistema_gestion_Mantencion)
[![Empresa](https://img.shields.io/badge/Empresa-Cambiaso%20Hnos.%20S.A.C.-gold.svg)](https://github.com/barriagada666-collab/Sistema_gestion_Mantencion)

---

## 📋 Descripción General

Plataforma cliente-servidor para la gestión técnica, operativa y estratégica del Departamento de Mantención industrial de **Cambiaso Hnos. S.A.C.** Permite la trazabilidad total del ciclo de vida de los activos, desde la emisión y ejecución de órdenes de trabajo hasta la planificación preventiva y el análisis jerárquico de fallas por planta, sección, máquina y componente.

---

## 🚀 Módulos Principales

1. **Gestión de Órdenes de Trabajo (OT):**
   - Emisión, asignación de personal técnico, control de insumos y repuestos.
   - Detalle de síntomas, causas, detenciones de planta y cierre técnico.
2. **Mantenimiento Preventivo (MP):**
   - Planificación periódica por frecuencia en horas.
   - Control de ciclos operativos y seguimiento de pautas preventivas por activo.
3. **Informes Estadísticos e Históricos:**
   - Análisis jerárquico recursivo de órdenes por Sección, Máquina y Componente.
   - Ranking de intervenciones por personal técnico, horas de detención y porcentajes de cumplimiento.
4. **Carta Gantt y Planificación:**
   - Visualización temporal de actividades y exportación dinámica a Microsoft Excel.
5. **Mantenedores Generales:**
   - Árbol jerárquico de activos, secciones, catálogo de repuestos e insumos, y administración de usuarios.
6. **Auditoría de Operaciones:**
   - Registro y trazabilidad completa de eventos y acciones de usuario.

---

## 🛠️ Tecnologías y Requisitos

- **Lenguaje:** Visual Basic .NET (VB.NET)
- **Framework:** .NET Framework 4.0 WinForms
- **Base de Datos:** Microsoft SQL Server (`SrvMagicInfo`)
- **Interoperabilidad:** Microsoft Office Interop (Excel y Access) y iTextSharp
- **Instalador:** Inno Setup 6 (Compresión sólida Ultra LZMA2, multi-resolución, soporte institucional)

---

## 📦 Instalación

El ejecutable instalador oficial se encuentra en la carpeta `Instalador/`:
- **Instalador:** `Instalador/Instalador_Sistema_Mantencion_v2026.1.exe`
- **Ruta por defecto:** `C:\Temp\Sistema de Mantencion`
- **Accesos Directos:** Crea automáticamente accesos en el Escritorio y Menú Inicio con el nuevo icono corporativo.

Para compilar la solución y empaquetar el instalador automáticamente:
- Ejecutar [`Compilar_Instalador.vbs`](file:///Compilar_Instalador.vbs) o [`Compilar_Instalador.ps1`](file:///Compilar_Instalador.ps1).

---

*Copyright © Cambiaso Hnos. S.A.C. 2026 - Todos los derechos reservados.*
