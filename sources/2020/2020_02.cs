using AoC;

namespace Year2020
{
	public class Item
	{
		public Item(int min, int max, char letter, string password)
		{
			this.Min = min;
			this.Max = max;
			this.Letter = letter;
			this.Password = password;
		}

		public int Min { get; }
		public int Max { get; }
		public char Letter { get; }
		public string Password { get; }
	};

	class Day02 : Solution
	{
		private static List<Item> Load(string[] input)
		{
			List<Item> list = new();
			foreach (var item in input)
			{
				string[] s = item.Split(' ');
				string[] range = s[0].Split('-');
				list.Add(new(int.Parse(range[0]), int.Parse(range[1]), s[1][0], s[2]));
			}

			return list;
		}

		public override Output PartOne(string[] input)
		{
			var items = Load(input);

			int c = 0;
			foreach (var x in items)
			{
				int p = x.Password.Count(c => c == x.Letter);
				if (p >= x.Min && p <= x.Max)
					c++;
			}

			return new(c);
		}

		public override Output PartTwo(string[] input)
		{
			var items = Load(input);

			int c = 0;
			foreach (var x in items)
				if ((x.Password[x.Min - 1] == x.Letter) ^ (x.Password[x.Max - 1] == x.Letter))
					c++;

			return new(c);
		}
	}
}
