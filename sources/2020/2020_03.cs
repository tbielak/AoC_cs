using AoC;

namespace Year2020
{
	class Day03 : Solution
	{
		public override Output PartOne(string[] input)
		{
			int x = 0;
			int c = 0;
			int width = input[0].Length;
			foreach (var s in input)
			{
				if (s[x] == '#') c++;
				x = (x + 3) % width;
			}

			return new(c);
		}

		public override Output PartTwo(string[] input)
		{
			long m = 1;
			int width = input[0].Length;
			int height = input.Length;
			foreach (var (sx, sy) in slopes)
			{
				int x = 0, y = 0, c = 0;
				do
				{
					if (input[y][x] == '#') c++;
					x += sx;
					y += sy;
					x %= width;
				} while (y < height);

				m *= c;
			}

			return new(m);
		}

		private static readonly List<(int, int)> slopes
			= new() { (1, 1), (3, 1), (5, 1), (7, 1), (1, 2) };
	}
}
