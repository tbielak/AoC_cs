using AoC;

namespace Year2021
{
	class Day03 : Solution
	{
		public override Output PartOne(string[] input)
		{
			string gamma_bin = "", epsilon_bin = "";
			for (int i = 0; i < input[0].Length; i++)
			{
				int zeros = input.Sum(s => s[i] == '0' ? 1 : 0);
				int ones = input.Length - zeros;
				gamma_bin += zeros <= ones ? '1' : '0';
				epsilon_bin += zeros > ones ? '1' : '0';
			}

			int gamma_rate = Convert.ToInt32(gamma_bin, 2);
			int epsilon_rate = Convert.ToInt32(epsilon_bin, 2);
			return new(gamma_rate * epsilon_rate);
		}

		private static int FindRating(string[] x, int xor_mask)
		{
			bool[] consider = Enumerable.Repeat(true, x.Length).ToArray();
			while (true)
			{
				for (int i = 0; i < x[0].Length; i++)
				{
					int zeros = 0;
					int ones = 0;
					for (int j = 0; j < x.Length; j++)
					{
						if (consider[j])
						{
							if (x[j][i] == '1')
								ones++;
							else
								zeros++;
						}
					}

					char keep = (char)((ones >= zeros ? 1 : 0) ^ xor_mask + '0');
					for (int j = 0; j < x.Length; j++)
						if (consider[j] && x[j][i] != keep)
								consider[j] = false;

					if (consider.Sum(c => c ? 1 : 0) == 1)
						for (int j = 0; j < x.Length; j++)
							if (consider[j])
								return Convert.ToInt32(x[j], 2);
				}
			}
		}

		public override Output PartTwo(string[] input)
		{
			int oxygen_rate = FindRating(input, 0);
			int co2_rate = FindRating(input, 1);
			return new(oxygen_rate * co2_rate);
		}
	}
}
