# Historial de Cambios (Changelog)

Todas las actualizaciones relevantes de **Sistema de Gestión Departamento Mantención** se documentan en este archivo bajo versionado anual corporativo (`YYYY.M` LTS).

---

## [2026.1 LTS] — 2026-11-19

### Novedades y Mejoras Funcionales
- **Carta Gantt renovada y con búsqueda directa:** Búsqueda instantánea y consulta por **N° de Mantención (`N° MP`)**, **ID de Ciclo**, máquina, sección, observación o estado, con selector de escala temporal (`Compacta`, `Normal`, `Detallada`), leyenda semántica de estados, desplazamiento vertical sincronizado y panel inferior desplegable con el detalle completo de tareas por ciclo.
- **Informe de Mantenciones Preventivas optimizado:** Filtrado inmediato por **Tipo de Mantención**, **Todos** o **Mostrar Solo Tareas** al seleccionar equipo u opción sin restricciones de fecha indebidas, carga automática de ciclos asociados al seleccionar cada plan y controles de fecha mostrados únicamente cuando corresponde.
- **Gestión integral de usuarios, perfiles y permisos:** Soporte completo para creación, edición y eliminación de perfiles personalizados, asignación granular de permisos por módulo y acceso al menú de configuración SQL restringido al perfil Administrador.
- **Estado de conexión visible e intuitivo:** Indicador luminoso de estado de servidor activo en la barra principal y en la ventana de configuración de base de datos, con reinicio controlado tras aplicar cambios de conexión.
- **Identidad visual unificada:** Nueva pantalla de arranque corporativa, cabecera institucional en inicio de sesión, paleta unificada de alto contraste y normalización de iconos y botones en los 40 formularios del sistema.

### Exportación y Reportes
- **Exportación a PDF en formato horizontal completo:** Visor e exportador nativo sin dependencias externas adaptado automáticamente al ancho completo de página horizontal para reportes extensos.
- **Plantillas Excel institucionales:** Homologación de estilos y colores corporativos en todas las plantillas de informes con respaldo nativo libre de Office para equipos sin Excel instalado.

### Correcciones y Estabilización
- Eliminación de recortes y superposiciones de iconos/textos en botones y grillas a distintas escalas de pantalla (DPI).
- Validación segura de entradas numéricas, fechas SQL y selección de filas/celdas en todos los buscadores y formularios.
- Corrección de carga de detalle en resúmenes de OT y ciclos de mantención preventiva.
- Optimización de apertura de formularios y carga de árbol jerárquico de activos en un único recorrido en memoria.
- Empaquetado autocontenido `.NET 8 LTS` para **Windows (`x64` / `ARM64`)** y **macOS Universal (`Apple Silicon ARM64` + `Intel x64`)** con compilación limpia de 0 errores y 0 advertencias.
