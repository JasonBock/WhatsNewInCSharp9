namespace WhatsNewInCSharp9
{
	// Should also implement IEquatable<ObjectNullability>...
	public sealed class ObjectNullability
	{
		public ObjectNullability(int value) => this.Value = value;

		public static bool operator ==(ObjectNullability? self, ObjectNullability? other) => true;
		public static bool operator !=(ObjectNullability? self, ObjectNullability? other) => !(self == other);

		public override bool Equals(object? obj) => 
			obj is ObjectNullability other ? this.Value == other.Value : false;

		public bool Check(object? obj) =>
			obj is ObjectNullability other ? this.Value == other.Value : false;

		public override int GetHashCode() => this.Value.GetHashCode();

		public int Value { get; }
	}
}