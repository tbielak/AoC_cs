using AoC;

namespace Year2017
{
	class Day03 : Solution
	{
		private static readonly (int, int)[] Update = new (int, int)[] { (1, 0), (0, -1), (-1, 0), (0, 1) };
		private static readonly int[] CountUpdate = new int[] { 0, 1, 0, 1 };

		record Point(int X, int Y);

		public override Output PartOne(string input)
		{
			int x = 0, y = 0, value = 1, count = 1;
			int target = int.Parse(input);

			while (true)
			{
				for (int j = 0; j < 4; j++)
				{
					for (int i = 0; i < count; i++)
					{
						if (value == target)
							return new(Math.Abs(x) + Math.Abs(y));

						x += Update[j].Item1;
						y += Update[j].Item2;
						value++;
					}

					count += CountUpdate[j];
				}
			}
		}

		private static int Neighbours(Point p, Dictionary<Point, int> spiral)
		{
			int sum = 0;
			for (int x = -1; x <= 1; x++)
			{
				for (int y = -1; y <= 1; y++)
				{
					Point t = new(p.X + x, p.Y + y);
					if (spiral.ContainsKey(t))
						sum += spiral[t];
				}
			}

			return sum;
		}

		public override Output PartTwo(string input)
		{
			Dictionary<Point, int> spiral = new();
			int target = int.Parse(input);

			Point p = new(0, 0);
			spiral[p] = 1;

			int count = 1;
			while (true)
			{
				for (int j = 0; j < 4; j++)
				{
					for (int i = 0; i < count; i++)
					{
						int value = Neighbours(p, spiral);
						if (value > target)
							return new(value);

						spiral[p] = value;
						p = new(p.X + Update[j].Item1, p.Y + Update[j].Item2);
					}

					count += CountUpdate[j];
				}
			}
		}
	}
}
