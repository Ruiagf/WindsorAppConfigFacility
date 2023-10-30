namespace AppConfigFacility.Tests.Integration
{
    using Castle.MicroKernel.Registration;
    using Castle.Windsor;
    using NUnit.Framework;
    using System.Configuration;

    [TestFixture]
    public class AppConfigFacilityComputedTests
    {
        [Test]
        public void Computed()
        {
            // Arrange
            var container = new WindsorContainer();
            container.AddFacility<AppConfigFacility>();

            // Act
            container.Register(Component.For<ITestConfig>().FromAppConfig(
                o => o.Computed(c => c.ComputedSetting, c => c.StringSetting + ":" + c.IntSetting)));

            // Assert
            var config = container.Resolve<ITestConfig>();

            var expectedResult = ConfigurationManager.AppSettings["StringSetting"] + ":" +
                                 ConfigurationManager.AppSettings["IntSetting"];
            Assert.AreEqual(expectedResult, config.ComputedSetting);
        }
    }
}
