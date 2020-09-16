using System;

namespace WhatsNewInCSharp9
{
	unsafe public static class PointingToFunctions
	{
		public static void Invoke(Action<int> a, delegate*<int, void> f)
		{
			a(42);
			f(42);
		}

		public static void Target(int value) => Console.Out.WriteLine(value);
	}
}