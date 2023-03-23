using DateTime_Service_Example;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Linq;
using System.Reflection;

namespace DateTime_Service_Test_4._8
{
    public class ProviderTests
    {
        private Mock<IDateTimeProvider> Provider;
        private const string Now = "1776-7-4T12:00:00";

        [SetUp]
        public void Setup()
        {
            Provider = new Mock<IDateTimeProvider>();
            Provider.Setup(p => p.Now()).Returns(DateTime.Parse(Now));
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