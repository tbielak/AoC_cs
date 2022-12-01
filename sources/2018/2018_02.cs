using AoC;

namespace Year2018
{
	class Day02 : Solution
	{
		public override Output PartOne(string[] input)
		{
			int two = 0, three = 0;
			foreach (string s in input)
			{
				Dictionary<char, int> charcount = new();
				foreach (char c in s)
				{
					charcount.TryGetValue(c, out int count);
					charcount[c] = count + 1;
				}

				two += charcount.ContainsValue(2) ? 1 : 0;
				three += charcount.ContainsValue(3) ? 1 : 0;
			}

			return new(two * three);
		}

		private static string Diff(string s1, string s2)
		{
			string x = "";
			for (int i = 0; i < s1.Length; i++)
				if (s1[i] == s2[i])
					x += s1[i];
	
			return x;
		}

		public override Output PartTwo(string[] input)
		{
			for (int i = 0; i < input.Length; i++)
			{
				for (int j = i + 1; j < input.Length; j++)
				{
					string x = Diff(input[i], input[j]);
					if (x.Length == input[i].Length - 1)
						return new(x);
				}
			}

			return new("?");
		}
	}
}
