using Microsoft.AspNetCore.Mvc;
using StreletzAPI;
using StreletzAPI.Json;
using StreletzProxyServer.Requests;
using StreletzProxyServer.Responses;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel;

namespace StreletzProxyServer
{
    [ApiController]
    //[Route("[controller]")]
    public class StreletzProxyController : ControllerBase
    {        
        private readonly ILogger<StreletzProxyController> _logger;
        readonly IStreletzClientManagerService _streletzClientService;

        #region Ctors

        public StreletzProxyController(ILogger<StreletzProxyController> logger, IStreletzClientManagerService streletzClientService)
        {
            _logger = logger;
            _streletzClientService = streletzClientService;
        }

        #endregion

        #region Requests

        #region Соединение и вход

        [HttpPost]
        [Route("Connect")]
        [SwaggerOperation(Summary = "Соединиться с сервером", Tags = new[] { "Соединение и вход" })]
        public async Task<IActionResult> Connect(ConnectRequest connectionRequest, CancellationToken token)
        {
            var result = await _streletzClientService.ConnectAsync(connectionRequest.Address);
            if (result.Success)
            {
                return Ok("Connected");
            }
            else return base.Problem(result.ErrorMessage);
            //return new ConnectResponse() { Connected = result.Success, ErrorMessage = result.ErrorMessage };            
        }


        [HttpPost]
        [Route("Disconnect")]
        [SwaggerOperation(Summary = "НЕ РЕАЛИЗОВАНО", Tags = new[] { "Соединение и вход" })]
        public async Task<IActionResult> Disconnect()
        {
            return base.StatusCode(StatusCodes.Status501NotImplemented);
        }

        [HttpPost]
        [Route("Login")]
        [SwaggerOperation(Summary = "Авторизация и аутентификация", Tags = new[] { "Соединение и вход" })]
        public async Task<LoginResponse> Login(LoginRequest loginRequest, CancellationToken token)
        {
            var result = await _streletzClientService.LogInAsync(loginRequest.UserName, loginRequest.Password);
            var response = new LoginResponse()
            {
                Authenticated = result.NotAuthenticated == null,
                UserName = result.UserName,
                UserRole = result.UserRole,
                ErrorMessage = result.NotAuthenticated
            };
            return response;

        }

        [HttpPost]
        [Route("Logout")]
        [SwaggerOperation(Summary = "НЕ РЕАЛИЗОВАНО", Tags = new[] { "Соединение и вход" })]
        public async Task<IActionResult> Logout()
        {
            return base.StatusCode(StatusCodes.Status501NotImplemented);
        }

        #endregion

        #region Информация

        [HttpGet]
        [Route("GetGeoDevices")]
        [SwaggerOperation(Summary = "Запросить информацию о браслетах и т.п.", Tags = new[] { "Информация" })]
        public async Task<IActionResult> GetGeoDevices(CancellationToken token)
        {
            var items = await _streletzClientService.GetGeoDevices();            
            var responce = new InfoResponse[items.Length];
            for (int i = 0; i < items.Length; i++)
            {
                responce[i] = InfoResponse.FromInfo(items[i]);
            }
            return Ok(responce);
        }

        [HttpGet]
        [Route("GetAllGeoDevicesStatus")]
        [SwaggerOperation(Summary = "Запросить текущее состояние", Tags = new[] { "Информация" })]
        public async Task<IActionResult> GetAllGeoDevicesStatus(CancellationToken token)
        {
            DeviceInfo[] result = await _streletzClientService.GetAllGeoDevices();
            return Ok(result);
        }

        [HttpGet]
        [Route("GetAnalogDevices")]
        [SwaggerOperation(Summary = "Запросить ингформацию об аналоговых устройствах", Tags = new[] { "Информация" })]
        public async Task<IActionResult> GetAnalogDevices(CancellationToken token)
        {
            AnalogValuesObject[] result = await _streletzClientService.GetAnalogDevices();
            return Ok(result);
        }

        [HttpGet]
        [Route("GetSegments")]
        [SwaggerOperation(Summary = "Запросить список сегментов", Tags = new[] { "Информация" })]
        public async Task<IActionResult> GetSegments(CancellationToken token)
        {
            var items = await _streletzClientService.GetSegments();
            var responce = new InfoResponse[items.Length];
            for (int i = 0; i < items.Length; i++)
            {
                responce[i] = InfoResponse.FromInfo(items[i]);
            }
            return Ok(responce);
        }

        [HttpGet]
        [Route("GetPartitions")]
        [SwaggerOperation(Summary = "Запросить разделы", Tags = new[] { "Информация" })]
        public async Task<IActionResult> GetPartitions(string segmentGuid, CancellationToken token)
        {
            if (string.IsNullOrEmpty(segmentGuid))
            {
                return BadRequest("Invalid segmentGuid");
            }
            var items = await _streletzClientService.GetPartitions(segmentGuid);
            var responce = new InfoResponse[items.Length];
            for (int i = 0; i < items.Length; i++)
            {
                responce[i] = InfoResponse.FromInfo(items[i]);
            }
            return Ok(responce);
        }

        #endregion

        #region Общее

