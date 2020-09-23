#pragma warning disable CS8321 // Local function is declared but never used
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using WhatsNewInCSharp9;

// Note that this is showing the top-level statements feature.
// https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-9.0/top-level-statements

//DemonstrateRecords();
//DemonstrateTargetTypeNew();
//DemonstrateModuleInitializer();
//DemonstrateLocalsInitFlag();
//DemonstrateNumberTypes();

// WARNING: Show the code, but DO NOT run this until at least RC2!
//DemonstrateCovariantReturnTypes();

//DemonstrateStaticAnonymousMethods();
//DemonstrateLocalFunctionAttributes();
//DemonstrateDiscardsInLambdas();
//DemonstrateFunctionPointers();
//DemonstrateBetterConditionalExpressions();
//DemonstratePartialMethodSignatures();
//DemonstratePatternMatchingEnhancements();
//DemonstrateGetEnumeratorExtension();
DemonstrateSourceGenerators();

// https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-9.0/records
void DemonstrateRecords()
{
	var customer = new Customer(22, "Jane");
	Console.Out.WriteLine(customer);
	Console.Out.WriteLine($"customer.age = {customer.Age}, customer.name = {customer.Name}");
	// This won't work...
	//customer.Age = 44;
	var (age, name) = customer;
	Console.Out.WriteLine($"age = {age}, name = {name}");

	var customerWithDifferentName = customer with { Name = "Joe" };
	Console.Out.WriteLine(
		$"customerWithDifferentName.age = {customerWithDifferentName.Age}, customerWithDifferentName.name = {customerWithDifferentName.Name}");

	var mutuableCustomer = new MutuableCustomer
	{
		Age = 33,
		Name = "Jeff"
	};

	Console.Out.WriteLine($"mutuableCustomer.Age = {mutuableCustomer.Age}, mutuableCustomer.Name = {mutuableCustomer.Name}");
	mutuableCustomer.Name = "Julie";
	Console.Out.WriteLine($"mutuableCustomer.Age = {mutuableCustomer.Age}, mutuableCustomer.Name = {mutuableCustomer.Name}");

	// Use ILSpy to see how equality is generated.
	var secondCustomer = new Customer(22, "Jane");
	Console.Out.WriteLine($"secondCustomer == customer is {secondCustomer == customer}");
}

// https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-9.0/target-typed-new
void DemonstrateTargetTypeNew()
{
	Customer customer = new(35, "Jane");
	var wrapper = new WrappedDictionary();
	wrapper.Add(customer.Age, customer.Name);
}

// https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-9.0/module-initializers
void DemonstrateModuleInitializer()
{
	Console.Out.WriteLine($"{nameof(DemonstrateModuleInitializer)} is called.");
	Console.Out.WriteLine(InitializedData.Values.Sum());
}

// https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-9.0/skip-localsinit
// https://devblogs.microsoft.com/dotnet/performance-improvements-in-net-5/#jit
//[SkipLocalsInit]
unsafe void DemonstrateLocalsInitFlag()
{
	Guid g;
	Console.Out.WriteLine(*&g);
}

// https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-9.0/native-integers
// https://devblogs.microsoft.com/dotnet/introducing-the-half-type/
void DemonstrateNumberTypes()
{
	// Can also use nuint
	nint value = 41;
	Console.Out.WriteLine(value.GetType().Name);

	var halfOfValue = (Half)22.2;
	var halfOfValueTruncated = (Half)22.24537189074831;
	Console.Out.WriteLine(halfOfValue);
	Console.Out.WriteLine(halfOfValueTruncated);
}

// https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-9.0/covariant-returns
void DemonstrateCovariantReturnTypes()
{
	var pipeline = new CustomPipeline();
	pipeline = pipeline.AddIdentifier(Guid.NewGuid())
		.AddName("Jason");

	var configuration = pipeline.GetConfiguration();
	Console.Out.WriteLine($"{configuration.Id}, {configuration.Name}");
}

