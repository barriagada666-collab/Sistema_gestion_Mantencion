; Script de Instalación para Sistema de Gestión Departamento Mantención
; Migrado y optimizado para Microsoft .NET 8 Windows Desktop (x64)
; Paquete Autocontenido (Self-Contained) - Zero Dependency
; Compatible con Inno Setup 6
; Configurado con máxima compresión y ruta C:\Temp\Sistema de Mantencion

#define MyAppName "Sistema de Gestión Departamento Mantención"
#define MyAppShortName "Sistema de Mantención"
#define MyAppVersion "2026.1"
#define MyAppPublisher "Cambiaso Hnos. S.A.C. — División de Mantención Industrial"
#define MyAppExeName "Sistema de Gestion Mantencion.exe"
#define MyAppIcon "mantencion\icons\app_icon.ico"

[Setup]
; Identificador único de la aplicación
AppId={{81543D95-46BE-4730-8A08-A163B21205D7}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppVerName={#MyAppName} v{#MyAppVersion} (.NET 8 Autocontenido)
AppPublisher={#MyAppPublisher}
AppComments=Sistema de Gestión Departamento Mantención v2026.1 LTS (.NET 8 Autocontenido, Zero-Dependency) - Cambiaso Hnos. S.A.C. (Placilla de Peñuelas, Valparaíso) - Creado por Boris Arriagada
VersionInfoDescription=Instalador Autocontenido Sistema de Gestión Departamento Mantención v2026.1 LTS (.NET 8 x64)
VersionInfoProductName=Sistema de Gestión Departamento Mantención
VersionInfoCompany=Cambiaso Hnos. S.A.C. — División de Mantención Industrial
VersionInfoCopyright=Copyright (C) 2026 Cambiaso Hnos. S.A.C. — Creado por Boris Arriagada
VersionInfoVersion=2026.1.0.0

; Arquitectura de 64 bits (x64 nativo / ARM64 compatible)
ArchitecturesAllowed=x64compatible
ArchitecturesInstallIn64BitMode=x64compatible

; Ruta por defecto solicitada: C:\Temp\Sistema de Mantencion
DefaultDirName=C:\Temp\Sistema de Mantencion
DefaultGroupName=Cambiaso Hnos. S.A.C\{#MyAppShortName}
DisableProgramGroupPage=no
AppendDefaultDirName=no
UsePreviousAppDir=no
UsePreviousGroup=no
SetupLogging=yes

; Icono del instalador y desinstalador
SetupIconFile={#MyAppIcon}
UninstallDisplayIcon={app}\{#MyAppExeName}
UninstallDisplayName={#MyAppName}

; Imágenes y Logotipos Institucionales del Asistente
WizardImageFile=mantencion\installer_art\wizard_banner.bmp,mantencion\installer_art\wizard_banner_2x.bmp
WizardSmallImageFile=mantencion\installer_art\wizard_small.bmp,mantencion\installer_art\wizard_small_2x.bmp

; Explicación e información del software durante la instalación
InfoBeforeFile=InfoSoftware.rtf

; Máxima compresión posible (LZMA2 Ultra64 sólido)
Compression=lzma2/ultra64
SolidCompression=yes
LZMAUseSeparateProcess=yes
LZMADictionarySize=262144
LZMANumBlockThreads=4

; Directorio y nombre de salida del instalador
OutputDir=Instalador
OutputBaseFilename=Instalador_Sistema_Mantencion_v2026.1

; Permisos de ejecución (permite instalar en C:\Temp sin exigir privilegios de administrador)
PrivilegesRequired=lowest
PrivilegesRequiredOverridesAllowed=dialog

; Estilo visual moderno
WizardStyle=modern
DisableWelcomePage=no
DisableDirPage=no
DisableReadyPage=no
CloseApplications=yes

[Languages]
Name: "spanish"; MessagesFile: "compiler:Languages\Spanish.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"

[Files]
; Publicación .NET 8 Autocontenida (Self-Contained x64) completa:
; Incluye Runtime .NET 8, CoreCLR, librerías WinForms, dependencias NuGet y librerías nativas (sni.dll, libSkiaSharp.dll)
Source: "mantencion\bin\Release\net8-selfcontained-x64\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs

; Plantillas Excel de Reportes e Informes Estadísticos / Preventivos
Source: "mantencion\plantillas\*.xls"; DestDir: "{app}\plantillas"; Flags: ignoreversion

; Icono de la Aplicación
Source: "mantencion\icons\app_icon.ico"; DestDir: "{app}"; Flags: ignoreversion

[Icons]
; Acceso directo en el Menú Inicio
Name: "{group}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; IconFilename: "{app}\app_icon.ico"
Name: "{group}\Desinstalar {#MyAppName}"; Filename: "{uninstallexe}"

; Acceso directo en el Escritorio
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; IconFilename: "{app}\app_icon.ico"; Tasks: desktopicon

[UninstallDelete]
Type: files; Name: "{app}\error_runtime.log"

[Run]
; Ejecutar aplicación al finalizar instalación si el usuario lo desea
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

[Code]
// Verificación del sistema previa a la instalación
function InitializeSetup(): Boolean;
begin
  Result := True;
  
  // Validar que el sistema operativo sea Windows de 64 bits (x64 / ARM64)
  if not Is64BitInstallMode then
  begin
    MsgBox('Este instalador contiene la versión de alto rendimiento de 64 bits (x64) para Microsoft .NET 8.' + #13#10 + #13#10 +
           'No es posible ejecutar esta instalación en un sistema operativo de 32 bits.' + #13#10 +
           'Por favor ejecute el instalador en un equipo con Windows 10 o Windows 11 de 64 bits.', mbCriticalError, MB_OK);
    Result := False;
    Exit;
  end;
end;
