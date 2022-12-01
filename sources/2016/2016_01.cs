using AoC;

namespace Year2016
{
	class Day01 : Solution
	{
		class Position
		{
			public void Walk(int face, int steps = 1)
			{
				X += Update[face].Item1 * steps;
				Y += Update[face].Item2 * steps;
			}

			public int Distance() => Math.Abs(X) + Math.Abs(Y);
			public override string ToString() => X.ToString() + "x" + Y.ToString();

			private int X;
			private int Y;

			private static readonly (int, int)[] Update = new (int, int)[] { (0, -1), (1, 0), (0, 1), (-1, 0) };
		}

		private static List<(int, int)> Load(string input)
		{
			List<(int, int)> route = new();
			foreach (string s in input.Replace(" ", "").Split(','))
				route.Add((s[0] == 'R' ? 1 : -1, int.Parse(s[1..])));

			return route;
		}

		public override Output PartOne(string input)
		{
			var route = Load(input);

			int face = 0;  // 0 = north; 1 = east; 2 = south; 3 = west
			Position position = new();
			foreach (var (direction, steps) in route)
			{
				face = (face + direction) & 3;
				position.Walk(face, steps);
			}

			return new(position.Distance());
		}

		public override Output PartTwo(string input)
		{
			var route = Load(input);

			int face = 0;   // 0 = north; 1 = east; 2 = south; 3 = west
			Position position = new();
			HashSet<string> visited = new() { position.ToString() };

			foreach (var (direction, steps) in route)
			{
				face = (face + direction) & 3;
				for (int i = 0; i < steps; i++)
				{
					position.Walk(face);
					if (visited.Contains(position.ToString()))
						return new(position.Distance());

					visited.Add(position.ToString());
				}
			}

			return new(-1);
		}
	}
}
