using Bunit;
using VerticalSliceArchitecture.Features.AddOrder;

namespace VerticalSliceArchitecture.Tests.Features.AddOrder;

public class AddOrderPageTests : UITestBase
{
    [Test]
    public void IAmAPointlessTest_ToDemonstrateUITesting()
    {
        var cut = TestContext.RenderComponent<AddOrderPage>();

        cut.Markup.Contains("form").Should().BeTrue();
    }
}
