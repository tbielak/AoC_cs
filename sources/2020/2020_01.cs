using AoC;

namespace Year2020
{
	class Day01 : Solution
	{
		public override Output PartOne(string[] input)
		{
			int[] x = Array.ConvertAll(input, v => int.Parse(v));

			foreach (int a in x)
				foreach (int b in x)
					if (2020 == a + b)
						return new(a * b);

			return new(-1);
		}

		public override Output PartTwo(string[] input)
		{
			int[] x = Array.ConvertAll(input, v => int.Parse(v));

			foreach (int a in x)
				foreach (int b in x)
					foreach (int c in x)
						if (2020 == a + b + c)
							return new(a * b * c);

			return new(-1);
		}
	}
}
