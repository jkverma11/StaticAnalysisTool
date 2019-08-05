@Echo OFF
Echo "Building solution/project file using batch file"
SET PATH=C:\Windows\Microsoft.NET\Framework\v4.0.30319\
SET SolutionPath=C:\Users\320050491\StaticAnalysisTool\StaticAnalyzerTool\StaticAnalyzerTool.sln

MSbuild %SolutionPath% /p:Configuration=Debug /p:Platform="Any CPU"

cd C:\Users\320050491\StaticAnalysisTool\StaticAnalyzerTool\StaticAnalyzerTool\bin\Debug
StaticAnalyzerTool.exe 
IF %ERRORLEVEL% == 0 (
    ECHO Successfully Launched the Analyzers
) ELSE (
    ECHO Failure while Launching the Analyzers
)

cd ..\..\..\..\
C:\WINDOWS\system32\WindowsPowerShell\v1.0\powershell.exe -ExecutionPolicy Bypass -File StaticAnalyzerToolReport.ps1
IF %ERRORLEVEL% == 0 (
    ECHO Successfull write to html file
) ELSE (
    ECHO Error while Writing to html file
)

StaticAnalyzerTool.exe
IF %ERRORLEVEL% == 0 (
    ECHO Successfully Launched the Analyzers
) ELSE (
    ECHO Failure while Launching the Analyzers
)
cmd /k