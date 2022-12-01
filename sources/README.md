## Projects

Directory | Contents
------------ | -------------
[2015](2015) | Year 2015 puzzle solutions.
[2016](2016) | Year 2016 puzzle solutions.
[2017](2017) | Year 2017 puzzle solutions.
[2018](2018) | Year 2018 puzzle solutions.
[2019](2019) | Year 2019 puzzle solutions.
[2020](2020) | Year 2020 puzzle solutions.
[2021](2021) | Year 2021 puzzle solutions.
[AoC](AoC) | Library which delivers execution environment for all the puzzles. It is used in all projects mentioned above. See [here](../bin) to explore solutions running.


## Special files

File | Contents
------------ | -------------
[AoC.sln](AoC.sln) | Solution file for Microsoft Visual Studio Community 2022.
[clean.bat](clean.bat) | Batch file used to remove all temporary files generated during work session with Microsoft Visual Studio (while editing/building solutions).
[PostBuild.bat](PostBuild.bat) | Batch file called as post-build step while building solution in *Release* configuration. It copies *.runtimeconfig.json* *.dll* and *.exe* files to *bin* directory (see [here](../bin)). It is safe to run it outside Visual Studio - in such case it does nothing.


## Building the solution

- download the repository
- open *AoC.sln* solution file in Microsoft Visual Studio Community 2022
- choose solution configuration and... just build it!

Note: At least .NET Framework 6.0 with C# 10 is required to build the projects. The most important reasons are: record types used and implicit usings enabled in project files.
