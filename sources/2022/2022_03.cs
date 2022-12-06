using AoC;

namespace Year2022
{
	class Day03 : Solution
	{
		static int Priority(char c)
		{
			return (c >= 'a') ? (int)(c - 'a' + 1) : (int)(c - 'A' + 27);
		}

		public override Output PartOne(string[] input)
		{
			return new(input.Sum(s =>
				Priority(s[..(s.Length / 2)].ToCharArray().Intersect(s[(s.Length / 2)..].ToCharArray()).First())));
		}

		public override Output PartTwo(string[] input)
		{
			int sum = 0;
			for (int i = 0; i < input.Length;)
			{
				Dictionary<char, int> contents = new();
				for (int j = 0; j < 3; j++)
					foreach (char c in input[i++])
					{
						contents.TryGetValue(c, out int value);
						contents[c] = value | (1 << j);
					}

				sum += Priority(contents.FirstOrDefault(x => x.Value == 7).Key);
			}

			return new(sum);
		}
	}
}
