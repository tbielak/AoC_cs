using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Numerics;
using System.Runtime.Intrinsics;

namespace AoC
{
	public class Engine
	{
		public Engine(int year, Dictionary<int, string> names, Repository repository)
		{
			this.year = year;
			this.names = names;
			this.repository = repository;
			this.cc = new();
		}

		private void Intro()
		{
			cc.WriteLine("{w}AdventOfCode.cs: " + year.ToString() + " Puzzle Solutions{d}, copyright(c) 2022 by {y}TomB{d}");
		}

		private void Help()
		{
			cc.WriteLine("{y}Available options:{d}");
			cc.WriteLine("{g}-h{d} : help (you are exploring it right now)");
			cc.WriteLine("{g}-c{d} : disable colorful output (useful when streaming to file)");
			cc.WriteLine("{g}-a{d} : show available solutions");
			cc.WriteLine("{g}-p <day>{d} : run solution(s) of selected <day> only (by default all available puzzle solutions are executed)");
			cc.WriteLine("{g}-p <day>:<n>{d} : run n-th solution of puzzle from day <day> (if it is not available, first one is executed)");
			cc.WriteLine("{g}-i <filename>{d} : run with <filename> as input (if not specified inputs are loaded from 'input' directory)");
			cc.WriteLine("{g}-s <x>{d} : execution speed testing (at least 10 times, at least <x> seconds to measure reliable execution time)");
			cc.WriteLine();
			cc.WriteLine("{y}Warning:{d} Not all combinations of options are supported. See valid ones in examples below:");
			cc.WriteLine("{g}<no options provided>{d} => run everything once, using as input the appropriate files read from 'input' directory");
			cc.WriteLine("{g}-a{d} => show available solutions");
			cc.WriteLine("{g}-p 2{d} => run only the solution(s) of 2nd day puzzle");
			cc.WriteLine("{g}-p 4:2{d} => run 2nd solution of 4th day puzzle");
			cc.WriteLine("{g}-p 5 -i my_input.txt{d} => run 5th day puzzle solution with the input read from my_input.txt file");
			cc.WriteLine("{g}-s 10{d} => execution speed testing of all puzzles, at least 10 times for 10 seconds (it may take a while!)");
			cc.WriteLine("{g}-p 7 -s 5{d} => execution speed testing 7th puzzle solution(s), at least 10 times for 5 seconds");
			cc.WriteLine();
			cc.WriteLine("Enjoy!");
		}

		void AvailableSolutions()
		{
			cc.WriteLine("{y}Solutions matrix:{d}");
			cc.WriteLine("{g}         1111111111222222{d}");
			cc.WriteLine("{g}1234567890123456789012345{d}  <== day");

			string solved = "";
			string solutions = "";
			for (int day = 1; day <= 25; day++)
			{
				var x = repository.Get();
				{ solved += x.TryGetValue(day, out (int, List<OneSolution>) value) ? value.Item1.ToString() : "-"; }
				{ solutions += x.TryGetValue(day, out (int, List<OneSolution>) value) ? value.Item2.Count.ToString() : "-"; }
			}

			cc.WriteLine(solved + "  <== parts solved");
			cc.WriteLine(solutions + "  <== number of solutions available");
		}

		string[] LoadInput(string input_filename, int day)
		{
			string filename = (input_filename == "") ? "input/" + year + "_" + day.ToString("00") + ".txt" : input_filename;
			try
			{
				return File.ReadAllLines(filename);
			}
			catch (Exception ex)
			{
				if (ex is System.IO.FileNotFoundException || ex is System.IO.DirectoryNotFoundException)
					cc.WriteLine("{r}ERROR: Input file not found!{d}");
				else
					cc.WriteLine("{r}ERROR: Cannot load input file!{d}");
			}

			return null!;
		}

		void PrintOutput((Output, ExecTimes) output, int count = 0)
		{
			foreach (var line in output.Item1.Contents)
				cc.WriteLine(line);

			string msg = (count == 0) ? "Execution time = {y}" : "Average execution time = {y}";

			var ts = output.Item2.Mslist;
			string specifier = "F";
			CultureInfo culture = CultureInfo.CreateSpecificCulture("en-EN");
			msg += ts.Sum().ToString(specifier, culture) + " ms{d}";

			if (ts.Count > 1)
			{
				msg += " (";
				for (int i = 0; i < ts.Count; i++)
				{
					msg += "{y}" + ts[i].ToString(specifier, culture) + " ms{d}";
					if (i < ts.Count - 1)
						msg += " / ";
				}

				msg += ")";
			}

			if (count > 0)
				msg += " (results of " + count.ToString() + " executions)";

			cc.WriteLine(msg);
		}

