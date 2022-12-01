using AoC;

namespace Year2019
{
	class Day01 : Solution
	{
		public override Output PartOne(string[] input) =>
			new(Array.ConvertAll(input, s => int.Parse(s)).Sum(v => v / 3 - 2));

		int FuelReq(int v)
		{
			int sum = 0;
			while (v > 0)
			{
				v = Math.Max(v / 3 - 2, 0);
				sum += v;
			}

			return sum;
		}

		public override Output PartTwo(string[] input) =>
			new(Array.ConvertAll(input, s => int.Parse(s)).Sum(v => FuelReq(v)));
	}
}
