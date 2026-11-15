#!/usr/bin/env python3
"""
Depura una carpeta de publicación autocontenida (.NET 8 WinForms) eliminando:
  - Ensamblados y nativos exclusivos de WPF (no usados por Windows Forms)
  - Símbolos de depuración y herramientas de diagnóstico (.pdb, .xml, createdump, mscordaccore, DiaSymReader)
  - Carpetas de idiomas extranjeros (conserva únicamente 'es')
Y sincroniza 'Sistema de Gestion Mantencion.deps.json' para evitar errores de carga en CoreCLR.
"""

import json
import os
import shutil
import sys

PRUNE_EXACT = {
    "createdump.exe",
    "D3DCompiler_47_cor3.dll",
    "DirectWriteForwarder.dll",
    "PenImc_cor3.dll",
    "PresentationCore.dll",
    "PresentationFramework.dll",
    "PresentationFramework.Aero.dll",
    "PresentationFramework.Aero2.dll",
    "PresentationFramework.AeroLite.dll",
    "PresentationFramework.Classic.dll",
    "PresentationFramework.Luna.dll",
    "PresentationFramework.Royale.dll",
    "PresentationFramework-SystemCore.dll",
    "PresentationFramework-SystemData.dll",
    "PresentationFramework-SystemDrawing.dll",
    "PresentationFramework-SystemXml.dll",
    "PresentationFramework-SystemXmlLinq.dll",
    "PresentationNative_cor3.dll",
    "PresentationUI.dll",
    "ReachFramework.dll",
    "System.Printing.dll",
    "System.Windows.Controls.Ribbon.dll",
    "System.Windows.Presentation.dll",
    "System.Xaml.dll",
    "wpfgfx_cor3.dll",
    "mscordaccore.dll",
    "mscordbi.dll",
}

FOREIGN_LOCALES = {
    "cs", "de", "en", "fr", "it", "ja", "ko",
    "pl", "pt-BR", "ru", "tr", "zh-Hans", "zh-Hant",
}


def should_prune_root_file(filename: str) -> bool:
    if filename in PRUNE_EXACT:
        return True
    if filename.startswith("Microsoft.DiaSymReader.Native."):
        return True
    if filename.startswith("mscordaccore_"):
        return True
    if filename.endswith(".pdb") or filename.endswith(".xml"):
        return True
    return False


def dir_size_bytes(path: str) -> int:
    total = 0
    for root, _, files in os.walk(path):
        for f in files:
            try:
                total += os.path.getsize(os.path.join(root, f))
            except OSError:
                pass
    return total


def main() -> int:
    if len(sys.argv) < 2:
        print("Uso: depurar_publicacion.py <ruta_publicacion>", file=sys.stderr)
        return 1

    pub_dir = os.path.abspath(sys.argv[1])
    if not os.path.isdir(pub_dir):
        print(f"Error: No existe el directorio {pub_dir}", file=sys.stderr)
        return 1

    before_bytes = dir_size_bytes(pub_dir)
    removed_keys = set()

    # 1. Eliminar archivos innecesarios en la raíz de publicación
    for name in list(os.listdir(pub_dir)):
        full = os.path.join(pub_dir, name)
        if os.path.isfile(full) and should_prune_root_file(name):
            os.remove(full)
            removed_keys.add(name)

    # 2. Eliminar carpetas de idiomas extranjeros (conservar 'es')
    for locale in FOREIGN_LOCALES:
        loc_dir = os.path.join(pub_dir, locale)
        if os.path.isdir(loc_dir):
            for fname in os.listdir(loc_dir):
                removed_keys.add(f"{locale}/{fname}")
            shutil.rmtree(loc_dir, ignore_errors=True)

    # 3. Sincronizar deps.json si existe
    deps_path = os.path.join(pub_dir, "Sistema de Gestion Mantencion.deps.json")
    if os.path.isfile(deps_path):
        with open(deps_path, "r", encoding="utf-8") as fh:
            deps = json.load(fh)

        for target_libs in deps.get("targets", {}).values():
            for lib_data in target_libs.values():
                for section in ("runtime", "native", "resources"):
                    sec_dict = lib_data.get(section)
                    if isinstance(sec_dict, dict):
                        for key in list(sec_dict.keys()):
                            base = os.path.basename(key)
                            if key in removed_keys or base in removed_keys or should_prune_root_file(base):
                                del sec_dict[key]
                            else:
                                prefix = key.split("/", 1)[0] if "/" in key else ""
                                if prefix in FOREIGN_LOCALES:
                                    del sec_dict[key]

        with open(deps_path, "w", encoding="utf-8") as fh:
            json.dump(deps, fh, indent=2)

    after_bytes = dir_size_bytes(pub_dir)
    saved_mb = (before_bytes - after_bytes) / (1024 * 1024)
    after_mb = after_bytes / (1024 * 1024)
    print(f"[OK] Publicacion depurada ({pub_dir}): -{saved_mb:.2f} MB ahorrados -> {after_mb:.2f} MB finales.")
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
