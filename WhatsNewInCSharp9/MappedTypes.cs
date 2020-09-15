using InlineMapping;
using System;

namespace WhatsNewInCSharp9
{
	[MapTo(typeof(Destination))]
	public sealed class Source
	{
		public decimal Amount { get; set; }
		public Guid Id { get; set; }
		public int Value { get; set; }
	}

	public sealed class Destination
	{
		public Guid Id { get; set; }
		public int Value { get; set; }
	}
}