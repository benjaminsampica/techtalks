using AutoBogus;
using Bogus;

namespace FakeData
{
    public static class FakeFactory
    {
        public static User CreateFakeUserSimple()
        {
            // AutoBogus extension of Bogus
            var user = AutoFaker.Generate<User>();

            return user;
        }

        public static User CreateRealishUser()
        {
            // Bogus
            var faker = new Faker<User>();

            // Specify per-property rules.
            faker.RuleFor(user => user.Email, faker => faker.Person.Email);

            // Specify bulk rules.
            faker.Rules((faker, user) =>
            {
                // 'Person' generates great random data that is related to each other.
                // There are ton of other properties/objects for random 'real' stuff.
                user.Email = faker.Person.Email;
                user.FirstName = faker.Person.FirstName;
                user.LastName = faker.Person.LastName;
                user.FullName = faker.Person.FullName;
                user.Age = faker.Random.Number(40, 80);
            });

            return faker.Generate();
        }

        public static int RandomInteger() => AutoFaker.Generate<int>();
        public static string RandomString() => AutoFaker.Generate<string>();
    }
}
