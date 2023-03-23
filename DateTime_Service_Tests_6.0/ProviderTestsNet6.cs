using DateTime_Service_Example;
using FluentAssertions;
using Moq;
using System.Reflection;

namespace DateTime_Service_Tests_6._0
{
    public class ProviderTestsNet6
    {
        private Mock<IDateTimeProvider> Provider;
        private const string Now = "1776-7-4T12:00:00";

        [SetUp]
        public void Setup()
        {
            Provider = new Mock<IDateTimeProvider>();
            Provider.Setup(p => p.Now()).Returns(DateTime.Parse(Now));
        }

        [Test(Description = "Validates that the net6.0 version of DateTimeProvider was loaded over netstandard version")]
        public void FrameworkLoadedIsNet6_0()
        {
            var assembly = Assembly.GetAssembly(typeof(DateTimeProvider));
            assembly.Should().NotBeNull();
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var attribute = assembly.CustomAttributes.FirstOrDefault(a => a.NamedArguments.Any(na=>na.MemberName.Equals("FrameworkDisplayName")));
            var argument = attribute.NamedArguments.FirstOrDefault(na => na.MemberName.Equals("FrameworkDisplayName"));
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            argument.TypedValue.Value.Should().Be(".NET 6.0");
        }

        [Test]
        public void DayIsTheFourth()
        {
            var now = Provider.Object.Now();
            var day = now.Day;
            day.Should().Be(4);
        }

        [Test]
        public void MonthIsJuly()
        {
            var now = Provider.Object.Now();
            var month = now.Month;
            month.Should().Be(7); // July
        }

        [Test]
        public void YearIs1776()
        {
            var now = Provider.Object.Now();
            var year = now.Year;
            year.Should().Be(1776);
        }

        [Test]
        public void TimeShouldBeNoon()
        {
            var now = Provider.Object.Now();
            var time = now.TimeOfDay;
            time.Hours.Should().Be(12);
        }

    }
}