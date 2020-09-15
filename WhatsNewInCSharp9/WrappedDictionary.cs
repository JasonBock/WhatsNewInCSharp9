using System.Collections.Generic;

namespace WhatsNewInCSharp9
{
	public sealed class WrappedDictionary
	{
		private readonly Dictionary<int, string> data = new();

		public void Add(int key, string value) => this.data.Add(key, value);
	}
}