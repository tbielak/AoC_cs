using AoC;

namespace Year2016
{
	class Day02 : Solution
	{
		private static readonly string directions = "UDLR";

		private static char Press(string[] keymap, string digit)
		{
			char curr = '5';
			foreach (char d in digit)
				curr = keymap[directions.IndexOf(d)][curr - '0'];

			return (curr > '9') ? (char)(curr - '0' - 10 + 'A') : curr;
		}

		private static Output EnterCode(string[] keymap, string[] input)
		{
			string code = "";
			foreach (string digit in input)
				code += Press(keymap, digit);

			return new(code);
		}

		public override Output PartOne(string[] input) =>
			EnterCode(new string[] { "0123123456", "0456789789", "0112445778", "0233566899" }, input);

		public override Output PartTwo(string[] input) =>
			EnterCode(new string[] { "0121452349678;", "036785:;<9:=<=", "0122355678::;=", "0134467899;<<=" }, input);
	}
}
