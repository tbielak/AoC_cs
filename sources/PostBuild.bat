@echo off
if not "%1"=="Release" goto :exit
for %%f in (runtimeconfig.json dll exe) do xcopy %2\*.%%f ..\..\bin /Q /Y >nul 2>nul
:exit
