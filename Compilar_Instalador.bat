@echo off
setlocal
title Compilador de Instalador - Sistema de Gestion Mantencion
cd /d "%~dp0"
powershell.exe -NoProfile -ExecutionPolicy Bypass -File "%~dp0Compilar_Instalador.ps1"
echo.
pause
