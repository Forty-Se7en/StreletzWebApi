using System;
using Newtonsoft.Json;

namespace StreletzAPI.Json
{
    /// <summary>
    /// This interface is for polymorphism using 
    /// (to set any classes, including classes with multiple deriving from other classes,
    /// as IObjectToken type with ObjectGuid member inside)
    /// </summary>
    public interface IObjectToken
    {
        [JsonProperty("objectGuid")]
        Guid ObjectGuid { get; set; }
    }

    /// <summary>
    /// Базовый класс всех объектов, содержащий уникальный идентификатор на объект системы.
    /// </summary>
    [Serializable]
    public class ObjectToken : IObjectToken
    {
        /// <summary>
        /// Уникальный идентификатор устройства
        /// </summary>
        [JsonProperty("objectGuid")]
        public Guid ObjectGuid { get; set; }
    }
}
