using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreletzAPI
{
    public enum BroadcastEventEnum
    {
        #region Geodata

        /// <summary>
        /// Event to broadcast Server Time
        /// </summary>
        broadcastServerTime,

        /// <summary>
        /// Event to broadcast GeoData Changes
        /// </summary>
        broadcastGeoData,

        /// <summary>
        /// Event to broadcast Events into EventPanel
        /// </summary>
        broadcastEventInfoItems,

        /// <summary>
        /// Event to broadcast Objects State into State Panel
        /// </summary>
        broadcastObjectStateItems,

        /// <summary>
        /// Event to broadcast Nodes Changes
        /// </summary>
        broadcastNodesChanged,

        /// <summary>
        /// Event to broadcast Warning about Full Project reloading
        /// </summary>
        broadcastReloadFullProject,

        /// <summary>
        /// Event to broadcast System Connection State changes
        /// </summary>
        broadcastSystemConnectionState,

        /// <summary>
        /// Event to broadcast Segment Connection State changes
        /// </summary>
        broadcastSegmentConnectionState,

        /// <summary>
        /// Event to broadcast initial GeoData
        /// </summary>
        broadcastGeoDataInitial,

        #endregion Geodata

        #region AnalogValues
        /// <summary>
        /// Event to broadcast Analog Values States
        /// </summary>
        broadcastAnalogValuesStates,

        /// <summary>
        /// Event to broadcast Analog Values Infos
        /// </summary>
        broadcastAnalogValuesInfos

        #endregion AnalogValues
    }
}
