using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreletzAPI
{
    public class ExCommandContainer
    {
        #region Fields

        private IEnumerable<Guid> objectsFor;
        private object[] commandArgsTemplate;

        #endregion

        #region Properties

        /// <summary> Идентификатор команды </summary>
        public Guid CommandGuid { get; set; }
        
        /// <summary> Объекты, которым команда адресована </summary>
        public IEnumerable<Guid> ObjectsFor
        {
            get
            {
                return objectsFor ?? Enumerable.Empty<Guid>();
            }
            set { objectsFor = value; }
        }

        /// <summary> Обобщенные параметры команды </summary>
        public object[] CommandArgsTemplate
        {
            get
            {
                return commandArgsTemplate ?? new object[0];
            }
            set { commandArgsTemplate = value; }
        }

        /// <summary>
        /// Индентификатор экземпляра команды, 
        /// по которому можно отличать результаты исполнения 
        /// разных экземпляров одной и той же команды. 
        /// </summary>
        public Guid CommandToken { get; set; }

        #endregion
    }
}
