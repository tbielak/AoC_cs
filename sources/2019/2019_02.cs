using AoC;

namespace Year2019
{
	class IntcodeVM
	{
		public static Dictionary<int, int> Parse(string input)
		{
			Dictionary<int, int> memory = new();
			int[] code = Array.ConvertAll(input.Split(','), s => int.Parse(s));
			for (int i = 0; i < code.Length; i++)
				memory[i] = code[i];

			return memory;
		}

		public IntcodeVM(Dictionary<int, int> input) => memory = new(input);
		public void Patch(int address, int value) => memory[address] = value;
		public int Peek(int address) => memory[address];

		public void Run()
		{
			while (true)
			{
				Operation op = (Operation)memory[ip++];
				switch (op)
				{
					case Operation.addition: { Store(Fetch() + Fetch()); break; }
					case Operation.multiplication: { Store(Fetch() * Fetch()); break; }
					case Operation.halt: return;
					default: throw new ArgumentOutOfRangeException("unsupported operation");
				}
			}
		}
		private int Fetch() => memory[memory[ip++]];
		private void Store(int v) => memory[memory[ip++]] = v;

		private int ip;
		private Dictionary<int, int> memory;
		enum Operation { addition = 1, multiplication = 2, halt = 99 };
	}

	class Day02 : Solution
	{
		public override Output PartOne(string input)
		{
			IntcodeVM vm = new(IntcodeVM.Parse(input));
			vm.Patch(1, 12);
			vm.Patch(2, 2);
			vm.Run();
			return new(vm.Peek(0));
		}

		public override Output PartTwo(string input)
		{
			var program = IntcodeVM.Parse(input);

			for (int noun = 0; noun <= 100; noun++)
			{
				for (int verb = 0; verb <= 100; verb++)
				{
					IntcodeVM vm = new(program);
					vm.Patch(1, noun);
					vm.Patch(2, verb);
					vm.Run();
					if (19690720 == vm.Peek(0))
						return new(100 * noun + verb);
				}
			}

			return new(-1);
		}
	}
}
