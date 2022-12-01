namespace AoC
{
	public class Repository
	{
		public Repository() => repo = new();
		public void Add(int day, int count, List<OneSolution> solutions) => repo.Add(day, (count, solutions));
		public Dictionary<int, (int, List<OneSolution>)> Get() => repo;

		private readonly Dictionary<int, (int, List<OneSolution>)> repo;
	}
}
