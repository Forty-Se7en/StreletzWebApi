using Newtonsoft.Json;
using StreletzAPI.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreletzAPI.Json
{
    /// <summary>
    /// Класс, использующийся для представления и передачи единичного события в протоколе JSON.
    /// </summary>
    public class EventInfo
    {
        /// <summary>
        /// Номер события в памяти контроллера КСГ.
        /// </summary>
        /// <remarks>
        /// Не является уникальным идентификатором! События от разных КСГ могут иметь одинаковые
        /// номера. Более того, даже в пределах одного КСГ существует кольцевой буфер (как
        /// правило, на 4096 событий), при переполнении которого номера начнут повторяться.
        /// </remarks>
        [JsonProperty("eventId")]
        public int EventId { get; set; }

        /// <summary>
        /// Время события по данным сервера (т.е. на момент регистрации события в системе).
        /// </summary>
        /// <remarks>
        /// Не следует путать с временем события по данным из аппаратуры. Аппаратное
        /// время наступления события по API не передаётся.
        /// </remarks>
        [JsonProperty("eventTime")]
        public string EventTime { get; set; }

        /// <summary>
        /// Описание события.
        /// </summary>
        [JsonProperty("eventDescr")]
        public string EventDescription { get; set; }

        /// <summary>
        /// Описание сегмента.
        /// </summary>
        [JsonProperty("segmentDescr")]
        public string SegmentDescription { get; set; }

        /// <summary>
        /// Описание Зоны (Раздела).
        /// </summary>
        [JsonProperty("partitionDescr")]
        public string PartitionDescription { get; set; }

        /// <summary>
        /// Описание датчика.
        /// </summary>
        [JsonProperty("deviceDescr")]
        public string DeviceDescription { get; set; }

        /// <summary>
        ///  Текстовое описание для столбца Датчик/Шлейф/ШС.
        /// </summary>
        [JsonProperty("pathDescr")]
        public string PathDescription { get; set; }

        /// <summary>
        /// EventClassType.
        /// </summary>
        [JsonProperty("eventClassType")]
        public EventClassType EventClassType { get; set; }

        /// <summary>
        /// Код Цвета.
        /// </summary>
        [JsonProperty("color")]
        public string Color { get; set; }

        /// <summary>
        /// Guid Зоны (Раздела).
        /// </summary>
        [JsonProperty("partitionGuid")]
        public Guid PartitionGuid { get; set; }

        /// <summary>
        /// Guid датчика.
        /// </summary>
        [JsonProperty("sensorGuid")]
        public Guid SensorGuid { get; set; }

        /// <summary>
        /// Номер датчика.
        /// </summary>
        [JsonProperty("sensorNumber")]
        public int SensorNumber { get; set; }

        /// <summary>
        /// Адрес датчика.
        /// </summary>
        [JsonProperty("sensorAddress")]
        public int SensorAddress { get; set; }

        /// <summary>
        /// Guid пользователя.
        /// </summary>
        [JsonProperty("UserGuid")]
        public Guid UserGuid { get; set; }

        /// <summary>
        /// Номер пользователя.
        /// </summary>
        [JsonProperty("userNumber")]
        public int UserNumber { get; set; }

        /// <summary>
        /// True, если локальные пользователи устройства.
        /// </summary>
        [JsonProperty("userType")]
        public bool UserType { get; set; }

        /// <summary>
        /// Возвращает "сырые" hex-данные события, преобразованные в строку.
        /// </summary>
        [JsonProperty("hex")]
        public string Hex { get; set; }

        /// <summary>
        /// Код типа события из аппаратуры.
        /// </summary>
        [JsonProperty("eventType")]
        public int EventType { get; set; }

        /// <summary>
        /// Тип устройства.
        /// </summary>
        [JsonProperty("deviceType")]
        public int DeviceType { get; set; }

        /// <summary>
        /// Подтип устройства.
        /// </summary>
        [JsonProperty("deviceSubType")]
        public int DeviceSubType { get; set; }

        /// <summary>
        /// Флаг (признак) восстановления события.
        /// </summary>
        /// <remarks>
        /// В системе принята типизация событий, при которой события с одним и тем же кодом могут иметь
        /// разные значения в зависимости от флага восстановления. Например:
        /// Событие "Постановка на охрану" - Код 0, Флаг восстановления == false
        /// Событие "Снятие с охраны" - Код 0, Флаг восстановления == true
        /// </remarks>
        [JsonProperty("isEventRestored")]
        public bool IsEventRestored { get; set; }

        /// <summary>
        /// Для физического типа адреса true.
        /// </summary>
        [JsonProperty("addressType")]
        public bool AddressType { get; set; }

        /// <summary>
        /// Номер узла.
        /// </summary>
        [JsonProperty("nodeNumber")]
        public int NodeNumber { get; set; }
    }
}

