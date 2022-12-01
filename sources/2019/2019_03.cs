using AoC;

namespace Year2019
{
	class Day03 : Solution
	{
		class Wire
		{
			public Wire(string input)
			{
				path = new();
				points = new();

				foreach (string s in input.Split(','))
					path.Add((s[0], int.Parse(s[1..])));
			}

			public void TwistsAndTurns()
			{
				int step = 0, x = 0, y = 0;
				foreach (var (direction, distance) in path)
				{
					for (int i = 0; i < distance; i++)
					{
						x += Turns[direction].Item1;
						y += Turns[direction].Item2;
						
						step++;
						points[(x, y)] = step;
					}
				}
			}

			public int DistanceToClosest(Wire other)
			{
				int distance = Int32.MaxValue;
				foreach (var (p, _) in points)
					if (other.points.ContainsKey(p))
						distance = Math.Min(distance, Math.Abs(p.Item1) + Math.Abs(p.Item2));

				return distance;
			}

			public int FewestSteps(Wire other)
			{
				int steps = Int32.MaxValue;
				foreach (var (p, s1) in points)
					if (other.points.TryGetValue(p, out int s2))
						steps = Math.Min(steps, s1 + s2);

				return steps;
			}

			private readonly List<(char, int)> path;
			private readonly Dictionary<(int, int), int> points;

			private static readonly Dictionary<char, (int, int)> Turns = new()
				{ { 'R', ( 1, 0 ) }, { 'U', ( 0, -1 ) }, { 'L', ( -1, 0 ) }, { 'D', ( 0, 1 ) } };
		}

		public override Output BothParts(string[] input)
		{
			Wire w1 = new(input[0]);
			Wire w2 = new(input[1]);

			w1.TwistsAndTurns();
			w2.TwistsAndTurns();
			return new(w1.DistanceToClosest(w2), w1.FewestSteps(w2));
		}
	}
}
