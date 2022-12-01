using AoC;

namespace Year2018
{
	class Day01 : Solution
	{
		public override Output PartOne(string[] input) => new(Array.ConvertAll(input, v => int.Parse(v)).Sum());

		public override Output PartTwo(string[] input)
		{
			HashSet<int> known = new();
			int freq = 0;

			while (true)
			{
				foreach (string f in input)
				{
					freq += int.Parse(f);
					if (known.Contains(freq))
						return new(freq);

					known.Add(freq);
				}
			}
		}
	}
}
