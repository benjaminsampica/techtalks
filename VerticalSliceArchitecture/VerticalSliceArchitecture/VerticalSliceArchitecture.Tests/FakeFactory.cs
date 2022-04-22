using VerticalSliceArchitecture.Entities;

namespace VerticalSliceArchitecture.Tests;

internal static class FakeFactory
{
    public static Product CreateFakeProduct()
    {
        var fakeProduct = new AutoFaker<Product>()
            .Ignore(p => p.Id);

        return fakeProduct.Generate();
    }

    public static Order CreateFakeOrder()
        => AutoFaker.Generate<Order>();
}
