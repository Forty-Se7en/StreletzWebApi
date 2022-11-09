using Microsoft.AspNet.SignalR.Client;
using Newtonsoft.Json;
using System.ComponentModel;
using StreletzAPI;
using StreletzAPI.Json;
using System.Security.Cryptography.X509Certificates;
using StreletzClient.Properties;
using StreletzAPI.Models;

namespace StreletzClient
{
    public class StreletzClient : IClient
    {
        #region Feilds

        //private static StreletzClient _instance;
        private static X509Certificate2 _clientCertificate;

        #endregion

        #region Propertiers

        public EConnectionStatus ConnectionStatus { get; private set; } = EConnectionStatus.Disconnected;

        public AccessInfo? AccessInfoResult { get; set; } = null;

        public bool? LogOutResult { get; set; } = null;

        public bool? ExecuteCommandResult { get; set; } = null;

        public List<DeviceInfo>? GetAllGeoDevicesResult { get; set; } = null;

        public List<EventInfo> LastEvent { get; private set; }
        object _lastEventLocker = new object();
        #endregion

        #region Hubs

        private HubConnection _connectionHub { get; set; }
        private string _connectionId { get; set; }

        private IHubProxy _commonHubProxy { get; set; }
        private IHubProxy _geoDataHubProxy { get; set; }
        private IHubProxy _configuratorHubProxy { get; set; }
        private IHubProxy _analogValuesHubProxy { get; set; }

        #endregion

        #region Ctors

        //private StreletzClient(){}

        //IClient IClient.GetInstance()
        //{
        //    return StreletzClient.GetInstance();
        //}

        //public static IClient GetInstance()
        //{
        //    if (_instance == null) _instance = new StreletzClient();
        //    return _instance;
        //}

        #endregion

        #region Соединение и вход

        #region Connect

        public void Connect(string address)
        {
            throw new NotImplementedException();
        }

        public async Task<ConnectResult> ConnectAsync(string address)
        {

            ConnectionStatus = EConnectionStatus.Connecting;

            try
            {
                _connectionHub = new HubConnection(address);

                _clientCertificate = new X509Certificate2();
                if (bool.TryParse(Settings.IsSslMode, out var value) && value)
                {
                    _clientCertificate.Import(Resources.childcert56311_5);

                    _connectionHub.AddClientCertificate(_clientCertificate);
                }

                //var clietCertificate = new X509Certificate2();

                _commonHubProxy = _connectionHub.CreateHubProxy("CommonHub");
                _geoDataHubProxy = _connectionHub.CreateHubProxy("GeoDataHub");
                _configuratorHubProxy = _connectionHub.CreateHubProxy("ConfiguratorHub");
                _analogValuesHubProxy = _connectionHub.CreateHubProxy("AnalogValuesHub");

                SubscribeEvents();

                _connectionHub.TraceLevel = TraceLevels.All;
                await _connectionHub.Start();
                _connectionId = _connectionHub.ConnectionId;
            }
            catch (Exception ex)
            {
                ConnectionStatus = EConnectionStatus.Disconnected;
                Console.WriteLine(ex.Message);
                return new ConnectResult() { Success = false, ErrorMessage = ex.Message };
            }

            ConnectionStatus = EConnectionStatus.Connected;
            return new ConnectResult() { Success = true };
        }

        #endregion

        #region LogIn

        //public async void LogIn(string login, string password)
        //{            
        //    {
        //        var separator = new[] { "," };

        //        string[] allowedToBroadcastEventsCommonArr = null;
        //        if (!string.IsNullOrEmpty(Settings.AllowedToBroadcastEventsCommon) && Settings.AllowedToBroadcastEventsCommon != "null")
        //        {
        //            allowedToBroadcastEventsCommonArr = Settings.AllowedToBroadcastEventsCommon.Split(separator, StringSplitOptions.None);
        //        }
        //        var credentialsCommon = new Credentials()
        //        {
        //            UserLogin = login,
        //            UserPassword = password,
        //            ConnectionId = _connectionId,
        //            AllowedToBrodcastEvents = allowedToBroadcastEventsCommonArr
        //        };
        //        await _commonHubProxy.Invoke(Methods.AuthenticateAndGetClientDataMethodName, credentialsCommon);

