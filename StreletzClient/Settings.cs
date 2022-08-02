using System.Configuration;

namespace StreletzAPI
{
    internal class Settings
    {       

        public static readonly string AllowedToBroadcastEventsCommon =
            ConfigurationManager.AppSettings["AllowedToBrodcastEventsCommon"];
        public static readonly string AllowedToBroadcastEventsConfigurator =
            ConfigurationManager.AppSettings["AllowedToBrodcastEventsConfigurator"];
        public static readonly string AllowedToBroadcastEventsGeoData =
            ConfigurationManager.AppSettings["AllowedToBrodcastEventsGeoData"];
        public static readonly string AllowedToBroadcastEventsAnalogValues =
            ConfigurationManager.AppSettings["AllowedToBrodcastEventsAnalogValues"];

        public static readonly string IsSslMode =
            ConfigurationManager.AppSettings["IsSslMode"];

    }
}
