using System.Collections.Generic;

namespace WhatsNewInCSharp9
{
	public static class EnumerationExtensions
	{
		public static IEnumerator<object> GetEnumerator(this ValuedCustomer self)
		{
			yield return self.Name;
			yield return self.Age;
			yield return self.Money;
		}
	}
}