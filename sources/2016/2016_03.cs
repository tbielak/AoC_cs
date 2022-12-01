using AoC;

namespace Year2016
{
	class Day03 : Solution
	{
		private static List<int[]> Load(string[] input)
		{
			List<int[]> data = new();
			foreach (string s in input)
			{
				int[] v = new int[3];
				for (int i = 0; i < 3; i++)
					v[i] = int.Parse(s.Substring(i * 5, 5).Trim());

				data.Add(v);
			}

			return data;
		}

		private static int IsTriangle(int[] x)
		{
			Array.Sort(x);
			return (x[0] + x[1] > x[2]) ? 1 : 0;
		}

		public override Output PartOne(string[] input) => new(Load(input).Sum(v => IsTriangle(v)));

		public override Output PartTwo(string[] input)
		{
			var data = Load(input);

			int count = 0;
			int col_sets = data.Count / 3;
			for (int i = 0; i < col_sets; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					int[] v = new int[3];
					for (int k = 0; k < 3; k++)
						v[k] = data[i * 3 + k][j];

					count += IsTriangle(v);
				}
			}

			return new(count);
		}
	}
}
