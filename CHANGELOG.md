# Historial de Cambios (Changelog)

Todas las actualizaciones relevantes de **Sistema de Gestión Departamento Mantención** se documentan en este archivo bajo versionado corporativo (`YYYY.M.P` LTS) para entornos **Windows 10 / 11 (64 bits)**.

---

## [2026.2.3 LTS] — 2026-11-24

### Edición Exclusiva Windows (`64 bits`), Gráficas del Instalador y Limpieza CI/CD
- **Eliminación completa de componentes heredados multiplataforma:** Se removieron íntegramente scripts, lanzadores, recursos, configuraciones de almacenamiento y artefactos ajenos a Windows tanto del código fuente, instaladores, documentación y flujo de integración continua como de Releases, Artefactos y Cachés publicados.
- **Pipeline CI/CD Windows optimizado:** Flujo dedicado para Windows (`x64`) con compilación limpia de verificación en **Debug** y **Release**, publicación autocontenida, empaquetado NuGet e instalador oficial Inno Setup 6.
- **Gráficas del instalador renovadas y automatizadas:** `Actualizar_Version.ps1` ahora regenera automáticamente los banners corporativos del asistente (`wizard_banner.bmp` y `wizard_banner_2x.bmp`) sincronizados con `VERSION.txt`, junto con descripciones simplificadas en `InfoSoftware.rtf` y `Setup_Mantencion.iss`.
- **Seguridad en utilidades de publicación:** Se reforzó el script de carga a GitHub para manejar credenciales únicamente en memoria sin incrustar tokens en URLs remotas.
- **Compilación estricta, pruebas y documentación renovada:** Validación completa de compilación `0` errores / `0` advertencias sin supresiones globales, pruebas funcionales del ciclo de vida del instalador y renovación integral de `README.md`, capturas (`41_FrmAcercaDe.png`), carrusel y guías en `/docs`.

---

## [2026.2.2 LTS] — 2026-11-24

### Gestión Integral de Personal (CRUD Completo y Lotes)
- **Padrón completo integrado en `Mantenedores → Personal`:** Carga unificada de todo el personal (activos e inactivos) con búsqueda en vivo por RUT, nombres, apellidos, alias, código interno, correo, planta, sección o cargo, combinable con filtros por **Estado**, **Planta**, **Sección** y **Cargo**, además de contador resumen en tiempo real.
- **CRUD completo en una sola vista:** Botones con icono y etiqueta clara (**Ingresar**, **Actualizar**, **Eliminar**, **Nuevo / Limpiar**, **Crear Usuario**, **Excel**, **PDF** y **Salir**), carga instantánea de cualquier fila al formulario superior con bloqueo seguro del RUT en modo edición e indicador visual de modo activo.
- **Compatibilidad total con RUT terminados en dígito verificador `K`:** Actualización transaccional auditada que corrige el error de conversión al editar trabajadores cuyo dígito verificador es `K`.
- **Gestión por lotes mediante checkboxes (`Sel.`):** Selección individual o masiva (**Sel. visibles** / clic en cabecera / tecla Espacio) persistente al cambiar filtros, con acciones masivas transaccionales y auditadas: **Activar Lote**, **Desactivar Lote**, **Reasignar Laboral** (Planta, Sección y/o Cargo con opción *«— Sin cambios —»*), **Eliminar Lote** (protegiendo automáticamente registros con historial operativo y ofreciendo desactivación en un clic) y **Limpiar Sel.**
- **Exportación inteligente a Excel y PDF:** Exporta automáticamente el lote marcado mediante checkboxes (o todo el listado filtrado si no hay selección activa).

### Auditoría Técnica, Seguridad, Compilación y Documentación
- **Compilación estricta (`0` errores, `0` advertencias reales sin supresiones):** Eliminación completa de `<NoWarn>42016,42017,42019</NoWarn>` tras corregir las 236 advertencias implícitas y de enlace tardío COM en reportes Excel y formularios OT/MP/Login mediante auxiliares tipados compartidos.
- **Defensa en profundidad y eficiencia GDI:** Validación directa de permisos de módulo dentro de **Gestión de Personal** y **Administración de Usuarios**, validación de rango numérico (`máx. 9 dígitos`) para código interno y reutilización cacheada de fuentes de estado en grilla con liberación al cerrar.
- **Documentación y README corporativos actualizados:** Renovación de [README.md](README.md), carrusel animado (`41` vistas), [Arquitectura Técnica](docs/ARQUITECTURA_TECNICA.md), [Manual Funcional](docs/MANUAL_FUNCIONAL.md), [Guía de Compilación](docs/GUIA_COMPILACION.md), [Guía de Despliegue](docs/GUIA_DESPLIEGUE.md) y [Paquetes Oficiales](Instalador/README.md).

---

## [2026.2.1 LTS] — 2026-11-23

### Auditoría, Seguridad, Limpieza y Estabilidad
- **Limpieza de código y control estricto de advertencias:** Eliminación de clase no utilizada sin referencias y depuración de supresiones de compilación para exponer cualquier advertencia real futura, manteniendo **0 errores y 0 advertencias** en **Debug** y **Release**.
- **Coherencia de caché en caliente:** Invalidación automática de cachés de nodos, personal y jerarquía estadística tanto al cambiar de servidor de datos como al cerrar sesión.
- **Refuerzo de autorización (Defensa en Profundidad):** Validación adicional de perfil Administrador al guardar cambios de conexión y sincronización visual inmediata de permisos en la gestión de personal.
- **Normalización ortográfica de interfaz:** Corrección de tildes y consistencia tipográfica en títulos de formularios, pestañas y mensajes de validación.

