using StreletzAPI.Json;
using StreletzAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreletzAPI
{
    public interface IClient
    {
        //public static IClient GetInstance() => throw new NotImplementedException();
        //public IClient GetInstance();

        #region Properties

        public AccessInfo? AccessInfoResult { get; set; }

        public bool? ExecuteCommandResult { get; set; }

        public List<DeviceInfo>? GetAllGeoDevicesResult { get; set; }

        public EConnectionStatus ConnectionStatus { get; }

        #endregion

        #region Соединение и вход

        public void Connect(string address);

        public Task<ConnectResult> ConnectAsync(string address);

        public Task LogInAsync(string login, string password);

        public Task LogOutAsync();

        #endregion

        #region Информация

        public Task<Info[]> GetGeoDevices();

        public Task<Info[]> GetSegments();

        public Task<Info[]> GetPartitions(string segmentGuid);

        public Task<LogicalObjectInfo[]> GetPartitionsGroups();

        public Task<Info[]> GetAccessAreas();

        public Task GetAllGeoDevices();

        public Task<AnalogValuesObject[]> GetAnalogDevices();

        #endregion

        #region Общее

        public Task ExecuteCommand(string commandGuid, string[] targets, string[] args);

        public Task<EventInfo[]> GetLastEvent();

        #endregion

    }
}
