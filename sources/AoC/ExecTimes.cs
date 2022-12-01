namespace AoC
{
	public class ExecTimes
	{
		public ExecTimes() => Mslist = new List<double>();
		public void Add(double s) => Mslist.Add(s);
		public void Add(TimeSpan ts) => Mslist.Add(ts.TotalSeconds * 1000);
		public List<double> Mslist { get; }
	}
}
