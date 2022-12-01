using AoC;

namespace Year2018
{
	class Day03 : Solution
	{
		record Point(int X, int Y);

		class Fabric
		{
			public Fabric(int id, Point p, int width, int height)
			{
				this.Id = id;
				this.P = p;
				this.Width = width;
				this.Height = height;
			}

			public (int id, Point p, int width, int height) Deconstruct() => (Id, P, Width, Height);

			private readonly int Id;
			private readonly Point P;
			private readonly int Width, Height;
		}

		private static List<Fabric> Load(string[] input)
		{
			List<Fabric> fabrics = new();
			foreach (string line in input)
			{
				string[] parts = line.Split(' ');
				string[] point = parts[2].Replace(":", "").Split(',');
				string[] size = parts[3].Split('x');
				fabrics.Add(new(
					int.Parse(parts[0].Replace("#", "")),
					new Point(int.Parse(point[0]), int.Parse(point[1])),
					int.Parse(size[0]), int.Parse(size[1])));
			}

			return fabrics;
		}

		public override Output PartOne(string[] input)
		{
			var fabrics = Load(input);
			
			Dictionary<Point, int> points = new();
			foreach (var f in fabrics)
			{
				var (id, p, width, height) = f.Deconstruct();
				for (int x = p.X; x < p.X + width; x++)
				{
					for (int y = p.Y; y < p.Y + height; y++)
					{
						Point np = new(x, y);
						points.TryGetValue(np, out int value);
						points[np] = value + 1;
					}
				}
			}

			return new(points.Sum(v => v.Value > 1 ? 1 : 0));
		}

		public override Output PartTwo(string[] input)
		{
			var fabrics = Load(input);

			HashSet<int> ids = new();
			Dictionary<Point, HashSet<int>> points = new();
			foreach (var f in fabrics)
			{
				var (id, p, width, height) = f.Deconstruct();
				ids.Add(id);
				for (int x = p.X; x < p.X + width; x++)
				{
					for (int y = p.Y; y < p.Y + height; y++)
					{
						Point np = new(x, y);
						if (!points.ContainsKey(np))
							points[np] = new();

						points[np].Add(id);
					}
				}
			}

			foreach (var p in points)
				if (p.Value.Count > 1)
					foreach (var id in p.Value)
						ids.Remove(id);

			return new(ids.ToArray()[0]);
		}
	}
}
