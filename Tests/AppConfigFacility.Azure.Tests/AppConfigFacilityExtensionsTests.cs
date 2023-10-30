namespace AppConfigFacility.Azure.Tests
{
    using System.Linq;
    using Castle.Windsor;
    using NUnit.Framework;

    [TestFixture]
    public class AppConfigFacilityExtensionsTests
    {
        [Test]
        public void FromAzure_RegistersAzureSettingsProvider()
        {
            // Arrange
            var container = new WindsorContainer();

            // Act
            container.AddFacility<AppConfigFacility>(c => c.FromAzure());

            // Assert
            var provider = (AggregateSettingsProvider)container.Resolve<ISettingsProvider>();

            Assert.IsInstanceOf<AzureSettingsProvider>(provider.SettingsProviders.Single());
        }
    }
}
