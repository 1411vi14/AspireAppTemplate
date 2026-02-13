using TUnit.Tests.Data;

namespace TUnit.Tests;

[ClassDataSource<DataClass>]
[ClassConstructor<DependencyInjectionClassConstructor>]
internal sealed class AndEvenMoreTests(DataClass dataClass)
{
	[Test]
	public void HaveFun()
	{
		Console.WriteLine(dataClass);
		Console.WriteLine("For more information, check out the documentation");
		Console.WriteLine("https://tunit.dev/");
	}
}