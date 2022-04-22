using VerticalSliceArchitecture.Entities;
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


public class AddOrderCommandTests : IntegrationTestBase
{
    [Test]
    public async Task GivenAListOfProductIds_ThenTheOrderIsCreatedWithThoseProducts()
    {
        var product = CreateFakeProduct();

        var command = new AddOrderCommand
        {
            ProductIds = new List<int> { product.Id }
        };

        await SendAsync(command);

        var order = await FindFirstAsync<Order>();
        order.ReferenceNumber.Should().NotBeEmpty();
    }

    // Tests for validator, etc.
}