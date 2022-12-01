using AoC;

namespace Year2017
{
	class Day01 : Solution
	{
		private static int Count(string input, int add = 1)
		{
			int sum = 0;
			for (int i = 0; i < input.Length; i++)
				if (input[i] == input[(i + add) % input.Length])
					sum += input[i] - '0';

			return sum;
		}

		public override Output PartOne(string input) => new (Count(input));

		public override Output PartTwo(string input) => new (Count(input, input.Length / 2));
	}
}
