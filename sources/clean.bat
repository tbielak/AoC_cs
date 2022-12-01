@echo off
for /d /r . %%d in (bin,obj) do @if exist "%%d" rd /s "%%d" /q
attrib -r -h .vs
rd /s .vs /q
