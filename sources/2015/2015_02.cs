using AoC;

namespace Year2015
{
	class Day02 : Solution
	{
		private static List<(int, int, int)> Load(string[] input)
		{
			List<(int, int, int)> items = new();
			foreach (string line in input)
			{
				string[] s = line.Split('x');
				items.Add(new(int.Parse(s[0]), int.Parse(s[1]), int.Parse(s[2])));
			}

			return items;
		}

		public override Output PartOne(string[] input)
		{
			var items = Load(input);

			int area = 0;
			int[] s = new int[3];
			foreach (var i in items)
			{
				var (l, w, h) = i;
				s[0] = l * w;
				s[1] = w * h;
				s[2] = h * l;
				Array.Sort(s);
				area += (s[0] + s[1] + s[2]) * 2 + s[0];
			}

			return new(area);
		}

		public override Output PartTwo(string[] input)
		{
			var items = Load(input);

			int ribbon = 0;
			int[] s = new int[3];
			foreach (var i in items)
			{
				(s[0], s[1], s[2]) = i;
				Array.Sort(s);
				ribbon += 2 * (s[0] + s[1]) + s[0] * s[1] * s[2];
			}

			return new(ribbon);
		}
	}
}
