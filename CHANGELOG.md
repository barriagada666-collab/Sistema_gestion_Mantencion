# Historial de Cambios (Changelog)

Todas las actualizaciones relevantes de **Sistema de Gestión Departamento Mantención** se documentan en este archivo bajo versionado anual corporativo (`YYYY.M` LTS).

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
