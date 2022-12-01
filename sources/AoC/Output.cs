namespace AoC
{
	public class Output
	{
		public Output() => Contents = new();

		public Output(int value) => Contents = new() { value.ToString() };
		public Output(long value) => Contents = new() { value.ToString() };
		public Output(string value) => Contents = new() { value };
		public Output(int v1, int v2) => Contents = new() { v1.ToString(), v2.ToString() };

		public bool Empty() => Contents.Count == 0;
		public void Add(Output input) => Contents.AddRange(input.Contents);

		public void Copy(Output other) => Contents = new(other.Contents);

		public List<string> Contents { get; set; }
	}
}
