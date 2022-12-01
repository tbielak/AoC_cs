using AoC;

namespace Year2015
{
	class Program
	{
		static int Main(string[] args)
		{
			var names = new Dictionary<int, string> {
				{ 1, "--- Day 1: Not Quite Lisp ---" },
				{ 2, "--- Day 2: I Was Told There Would Be No Math ---" },
				{ 3, "--- Day 3: Perfectly Spherical Houses in a Vacuum ---" }
			};

			Repository repo = new();
			repo.Add(1, 2, new List<OneSolution> { new("", new Day01()) });
			repo.Add(2, 2, new List<OneSolution> { new("", new Day02()) });
			repo.Add(3, 2, new List<OneSolution> { new("", new Day03()) });

			Engine engine = new(2015, names, repo);
			return engine.Run(args);
		}
	}
}
