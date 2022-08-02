using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreletzAPI
{
    public enum EventEnum
    {
        #region Geodata
        /// <summary>
        /// CallBack to WinForm C# Client
        ///  from Hub method:  string GetServerTime(string connectionId)
        /// </summary>
        getCurrentServerTime,

        /// <summary>
        /// CallBack to WinForm C# Client
        ///  from Hub method: AccessInfoModel AuthenticateAndGetClientData(
        /// Credentials credentials) 
        /// </summary>
        getAccessInfo,

        /// <summary>
        /// CallBack to WinForm C# Client
        ///  from Hub method: string LogOut(string connectionId) 
        /// </summary>
        getLogoutResult,

        /// <summary>
        /// CallBack to WinForm C# Client
        ///  from Hub method: List<Geodata/> GetGeoDeviceTrack(
        /// GeoDeviceTrackInfo deviceTrackInfo) 
        /// </summary>
        getGeoDeviceTrack,

        /// <summary>
        /// CallBack to WinForm C# Client
        ///  from Hub method: List<DeviceInfo/> GetAllGeoDevices(string connectionId) 
        /// </summary>
        getAllGeoDevicesInfos,

        /// <summary>
        /// CallBack to WinForm C# Client
        ///  from Hub method: List<DeviceInfo/> GetGeoDevices(GnssOnInfo gnssOnInfo) 
        /// </summary>
        getGeoDevicesInfos,

        /// <summary>
        /// CallBack to WinForm C# Client
        ///  from Hub method: List<Geodata/> GetInitialGeodataInfoItems(string connectionId) 
        /// </summary>
        getGeoDataInitial,

        /// <summary>
        /// CallBack to WinForm C# Client
        ///  from Hub method: List<LightSchemaDtoInfo/> GetAllSchemas(string connectionId) 
        /// </summary>
        getAllSchemas,

        /// <summary>
        /// CallBack to WinForm C# Client
        ///  from Hub method: List<SegmentConnectionStateInfo/> GetInitialSegmentConState(string connectionId) 
        /// </summary>
        getInitialSegmentConnectionState,

        /// <summary>
        /// CallBack to WinForm C# Client
        ///  from Hub method: Geodata GetGeoDeviceLastGeodata(
        /// GeoDeviceLastGeodataInfo geoDeviceLastGeodataInfo) 
        /// </summary>
        getLastGeoDataInfo,

        /// <summary>
        /// CallBack to WinForm C# Client
        ///  from Hub method: List<LogicalObjectInfo/> GetPartitionGroupsInfos(
        /// string connectionId) 
        /// </summary>
        getPartitionGroupsItems,

        /// <summary>
        /// CallBack to WinForm C# Client
        ///  from Hub method: List<LogicalObjectInfo/> GetPartitionsInfos(string connectionId) 
        /// </summary>
        getPartitionsItems,

        /// <summary>
        /// CallBack to WinForm C# Client
        ///  from Hub method: List<LogicalObjectInfo/> GetOutputGroupsInfos(
        /// string connectionId) 
        /// </summary>
        getOutputGroupsItems,

        /// <summary>
        /// CallBack to WinForm C# Client
        ///  from Hub method: List<LogicalObjectInfo/> GetFireAutomaticZonesInfos(
        /// string connectionId) 
        /// </summary>
        getFireAutomaticZonesItems,

        /// <summary>
        /// CallBack to WinForm C# Client
        ///  from Hub method: List<AccessAreaInfo/> GetAccessAreas(string connectionId) 
        /// </summary>
        getAccessAreasItems,

        /// <summary>
        /// CallBack to WinForm C# Client
        ///  from Hub method: List<GeoObjectInfo/> GetMapObjects(string connectionId) 
        /// </summary>
        getGeoObjectItems,

        /// <summary>
        /// CallBack to WinForm C# Client
        ///  from Hub method: List<SchemaDeviceInfo/> GetDevicesFromSchema(DevicesFromSchemaRequest request) 
        /// </summary>
        getSchemaDevices,

        /// <summary>
        /// CallBack to WinForm C# Client
        ///  from Hub method: ViewerSchemaGeoLinksInfo GetGeoLinksFromSchema(DevicesFromSchemaRequest request)
        /// </summary>
        getGeoLinksOfSchema,

        #endregion Geodata

        #region AnalogValues

        /// <summary>
        /// CallBack to WinForm C# Client
        ///  from AnalogValuesHub method: 
        /// List<AnalogValuesBaseModel/> GetIntialAnalogValues(string connectionId)
        /// </summary>
        getIntialAnalogValueModels,

        #endregion AnalogValues

        #region Common

        /// <summary>
        /// CallBack to WinForm C# Client
        /// from CommonHub method: 
        /// void ExecuteCommands(ExCommandInfo executingCommandInfo) 
        /// </summary>
        getExecuteCommandsResult,

        /// <summary>
        /// CallBack to WinForm C# Client
        /// from CommonHub method: 
        /// void ExecuteMacro(ExecuteMacroInfo exMacroInfo) 
        /// </summary>
        getExecuteMacroResult

        #endregion Common

        #region ConfiguratorHub



        #endregion
    }
}
