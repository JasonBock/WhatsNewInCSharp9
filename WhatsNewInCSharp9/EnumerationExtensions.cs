using System;
using System.Collections.Generic;

namespace WhatsNewInCSharp9
{
	//public class Stuff
	//{
	//	public Guid Id { get; set; }
	//	public int Value { get; set; }

	//	public IEnumerator<object> GetEnumerator()
	//	{
	//		yield return this.Id;
	//		yield return this.Value;
	//	}
	//}

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