using System.Diagnostics.CodeAnalysis;

namespace Web.Api.Application.Tests;

internal class UnitTest1
{
	[Test]
	public void Test1()
	{
		true.Should().BeTrue().And.NotBe(false);
	}


	[Test]
	[SuppressMessage("Usage", "TUnitAssertions0005:Assert.That(...) should not be used with a constant value")]
	public async Task Test2()
	{
		await Assert.That(true).IsEqualTo(true).And.IsNotEqualTo(false);
	}
}