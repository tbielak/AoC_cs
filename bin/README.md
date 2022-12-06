## Executables

After successful build in *Release* configuration you'll find your executables here, in *bin* directory. You can run them directly from this location, as they read puzzle input (by default) from *input* directory.

To run executable "as designed", just pick up one *exe* file and run it from command line prompt, without any parameters:
```sh
> 2022.exe
```


## Command line options

To get familiar with command line options, run the executable with *-h* switch (help):
```sh
> 2022 -h
```

To run single day puzzle solution(s) use *-p* switch and select the day. Example of running 2nd day puzzle solution(s):
```sh
> 2022 -p 2
```

Puzzles may have more than one solution of the problem. To see how many solutions is available per day use *-a* switch:
```sh
> 2022 -a
```

To run single solution also use *-p* switch and select the day and the solution. Example of running 18th day, 2nd puzzle solution:
```sh
> 2021 -p 18:2
```

To run single day solution(s) with your input, place your input file in *bin* directory and put the filename in *-i* switch. Example:
```sh
> 2021 -p 2 -i my_2021_02_input.txt
```

To measure execution time of the solution(s) use *-s* switch. In this mode each puzzle solution is run at least ten times and at least for specified seconds (ten seconds, if numeric value is not provided after *-s* switch). It may take some time to obtain all results, so please be patient. 10% of the highest and 10% of the lowest time measurements are dropped, the average time of all remaining executions is printed. Repeatability of results is checked after each execution. These consistency checks and preparing input data for subsequent code executions are outside the measurement scope, thus the execution may last longer than expected. Time of execution does not include input file loading, but includes processing input data (from list of strings to any other structure needed by solution). Command example:
```sh
> 2021 -p 2 -s 15
```

Output is printed on console using colored text. Selecting the colors is achieved by emitting escape sequences. This feature in supported by *cmd.exe* and *conhost.exe* console processes starting from Windows 10 TH2 v1511. If you see garbage instead of colors, use *-c* switch to disable coloring (it is also useful when redirecting output to file for further processing):
```sh
> 2021 -p 2 -c
```

## Debugging the solution

Use Microsoft Visual Studio Community 2022 in Windows to debug the solution. Build the executables in *Debug* configuration, and choose the puzzle solution providing *Command Arguments* (*-p* switch) + optionally: your input file (*-i* switch). Place the breakpoint in the appropriate *cs* file, e.g. in *PartOne* method of solution class and run it. Enjoy!


## Cleaning the folder

Run *clean.bat* script to remove all output files from *bin* directory.
