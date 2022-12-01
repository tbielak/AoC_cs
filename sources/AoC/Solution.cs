using System.Diagnostics;

namespace AoC
{
	public class Solution
	{
		public virtual Output PartOne(string input) => new();
		public virtual Output PartOne(string[] input) => new();
		public virtual Output PartTwo(string input) => new();
		public virtual Output PartTwo(string[] input) => new();
		public virtual Output BothParts(string input) => new();
		public virtual Output BothParts(string[] input) => new();

		public (Output, ExecTimes) run(string[] input)
		{
			Output output, output_part2;
			ExecTimes execTimes = new();
			Stopwatch stopWatch = new();

			stopWatch.Start();
			output = (input.Length > 1) ? BothParts(input) : BothParts(input[0]);
			stopWatch.Stop();
			if (!output.Empty())
			{
				execTimes.Add(stopWatch.Elapsed);
				return (output, execTimes);
			}

			stopWatch.Reset();
			stopWatch.Start();
			output = (input.Length > 1) ? PartOne(input) : PartOne(input[0]);
			stopWatch.Stop();
			execTimes.Add(stopWatch.Elapsed);

			stopWatch.Reset();
			stopWatch.Start();
			output_part2 = (input.Length > 1) ? PartTwo(input) : PartTwo(input[0]);
			stopWatch.Stop();
			if (!output_part2.Empty())
			{
				output.Add(output_part2);
				execTimes.Add(stopWatch.Elapsed);
			}

			return (output, execTimes);
		}
	}
}
