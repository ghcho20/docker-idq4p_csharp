@echo off

set INAME=dnet:idq4p
echo ^> Check image(%INAME%)
for /F "tokens=* USEBACKQ" %%I in (`docker images -q %INAME%`) do (
    set INAME_CHECK=%%I
)
if [%INAME_CHECK%]==[] (
    echo ^> Install docker image(%INAME%)
) else (
    echo ^> Image(%INAME%) found !
)
if [%INAME_CHECK%]==[] (
    docker build --rm -t %INAME% .
)

set CNAME=dnet
if NOT [%1]==[] (
    set CNAME=%1
)
echo ^> Launch a container(%CNAME%)
for /F "tokens=* USEBACKQ" %%P in (`echo %CD%`) do (
    set WORKSPACE=%%P\ws
)
docker run --rm --name %CNAME% -v "%WORKSPACE%:/workspace" -it %INAME%