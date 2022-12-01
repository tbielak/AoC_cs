using AoC;

namespace Year2021
{
	class Day02 : Solution
	{
		public static List<(char, int)> Load(string[] input)
		{
			List<(char, int)> course = new();
			foreach (var line in input)
			{
				string[] s = line.Split(' ');
				course.Add(new(s[0][0], int.Parse(s[1])));
			}

			return course;
		}

		public override Output PartOne(string[] input)
		{
			var course = Load(input);

			long position = 0, depth = 0;
			foreach (var (command, units) in course)
			{
				switch (command)
				{
					case 'd': depth += units; break;
					case 'u': depth -= units; break;
					default: position += units; break;
				}
			}

			return new(position * depth);
		}

		public override Output PartTwo(string[] input)
		{
			var course = Load(input);

			long position = 0, depth = 0, aim = 0;
			foreach (var (command, units) in course)
			{
				switch (command)
				{
					case 'd': aim += units; break;
					case 'u': aim -= units; break;
					default:
					{
						position += units;
						depth += aim * units;
						break;
					}
				}
			}

			return new(position * depth);
		}
	}
}
