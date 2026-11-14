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
[![Soporte](https://img.shields.io/badge/Plataformas-Windows%20%7C%20macOS%20Universal-0e705b.svg?logo=apple&logoColor=white)](https://github.com/barriagada666-collab/Sistema_gestion_Mantencion/releases)
[![Iconografía](https://img.shields.io/badge/Iconos-Lucide%20Icons%2032--bit%20RGBA-16a34a.svg?logo=lucide&logoColor=white)](https://lucide.dev/)
[![Distribución](https://img.shields.io/badge/Distribuci%C3%B3n-Autocontenida%20(Zero--Dependency)-107850.svg?logo=windows&logoColor=white)](https://github.com/barriagada666-collab/Sistema_gestion_Mantencion/releases)
[![Empresa](https://img.shields.io/badge/Empresa-Cambiaso%20Hnos.%20S.A.C.-B91C1C.svg)](https://www.cambiaso.cl/)

<p align="center">
  <a href="https://github.com/barriagada666-collab/Sistema_gestion_Mantencion/releases/download/v2026.1/Instalador_Sistema_Mantencion_v2026.1.exe"><img src="https://img.shields.io/badge/%E2%AC%87%EF%B8%8F_INSTALADOR_WINDOWS-v2026.1_LTS_(55.5_MB)-025E87?style=for-the-badge&logo=windows&logoColor=white" alt="Descargar Instalador Windows" /></a>&nbsp;
  <a href="https://github.com/barriagada666-collab/Sistema_gestion_Mantencion/releases/download/v2026.1/Instalador_Sistema_Mantencion_v2026.1_macOS.dmg"><img src="https://img.shields.io/badge/%E2%AC%87%EF%B8%8F_INSTALADOR_MAC_(DMG)-v2026.1_Universal_(92_MB)-0e705b?style=for-the-badge&logo=apple&logoColor=white" alt="Descargar Instalador macOS DMG" /></a>&nbsp;
  <a href="https://github.com/barriagada666-collab/Sistema_gestion_Mantencion/releases/tag/v2026.1"><img src="https://img.shields.io/badge/GITHUB_RELEASES-v2026.1-107850?style=for-the-badge&logo=github&logoColor=white" alt="GitHub Releases" /></a>
</p>

</div>

---

## 📋 Descripción Ejecutiva

El **Sistema de Gestión Mantención** es una plataforma corporativa cliente-servidor de alta disponibilidad desarrollada a la medida para centralizar, planificar, auditar y controlar la totalidad de las actividades de mantenimiento industrial de maquinaria, líneas de producción e infraestructura técnica en las plantas de **Cambiaso Hnos. S.A.C.**

Desarrollada sobre **Microsoft .NET 8 LTS** en arquitectura **Autocontenida (Self-Contained / Zero-Dependency)** con soporte nativo de distribución tanto para entornos **Windows (x64)** como para **macOS Universal (Apple Silicon M1/M2/M3/M4 e Intel)**:

* 🚀 **Zero-Dependency:** No requiere la preinstalación del SDK ni de paquetes Runtime de .NET en las estaciones de trabajo cliente.
* 📦 **Independencia Operativa:** Empaqueta CoreCLR x64, librerías gráficas vectoriales, drivers nativos y dependencias para operar de forma 100% aislada y segura en entornos de planta.
* 🎨 **Modernización Integral de Iconos (Lucide Icons):** 100% de la iconografía del sistema actualizada con gráficos vectoriales profesionales con canal alfa de 32-bit (RGBA), eliminando fondos sucios de antiguos JPGs y dithering dentado de GIFs de 256 colores.
* ⚡ **Alto Rendimiento y Conexiones SQL Optimizadas:** Precalentamiento de pool de conexiones SQL, `Packet Size=8192`, `MARS`, caché thread-safe en memoria (`CatalogoCache`) para tablas maestras, dibujo con doble búfer (`DoubleBuffered`) anti-parpadeo y liberación determinista de recursos COM.
* 🍏 **Instalador Universal para macOS (DMG y ZIP):** Paquete nativo `Sistema de Gestión Mantención.app` con icono Retina `.icns` de 1024x1024, lanzador universal y script de instalación de 1 clic `Instalar_en_Mac.command` sin alterar en lo absoluto el código fuente ni los binarios de Windows.
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

## 🎨 Biblioteca de Iconos Modernizados (Lucide Icons 32-bit RGBA)

Se modernizó el 100% de los iconos del sistema adoptando la biblioteca profesional [**Lucide Icons**](https://lucide.dev/), renderizada vectorialmente en alta resolución mediante `@resvg/resvg-js` y `Pillow`:

| Acción / Control | Icono Lucide | Color Semántico | Formato Anterior | Formato Actual |
| :--- | :--- | :--- | :--- | :--- |
| **Eliminar Registro** | `trash-2` | Carmín `#dc2626` | `eliminar.jpg` (Fondo gris sucio) | `eliminar.png` (24x24 RGBA) |
| **Eliminar Fila Grilla** | `trash-2` | Carmín `#dc2626` | `16 (Delete).ico` (16x16 XP) | `16 (Delete).ico` (Multirresolución RGBA) |
| **Quitar Ítem OT** | `minus-circle` | Carmín `#dc2626` | `action_remove.png` (16x16) | `action_remove.png` (16x16 RGBA) |
| **Anular OT** | `ban` | Rojo `#ef4444` | `anular.png` (Baja resolución) | `anular.png` (16x16 y 48x48 RGBA) |
| **Guardar Formulario** | `save` | Esmeralda `#059669` | `guardar.png` | `guardar.png` (24x24 RGBA) |
| **Guardar Línea** | `save` | Esmeralda `#059669` | `guardar_16x16.png` | `guardar_16x16.png` (16x16 RGBA) |
| **Agregar Fila** | `plus-circle` | Verde `#16a34a` | `add.png` | `add.png` (16x16 RGBA) |
| **Nuevo Registro** | `plus-circle` | Verde `#16a34a` | `nuevo.png` | `nuevo.png` (24x24 RGBA) |
| **Nuevo Documento** | `file-plus-2` | Verde `#16a34a` | `nuevo-documento_24x24.png` | `nuevo-documento_24x24.png` (24x24 RGBA) |
| **Nuevo Usuario** | `user-plus` | Azul Real `#2563eb` | `Nuevo_Usuario.gif` (256 colores) | `Nuevo_Usuario.png` (24x24 RGBA) |
| **Agregar Tareas** | `list-plus` | Esmeralda `#059669` | `agregar_tareas.gif` (256 colores) | `agregar_tareas.png` (24x24 RGBA) |
| **Limpiar Formulario** | `rotate-ccw` | Índigo `#4f46e5` | `clear.png` | `clear.png` (24x24 RGBA) |
| **Limpiar Filtros** | `rotate-ccw` | Índigo `#4f46e5` | `16 (Clear).ico` | `16 (Clear).ico` (Multirresolución RGBA) |
| **Buscar / Filtrar** | `search` | Azul Cielo `#0284c7`| `icono_buscar1.png` | `icono_buscar1.png` (24x24 RGBA) |
| **Buscar en Catálogo**| `search` | Azul Cielo `#0284c7`| `icono_buscar.png` | `icono_buscar.png` (30x30 RGBA) |
| **Lupa en Grilla** | `search` | Azul Cielo `#0284c7`| `16 (Find).ico` | `16 (Find).ico` (Multirresolución RGBA) |
| **Salir de Ventana** | `log-out` | Rosa Carmín `#e11d48`| `salir.gif` (Bordes dentados) | `salir.png` (24x24 RGBA) |
| **Cerrar Sesión** | `log-out` | Rojo `#dc2626` | `cerrar-sesion.png` | `cerrar-sesion.png` (24x24 RGBA) |
| **Exportar a Excel** | `file-spreadsheet`| Verde Excel `#107c41`| `icono-excel1.gif` | `icono-excel1.png` (24x24 RGBA) |
| **Exportar a PDF** | `file-text` | Rojo Adobe `#dc2626`| `icono_pdf.png` | `icono_pdf.png` (24x24 RGBA) |
| **Mant. Preventivo** | `clipboard-check` | Esmeralda `#059669`| `checklist.png` | `checklist.png` (48x48 RGBA) |
| **Tareas Máquinas** | `list-todo` | Cian `#0891b2` | `15tareas.png` | `15tareas.png` (48x48 RGBA) |
| **Planif. Ciclos** | `calendar-clock`| Azul `#0284c7` | `Plan_Ciclos_16x16.png` | `Plan_Ciclos_16x16.png` (16x16 RGBA) |
| **Carta Gantt** | `calendar-range`| Violeta `#6366f1` | `Ícono,_Gantt.gif` | `Ícono,_Gantt.png` (24x24 RGBA) |
| **Órdenes Trabajo** | `clipboard-list` | Ámbar `#d97706` | `notas.jpg` (Sin canal alfa) | `notas.png` (24x24 RGBA) |
| **Operaciones** | `wrench` | Pizarra `#475569` | `operations.gif` | `operations.png` (32x32 RGBA) |
| **Informes** | `chart-column-big`| Azul `#0284c7` | `informe.png` | `informe.png` (96x96 RGBA) |
| **Personal Técnico**| `user-check` | Azul Real `#2563eb` | `personal-icono-5904-96.png` | `personal-icono-5904-96.png` (96x96 RGBA) |
| **Usuarios Sistema**| `users` | Índigo `#4338ca` | `icono_usuarios.gif` | `icono_usuarios.png` (96x96 RGBA) |
| **Cargos y Puestos**| `briefcase` | Teal `#0f766e` | `puesto_trabajo.png` | `puesto_trabajo.png` (96x96 RGBA) |
| **Secciones Planta**| `layout-grid` | Ámbar `#d97706` | `icono_seccion.png` | `icono_seccion.png` (64x64 RGBA) |
| **Plantas y Fábrica**| `factory` | Pizarra `#475569` | `icono_fabrica_ezg_2.jpg` | `icono_fabrica_ezg_2.png` (96x96 RGBA) |
| **Máquinas / Nodos**| `cog` | Grafito `#334155` | `icono_dock_bol_museo.png` | `icono_dock_bol_museo.png` (96x96 RGBA) |
| **Insumos / Items** | `boxes` | Ámbar `#b45309` | `items.jpg` (Fondo blanco sucio)| `items.png` (64x64 RGBA) |
| **Icono Aplicación** | Insignia Engranaje | Teal / Esmeralda | ICO de baja resolución | `app_icon.ico` (16 a 256px) + `app_icon.icns` (1024px) |

---

## ⚡ Optimizaciones de Velocidad y SQL

1. **Afinamiento de Conexiones SQL:**
   - Habilitación de `Packet Size=8192` para transferencias masivas de datos con menor fragmentación de paquetes de red.
   - Activación de `MultipleActiveResultSets=True` (MARS) para ejecución paralela de lectores y comandos.
   - Desactivación de auto-enrolamiento en transacciones distribuidas (`Enlist=False`) para reducir overhead de coordinación.
   - Precalentamiento del Connection Pool (`Min Pool Size=5`) al inicio de la aplicación para eliminar la latencia del primer inicio de sesión.
2. **Caché en Memoria Thread-Safe (`CatalogoCache`):**
   - Catálogos de consulta frecuente e infrecuente modificación (Cargos, Plantas, Secciones, Síntomas, Modos de Falla y Autocomplete de Personal) se cargan una única vez en memoria mediante diccionarios concurrentes (`ConcurrentDictionary`).
   - Reducción drástica del tráfico de red y carga sobre el servidor SQL Server corporativo.
3. **Eliminación de Parpadeo y Congelamiento de UI:**
   - Invocación de `DoubleBuffered = True` mediante reflexión protegida en formularios, grillas DataGridView y árboles TreeView.
   - Encapsulamiento de cargas masivas de datos entre `SuspendLayout()` / `ResumeLayout()` y `BeginUpdate()` / `EndUpdate()`.
   - Idempotencia en `AplicarTemaModerno` para evitar reprocesamiento recursivo de controles en activaciones de ventanas MDI.
4. **Limpieza de Código Huérfano y Obsoleto (52 archivos):**
   - Eliminación de 23 controladores de eventos vacíos (`_CellContentClick`, `_TextChanged`, `_Paint`, `_Enter`).
   - Depuración de métodos de plantilla MDI de Visual Studio no utilizados (`ShowNewForm`, `OpenFile`, `SaveAs`, `Cut`, `Copy`, `Paste`, `Cascade`, `Tile`, `CloseAll`).
   - Estandarización de recursos incrustados legacy (como `btn_guardar` en `frm_OT`) migrados al almacén central `My.Resources`.

---

## 🍏 Instalador Universal para macOS (Apple Silicon M1-M4 e Intel)

El sistema cuenta con un instalador nativo para usuarios de computadores Mac sin alterar en nada la versión de Windows:

### Componentes de la versión macOS:
* **`Sistema de Gestión Mantención.app`:** Paquete de aplicación nativo de macOS estructurado según los estándares de Apple.
* **`Contents/Info.plist`:** Metadatos de bundle (`cl.cambiaso.mantencion`), alta resolución Retina y categorización empresarial.
* **`Contents/Resources/app_icon.icns`:** Icono Apple ICNS multirresolución de alta definición (hasta 1024x1024).
* **`Contents/MacOS/launcher`:** Lanzador bash universal que detecta automáticamente si el Mac es Apple Silicon (`arm64`) o Intel (`x86_64`), enlaza directamente con **Whisky** si está presente en `/Applications`, o utiliza Wine CLI aislando el prefijo (`~/Library/Application Support/SistemaMantencion/wineprefix`).
* **`Instalar_en_Mac.command`:** Script de instalación de 1-clic con doble clic que copia la aplicación a `/Applications`, remueve el atributo de cuarentena de Apple Gatekeeper (`xattr -dr com.apple.quarantine`) y valida el entorno.
* **`Iniciar_con_Whisky.command`:** Lanzador rápido directo de 1-clic para usuarios con Whisky instalado en macOS.

### Opciones de Descarga para Mac:
1. **Imagen de Disco Apple (.DMG):** `Instalador_Sistema_Mantencion_v2026.1_macOS.dmg` — Monta el volumen virtual en el Finder para arrastrar y soltar hacia `/Applications`.
2. **Paquete Portable (.ZIP):** `Instalador_Sistema_Mantencion_v2026.1_macOS_Universal.zip` — Incluye la aplicación, el asistente `Instalar_en_Mac.command` y el lanzador directo `Iniciar_con_Whisky.command`.

---

## 🛠️ Stack Tecnológico y Dependencias

| Componente | Tecnología | Versión | Rol en el Sistema |
| :--- | :--- | :--- | :--- |
| **Lenguaje** | Visual Basic .NET | 16.0+ | Sintaxis orientada a objetos moderna y tipado estricto. |
| **Plataforma** | Microsoft .NET | **8.0 LTS** | Runtime CoreCLR x64 de alto rendimiento. |
| **UI Framework** | Windows Forms | 8.0 Desktop | Interfaz MDI con renderizado en doble búfer. |
| **Iconografía** | Lucide Icons | 1.73+ | Biblioteca vectorial industrial con canal alfa RGBA 32-bit. |
| **Base de Datos** | Microsoft SQL Server | 2012 - 2022 | Motor transaccional relacional corporativo (`SrvMagicInfo`). |
| **Acceso a Datos** | `System.Data.SqlClient` | 4.8.6 | Driver SQL nativo con `sni.dll` x64 embebido y PacketSize 8192. |
| **Automatización Office** | `MicrosoftOfficeCore` | 15.0.0 | Ensamblado PIA `office.dll` v15 para compatibilidad universal. |
| **Librería Excel** | `Interop.Excel` | 15.0.4795 | Manipulación nativa de hojas de cálculo e inserción matricial 2D. |
| **Generación PDF** | `iTextSharp.LGPLv2.Core` | 3.4.22 | Motor vectorial independiente para exportar PDF sin depender de Office. |
| **Empaquetador Windows** | Inno Setup | 6.7.3 | Instalador autocontenido x64 con compresión sólida LZMA2. |
| **Empaquetador macOS** | Apple `hdiutil` / ICNS | macOS Sequoia | Creación de imágenes de disco DMG y paquetes `.app` universales. |
| **CI/CD** | GitHub Actions | Windows & macOS | Pipeline dual automatizado de compilación y empaquetado. |

---

## 📂 Estructura del Repositorio

```text
Sistema_gestion_Mantencion/
├── .github/
│   └── workflows/
│       └── build-and-package.yml        # Pipeline CI/CD dual (Windows Inno Setup + macOS DMG)
├── Instalador/
│   ├── Instalador_Sistema_Mantencion_v2026.1.exe           # Instalador oficial Windows x64 (55.5 MB)
│   ├── Instalador_Sistema_Mantencion_v2026.1_macOS.dmg     # Instalador oficial Apple DMG (92 MB)
│   ├── Instalador_Sistema_Mantencion_v2026.1_macOS_Universal.zip # Paquete macOS Universal (82 MB)
│   ├── checksums_sha256.txt            # Checksums SHA-256 versión Windows
│   └── checksums_mac_sha256.txt        # Checksums SHA-256 versión macOS
├── mantencion/
│   ├── class/                           # Lógica de negocio, acceso a datos y utilidades
│   │   ├── Auditoria.vb                 # Consultas, agrupaciones y KPIs de auditoría
│   │   ├── Conexion.vb                  # Conexión SQL Server optimizada (PacketSize, MARS)
│   │   ├── FormatoGrillas.vb            # Estilos corporativos, doble búfer y DataGridViews
│   │   ├── Informes.vb                  # Motor de exportación Excel en bloque 2D y PDF
│   │   ├── MantPreventiva.vb            # Gestión de ciclos y pautas preventivas
│   │   ├── Nodo.vb                      # Jerarquía de activos fabriles y búsqueda
│   │   ├── OT.vb                        # Lógica de Órdenes de Trabajo y reportes
│   │   ├── Usuario.vb                   # Gestión de usuarios, perfiles y permisos
│   │   └── Utilitarios.vb               # Autoajuste de columnas, COM cleanup y temas
│   ├── forms/                           # Vistas y formularios WinForms
│   │   ├── FrmAdminAuditoria.vb         # Módulo de auditoría con KPIs y drill-down
│   │   ├── FrmAdminUsuarios.vb          # Administración de usuarios responsiva
│   │   ├── FrmCartaGantt.vb             # Planificador gráfico Gantt
│   │   ├── FrmConfiguracionServidor.vb  # Configurador de servidor en caliente
│   │   ├── FrmInfOT.vb                  # Generación y filtro de informes OT
│   │   ├── FrmInfOtCR.vb                # Visor e impresión vectorial de OT
│   │   ├── FrmResumenes.vb              # Cuadros de mando y estadísticas
│   │   ├── frm_OT.vb                    # Gestión completa de Órdenes de Trabajo
│   │   └── principal.vb                 # Contenedor MDI y navegación global
│   ├── icons/                           # Iconos institucionales (.ico, .png, .icns)
│   │   ├── app_icon.ico                 # Icono Windows multirresolución (16 a 256px)
│   │   ├── app_icon.icns                # Icono macOS Retina de alta definición (hasta 1024px)
│   │   └── app_icon_rounded.png         # Icono insignia corporativo
│   ├── img/                             # Logos corporativos de Cambiaso Hnos. S.A.C.
│   ├── installer_art/                   # Gráficos y banners de Inno Setup
│   ├── plantillas/                      # 8 Plantillas oficiales Excel (.xls)
│   └── mantencion.vbproj                # Proyecto SDK-Style .NET 8 LTS
├── automatizadores de instalacion/      # Scripts de compilación, diagnóstico y publicación
│   ├── Compilar_Instalador.bat          # Lanzador directo de compilación (.bat)
│   ├── Compilar_Instalador.ps1          # Automatizador PowerShell .NET 8 + Inno Setup
│   ├── Generar_Instalador_Mac.sh        # Generador del paquete e instalador para macOS
│   ├── Publicar_Release_GitHub.ps1      # Publicador en GitHub Releases (API REST)
│   ├── Subir_a_GitHub.ps1               # Sincronización y empuje rápido a GitHub
│   └── diagnostico_entorno.ps1          # Diagnóstico de conectividad SQL y librerías
├── Setup_Mantencion.iss                 # Script oficial de compilación Inno Setup 6
└── README.md                            # Documentación técnica y ejecutiva oficial
```

---

## 🔒 Descarga y Verificación de Integridad

| Archivo | Plataforma | Tamaño | Descarga Oficial | Checksum SHA-256 |
| :--- | :--- | :--- | :--- | :--- |
| **`Instalador_Sistema_Mantencion_v2026.1.exe`** | Windows 10/11 x64 | **55.52 MB** | [⬇️ Descargar Instalador Windows](https://github.com/barriagada666-collab/Sistema_gestion_Mantencion/releases/download/v2026.1/Instalador_Sistema_Mantencion_v2026.1.exe) | `7206C13C5A3083282F37403C0D603AEC7293D7609DBFDBC56EEDD3EFCB653918` |
| **`Instalador_Sistema_Mantencion_v2026.1_macOS.dmg`** | macOS Universal (DMG)| **92.0 MB** | [⬇️ Descargar Instalador macOS DMG](https://github.com/barriagada666-collab/Sistema_gestion_Mantencion/releases/download/v2026.1/Instalador_Sistema_Mantencion_v2026.1_macOS.dmg) | `129637ac3e7d9a7af47848521cb02b652b964e90279ca106b13e191921c8d4bc` |
| **`Instalador_Sistema_Mantencion_v2026.1_macOS_Universal.zip`** | macOS Universal (ZIP)| **77.0 MB** | [⬇️ Descargar Paquete macOS ZIP](https://github.com/barriagada666-collab/Sistema_gestion_Mantencion/releases/download/v2026.1/Instalador_Sistema_Mantencion_v2026.1_macOS_Universal.zip) | `38663b5d5738cf651b994ab41c4e04fcc67f451d1bc1936522bf6b4b9b08cf6e` |

### Verificación de Integridad:

#### En Windows (PowerShell):
```powershell
Get-FileHash -Path ".\Instalador\Instalador_Sistema_Mantencion_v2026.1.exe" -Algorithm SHA256
```
> Valor de coincidencia esperado:  
> `7206C13C5A3083282F37403C0D603AEC7293D7609DBFDBC56EEDD3EFCB653918`

#### En macOS (Terminal):
```bash
shasum -a 256 "Instalador_Sistema_Mantencion_v2026.1_macOS.dmg"
```
> Valor de coincidencia esperado:  
> `129637ac3e7d9a7af47848521cb02b652b964e90279ca106b13e191921c8d4bc`

---

<div align="center"> 
<p align="center">
  <a href="https://github.com/barriagada666-collab/Sistema_gestion_Mantencion/releases/download/v2026.1/Instalador_Sistema_Mantencion_v2026.1.exe"><img src="https://img.shields.io/badge/%E2%AC%87%EF%B8%8F_DESCARGAR_WINDOWS-v2026.1_LTS_(55.5_MB)-025E87?style=for-the-badge&logo=windows&logoColor=white" alt="Descargar Windows" /></a>&nbsp;
  <a href="https://github.com/barriagada666-collab/Sistema_gestion_Mantencion/releases/download/v2026.1/Instalador_Sistema_Mantencion_v2026.1_macOS.dmg"><img src="https://img.shields.io/badge/%E2%AC%87%EF%B8%8F_DESCARGAR_MAC_(DMG)-v2026.1_Universal_(92_MB)-0e705b?style=for-the-badge&logo=apple&logoColor=white" alt="Descargar Mac DMG" /></a>&nbsp;
  <a href="https://github.com/barriagada666-collab/Sistema_gestion_Mantencion/releases/tag/v2026.1"><img src="https://img.shields.io/badge/GITHUB_RELEASES-v2026.1-107850?style=for-the-badge&logo=github&logoColor=white" alt="GitHub Releases" /></a>
</p>
  
### Cambiaso Hnos. S.A.C. — División de Mantención Industrial
📍 **Virginia Bravo Letelier 777, Placilla de Peñuelas, Valparaíso, Chile**  
👨‍💻 **Creado por Boris Arriagada**

</div>