### Documentación Completa
- Incorporación de documentación profesional separada por audiencia: [Arquitectura Técnica](docs/ARQUITECTURA_TECNICA.md), [Manual Funcional](docs/MANUAL_FUNCIONAL.md), [Guía de Compilación](docs/GUIA_COMPILACION.md) y [Guía de Despliegue](docs/GUIA_DESPLIEGUE.md).

---

## [2026.2.0 LTS] — 2026-11-20

### Versionado, Identificación e Interfaz Principal
- **Control centralizado de versiones (`v2026.2.0 LTS`):** Fuente única de verdad para ensamblado, compilación `.NET`, paquete NuGet, asistente e instalador Windows y flujo CI/CD en GitHub Actions, con utilidad dedicada para incrementar versiones de compilación sin ediciones manuales dispersas.
- **Nueva opción `Acerca de` en el menú principal:** Ventana modal corporativa accesible para todos los perfiles de usuario que muestra la versión instalada, la compilación/arquitectura en ejecución, la ruta instalada y el **día y hora exacta de instalación** registrados automáticamente por el instalador.
- **Indicador de versión en esquina inferior derecha:** La barra inferior muestra de forma permanente la versión activa, permitiendo abrir **Acerca de** directamente al hacer clic.

### Mejoras Funcionales y Visuales
- **Rangos de fecha por defecto `[Ayer .. Hoy]`:** Todos los selectores de período en informes de OT, resúmenes, informes preventivos (individual y varias máquinas), auditoría de eventos y calendario de turnos se inicializan por defecto un día antes de hoy como fecha de inicio y el día de hoy como fecha de término, manteniendo dicho rango al limpiar filtros.
- **Barras de Carta Gantt y exportación en color sólido puro:** Se eliminó el texto superpuesto de horas/identificadores sobre las barras coloreadas tanto en la grilla interactiva de Carta Gantt como en la exportación horizontal a Excel y PDF, manteniendo los colores semánticos, información emergente y columnas de detalle sin recorte de cabeceras.
- **Estabilidad de selección múltiple en recargas sucesivas:** Preservación consistente de índices de columnas al recargar búsquedas en grillas con columna de selección por casillas.

---

## [2026.1 LTS] — 2026-11-19

### Novedades y Mejoras Funcionales
- **Carta Gantt con selección múltiple y búsqueda directa:** Casillas selectoras para generar o filtrar la Carta Gantt sobre un ciclo puntual o varios ciclos elegidos (`Solo Marcados`), consulta directa por **N° de Mantención (`N° MP`)**, **ID de Ciclo**, máquina o estado, escala temporal ajustable, desplazamiento sincronizado, soporte multi-año ampliado y panel inferior de tareas.
- **Informes de Mantención Preventiva (Máquina Individual y Varias Máquinas):** Búsqueda por fecha de inicio dentro del rango consultado, ordenamiento desde la mantención preventiva creada más recientemente, carga completa de tareas realizadas y pendientes por máquina, y selección flexible por equipo individual o múltiples equipos.
- **Gestión integral de usuarios, perfiles y permisos:** Soporte completo para creación, edición y eliminación de perfiles personalizados, asignación granular de permisos por módulo y acceso al menú de configuración SQL restringido al perfil Administrador.
- **Estado de conexión visible e intuitivo:** Indicador luminoso de estado de servidor activo en la barra principal y en la ventana de configuración de base de datos, con reinicio controlado tras aplicar cambios de conexión.
- **Identidad visual unificada:** Nueva pantalla de arranque corporativa, cabecera institucional en inicio de sesión, paleta unificada de alto contraste y normalización de iconos y botones en todos los formularios del sistema.

### Exportación y Reportes
- **Exportación unificada de Carta Gantt e informes en Excel y PDF:** Hojas de resumen, calendario individual y calendario multi-máquina alineadas entre vista previa y exportación, con formato horizontal adaptado, fechas preservadas y encabezados legibles en rangos cortos o extensos.
- **Exportación a PDF en formato horizontal completo:** Visor e exportador nativo sin dependencias externas adaptado automáticamente al ancho completo de página horizontal para reportes extensos.
- **Plantillas Excel institucionales:** Homologación de estilos y colores corporativos en todas las plantillas de informes con respaldo libre de Office para equipos sin Excel instalado.

### Correcciones y Estabilización
- Eliminación del error por exceso de columnas en rangos multi-año de Carta Gantt y soporte para calendarios superiores a 256 columnas en exportaciones Excel/PDF.
- Eliminación de recortes y superposiciones de iconos/textos en botones y grillas a distintas escalas de pantalla (DPI).
- Validación segura de entradas numéricas, fechas y selección de filas/celdas en todos los buscadores y formularios.
- Corrección de carga de detalle en resúmenes de OT, tareas realizadas/pendientes de MP y actualización automática de formularios de Gantt ya abiertos.
- Optimización de apertura de formularios, carga de árbol jerárquico de activos en un único recorrido y generación ágil de impresión/PDF.
- Empaquetado autocontenido `.NET 8 LTS` para **Windows (`x64`)** con compilación limpia de 0 errores y 0 advertencias.
