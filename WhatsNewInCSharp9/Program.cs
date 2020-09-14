using System;
using System.Collections.Generic;

DemonstrateRecords();
DemonstrateTargetTypeNew();

void DemonstrateRecords()
{
	var customer = new Customer(22, "Jane");
	Console.Out.WriteLine(customer);
	// This won't work...
	// customer.age = 44;

	var customerWithDifferentName = customer with { name = "Joe" };
	Console.Out.WriteLine(customerWithDifferentName);

	var mutuableCustomer = new MutuableCustomer(33, "Jeff");
	mutuableCustomer.Name = "Julie";
	Console.Out.WriteLine(mutuableCustomer);
}

void DemonstrateTargetTypeNew()
{
	Customer customer = new(35, "Jane");
	var wrapper = new WrappedDictionary();
	wrapper.Add(customer.age, customer.name);
}

public record Customer(int age, string name);

public record MutuableCustomer
{
	public MutuableCustomer(int age, string name) =>
		(this.Age, this.Name) = (age, name);

	public int Age { get; init; }
	public string Name { get; set; }
}

public sealed class WrappedDictionary
{
	private readonly Dictionary<int, string> data = new();

	public void Add(int key, string value) => this.data.Add(key, value);
}