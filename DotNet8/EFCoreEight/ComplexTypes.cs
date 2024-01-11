using EFCoreEight;
using System.ComponentModel.DataAnnotations.Schema;

namespace EfCoreEight;

[ComplexType]
public class Address
{
    public required string Line1 { get; set; }
    public string? Line2 { get; set; }
    public required string City { get; set; }
    public required string Country { get; set; }
    public required string PostCode { get; set; }
}

public class User
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required Address Address { get; set; }
}

public class OwnedTypesTests : TestBase
{
    [Test]
    public async Task AddOwnedTypes()
    {
        var user = new User
        {
            Name = "Willow",
            Address = new() { Line1 = "Barking Gate", City = "Walpole St Peter", Country = "UK", PostCode = "PE14 7AV" }
        };

        var dbContext = GetRequiredService<TestDbContext>();
        dbContext.Users.Add(user);
        await dbContext.SaveChangesAsync();
    }
}