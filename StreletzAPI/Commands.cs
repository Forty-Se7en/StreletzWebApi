namespace StreletzAPI
{
    public class Commands
    {
        /// <summary> Команды управления разделами </summary>
        public class Part
        {
            /// <summary> Снять с охраны </summary>
            public const string Disarm = "F989BE22-3743-4381-87E2-0AB6C4354172";

            /// <summary> Поставить на охрану </summary>
            public const string Arm = "1F9ECC39-C49E-4B41-A809-A1D7BAD867A2";

            /// <summary> 'Перевзять' на охрану </summary>
            public const string Rearm = "19437BE8-24DB-469E-813C-4A06C1D6472D";

            /// <summary> Сбросить неисправности </summary>
            public const string DropProblems = "49986087-D147-47BA-925F-5496F79060E9";
        }

        /// <summary> Команды управления группами разделов </summary>
        public class PartGroup
        {
            /// <summary> Снять с охраны </summary>
            public const string Disarm = "1B12ED1F-3A01-4712-B697-AB126B015D95";

            /// <summary> Поставить на охрану </summary>
            public const string Arm = "080EC455-612A-40BB-9D4C-63ED25712262";

            /// <summary> 'Перевзять' на охрану </summary>
            public const string Rearm = "50958397-D303-4929-B6BF-9ACD2ED2683B";

            /// <summary> Сбросить неисправности </summary>
            public const string DropProblems = "06DD0066-303A-4956-8D83-C4F57374EB65";
        }

        /// <summary> Управление группами исполнительных устройств </summary>
        public class ExecutingDeviceGroup
        {
            /// <summary> Отключить </summary>
            public const string TurnOn = "4D736AD2-3857-4134-8C61-01FAB0AA9F01";

            /// <summary> Включить </summary>
            public const string TurnOff = "3C33279F-241A-42AB-B4F5-9D4914517AE2";

            /// <summary> Стоп всех выходов </summary>
            public const string StopAllExits = "EA074E25-A9C1-4314-B21E-44BF0944EB95";

            /// <summary> Старт всех выходов </summary>
            public const string StartAllExits = "3E557B3A-CB9D-46FE-82A0-16E688BF697F";

            /// <summary> Старт выхода </summary>
            public const string StartExit = "EEE6EAD5-0C0E-48C1-BA41-598E4552EC40";

        }

        /// <summary> Управление зонами геолокации </summary>
        public class LocationZone
        {
            /// <summary> Отключить </summary>
            public const string TurnOn = "8B2A9C3C-FCE0-4AC7-A198-BEDD532E9ADF";

            /// <summary> Включить </summary>
            public const string TurnOff = "817CB026-A4F3-487A-A66D-D6C894269D43";
        }

        /// <summary> Управление браслетами </summary>
        public class Wristband
        {
            /// <summary> Отправить SMS </summary>
            public const string SendMessage = "033D0402-3A3A-4BEC-9930-B50C021B6C53";

            /// <summary> Включить режим работы "Браслет" </summary>
            public const string ModeWristbandEnable = "F9B3B0EB-7A85-4C12-B8CF-0A59AF5D51C4";

            /// <summary> Включить режим работы "Детектор движения" </summary>
            public const string ModeMotionDetectorEnable = "DE115F5D-0CFD-4C8E-9BA0-80A57D5DC199";

            /// <summary> Выключить режим локации </summary>
            public const string ModeLocationDisable = "F33E093A-1D97-4AF2-8F7B-6BBE609FC0B6";

            /// <summary> Выключить режимы локации и контроля неподвижности </summary>
            public const string ModeLocationAndImmobilityDisable = "9A3D9330-B469-49AB-AB88-79C26B3A545E";

            /// <summary> Выключить контроль неподвижности </summary>
            public const string ModeImmobilityDisable = "1AC89F2C-E6C2-4801-BA87-D9101A1E5DAC";

            /// <summary> Включить режим локации </summary>
            public const string SModeLocationEnableendSMS = "C2BE7A9C-1968-46CD-8B6C-D490249A251F";

            /// <summary> Включить режимы локации и контроля неподвижности </summary>
            public const string ModeLocationAndImmobilityEnable = "54A48A68-2B4D-43C3-BA8C-2037E3633F36";

            /// <summary> Включить контроль неподвижности </summary>
            public const string ModeImmobilityEnable = "BB4226F4-9A33-490D-A9EF-FF57C721BC01";

            /// <summary> Сигнал: моргание светодиодами </summary>
            public const string LEDBlinking = "175E7ADB-C34B-49CC-8174-5986CDFFFFB5";
        }

        /// <summary> Управление интегральными устройствами линии S2 </summary>
        public class IntegratedDeviceS2Line
        {
            /// <summary> Сигнал: моргание светодиодами </summary>
            public const string LEDBlinking = "FBB45A1A-5AB7-4CB6-99C3-65FE27F95116";

            /// <summary> Перезапустить </summary>
            public const string Restart = "5C7742F7-F2D5-4D70-B7B8-CE5F2576ED7F";
        }

        /// <summary> Управление устройствами радиосистемы Стрелец-ПРО </summary>
        public class RadioSystemStreletsPRO
        {
            /// <summary> Сигнал: моргание светодиодами </summary>
            public const string LEDBlinking = "175E7ADB-C34B-49CC-8174-5986CDFFFFB5";

            /// <summary> Включить зеленый индикатор </summary>
            public const string TurnOnGreenIndicator = "B712CA47-6D9B-40F3-9612-4DD182F6F350";

            /// <summary> Включить красный индикатор </summary>
            public const string TurnOnRedIndicator = "48DEB14E-4148-4B6A-9CEC-054C43E46001";

            /// <summary> Отключить индикацию </summary>
            public const string TurnOffIndication = "C1961AD8-5A74-4BB1-A238-20D2CA3A6AFB";

            /// <summary> Включить адрес </summary>
            public const string TurnOnAddress = "313F82BA-1602-4731-8590-26609E566107";

            /// <summary> Игнорировать адрес </summary>
            public const string IgnoreAddress = "9CFE51D9-CDE2-457C-A8DC-E65212C997D1";
        }

        /// <summary> Управление устройствами проводной системы БСЛ240-И </summary>
        public class WiredSystemBSL240i
        {
            /// <summary> Сигнал: моргание светодиодами </summary>
            public const string LEDBlinking = "FBB45A1A-5AB7-4CB6-99C3-65FE27F95116";

            /// <summary> Включить зеленый индикатор </summary>
            public const string TurnOnGreenIndicator = "143F4007-F649-4DB5-B614-DD37CCB6D98D";

            /// <summary> Включить красный индикатор </summary>
            public const string TurnOnRedIndicator = "E345A88F-5B41-44DA-AB6F-9B4E99EDA9F1";

            /// <summary> Отключить индикацию </summary>
            public const string TurnOffIndication = "81492F74-FF19-4649-BAF1-09C3533DED3B";

            /// <summary> Включить адрес </summary>
            public const string TurnOnAddress = "38544F8E-A468-4D2E-B8E9-354F23BF5C36";

            /// <summary> Игнорировать адрес </summary>
            public const string IgnoreAddress = "CAA7E94B-F313-4893-8E18-E7E632AAB2F2";
        }

        /// <summary> Управление устройствами радиосистемы Стрелец </summary>
        public class RadioSystemStrelets
        {
            /// <summary> Включить зеленый индикатор </summary>
            public const string TurnOnGreenIndicator = "2138B34F-CA92-4429-959C-D9F3F67A0E4A";

            /// <summary> Включить красный индикатор </summary>
            public const string TurnOnRedIndicator = "FDB99F41-17D8-4DFA-9864-27A5EDDB8643";

            /// <summary> Отключить индикацию </summary>
            public const string TurnOffIndication = "5262C5B1-048C-48D6-B9BA-BC426E9ED10E";

            /// <summary> Включить адрес </summary>
            public const string TurnOnAddress = "D79082F7-8041-498E-AF53-4B6515FCC6C8";

            /// <summary> Игнорировать адрес </summary>
            public const string IgnoreAddress = "26CA52DD-34EC-4C1F-AB9F-F5E407C0EED6";
        }

    }
}
