using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreletzAPI.Json
{
    /// <summary>
    /// Логический объект (раздел, группа разделов, группа ИУ, ЗПА)
    /// </summary>
    [Serializable]
    public class LogicalObjectInfo : BaseStateInfo
    {
        /// <summary>
        /// Описание объекта
        /// </summary>
        [JsonProperty("childObjectsList")]
        public List<Guid> ChildObjectsList { get; set; }
    }
}
