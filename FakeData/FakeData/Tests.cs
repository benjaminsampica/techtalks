using NUnit.Framework;
using System.Diagnostics;
using System.Threading.Tasks;

namespace FakeData
{
    using static FakeFactory;

    public class Tests
    {
        [Test]
        public void RandomRawFakes()
        {
            Debug.WriteLine(CreateFakeUserSimple().ToString());
            Debug.WriteLine(CreateRealishUser().ToString());
        }

        [Test]
        public void GivenUserWithInvalidEmail_ThenReturnsFalse()
        {
            var user = CreateFakeUserSimple();
            user.Email = null;

            var result = UserEmailValidator.IsValidEmail(user);

            Assert.IsFalse(result);
        }

        [Test]
        public async Task SeedDataFakes()
        {
            var sut = new SeedDataService();

            var users = await sut.SeedAsync();

            foreach (var user in users)
            {
                Debug.WriteLine(user.ToString());

                Assert.IsNotEmpty(user.Email);
                Assert.IsNotEmpty(user.FirstName);
                Assert.IsNotEmpty(user.LastName);
                Assert.IsNotEmpty(user.FullName);
            }
        }
    }
}