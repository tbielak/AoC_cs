using AoC;

namespace Year2022
{
	class Day02 : Solution
	{
		public override Output PartOne(string[] input)
		{
			int score = 0;
			foreach (var s in input)
			{
				// 1 = rock, 2 = paper, 3 = scissors
				int op = (int)s[0] - (int)'A' + 1;
				int me = (int)s[2] - (int)'X' + 1;

				if (op == me)
					score += me + 3;
				else
					score += me + (((me == 1 && op == 3) || (me == 3 && op == 2) || (me == 2 && op == 1)) ? 6 : 0);
			}

			return new(score);
		}

		public override Output PartTwo(string[] input)
		{
			int score = 0;
			foreach (var s in input)
			{
				// 1 = rock, 2 = paper, 3 = scissors
 				int op = (int)s[0] - (int)'A' + 1;
				int me = (int)s[2] - (int)'X' + 1;

				if (me == 2)
					score += op + 3;
				else
					score += ((op + (me % 3)) % 3) + (me - 1) * 3 + 1;
			}

			return new(score);
		}
	}
}
