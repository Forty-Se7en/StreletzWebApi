using StreletzAPI;
using StreletzAPI.Json;
using StreletzAPI.Models;


namespace StreletzProxyServer
{
    public class StreletzClientManagerService : IStreletzClientManagerService
    {
        
        IClient _client;              


        public StreletzClientManagerService(IClient client)
        {
            _client = client;
        }

        #region Соединение и вход

        public async Task<ConnectResult> ConnectAsync(string address)
        {
            return await _client.ConnectAsync(address);
            //return false;
        }

        public async Task<AccessInfo> LogInAsync(string login, string password)
        {
            await _client.LogInAsync(login, password);
            return await WaitForAuthenticationResult();
        }

        public async Task LogOutAsync()
        {
            await _client.LogOutAsync();
        }

        #endregion

        #region Информация

        public async Task<Info[]> GetGeoDevices()
        {
            return await _client.GetGeoDevices();
        }

        public async Task<DeviceInfo[]> GetAllGeoDevices()
        {
            await _client.GetAllGeoDevices();
            return await WaitForGetAllGeoDevicesResult();            
        }

        public async Task<Info[]> GetSegments()
        {
            return await _client.GetSegments();
        }

        public async Task<Info[]> GetPartitions(string segmentGuid)
        {
            return await _client.GetPartitions(segmentGuid);
        }

        public async Task<LogicalObjectInfo[]> GetPartitionsGroups()
        {
            return await _client.GetPartitionsGroups();
        }

        public async Task<Info[]> GetAccessAreas()
        {
            return await _client.GetAccessAreas();
        }

        public async Task<AnalogValuesObject[]> GetAnalogDevices()
        {
            return await _client.GetAnalogDevices();
        }

        #endregion

        #region Общее

        public async Task<bool> ExecuteCommand(string commandGuid, string[] recipients, string[] parameters)
        {
            await _client.ExecuteCommand(commandGuid, recipients, parameters);
            return await WaitForExecuteCommandResult();
        }

        public async Task<EventInfo[]> GetLastEvent()
        {
            return await _client.GetLastEvent();
        }

        #endregion

        #region Команды управления разделами

        public async Task<bool> ArmZone(string guid)
        {
            await this.ExecuteCommand(Commands.Part.Arm, new[] { guid }, null);
            return await WaitForExecuteCommandResult();
        }

        public async Task<bool> DisarmZone(string guid)
        {
            await this.ExecuteCommand(Commands.Part.Disarm, new[] { guid }, null);
            return await WaitForExecuteCommandResult();
        }

        public async Task<bool> RearmZone(string guid)
        {
            await this.ExecuteCommand(Commands.Part.Rearm, new[] { guid }, null);
            return await WaitForExecuteCommandResult();
        }

        public async Task<bool> DropProblems(string guid)
        {
            await this.ExecuteCommand(Commands.Part.DropProblems, new[] { guid }, null);
            return await WaitForExecuteCommandResult();
        }

        #endregion

        #region Управление браслетами

        public async Task<bool> SignalWristBand(string? guid)
        {
            await this.ExecuteCommand(Commands.Wristband.LEDBlinking, new[] { guid }, null);
            return await WaitForExecuteCommandResult();
        }

        public async Task<bool> SendMessage(string[] recipients, string[] parameters)
        {
            await this.ExecuteCommand(Commands.Wristband.SendMessage, recipients, parameters);
            //return await WaitForExecuteCommandResult();
            return true;
        }

        #endregion

        #region Methods

        async Task<bool> WaitForExecuteCommandResult()
        {
            while (_client.ExecuteCommandResult == null)
            {
                await Task.Delay(100);
            }
            bool result = (bool)_client.ExecuteCommandResult;
            _client.ExecuteCommandResult = null;
            return result;
        }

        async Task<AccessInfo> WaitForAuthenticationResult()
        {
            while (_client.AccessInfoResult == null)
            {
                await Task.Delay(100);
            }
            var accessInfo = _client.AccessInfoResult;
            _client.AccessInfoResult = null;
            return accessInfo;
        }        

        async Task<DeviceInfo[]> WaitForGetAllGeoDevicesResult()
        {
            while (_client.GetAllGeoDevicesResult == null)
            {
                await Task.Delay(100);
            }
            var result = _client.GetAllGeoDevicesResult;
            _client.GetAllGeoDevicesResult = null;
            return result.ToArray();
        }

        #endregion
    }
}
