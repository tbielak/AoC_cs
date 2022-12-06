using AoC;

namespace Year2022
{
	class Program
	{
		static int Main(string[] args)
		{
			var names = new Dictionary<int, string> {
				{ 1, "--- Day 1: Calorie Counting ---" },
				{ 2, "--- Day 2: Rock Paper Scissors ---" },
				{ 3, "--- Day 3: Rucksack Reorganization ---" }
			};

			Repository repo = new();
			repo.Add(1, 2, new List<OneSolution> { new("", new Day01()) });
			repo.Add(2, 2, new List<OneSolution> { new("", new Day02()) });
			repo.Add(3, 2, new List<OneSolution> { new("", new Day03()) });

			Engine engine = new(2022, names, repo);
			return engine.Run(args);
		}
	}
}
