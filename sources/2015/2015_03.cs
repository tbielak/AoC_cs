using AoC;

namespace Year2015
{
	class Day03 : Solution
	{
		public override Output PartOne(string input)
		{
			int x = 0;
			int y = 0;
			HashSet<(int, int)> visited = new() { (x, y) };

			foreach (char c in input)
			{
				if ('^' == c) y--;
				if ('v' == c) y++;
				if ('>' == c) x--;
				if ('<' == c) x++;
				visited.Add((x, y));
			}

			return new(visited.Count);
		}

		public override Output PartTwo(string input)
		{
			int[] x = new int[2];
			int[] y = new int[2];
			HashSet<(int, int)> visited = new() { (x[0], y[0]) };

			int i = 0;
			foreach (char c in input)
			{
				if ('^' == c) y[i]--;
				if ('v' == c) y[i]++;
				if ('>' == c) x[i]--;
				if ('<' == c) x[i]++;
				visited.Add((x[i], y[i]));
				i ^= 1;
			}

			return new(visited.Count);
		}
	}
}
