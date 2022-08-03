using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreletzAPI.Json
{
    /// <summary>
    /// Базовый класс всех устройств
    /// </summary>
    [Serializable]
    public class DeviceInfo : BaseStateInfo
    {
        public DeviceInfo()
            : base()
        { }
    }
}
