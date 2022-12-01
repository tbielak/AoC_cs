using AoC;

namespace Year2018
{
	class Program
	{
		static int Main(string[] args)
		{
			var names = new Dictionary<int, string> {
				{ 1, "--- Day 1: Chronal Calibration ---" },
				{ 2, "--- Day 2: Inventory Management System ---" },
				{ 3, "--- Day 3: No Matter How You Slice It ---" }
			};

			Repository repo = new();
			repo.Add(1, 2, new List<OneSolution> { new("", new Day01()) });
			repo.Add(2, 2, new List<OneSolution> { new("", new Day02()) });
			repo.Add(3, 2, new List<OneSolution> { new("", new Day03()) });

			Engine engine = new(2018, names, repo);
			return engine.Run(args);
		}
	}
}
