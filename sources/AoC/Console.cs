using System.Runtime.InteropServices;

namespace AoC
{
	class Console
	{
		// See Setup() below -> enabling Console Virtual Terminal Sequences in Windows.
		// Feature supported by cmd.exe and conhost.exe starting from Windows 10 TH2 v1511.

		private const int STD_OUTPUT_HANDLE = -11;
		private const uint ENABLE_VIRTUAL_TERMINAL_PROCESSING = 0x0004;
		private const uint DISABLE_NEWLINE_AUTO_RETURN = 0x0008;

		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern IntPtr GetStdHandle(int nStdHandle);

		[DllImport("kernel32.dll")]
		private static extern bool GetConsoleMode(IntPtr hConsoleHandle, out uint lpMode);

		[DllImport("kernel32.dll")]
		private static extern bool SetConsoleMode(IntPtr hConsoleHandle, uint dwMode);
		public void Setup(bool colors_enabled)
		{
			this.colors_enabled = colors_enabled;
			if (!colors_enabled)
				return;

			var iStdOut = GetStdHandle(STD_OUTPUT_HANDLE);
			if (!GetConsoleMode(iStdOut, out uint outConsoleMode))
			{
				colors_enabled = false;
				return;
			}

			outConsoleMode |= ENABLE_VIRTUAL_TERMINAL_PROCESSING | DISABLE_NEWLINE_AUTO_RETURN;
			if (!SetConsoleMode(iStdOut, outConsoleMode))
			{
				colors_enabled = false;
				return;
			}
		}

		public void WriteLine() => System.Console.WriteLine();

		public void WriteLine(string s)
		{
			if (colors_enabled)
				s = s.Replace("{d}", "\x1B[0m").Replace("{y}", "\x1B[93m").Replace("{w}", "\x1B[97m")
					.Replace("{g}", "\x1B[92m").Replace("{r}", "\x1B[91m");
			else
				s = s.Replace("{d}", "").Replace("{y}", "").Replace("{w}", "")
					.Replace("{g}", "").Replace("{r}", "");

			System.Console.WriteLine(s);
		}

		private bool colors_enabled;
	}
}
