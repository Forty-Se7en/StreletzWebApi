using StreletzAPI.Json;

namespace StreletzProxyServer.Responses
{
    public class InfoResponse
    {
        /// <summary>
        /// Уникальный идентификатор устройства
        /// </summary>
        public Guid ObjectGuid { get; set; }

        /// <summary>
        /// Номер устройства/логического объекта согласно вложенности его в общем дереве
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Наименование устройства/прибора
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Пользовательское описание, заданное для устройства
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Тип устройства согласно таблицы экпорта
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// Подтип устройства согласно таблицы экпорта
        /// </summary>
        public int Subtype { get; set; }

        /// <summary>
        /// Ключ к Иконке 
        /// (Имя иконки без расширения).
        /// </summary>
        public string Icon { get; set; }

        public static InfoResponse FromInfo(Info info)
        {
            return new InfoResponse()
            {
                ObjectGuid = info.ObjectGuid,
                Number = info.Number,
                Name = info.Name,
                Description = info.Description,
                Type = info.Type,
                Subtype = info.Subtype,
                Icon = info.Icon
            };
        }
    }
}