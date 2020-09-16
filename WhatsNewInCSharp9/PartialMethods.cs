namespace WhatsNewInCSharp9
{
	public partial class PartialMethods
	{
		// This was the way it always was
		//partial void Calculate();

		// Now you can declare accessibility and return values:
		// Returning a value requires accessibility declaration.
		// Partial methods with accessibility require an implementation.
		public partial int Calculate();
	}

	public partial class PartialMethods
	{
		public partial int Calculate() => 10;
	}
}