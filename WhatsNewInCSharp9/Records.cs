using System;

public record Customer(int age, string name);

public record IdentifiedCustomer(Guid id, int age, string name)
	: Customer(age, name);

public record MutuableCustomer
{
	public MutuableCustomer(int age, string name) =>
		(this.Age, this.Name) = (age, name);

	public int Age { get; init; }
	public string Name { get; set; }
}