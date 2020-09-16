using System;

public record Customer(int Age, string Name);

public record IdentifiedCustomer(Guid Id, int Age, string Name)
	: Customer(Age, Name);

public record ValuedCustomer(decimal Money, int Age, string Name)
	: Customer(Age, Name);

public record MutuableCustomer
{
	public MutuableCustomer(int age, string name) =>
		(this.Age, this.Name) = (age, name);

	// https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-9.0/init
	public int Age { get; init; }
	public string Name { get; set; }
}