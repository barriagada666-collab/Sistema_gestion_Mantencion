; Script de Instalación para Sistema de Gestión Departamento Mantención
; Migrado y optimizado para Microsoft .NET 8 Windows Desktop
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
AppVerName={#MyAppName} v{#MyAppVersion} (.NET 8)
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
; Publicación .NET 8 completa: ejecutables, dependencias NuGet y configuraciones
Source: "mantencion\bin\Release\net8-publish\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs

; Plantillas Excel de Reportes e Informes Estadísticos / Preventivos
Source: "mantencion\plantillas\*.xls"; DestDir: "{app}"; Flags: ignoreversion

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

[Code]
// Función para verificar si .NET 8 Desktop Runtime está instalado en el equipo
function IsDotNet8DesktopRuntimeInstalled(): Boolean;
var
  RegKeyx64, RegKeyx86: string;
  Names: TArrayOfString;
  I: Integer;
  DotNetDir64, DotNetDir32: string;
  FindRec: TFindRec;
begin
  Result := False;

  // 1. Verificación por Registro de Windows (x64 y WOW6432Node)
  RegKeyx64 := 'SOFTWARE\dotnet\Setup\InstalledVersions\x64\sharedfx\Microsoft.WindowsDesktop.App';
  RegKeyx86 := 'SOFTWARE\WOW6432Node\dotnet\Setup\InstalledVersions\x64\sharedfx\Microsoft.WindowsDesktop.App';

  if RegGetValueNames(HKEY_LOCAL_MACHINE, RegKeyx64, Names) then
  begin
    for I := 0 to GetArrayLength(Names) - 1 do
    begin
      if Copy(Names[I], 1, 4) = '8.0.' then
      begin
        Result := True;
        Exit;
      end;
    end;
  end;

  if RegGetValueNames(HKEY_LOCAL_MACHINE, RegKeyx86, Names) then
  begin
    for I := 0 to GetArrayLength(Names) - 1 do
    begin
      if Copy(Names[I], 1, 4) = '8.0.' then
      begin
        Result := True;
        Exit;
      end;
    end;
  end;

  // 2. Verificación por Sistema de Archivos en carpetas compartidas de dotnet
  DotNetDir64 := ExpandConstant('{commonpf}') + '\dotnet\shared\Microsoft.WindowsDesktop.App\8.0.*';
  DotNetDir32 := ExpandConstant('{commonpf32}') + '\dotnet\shared\Microsoft.WindowsDesktop.App\8.0.*';

  if FindFirst(DotNetDir64, FindRec) then
  begin
    Result := True;
    FindClose(FindRec);
    Exit;
  end;

  if FindFirst(DotNetDir32, FindRec) then
  begin
    Result := True;
    FindClose(FindRec);
    Exit;
  end;
end;

function InitializeSetup(): Boolean;
var
  ErrorCode: Integer;
  MsgText: string;
begin
  Result := True;
  
  if not IsDotNet8DesktopRuntimeInstalled() then
  begin
    MsgText := 'Esta versión fue modernizada a Microsoft .NET 8 y requiere que el equipo disponga de:' + #13#10 + #13#10 +
               '  • Microsoft .NET 8 Desktop Runtime (x64 / x86)' + #13#10 + #13#10 +
               'No se detectó este componente instalado en su sistema.' + #13#10 + #13#10 +
               '¿Desea abrir la página oficial de descarga de Microsoft para instalarlo ahora?';
               
    if MsgBox(MsgText, mbConfirmation, MB_YESNO) = IDYES then
    begin
      ShellExec('open', 'https://dotnet.microsoft.com/download/dotnet/8.0/runtime', '', '', SW_SHOWNORMAL, ewNoWait, ErrorCode);
    end;
  end;
end;
