Set fso = CreateObject("Scripting.FileSystemObject")
Set shell = CreateObject("WScript.Shell")
scriptDir = fso.GetParentFolderName(WScript.ScriptFullName)
cmd = "powershell.exe -NoProfile -Command ""Set-Location '" & scriptDir & "'; (Get-Content 'Subir_a_GitHub.ps1' -Raw) | Invoke-Expression; Write-Host ''; Read-Host 'Presione Enter para finalizar...'"""
shell.Run cmd, 1, True
