using Bunit;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework;

namespace VerticalSliceArchitecture.Tests
{
    public class UITestBase : TestContextWrapper
    {
        private readonly Mock<IMediator> _mockMediator = new();

        [SetUp]
        public void Setup()
        {
            TestContext = new Bunit.TestContext();
            TestContext.Services.AddSingleton(_mockMediator.Object);
        }

        [TearDown]
        public void TearDown() => TestContext?.Dispose();
    }
}