        [HttpPost]
        [Route("ExecuteCommand")]
        [SwaggerOperation(Summary = "Выполнить команду по guid", Tags = new[] { "Общее" })]
        public async Task<IActionResult> ExecuteCommand(ExecuteCommandRequest request, CancellationToken token)
        {
            bool result = await _streletzClientService.ExecuteCommand(request.CommandGuid, request.Recipients, request.Params);
            if (result == true) return Ok("Выполнено");
            else return StatusCode(520);

        }

        [HttpGet]
        [Route("GetLastEvent")]
        [SwaggerOperation(Summary = "Вернуть последнее событие", Tags = new[] { "Общее" })]
        public async Task<IActionResult> GetLastEvent()
        {
            var result = await _streletzClientService.GetLastEvent();
            if (result == null || result.Length == 0) return Ok("События отсуствуют");
            else return Ok(result);
        }

        #endregion

        #region События зоны

        [HttpGet]
        [Route("Subscribe/{zone}")]
        [SwaggerOperation(Summary = "Подписаться на события зоны (НЕ РЕАЛИЗОВАНО)", Tags = new[] { "События зоны" })]
        public async Task<IActionResult> Subscribe(string zone, CancellationToken token)
        {
            return base.StatusCode(StatusCodes.Status501NotImplemented);
        }

        [HttpGet]
        [Route("GetLastEvents/{zone}")]
        [SwaggerOperation(Summary = "Запросить последние события (НЕ РЕАЛИЗОВАНО)", Tags = new[] { "События зоны" })]
        public async Task<IActionResult> GetEvents(string zone, CancellationToken token)
        {
            return base.StatusCode(StatusCodes.Status501NotImplemented);
        }

        #endregion

        #region Команды управления разделами

        [HttpGet]
        [Route("Arm/{guid}")]
        [SwaggerOperation(Summary = "Поставить зону на охрану", Tags = new[] { "Команды управления разделами" })]
        public async Task<IActionResult> ArmZone(string guid, CancellationToken token)
        {
            bool result = await _streletzClientService.ArmZone(guid);
            if (result == true) return Ok("Выполнено");
            else return StatusCode(520);
        }

        [HttpGet]
        [Route("Disarm/{guid}")]
        [SwaggerOperation(Summary = "Снять зону с охраны", Tags = new[] { "Команды управления разделами" })]
        public async Task<IActionResult> DisarmZone(string guid, CancellationToken token)
        {
            bool result = await _streletzClientService.DisarmZone(guid);
            if (result == true) return Ok("Выполнено");
            else return StatusCode(520);
        }

        [HttpGet]
        [Route("Rearm/{guid}")]
        [SwaggerOperation(Summary = "\"Перевзять\" зону на охрану", Tags = new[] { "Команды управления разделами" })]
        public async Task<IActionResult> RearmZone(string guid, CancellationToken token)
        {
            bool result = await _streletzClientService.RearmZone(guid);
            if (result == true) return Ok("Выполнено");
            else return StatusCode(520);
        }

        [HttpGet]
        [Route("SignalZone/{guid}")]
        [SwaggerOperation(Summary = "Моргание светодиодами всеми устройствами раздела (НЕ РЕАЛИЗОВАНО)", Tags = new[] { "Команды управления разделами" })]
        public async Task<IActionResult> SignalZone(string zone, CancellationToken token)
        {
            return base.StatusCode(StatusCodes.Status501NotImplemented);
        }

        [HttpGet]
        [Route("DropProblems/{zone}")]
        [SwaggerOperation(Summary = "Сбросить пожары и неисправности", Tags = new[] { "Команды управления разделами" })]
        public async Task<IActionResult> DropProblems(string guid, CancellationToken token)
        {
            bool result = await _streletzClientService.DropProblems(guid);
            if (result == true) return Ok("Выполнено");
            else return StatusCode(520);
        }

        #endregion

        #region Управление браслетами

        [HttpGet]
        [Route("GetGeoDeviceLocation/{id}")]
        [SwaggerOperation(Summary = "НЕ РЕАЛИЗОВАНО", Tags = new[] { "Управление браслетами" })]
        public async Task<IActionResult> GetGeoDeviceLocation(string id, CancellationToken token)
        {
            return base.StatusCode(StatusCodes.Status501NotImplemented);
        }

        [HttpPost]
        [Route("SendMessage")]
        [SwaggerOperation(Summary = "Отправить сообщение", Tags = new[] { "Управление браслетами" })]
        public async Task<IActionResult> SendMessage(SendMessageRequest request, CancellationToken token)
        {
            if (request.Recipients == null || request.Recipients.Length < 1) 
                return new BadRequestObjectResult("Количество получателей не может быть меньше одного");
            bool commandSend = await _streletzClientService.SendMessage(request.Recipients, request.Params);
            if (commandSend) return new OkObjectResult("Команда принята");
            else return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }

        [HttpGet]
        [Route("SignalWristband/{guid?}")]
        [SwaggerOperation(Summary = "Моргание светодиодами", Tags = new[] { "Управление браслетами" })]
        public async Task<IActionResult> SignalWristBand(string? guid, CancellationToken token)
        {
            bool result = await _streletzClientService.SignalWristBand(guid);
            if (result == true) return Ok("Выполнено");
            else return StatusCode(520);
        }

        #endregion

        //[HttpGet]
        //[Route("GetDeviceInfo/{zone}")]

        //public object GetState(string zone)
        //{
        //    return new object();
        //}

        #endregion

        #region Methods
        

        #endregion

    }
}