// https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-9.0/static-anonymous-functions
void DemonstrateStaticAnonymousMethods()
{
	var value = 42;
	var values = new[] { 2, 4, 6 };

	Console.Out.WriteLine(values.Any(_ =>
	{
		if (_ != value)
		{
			value = _;
		}

		return _ == value;
	}));
	Console.Out.WriteLine(value);

	// Can't do this:
	/*
	Console.Out.WriteLine(values.Any(static _ =>
	{
		if (_ != value)
		{
			value = _;
		}

		return _ == value;
	}));
	*/

	const int constValue = 42;
	Console.Out.WriteLine(values.Any(static _ => _ == constValue));
}

// https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-9.0/local-function-attributes
void DemonstrateLocalFunctionAttributes()
{
	//[Obsolete("Use + instead")]
	static int Add(int a, int b) => a + b;

	Console.Out.WriteLine(Add(2, 3));
}

// https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-9.0/lambda-discard-parameters
void DemonstrateDiscardsInLambdas()
{
	static void CanContinue(Func<string, Dictionary<Guid, Customer>, bool> evaluation) => 
		Console.Out.WriteLine(evaluation("Value", new()) ? "Yes" : "No");

	CanContinue((_, _) => true);
}

// https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-9.0/function-pointers
unsafe void DemonstrateFunctionPointers() =>
	PointingToFunctions.Invoke(
		PointingToFunctions.Target,
		&PointingToFunctions.Target);

// https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-9.0/target-typed-conditional-expression
void DemonstrateBetterConditionalExpressions()
{
	var identifiedCustomer = new IdentifiedCustomer(Guid.NewGuid(), 22, "Josh");
	var valuedCustomer = new ValuedCustomer(100_000_000M, 18, "Jane");

	// Cannot use "var winner" here.
	Customer winner = new Random().Next(2) == 0 ? identifiedCustomer : valuedCustomer;

	Console.Out.WriteLine($"Winner is {winner.Name}");
}

// https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-9.0/extending-partial-methods
void DemonstratePartialMethodSignatures() => 
	Console.Out.WriteLine(new PartialMethods().Calculate());

// https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-9.0/patterns3
// https://devblogs.microsoft.com/dotnet/welcome-to-c-9-0/#logical-patterns
void DemonstratePatternMatchingEnhancements()
{
	Console.Out.WriteLine($"3 is {Qwirkle.Qualify(3)}");
	Console.Out.WriteLine($"12 is {Qwirkle.Qualify(12)}");
	Console.Out.WriteLine($"19 is {Qwirkle.Qualify(19)}");
	Console.Out.WriteLine($"72 is {Qwirkle.Qualify(72)}");
	Console.Out.WriteLine($"-2 is {Qwirkle.Qualify(-2)}");
	Console.Out.WriteLine($"100 is {Qwirkle.Qualify(100)}");

	var nullability = new ObjectNullability(3);
	Console.Out.WriteLine($"nullability.Equals(new ObjectNullability(3)) : {nullability.Equals(new ObjectNullability(3))}");
	Console.Out.WriteLine($"nullability.Equals(null) : {nullability.Equals(null)}");
	Console.Out.WriteLine();
	Console.Out.WriteLine($"nullability != null : {nullability != null}");
	Console.Out.WriteLine($"nullability is {{ }} : {nullability is { }}");
	Console.Out.WriteLine($"nullability is not null : {nullability is not null}");
}

// https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-9.0/extension-getenumerator
void DemonstrateGetEnumeratorExtension()
{
	var valuedCustomer = new ValuedCustomer(100_000_000M, 18, "Jane");

	foreach (var value in valuedCustomer)
	{
		Console.Out.WriteLine(value);
	}
}

// https://devblogs.microsoft.com/dotnet/introducing-c-source-generators/
// https://devblogs.microsoft.com/dotnet/new-c-source-generator-samples/
void DemonstrateSourceGenerators()
{
	var source = new Source
	{
		Amount = 33M,
		Id = Guid.NewGuid(),
		Value = 10
	};

	var destination = source.MapToDestination();

	Console.Out.WriteLine($"{nameof(destination)}.{nameof(Destination.Id)} = {destination.Id}");
	Console.Out.WriteLine($"{nameof(destination)}.{nameof(Destination.Value)} = {destination.Value}");
}
#pragma warning restore CS8321 // Local function is declared but never used
