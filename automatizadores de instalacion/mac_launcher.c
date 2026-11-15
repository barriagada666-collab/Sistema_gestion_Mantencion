/*
 * Launcher Universal Nativo para macOS (Apple Silicon ARM64 & Intel x86_64)
 * Sistema de Gestión Departamento Mantención - Cambiaso Hnos. S.A.C.
 *
 * Compilado como binario Mach-O Universal (arm64 + x86_64) sin dependencias
 * de Rosetta 2 en Apple Silicon (compatible con macOS 11 a macOS 27 Golden Gate y 28+).
 */

#include <limits.h>
#include <mach-o/dyld.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <unistd.h>

static void show_error_dialog(const char *msg) {
    char cmd[2048];
    snprintf(cmd, sizeof(cmd),
             "/usr/bin/osascript -e 'display alert \"Sistema de Gestión Mantención\" "
             "message \"%s\" as critical' >/dev/null 2>&1",
             msg);
    (void)system(cmd);
}

int main(int argc, char *argv[]) {
    uint32_t buf_size = PATH_MAX;
    char raw_exe[PATH_MAX];
    char resolved_exe[PATH_MAX];

    if (_NSGetExecutablePath(raw_exe, &buf_size) != 0) {
        fprintf(stderr, "Error: No se pudo obtener la ruta del ejecutable.\n");
        return 1;
    }

    if (realpath(raw_exe, resolved_exe) == NULL) {
        snprintf(resolved_exe, sizeof(resolved_exe), "%s", raw_exe);
    }

    /* resolved_exe = .../App.app/Contents/MacOS/launcher -> subir 2 niveles a Contents */
    char *last_slash = strrchr(resolved_exe, '/');
    if (last_slash == NULL) {
        return 1;
    }
    *last_slash = '\0'; /* .../Contents/MacOS */

    last_slash = strrchr(resolved_exe, '/');
    if (last_slash == NULL) {
        return 1;
    }
    *last_slash = '\0'; /* .../Contents */

    char launch_script[PATH_MAX];
    int n = snprintf(launch_script, sizeof(launch_script), "%s/Resources/launch_wine.sh", resolved_exe);
    if (n < 0 || (size_t)n >= sizeof(launch_script)) {
        fprintf(stderr, "Error: Ruta demasiado larga.\n");
        return 1;
    }

    if (access(launch_script, R_OK) != 0) {
        show_error_dialog("No se encontró el script de arranque interno (Resources/launch_wine.sh). Reinstale la aplicación.");
        return 1;
    }

#if defined(__arm64__) || defined(__aarch64__)
    const char *arch_slice = "arm64";
#elif defined(__x86_64__)
    const char *arch_slice = "x86_64";
#else
    const char *arch_slice = "unknown";
#endif

    size_t new_argc = (size_t)argc + 3;
    char **new_argv = (char **)calloc(new_argc, sizeof(char *));
    if (new_argv == NULL) {
        return 1;
    }

    new_argv[0] = (char *)"/bin/bash";
    new_argv[1] = launch_script;
    new_argv[2] = (char *)arch_slice;
    for (int i = 1; i < argc; i++) {
        new_argv[i + 2] = argv[i];
    }
    new_argv[argc + 2] = NULL;

    execv("/bin/bash", new_argv);

    perror("execv /bin/bash");
    free(new_argv);
    return 1;
}
