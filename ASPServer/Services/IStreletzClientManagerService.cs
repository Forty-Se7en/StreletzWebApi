using StreletzAPI.Json;
using StreletzAPI.Models;

namespace StreletzProxyServer
{
    public interface IStreletzClientManagerService
    {
        #region Properties
        

        #endregion

        #region Соединение и вход

        public Task<ConnectResult> ConnectAsync(string address);

        public Task<AccessInfo> LogInAsync(string login, string password);

        public Task LogOutAsync();

        #endregion

        #region Информация

        public Task<Info[]> GetGeoDevices();

        public Task GetAllGeoDevices();

        public Task<Info[]> GetSegments();

        public Task<Info[]> GetPartitions(string segmentGuid);

        public Task<LogicalObjectInfo[]> GetPartitionsGroups();

        public Task<Info[]> GetAccessAreas();

        #endregion 

        #region Общее

        public Task<bool> ExecuteCommand(string commandGuid, string[] recipients, string[] parameters);        

        #endregion

        #region Команды управления разделами
        
        public Task<bool> ArmZone(string guid);

        public Task<bool> DisarmZone(string guid);

        public Task<bool> RearmZone(string guid);

        public Task<bool> DropProblems(string guid);

        #endregion

        #region Управление браслетами

        public Task<bool> SendMessage(string[] recipients, string[] parameters);

        public Task<bool> SignalWristBand(string guid);
              

        #endregion
    }
}