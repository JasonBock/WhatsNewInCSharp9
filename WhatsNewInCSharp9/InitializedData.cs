using System;
using System.Collections.Immutable;
using System.Runtime.CompilerServices;

namespace WhatsNewInCSharp9
{
	public static class InitializedData
	{
		[ModuleInitializer]
		internal static void Initialize()
		{
			Console.Out.WriteLine($"{nameof(Initialize)} is called.");
			InitializedData.Values = new[] { 2, 4, 6 }.ToImmutableArray();
		}

		public static ImmutableArray<int> Values { get; private set; }
	}
}