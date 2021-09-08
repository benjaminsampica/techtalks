using NUnit.Framework;
using System.Threading.Tasks;

namespace VerticalSliceArchitecture.Tests
{
    using static IntegrationTesting;

    public class IntegrationTestBase
    {
        [SetUp]
        public async Task SetUp()
        {
            await ResetState();
        }
    }
}
