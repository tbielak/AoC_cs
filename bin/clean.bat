@for %%f in ("*") do if /i not "%%~nxf"=="clean.bat" if /i not "%%~nxf"=="README.md" del "%%f"
