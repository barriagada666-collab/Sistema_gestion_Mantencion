; Script de Instalación para Sistema de Gestión Departamento Mantención
; Compatible con Inno Setup 6
; Configurado con máxima compresión y ruta C:\Temp\Sistema de Mantencion

#define MyAppName "Sistema de Gestión Departamento Mantención"
#define MyAppShortName "Sistema de Mantención"
#define MyAppVersion "2026.1"
#define MyAppPublisher "Cambiaso Hnos. S.A.C."
#define MyAppExeName "Sistema de Gestion Mantencion.exe"
#define MyAppIcon "mantencion\icons\app_icon.ico"

[Setup]
; Identificador único de la aplicación
AppId={{81543D95-46BE-4730-8A08-A163B21205D7}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppVerName={#MyAppName} v{#MyAppVersion}
AppPublisher={#MyAppPublisher}

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

; Permisos de ejecución (permite instalar en C:\Temp sin exigir permisos de administrador)
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
; Ejecutable Principal y Archivo de Configuración
Source: "mantencion\bin\Release\Sistema de Gestion Mantencion.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "mantencion\bin\Release\Sistema de Gestion Mantencion.exe.config"; DestDir: "{app}"; Flags: ignoreversion

; Bibliotecas del Sistema y COM Interop
Source: "mantencion\bin\Release\itextsharp.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "mantencion\bin\Release\Microsoft.Office.Interop.Access.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "mantencion\bin\Release\Microsoft.Office.Interop.Excel.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "mantencion\bin\Release\Microsoft.Vbe.Interop.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "mantencion\bin\Release\office.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "mantencion\lib\dao.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "mantencion\lib\adodb.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "mantencion\lib\Microsoft.AnalysisServices.AdomdClient.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "mantencion\lib\Microsoft.Office.interop.access.dao.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "mantencion\lib\stdole.dll"; DestDir: "{app}"; Flags: ignoreversion

; Plantillas Excel de Reportes e Informes Estadísticos / Preventivos
Source: "mantencion\bin\Release\inf_ot.xls"; DestDir: "{app}"; Flags: ignoreversion
Source: "mantencion\bin\Release\inf_MP.xls"; DestDir: "{app}"; Flags: ignoreversion
Source: "mantencion\bin\Release\inf_listado_ciclo_mp.xls"; DestDir: "{app}"; Flags: ignoreversion
Source: "mantencion\bin\Release\inf_estadistico.xls"; DestDir: "{app}"; Flags: ignoreversion
Source: "mantencion\bin\Release\inf_datos_tecnicos.xls"; DestDir: "{app}"; Flags: ignoreversion
Source: "mantencion\bin\Release\inf_auditoria.xls"; DestDir: "{app}"; Flags: ignoreversion
Source: "mantencion\bin\Release\inf_gantt.xls"; DestDir: "{app}"; Flags: ignoreversion
Source: "mantencion\bin\Release\InfGantt.xls"; DestDir: "{app}"; Flags: ignoreversion

; Icono de la Aplicación
Source: "mantencion\icons\app_icon.ico"; DestDir: "{app}"; Flags: ignoreversion

[Icons]
; Acceso directo en el Menú Inicio
Name: "{group}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; IconFilename: "{app}\app_icon.ico"
Name: "{group}\Desinstalar {#MyAppName}"; Filename: "{uninstallexe}"

; Acceso directo en el Escritorio
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; IconFilename: "{app}\app_icon.ico"; Tasks: desktopicon

[Run]
; Ejecutar aplicación al finalizar instalación si el usuario lo desea
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent
