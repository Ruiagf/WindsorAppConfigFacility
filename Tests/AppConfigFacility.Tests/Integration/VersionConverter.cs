namespace AppConfigFacility.Tests.Integration
{
    using Castle.Core.Configuration;
    using System;

    [Serializable]
    public class VersionConverter : AbstractTypeConverter
    {
        public override bool CanHandleType(Type type)
        {
            return type == typeof(Version);
        }

        public override object PerformConversion(string value, Type targetType)
        {
            return Version.Parse(value);
        }

        public override object PerformConversion(IConfiguration configuration, Type targetType)
        {
            return PerformConversion(configuration.Value, targetType);
        }
    }
}