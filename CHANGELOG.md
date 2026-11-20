# Historial de Cambios (Changelog)

Todas las actualizaciones relevantes de **Sistema de Gestión Departamento Mantención** se documentan en este archivo bajo versionado corporativo (`YYYY.M.P` LTS).

---

## [2026.2.0 LTS] — 2026-11-20

### Versionado, Identificación e Interfaz Principal
- **Control centralizado de versiones (`v2026.2.0 LTS`):** Fuente única de verdad para ensamblado, compilación `.NET`, paquete NuGet, asistente e instalador Windows, paquete macOS Universal y flujo CI/CD en GitHub Actions, con utilidad dedicada para incrementar versiones de compilación sin ediciones manuales dispersas.
- **Nueva opción `Acerca de` en el menú principal:** Ventana modal corporativa accesible para todos los perfiles de usuario que muestra la versión instalada, la compilación/arquitectura en ejecución, la ruta instalada y el **día y hora exacta de instalación** registrados automáticamente por el instalador.
- **Indicador de versión en esquina inferior derecha:** La barra inferior muestra de forma permanente la versión activa (`v2026.2.0`), permitiendo abrir **Acerca de** directamente al hacer clic.

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
- **Plantillas Excel institucionales:** Homologación de estilos y colores corporativos en todas las plantillas de informes con respaldo nativo libre de Office para equipos sin Excel instalado.

### Correcciones y Estabilización
- Eliminación del error por exceso de columnas en rangos multi-año de Carta Gantt y soporte para calendarios superiores a 256 columnas en exportaciones Excel/PDF.
- Eliminación de recortes y superposiciones de iconos/textos en botones y grillas a distintas escalas de pantalla (DPI).
- Validación segura de entradas numéricas, fechas SQL y selección de filas/celdas en todos los buscadores y formularios.
- Corrección de carga de detalle en resúmenes de OT, tareas realizadas/pendientes de MP y actualización automática de formularios de Gantt ya abiertos.
- Optimización de apertura de formularios, carga de árbol jerárquico de activos en un único recorrido y generación ágil de impresión/PDF.
- Empaquetado autocontenido `.NET 8 LTS` para **Windows (`x64` / `ARM64`)** y **macOS Universal (`Apple Silicon ARM64` + `Intel x64`)** con compilación limpia de 0 errores y 0 advertencias.
