using Microsoft.EntityFrameworkCore;

namespace TestContainersDotNet8;

public class Tests : IntegrationTestBase
{
    [Test]
    public async Task Test1()
    {
        var dbContext = GetRequiredService<TestDbContext>();

        dbContext.Users.Add(new User { Name = "Test" });
        await dbContext.SaveChangesAsync();

        var user = await dbContext.Users.SingleAsync();
        Assert.That(user is not null);
    }
}