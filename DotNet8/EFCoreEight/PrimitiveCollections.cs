namespace EFCoreEight;

public class PrimitiveCollection
{
    public int Id { get; set; }
    // serialized as json.
    public required IEnumerable<int> Ints { get; set; }
    public required ICollection<string> Strings { get; set; }
    public required IList<DateOnly> Dates { get; set; }
    public required uint[] UnsignedInts { get; set; }
    public required List<bool> Booleans { get; set; }
    public required List<Uri> Urls { get; set; }
}

public class PrimitiveCollectionTests : TestBase
{
    [Test]
    public async Task AddPrimitiveCollection()
    {
        var primitiveCollection = new PrimitiveCollection
        {
            Ints = [1, 2, 3],
            Strings = ["Hi"],
            Dates = [DateOnly.MaxValue],
            UnsignedInts = [1],
            Booleans = [true, false],
            Urls = [new Uri("https://www.google.com")]
        };

        var dbContext = GetRequiredService<TestDbContext>();
        dbContext.PrimitiveCollections.Add(primitiveCollection);
        await dbContext.SaveChangesAsync();
    }
}