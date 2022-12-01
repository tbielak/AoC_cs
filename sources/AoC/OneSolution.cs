namespace AoC
{
	public class OneSolution
	{
		public OneSolution(string description, Solution solution)
		{
			this.Description = description;
			this.Solution = solution;
		}

		public string Description { get; }
		public Solution Solution { get; }
	}
}
