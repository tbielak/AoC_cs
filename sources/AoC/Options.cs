namespace AoC
{
	class Options
	{
		public Options(string[] args)
		{
			colors = true;
			help = false;
			available = false;
			speed = 0;
			day = -1;
			solution = -1;
			input_filename = "";

			for (int i = 0; i < args.Length; i++)
			{
				string x = args[i];
				if (x == "-c")
					colors = false;

				if (x == "-h")
					help = true;

				if (x == "-a")
					available = true;

				if (x == "-s")
				{
					speed = 10;
					if (args.Length > i + 1)
					{
						i++;
						speed = ParseInt(args[i], 0);
						if (speed == 0)
						{
							speed = 10;
							i--;
						}
					}
				}

				if (x == "-p" && args.Length > i + 1)
				{
					i++;
					string[] subs = args[i].Split(':');
					day = ParseInt(subs[0], -1);
					solution = (subs.Length == 1) ? -1 : ParseInt(subs[1], -1) - 1;
				}

				if (x == "-i" && args.Length > i + 1)
				{
					i++;
					input_filename = args[i];
				}
			}
		}

		private int ParseInt(string s, int default_value)
		{
			int value;
			if (int.TryParse(s, out value))
				return value;

			return default_value;
		}

		public bool colors { get; }
		public bool help { get; }
		public bool available { get; }
		public int speed { get; }
		public int day { get; }
		public int solution { get; }
		public string input_filename { get; }
	}
}
