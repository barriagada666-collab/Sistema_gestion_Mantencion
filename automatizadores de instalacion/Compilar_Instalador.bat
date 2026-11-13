@echo off
setlocal
title Compilador de Instalador - Sistema de Gestion Mantencion
cd /d "%~dp0"
powershell.exe -NoProfile -ExecutionPolicy Bypass -Command "& { Set-Location '%~dp0'; (Get-Content '%~dp0Compilar_Instalador.ps1' -Raw) | Invoke-Expression }"
echo.
pause