        //        string[] allowedToBroadcastEventsConfiguratorArr = null;
        //        if (!string.IsNullOrEmpty(Settings.AllowedToBroadcastEventsConfigurator) && Settings.AllowedToBroadcastEventsConfigurator != "null")
        //        {
        //            allowedToBroadcastEventsConfiguratorArr = Settings.AllowedToBroadcastEventsConfigurator.Split(separator, StringSplitOptions.None);
        //        }
        //        var credentialsConfigurator = new Credentials()
        //        {
        //            UserLogin = login,
        //            UserPassword = password,
        //            ConnectionId = _connectionId,
        //            AllowedToBrodcastEvents = allowedToBroadcastEventsConfiguratorArr
        //        };
        //        await _configuratorHubProxy.Invoke(Methods.AuthenticateAndGetClientDataMethodName, credentialsConfigurator);

        //        string[] allowedToBrodcastEventsGeoDataArr = null;
        //        if (!string.IsNullOrEmpty(Settings.AllowedToBroadcastEventsGeoData) && Settings.AllowedToBroadcastEventsGeoData != "null")
        //        {
        //            allowedToBrodcastEventsGeoDataArr = Settings.AllowedToBroadcastEventsGeoData.Split(separator, StringSplitOptions.None);
        //        }
        //        var credentialsGeoData = new Credentials()
        //        {
        //            UserLogin = login,
        //            UserPassword = password,
        //            ConnectionId = _connectionId,
        //            AllowedToBrodcastEvents = allowedToBrodcastEventsGeoDataArr
        //        };
        //        await _geoDataHubProxy.Invoke(Methods.AuthenticateAndGetClientDataMethodName, credentialsGeoData);

        //        string[] allowedToBrodcastEventsAnalogValuesArr = null;
        //        if (!string.IsNullOrEmpty(Settings.AllowedToBroadcastEventsAnalogValues) && Settings.AllowedToBroadcastEventsAnalogValues != "null")
        //        {
        //            allowedToBrodcastEventsAnalogValuesArr = Settings.AllowedToBroadcastEventsAnalogValues.Split(separator, StringSplitOptions.None);
        //        }
        //        var credentialsAnalogValues = new Credentials()
        //        {
        //            UserLogin = login,
        //            UserPassword = password,
        //            ConnectionId = _connectionId,
        //            AllowedToBrodcastEvents = allowedToBrodcastEventsAnalogValuesArr
        //        };
        //        await _analogValuesHubProxy.Invoke(Methods.AuthenticateAndGetClientDataMethodName, credentialsAnalogValues);
        //    }
        //}

        public async Task LogInAsync(string login, string password)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrWhiteSpace(login) || string.IsNullOrEmpty(password) || string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Login and password can not be empty");
            }

