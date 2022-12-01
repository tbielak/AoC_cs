using AoC;

namespace Year2017
{
	class Day02 : Solution
	{
		private static List<int[]> Load(string[] input)
		{
			List<int[]> data = new();
			foreach (string s in input)
				data.Add(Array.ConvertAll(s.Split("\t"), s => int.Parse(s)));

			return data;
		}

		public override Output PartOne(string[] input) => new (Load(input).Sum(row => row.Max() - row.Min()));

		public override Output PartTwo(string[] input)
		{
			var data = Load(input);

			int sum = 0;
			foreach (var row in data)
			{
				for (int i = 0; i < row.Length; i++)
				{
					for (int j = i + 1; j < row.Length; j++)
					{
						int a = row[i];
						int b = row[j];
						if (a < b)
							(b, a) = (a, b);

						if ((a % b) == 0)
						{
							sum += a / b;
							break;
						}
					}
				}
			}

			return new (sum);
		}
	}
}