		bool Execute(bool print_info, ref (Output, ExecTimes) output, string input_filename, int day, int solution)
		{
			(int, List<OneSolution>) solutions;
			if (!repository.Get().TryGetValue(day, out solutions))
			{
				if (print_info)
					cc.WriteLine("{r}ERROR: Day " + day.ToString() + " solution(s) are not available.{d}");

				return false;
			}

			if (solution >= solutions.Item2.Count)
			{
				if (print_info)
					cc.WriteLine("{r}ERROR: Requested solution is not available.{d}");

				return false;
			}

			if (print_info)
				cc.WriteLine("{g}" + names[day] + "{d}");

			OneSolution one_solution = solutions.Item2[solution];
			if (one_solution.Description != "")
			{
				string s = ": " + one_solution.Description;
				s = s.Replace("{T}", ", " + Environment.ProcessorCount + " concurrent threads");

				if (print_info)
				{
					if (solutions.Item2.Count > 1)
						cc.WriteLine("{g}--- Solution #" + (solution + 1).ToString() + s + "{d}");
					else
						cc.WriteLine("{g}--- " + s[2..] + "{d}");
				}
			}

			string[] input = LoadInput(input_filename, day);
			if (input is null)
				return false;

			output = one_solution.Solution.run(input);
			return true;
		}

		void ExecuteSolution(int speed, string input_filename, int day, int solution)
		{
			if (speed > 0)
			{
				int count = 0;
				bool ok = false;
				bool first = true;
				(Output, ExecTimes) output;
				Output ref_output = new();
				List<ExecTimes> exec_times = new();
				Stopwatch stopWatch = new();
				stopWatch.Start();
				while (true)
				{
					count++;
					output = (new(), new());
					ok = Execute(first, ref output, input_filename, day, solution);
					if (!ok)
						break;

					if (first)
					{
						first = false;
						ref_output.Copy(output.Item1);
						for (int j = 0; j < output.Item2.Mslist.Count; j++)
							exec_times.Add(new());
					}
					else
					{
						if (!ref_output.Contents.SequenceEqual(output.Item1.Contents))
						{
							cc.WriteLine("{r}ERROR: Different results obtained in successive executions{d}");
							break;
						}
					}

					for (int j = 0; j < output.Item2.Mslist.Count; j++)
						exec_times[j].Add(output.Item2.Mslist[j]);

					double time_elapsed = stopWatch.Elapsed.TotalSeconds;
					if (time_elapsed >= speed && count >= 10)
					{
						int min_i = count / 10;
						int max_i = count - min_i;
						for (int j = 0; j < exec_times.Count; j++)
						{
							exec_times[j].Mslist.Sort();

							int c = 0;
							output.Item2.Mslist[j] = 0;
							for (int i = min_i; i < max_i; i++)
							{
								output.Item2.Mslist[j] += exec_times[j].Mslist[i];
								c++;
							}

							output.Item2.Mslist[j] /= c;
						}

						break;
					}
				}

				if (ok)
					PrintOutput(output, count);
				else
					cc.WriteLine("{r}ERROR: Unable to run speed test{d}");
			}
			else
			{
				(Output, ExecTimes) output = (new(), new());
				if (Execute(true, ref output, input_filename, day, solution))
					PrintOutput(output);
			}
		}

		void ExecuteDay(int speed, string input_filename, int day)
		{
			(int, List<OneSolution>) solutions;
			if (!repository.Get().TryGetValue(day, out solutions))
			{
				cc.WriteLine("{r}ERROR: Day " + day.ToString() + " solution(s) are not available.{d}");
				return;
			}

			for (int sol = 0; sol < solutions.Item2.Count; sol++)
				ExecuteSolution(speed, input_filename, day, sol);
		}

		void ExecuteAll(int speed)
		{
			foreach (var (day, solutions) in repository.Get())
				for (int sol = 0; sol < solutions.Item2.Count; sol++)
					ExecuteSolution(speed, "", day, sol);
		}

		public int Run(string[] args)
		{
			Options opt = new Options(args);
			cc.Setup(opt.colors);
			Intro();

			if (opt.help)
			{
				Help();
				return 0;
			}

			if (opt.available)
			{
				AvailableSolutions();
				return 0;
			}

			if (opt.speed > 0)
			{
				string[] rep = { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten" };
				string s;
				if (opt.speed > 0 && opt.speed < 11)
					s = rep[opt.speed - 1];
				else
					s = opt.speed.ToString();

				s += " second";
				if (opt.speed > 1)
					s += "s";

				cc.WriteLine("{y}Warning:{d} In this mode ({g}-s{d}) each puzzle solution is run at least ten times and at least for " + s + ".");
				cc.WriteLine("It may take some time to obtain all results, please be patient. 10% of the highest and the lowest time measurements");
				cc.WriteLine("are dropped, the average time of all remaining is printed. Repeatability of results is checked after each execution.");
			}

			if (opt.day > -1)
			{
				if (opt.solution > -1)
					ExecuteSolution(opt.speed, opt.input_filename, opt.day, opt.solution);
				else
					ExecuteDay(opt.speed, opt.input_filename, opt.day);
			}
			else
				ExecuteAll(opt.speed);

			return 0;
		}

		private readonly int year;
		private readonly Dictionary<int, string> names;
		private readonly Repository repository;
		private Console cc;
	}
}
