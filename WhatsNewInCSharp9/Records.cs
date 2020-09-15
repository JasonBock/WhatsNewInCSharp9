using System;

public record Customer(int age, string name);

public record IdentifiedCustomer(Guid id, int age, string name)
	: Customer(age, name);

public record MutuableCustomer
{
	public MutuableCustomer(int age, string name) =>
		(this.Age, this.Name) = (age, name);

	// https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-9.0/init
	public int Age { get; init; }
	public string Name { get; set; }
}