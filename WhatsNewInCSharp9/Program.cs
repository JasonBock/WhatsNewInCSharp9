#pragma warning disable CS8321 // Local function is declared but never used
using System;
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
DemonstrateCovariantReturnTypes();
//DemonstrateStaticAnonymousMethods();
//DemonstrateLocalFunctionAttributes();
//DemonstrateDiscardsInLambdas();
//DemonstrateFunctionPointers();
//DemonstrateBetterConditionalExpressions();
//DemonstratePartialMethodSignatures();
//DemonstratePatternMatchingEnhancements();
//DemonstrateGetEnumeratorExtension();
//DemonstrateSourceGenerators();

// https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-9.0/records
void DemonstrateRecords()
{
	var customer = new Customer(22, "Jane");
	Console.Out.WriteLine(customer);
	Console.Out.WriteLine($"customer.age = {customer.age}, customer.name = {customer.name}");
	// This won't work...
	// customer.age = 44;
	var (age, name) = customer;
	Console.Out.WriteLine($"age = {age}, name = {name}");

	var customerWithDifferentName = customer with { name = "Joe" };
	Console.Out.WriteLine(
		$"customerWithDifferentName.age = {customerWithDifferentName.age}, customerWithDifferentName.name = {customerWithDifferentName.name}");

	var mutuableCustomer = new MutuableCustomer(33, "Jeff");
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
	wrapper.Add(customer.age, customer.name);
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

}

// https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-9.0/function-pointers
void DemonstrateFunctionPointers()
{

}

// https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-9.0/target-typed-conditional-expression
void DemonstrateBetterConditionalExpressions()
{

}

// https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-9.0/extending-partial-methods
void DemonstratePartialMethodSignatures()
{

}

// https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-9.0/patterns3
// https://devblogs.microsoft.com/dotnet/welcome-to-c-9-0/#logical-patterns
void DemonstratePatternMatchingEnhancements()
{

}

// https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-9.0/extension-getenumerator
void DemonstrateGetEnumeratorExtension()
{

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

	//var destination = source.MapToDestination();
}
#pragma warning restore CS8321 // Local function is declared but never used