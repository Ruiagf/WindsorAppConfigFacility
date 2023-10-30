﻿namespace AppConfigFacility.Tests.Unit
{
    using System;
    using Castle.MicroKernel.SubSystems.Conversion;
    using NUnit.Framework;

    [TestFixture]
    public class EnvironmentSettingsProviderTests
    {
        [Test]
        public void CanGetSettingFromEnvironment()
        {
            // Arrange
            const string expectedValue = "Test123";
            const string variableName = "AppConfigFacilityTestVar";

            Environment.SetEnvironmentVariable(variableName, expectedValue);
            var provider = new EnvironmentSettingsProvider(new DefaultConversionManager());

            // Act
            var setting = (string)provider.GetSetting(variableName, typeof(string));

            // Assert
            Assert.AreEqual(expectedValue, setting);
        }

        [Test]
        public void ReturnsNullIfEnvironmentVariableNotSet()
        {
            // Arrange
            const string variableName = "StringSetting";
            
            var provider = new EnvironmentSettingsProvider(new DefaultConversionManager());

            // Act
            var setting = (string)provider.GetSetting(variableName, typeof(string));

            // Assert
            Assert.IsNull(setting);
        }
    }
}
