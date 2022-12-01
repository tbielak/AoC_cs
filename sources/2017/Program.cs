using AoC;

namespace Year2017
{
	class Program
	{
		static int Main(string[] args)
		{
			var names = new Dictionary<int, string> {
				{ 1, "--- Day 1: Inverse Captcha ---" },
				{ 2, "--- Day 2: Corruption Checksum ---" },
				{ 3, "--- Day 3: Spiral Memory ---" }
			};

			Repository repo = new();
			repo.Add(1, 2, new List<OneSolution> { new("", new Day01()) });
			repo.Add(2, 2, new List<OneSolution> { new("", new Day02()) });
			repo.Add(3, 2, new List<OneSolution> { new("", new Day03()) });

			Engine engine = new(2017, names, repo);
			return engine.Run(args);
		}
	}
}
