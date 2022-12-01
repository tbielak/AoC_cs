using AoC;

namespace Year2015
{
	class Day01 : Solution
	{
		public override Output PartOne(string input)
		{
			return new(input.Count(c => c == '(') - input.Count(c => c == ')'));
		}

		public override Output PartTwo(string input)
		{
			int floor = 0;
			for (int i = 0; i < input.Length; i++)
			{
				if ('(' == input[i]) floor++;
				if (')' == input[i]) floor--;
				if (-1 == floor)
					return new(i + 1);
			}

			return new(-1);
		}
	}
}
