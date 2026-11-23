# Manual Funcional del Usuario

**Sistema de Gestión Departamento Mantención** — Cambiaso Hnos. S.A.C.

---

## 1. Acceso e Interfaz Principal

1. **Inicio de Sesión:** Ingrese su usuario y contraseña corporativos. Si es la primera instalación y necesita ajustar la conexión a red, un administrador puede acceder a las opciones de conexión.
2. **Menú Superior:** Organiza los módulos habilitados para su perfil:
   - **Órdenes de Trabajo:** Ingreso, edición, cierre y anulación de OT.
   - **Mant. Preventiva:** Gestión de pautas preventivas, ciclos y planificación masiva.
   - **Informes:** Consultas de OT, resúmenes estadísticos, mantenciones preventivas (individual y varias máquinas) y Carta Gantt.
   - **Mantenedores:** Administración de activos/nodos, tareas por máquina, fichas técnicas, plantas, secciones, cargos, personal, turnos y usuarios.
   - **Control de Eventos:** Auditoría operativa con estadísticas y filtros.
   - **Acerca de:** Muestra versión instalada, día y hora exacta de instalación, entorno y ruta de ejecución.
   - **Salir:** Permite cerrar sesión (cambiando de usuario) o salir de la aplicación (`Ctrl+Q`).
3. **Barra Inferior de Estado:**
   - **Izquierda:** Usuario en sesión e indicador luminoso del estado de conexión al servidor.
   - **Esquina Inferior Derecha:** Versión instalada activa (por ejemplo `v2026.2.1`); al hacer clic abre directamente la ventana **Acerca de**.

---

## 2. Órdenes de Trabajo (OT)

- **Navegación por Activos:** Use el buscador superior del árbol jerárquico para localizar rápidamente planta, sección, máquina o componente.
- **Registro y Edición:** Permite registrar fecha/hora de recepción e inicio, síntoma, modo de falla, detención, tipo de trabajo, descripción breve/técnica, personal asignado, insumos/repuestos y OT externas.
- **Cierre y Anulación:** El cierre y la anulación están controlados por los permisos asignados a su perfil.

---

## 3. Mantención Preventiva y Planificación de Ciclos

- **Gestión de MP:** Cree o actualice planes preventivos indicando frecuencia (horas), tiempo de aviso previo, tipo (mecánica, eléctrica, etc.) y estado.
- **Ciclos y Tareas:** Administre cada ciclo programado, sus fechas/horas de inicio y término, tareas realizadas/pendientes, personal e insumos.
- **Planificar Ciclos:** Genere múltiples ciclos futuros automáticamente a partir de la frecuencia y duración del último ciclo con vista previa antes de confirmar.

---

## 4. Informes y Rangos de Fecha por Defecto

- **Rango Inicial Automático:** Todos los formularios con filtro por rango de fechas (Informe OT, Resúmenes Estadísticos, Informe de Mantención Preventiva, Ciclos Varias Máquinas, Auditoría y Calendario de Turnos) se inician por defecto con:
  - **Fecha Inicio:** un día antes de hoy (`Ayer`).
  - **Fecha Término:** día actual (`Hoy`).
- Al presionar **Limpiar**, los filtros restablecen el mismo rango predeterminado `[Ayer .. Hoy]`.
- **Exportación Integrada:** Cada informe dispone de exportación a **Excel** y **PDF horizontal completo** listo para impresión.

---

## 5. Carta Gantt Interactiva y Exportación

- **Selección Flexible de Ciclos:** En los informes preventivos puede:
  - Marcar **uno o múltiples ciclos** mediante las casillas de selección (`Sel.`) antes de abrir la Carta Gantt.
  - Activar **Solo ciclo seleccionado** para enfocar únicamente el ciclo activo.
  - Filtrar dentro de la propia Carta Gantt por **N° MP**, **ID Ciclo**, búsqueda rápida, **Estado**, escala temporal o botón **Solo Marcados**.
- **Visualización Limpia:** Las barras de calendario se muestran en color sólido puro según su estado (pendiente, terminado o vencido), sin texto superpuesto sobre las celdas de color; al pasar el cursor sobre una barra se despliega el resumen emergente y en el panel inferior se muestran las tareas detalladas del ciclo seleccionado.
- **Exportación Excel y PDF:** Respeta los ciclos visibles o marcados, organiza resumen general, calendario individual o multi-máquina con cabeceras completas y aplica colores puros en el calendario.

---

## 6. Activos, Personal, Turnos, Seguridad y Auditoría

- **Activos y Datos Técnicos:** Gestione la estructura jerárquica de equipos, catálogo de atributos técnicos y fichas técnicas por máquina.
- **Personal y Turnos:** Administre trabajadores, cargos, plantas, secciones y calendario de programación de turnos.
- **Usuarios y Perfiles:** Cree o edite perfiles personalizados y asigne permisos individuales por módulo/operación.
- **Auditoría de Operaciones:** Consulte el historial de eventos por rango de fechas, sesión, operación, equipo o tabla, con indicadores KPI y exportación a Excel/PDF.
