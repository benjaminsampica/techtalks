using BlazorTechTalk.BlazorUI.Pages;
using BlazorTechTalk.Shared.Application;
using Bunit;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework;
using System;
using System.Threading;
using TestContext = Bunit.TestContext;

namespace BlazorTechTalk.Tests.BlazorUI.Pages
{
    public class WeatherForecastFormTests : TestContext
    {
        [Test]
        public void WhenFirstRendered_ThenRendersAsExpected()
        {
            Services.AddSingleton(Mock.Of<IMediator>());
            var sut = RenderComponent<WeatherForecastForm>();

            var summaryLabel = sut.Find("label");
            summaryLabel.TextContent.Should().Be("Summary");

            var summary = sut.FindComponent<InputText>();
            summary.Instance.AdditionalAttributes.Should().Contain(aa => aa.Key == "placeholder" && aa.Value == "Enter a summary...");
        }

        [Test]
        public void GivenFormIsFilledOutCorrectly_WhenSubmitButtonIsClicked_ThenSubmitsFormData()
        {
            // Arrange.
            var mockMediator = new Mock<IMediator>();
            Services.AddSingleton(mockMediator.Object);
            var sut = RenderComponent<WeatherForecastForm>();

            var stubDateValue = "3000-01-01";
            var date = sut.Find("input[type='date']");
            date.Change(stubDateValue);

            var chilly = "Chilly";
            var summary = sut.FindComponent<InputText>();
            sut.InvokeAsync(() => summary.Instance.ValueChanged.InvokeAsync(chilly));

            var thirtyDegreesCelsius = 30;
            var temperature = sut.FindComponent<InputNumber<int>>();
            sut.InvokeAsync(() => temperature.Instance.ValueChanged.InvokeAsync(thirtyDegreesCelsius));

            var form = sut.Find("form");

            // Act.
            form.Submit();

            // Assert.
            mockMediator.Verify(m => m.Send(new WeatherForecastFormCommand { Date = DateTime.Parse(stubDateValue), Summary = chilly, TemperatureC = thirtyDegreesCelsius }, CancellationToken.None), Times.Once);
        }
    }
}