            await LogInCommonHubProxy(login, password);
            await LogInConfiguratorHubProxy(login, password);
            await LogInGeoDataHubProxy(login, password);
            await LogInAnalogValuesHubProxy(login, password);
        }

        async Task LogInCommonHubProxy(string login, string password)
        {
            string[] allowedToBroadcastEventsArr = null;
            if (!string.IsNullOrEmpty(Settings.AllowedToBroadcastEventsCommon) && Settings.AllowedToBroadcastEventsCommon != "null")
            {
                allowedToBroadcastEventsArr = Settings.AllowedToBroadcastEventsCommon.Split(",", StringSplitOptions.None);
            }

            var credentials = new Credentials()
            {
                UserLogin = login,
                UserPassword = password,
                ConnectionId = _connectionId,
                AllowedToBrodcastEvents = allowedToBroadcastEventsArr
            };

            await _commonHubProxy.Invoke(Methods.AuthenticateAndGetClientDataMethodName, credentials);
        }

        async Task LogInConfiguratorHubProxy(string login, string password)
        {
            string[] allowedToBroadcastEventsArr = null;
            if (!string.IsNullOrEmpty(Settings.AllowedToBroadcastEventsConfigurator) && Settings.AllowedToBroadcastEventsConfigurator != "null")
            {
                allowedToBroadcastEventsArr = Settings.AllowedToBroadcastEventsConfigurator.Split(",", StringSplitOptions.None);
            }

            var credentials = new Credentials()
            {
                UserLogin = login,
                UserPassword = password,
                ConnectionId = _connectionId,
                AllowedToBrodcastEvents = allowedToBroadcastEventsArr
            };
            await _configuratorHubProxy.Invoke(Methods.AuthenticateAndGetClientDataMethodName, credentials);
        }

        async Task LogInGeoDataHubProxy(string login, string password)
        {
            string[] allowedToBroadcastEventsArr = null;
            if (!string.IsNullOrEmpty(Settings.AllowedToBroadcastEventsGeoData) && Settings.AllowedToBroadcastEventsGeoData != "null")
            {
                allowedToBroadcastEventsArr = Settings.AllowedToBroadcastEventsGeoData.Split(",", StringSplitOptions.None);
            }

            var credentials = new Credentials()
            {
                UserLogin = login,
                UserPassword = password,
                ConnectionId = _connectionId,
                AllowedToBrodcastEvents = allowedToBroadcastEventsArr
            };
            await _geoDataHubProxy.Invoke(Methods.AuthenticateAndGetClientDataMethodName, credentials);
        }

        async Task LogInAnalogValuesHubProxy(string login, string password)
        {
            string[] allowedToBroadcastEventsArr = null;
            if (!string.IsNullOrEmpty(Settings.AllowedToBroadcastEventsAnalogValues) && Settings.AllowedToBroadcastEventsAnalogValues != "null")
            {
                allowedToBroadcastEventsArr = Settings.AllowedToBroadcastEventsAnalogValues.Split(",", StringSplitOptions.None);
            }

            var credentials = new Credentials()
            {
                UserLogin = login,
                UserPassword = password,
                ConnectionId = _connectionId,
                AllowedToBrodcastEvents = allowedToBroadcastEventsArr
            };
            await _analogValuesHubProxy.Invoke(Methods.AuthenticateAndGetClientDataMethodName, credentials);
        }

        public async Task LogOutAsync()
        {
            await _commonHubProxy.Invoke(Methods.LogOutMethodName, _connectionId);
            await _configuratorHubProxy.Invoke(Methods.LogOutMethodName, _connectionId);
            await _geoDataHubProxy.Invoke(Methods.LogOutMethodName, _connectionId);
            await _analogValuesHubProxy.Invoke(Methods.LogOutMethodName, _connectionId);
        }

        #endregion

        #endregion

        #region Commands

        public async Task ExecuteCommand(string commandGuid, string[] targets, string[] args)
        {
            var container = new ExCommandContainer();

            container.CommandGuid = Guid.Parse(commandGuid.ToLower());

            var objectsFor = new List<Guid>();
            foreach (var target in targets)
            {
                objectsFor.Add(Guid.Parse(target));
            }
            container.ObjectsFor = objectsFor;
            container.CommandArgsTemplate = args;
            container.CommandToken = Guid.NewGuid();

            await this.SendCommands(new[] { container });
        }

        private async void GetInitialGeodataInfoItems()
        {
            await _geoDataHubProxy.Invoke(Methods.GetInitialGeoDataInfoItemsMethodName, _connectionId);
        }

        private async void GetInitialAllGeoDevices()
        {
            await _geoDataHubProxy.Invoke(Methods.GetAllGeoDevicesMethodName, new object[] { _connectionId });
        }

        public async Task GetAllGeoDevices()
        {
            await _geoDataHubProxy.Invoke(Methods.GetAllGeoDevicesMethodName, new object[] { _connectionId });
        }

        //private async Task SendCommand(ExCommandContainer command)
        //{
        //    await _commonHubProxy.Invoke(Methods.ExecuteCommandMethodName,
        //        _connectionId, command);
        //}

        private async Task SendCommands(IEnumerable<ExCommandContainer> executingCommandContainers)
        {
            await _commonHubProxy.Invoke(Methods.ExecuteCommandMethodName,
                _connectionId, executingCommandContainers);
        }

        #endregion

        #region Methods

        public async Task<Info[]> GetGeoDevices()
        {
            //if (_configuratorHubProxy == null) return null;
            return (await _configuratorHubProxy.Invoke<IEnumerable<Info>>(Methods.GetGeoDevicesMethodName, _connectionId)).ToArray();
        }

        public async Task<Info[]> GetSegments()
        {
            return (await _configuratorHubProxy.Invoke<IEnumerable<Info>>(Methods.GetSegmentsMethodName, _connectionId))
                .ToArray();
        }

        public async Task<Info[]> GetPartitions(string segmentGuid)
        {
            return (await _configuratorHubProxy.Invoke<IEnumerable<Info>>(Methods.GetPartitionsMethodName, _connectionId, segmentGuid))
                .ToArray();
        }

        public async Task<LogicalObjectInfo[]> GetPartitionsGroups()
        {
            return (await _geoDataHubProxy.Invoke<IEnumerable<LogicalObjectInfo>>(Methods.GetPartitionGroupsInfosMethodName, _connectionId))
                .ToArray();
        }

        public async Task<LogicalObjectInfo[]> GetOutputGroups()
        {
            return (await _geoDataHubProxy.Invoke<IEnumerable<LogicalObjectInfo>>(Methods.GetOutputGroupsInfosMethodName, _connectionId)).ToArray();
        }

        public async Task<Info[]> GetAccessAreas()
        {
            return (await _configuratorHubProxy.Invoke<IEnumerable<Info>>(Methods.GetAccessAreasMethodName, _connectionId))
                .ToArray();
        }

        public async Task<EventInfo[]> GetLastEvent()
        {
            lock(_lastEventLocker)
            {
                return LastEvent?.ToArray() ?? null;
            }
        }

        public async Task<AnalogValuesObject[]> GetAnalogDevices()
        {
            var analogValues = (await _analogValuesHubProxy.Invoke<IEnumerable<AnalogValuesObject>>("GetIntialAnalogValues", _connectionId))
                .ToArray();
            return analogValues;

        }
        #endregion

        #region Подписки на события

        void SubscribeEvents()
        {
            // server time
            _commonHubProxy.On<string>(BroadcastEventEnum.broadcastServerTime.ToString(), (dateTime) =>
            {

            });

            _commonHubProxy.On<object>(EventEnum.getExecuteCommandsResult.ToString(), (result) =>
            {
                ExecuteCommandsResult(result);
            });

            // from Hub method: AccessInfoModel AuthenticateAndGetClientData(Credentials credentials) 
            _geoDataHubProxy.On<object>(EventEnum.getAccessInfo.ToString(), (accessInfoResult) =>
            {
                AnalyzeAuthenticationResult(accessInfoResult);
            });

            _geoDataHubProxy.On<object>(EventEnum.getLogoutResult.ToString(), (logoutResult) =>
            {
                AnalyzeLogoutResult(logoutResult);
            });

            // from Hub method: List<Geodata> GetInitialGeodataInfoItems(string connectionId) 
            _geoDataHubProxy.On<object>(EventEnum.getGeoDataInitial.ToString(), (geoDataModels) =>
            {
                PrepareInitialGeodata(geoDataModels);
            });

            _geoDataHubProxy.On<object>(BroadcastEventEnum.broadcastObjectStateItems.ToString(), (objStateItems) =>               // TODO for test only
            {
                Console.WriteLine("broadcastObjectStateItems event");
                //AnalyzeObjectStateItems(objStateItems);
            });

            _geoDataHubProxy.On<object>(BroadcastEventEnum.broadcastEventInfoItems.ToString(), (eventInfoItems) =>               // TODO for test only
            {
                lock (_lastEventLocker)
                {
                    LastEvent = JsonConvert.DeserializeObject<List<EventInfo>>(eventInfoItems.ToString());
                    //this.ExecuteCommand(Commands.Wristband.SendMessage, new[] { "9c657747-8330-4943-ac22-996e0de000b5" } , new[] {$"{LastEvent.First().PathDescription}: {LastEvent.First().EventDescription}" });
                }
                //Console.WriteLine("broadcastEventInfoItems event");
                //AnalyzeObjectStateItems(objStateItems);
            });

            _geoDataHubProxy.On<object>(BroadcastEventEnum.broadcastGeoData.ToString(), (objStateItems) =>               // TODO for test only
            {
                Console.WriteLine("broadcastGeoData event");
                //AnalyzeObjectStateItems(objStateItems);
            });            

            _geoDataHubProxy.On<object>(EventEnum.getAllGeoDevicesInfos.ToString(), (deviceInfoList) =>
            {
                var resultList =
                JsonConvert.DeserializeObject<List<DeviceInfo>>(
                    deviceInfoList.ToString());
                GetAllGeoDevicesResult = resultList;
                //PrepareInitialGeoDevicesInfos(deviceInfoList);
            });

        }

        #region Event Handlers

        private void AnalyzeAuthenticationResult(object accessInfoResult)
        {
            var accessInfo =
                JsonConvert.DeserializeObject<AccessInfo>(
                accessInfoResult.ToString());

            AccessInfoResult = accessInfo;

            GetInitialGeodataInfoItems();
            GetInitialAllGeoDevices();
        }

        private void ExecuteCommandsResult(object result)
        {
            bool.TryParse(result.ToString(), out var res);
            ExecuteCommandResult = res;
        }

        private void PrepareInitialGeodata(object geoDataModels)
        {
            var geoData =
                JsonConvert.DeserializeObject<BindingList<GeoData>>(
                geoDataModels.ToString());
        }

        private void AnalyzeLogoutResult(object logoutResult)
        {
            LogOutResult = (bool)LogOutResult;
        }

        #endregion

        #endregion
    }
}