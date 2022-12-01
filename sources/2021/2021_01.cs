using AoC;

namespace Year2021
{
	class Day01 : Solution
	{
		public override Output PartOne(string[] input)
		{
			int[] x = Array.ConvertAll(input, v => int.Parse(v));

			int c = 0;
			for (int i = 1; i < x.Length; i++)
				if (x[i] > x[i - 1])
					c++;

			return new(c);
		}

		public override Output PartTwo(string[] input)
		{
			int[] x = Array.ConvertAll(input, v => int.Parse(v));

			int c = 0;
			for (int i = 3; i < x.Length; i++)
				if (x[i] + x[i - 1] + x[i - 2] > x[i - 1] + x[i - 2] + x[i - 3])
					c++;

			return new(c);
		}
	}
}
