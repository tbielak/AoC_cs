using AoC;

namespace Year2022
{
	class Day01 : Solution
	{
		static int TotalCalories(string[] input, int top_count = 1)
		{
			List<int> elfs = new();
			int calories = 0;
			foreach (var line in input)
			{
				if (line == "")
				{
					elfs.Add(calories);
					calories = 0;
				}
				else
					calories += int.Parse(line);
			}

			elfs.Add(calories);
			elfs.Sort();
			return elfs.TakeLast(top_count).Sum();
		}

		public override Output PartOne(string[] input)
		{
			return new(TotalCalories(input));
		}

		public override Output PartTwo(string[] input)
		{
			return new(TotalCalories(input, 3));
		}
	}
}
