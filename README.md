# Streletz Web Api
## Web api для отправки команд по http на сервер ПО стрелец. Содержит ASP NET CORE WEB server и клиент для общения с сервером ПО Стрелец. Присоединяется 

### Соединение и вход
Перед началом работы требуется выполнить соединение с сервером и пройти процедуру аутентификации. Для этого необходимо выполнить следующие запросы:
#### /Connect
##### Post
Отправляет запрос на соединение с сервером.
Вид запроса:
{
  "address": "http://DESKTOP-KILC044:8030"
}
При успешном соединении возвращает код 200, в противном случае код 500 с описанием ошибки.
#### /Login
##### Post
Процедура авторизации и аутентификации.
Вид запроса:
{
  "userName": "web1",
  "password": "a1a1a1a1"
}
Вид ответа:
{
  "authenticated": true,
  "userName": "web1",
  "userRole": "admin",
  "errorMessage": "null"
}
При успешной аутентификации в поле authenticated устанавливается флаг true и поле errorMessage содержит null. В противном случае поле authenticated будет содержать флаг false, а поле errorMessage - описание ошибки.
### Получение информации с сервера
Существует возможность выполнить несколько get запросов на сервер для получения информации об устройствах и их состояниях, а именно:
#### /GetGeoDevices
##### Get
Запрашивает информацию об имеющихся браслетах. 
Пример ответа:
[
  {
    "objectGuid": "9c657747-8330-4943-ac22-996e0de000b5",
    "number": 1792,
    "name": "Браслет-ПРО исп. Д",
    "description": "",
    "type": 128,
    "subtype": 117,
    "icon": null
  },
  {
    "objectGuid": "42ff11f3-5625-4548-b09c-c510f2f18817",
    "number": 1793,
    "name": "Браслет-ПРО исп. Д",
    "description": "",
    "type": 128,
    "subtype": 117,
    "icon": null
  }
]
#### /GetAllGeoDevicesStatus
##### Get
Запрашивает текущее состояние всех браслетов.
Пример ответа:
[
  {
    "info": {
      "number": 1792,
      "name": "Браслет-ПРО исп. Д",
      "description": "",
      "type": 128,
      "subtype": 117,
      "icon": null,
      "objectGuid": "9c657747-8330-4943-ac22-996e0de000b5"
    },
    "state": {
      "flags": {
        "warningGuard": false,
        "warningPanic": false,
        "warningCompulsion": false,
        "warningFire": false,
        "warningFireAttension": false,
        "warningTechnological": false,
        "break": false,
        "delaysGuardOn": false,
        "delaysDelay": false,
        "delaysReGuard": false,
        "disrepairsDisrepair": true,
        "disrepairsBreaking": false,
        "disrepairsRound": false,
        "activation": false,
        "block": false,
        "extiguisherZoneFire": false,
        "successfulStart": false
      },
      "objectState": "",
      "objectStateCode": 4,
      "objectStateCssColor": "rgb(255,204,102)",
      "objectGuid": "9c657747-8330-4943-ac22-996e0de000b5"
    }
  },
  {
    "info": {
      "number": 1793,
      "name": "Браслет-ПРО исп. Д",
      "description": "",
      "type": 128,
      "subtype": 117,
      "icon": null,
      "objectGuid": "42ff11f3-5625-4548-b09c-c510f2f18817"
    },
    "state": {
      "flags": {
        "warningGuard": false,
        "warningPanic": false,
        "warningCompulsion": false,
        "warningFire": false,
        "warningFireAttension": false,
        "warningTechnological": false,
        "break": false,
        "delaysGuardOn": false,
        "delaysDelay": false,
        "delaysReGuard": false,
        "disrepairsDisrepair": false,
        "disrepairsBreaking": false,
        "disrepairsRound": false,
        "activation": false,
        "block": false,
        "extiguisherZoneFire": false,
        "successfulStart": false
      },
      "objectState": "",
      "objectStateCode": 2,
      "objectStateCssColor": "rgb(127,127,127)",
      "objectGuid": "42ff11f3-5625-4548-b09c-c510f2f18817"
    }
  }
]
#### /GetAnalogDevices
##### Get
Запрашивает инфаормацию об аналоговых устройствах:
Пример ответа:
[
  {
    "avInfo": {
      "segment": "Сегмент 1",
      "device": "1.1 КСГ РР-И-ПРО 2×S2",
      "sensor": "1.1 КСГ РР-И-ПРО 2×S2",
      "sensorType": "КСГ РР-И-ПРО 2×S2",
      "partition": "001: Зона",
      "radioParent": "",
      "typeAnalog1": null,
      "typeAnalog2": null,
      "typeAnalog3": null,
      "typeAnalog4": null,
      "number": 1,
      "name": "",
      "description": "Контроллер сегмента с поддержкой ПРО-устройств",
      "type": 28,
      "subtype": 0,
      "icon": "ks",
      "objectGuid": "fd2e93ea-6c4d-4fe5-b213-4da1afa6e529"
    },
    "avState": {
      "actuality": "63795560764",
      "actualityColor": "orangeredColor",
      "op": "0 В",
      "oPcolor": "orangeredColor",
      "rp": "",
      "rPcolor": "transparentColor",
      "fault": "Взлом, Неисправность ОП, Неисправность РП",
      "faultColor": "orangeredColor",
      "dv": "Вскрыт",
      "dVcolor": null,
      "temp": "25° C",
      "analog1": "",
      "analog1ForeColor": "foreColorGray",
      "analog2": "",
      "analog2ForeColor": "foreColorGray",
      "analog3": "",
      "analog3ForeColor": "foreColorGray",
      "analog4": "",
      "analog4ForeColor": "foreColorGray",
      "timePoint": "0001-01-01T00:00:00",
      "objectGuid": "fd2e93ea-6c4d-4fe5-b213-4da1afa6e529"
    }
  },
  {
    "avInfo": {
      "segment": "Сегмент 1",
      "device": "1.1 КСГ РР-И-ПРО 2×S2",
      "sensor": "5 Аврора-ДТ-ПРО",
      "sensorType": "Аврора-ДТ-ПРО",
      "partition": "002: Зона",
      "radioParent": "1.1 КСГ РР-И-ПРО 2×S2",
      "typeAnalog1": "Дым",
      "typeAnalog2": "Температура",
      "typeAnalog3": "Запыленность",
      "typeAnalog4": null,
      "number": 5,
      "name": "",
      "description": "Комбинированный извещатель радиоканальный",
      "type": 128,
      "subtype": 16,
      "icon": "Avrora-DTR",
      "objectGuid": "c77d5234-9c66-486c-8e87-6060ec71a487"
    },
    "avState": {
      "actuality": "63795560764",
      "actualityColor": "orangeredColor",
      "op": "3,1 В",
      "oPcolor": "transparentColor",
      "rp": "3,3 В",
      "rPcolor": "transparentColor",
      "fault": "",
      "faultColor": "transparentColor",
      "dv": "Закрыт",
      "dVcolor": "transparentColor",
      "temp": "-5° C",
      "analog1": "25",
      "analog1ForeColor": "foreColorBlack",
      "analog2": "25,2° С",
      "analog2ForeColor": "foreColorBlack",
      "analog3": "0",
      "analog3ForeColor": "foreColorBlack",
      "analog4": "",
      "analog4ForeColor": "foreColorGray",
      "timePoint": "0001-01-01T00:00:00",
      "objectGuid": "c77d5234-9c66-486c-8e87-6060ec71a487"
    }
  },
  ... и т.д.
]
#### /GetSegments
##### Get
Запрашивает информацию о сегментах:
Пример ответа:
[
  {
    "objectGuid": "418ec8eb-2acc-4f88-8971-2fb1ae5ca8df",
    "number": 1,
    "name": "",
    "description": "",
    "type": 0,
    "subtype": 0,
    "icon": ""
  }
]
#### /GetPartitions
##### Get 
Запрашивает информацию о разделах:
Пример ответа:
{
  "type": "https://tools.ietf.org/html/rfc7231#section-6.5.1",
  "title": "One or more validation errors occurred.",
  "status": 400,
  "traceId": "00-644d4e98687253e9a38b593592b5d4c7-7370f41da2faad1a-00",
  "errors": {
    "segmentGuid": [
      "The segmentGuid field is required."
    ]
  }
}
### Общее
В данном разделе представлены некоторые общие запросы, которые не вошли в другие разделы:
#### /ExecuteCommand
##### Post
Отправляет запрос на выполнение команды по ее GUID.
Пример команд: https://soft.streletz.ru/articles/commands.html
Тело запроса:
{
  "commandGuid": "string",
  "recipients": [
    "string"
  ],
  "params": [
    "string"
  ]
}
где 
commandGuid - GUIG команды,
recipients - массив GUID-ов получателей,
params - дополнительные параметры (например, при отправке сообщения на браслет в качестве первого параметра указывается текст сообщения).
Ответ: код 200, если команда была обработана и отправлена. 
#### /GetLastEvent
##### Get
Запрашивает последнее произошедшее событие.
Пример ответа:
{[
  {
    "eventId": 141,
    "eventTime": "03.08.2022 14:14:49",
    "eventDescr": "Корпус закрыт",
    "segmentDescr": "Сегмент 1",
    "partitionDescr": "Зона 2",
    "deviceDescr": "1.1 КСГ РР-И-ПРО 2×S2",
    "pathDescr": "3 Икар-ПРО",
    "eventClassType": 0,
    "color": "white",
    "partitionGuid": "cf7240f9-4fbc-478c-841e-21b635b0d0c3",
    "sensorGuid": "b047831a-4a21-468e-b10a-54b99bfe55f1",
    "sensorNumber": 128,
    "sensorAddress": 128,
    "UserGuid": "00000000-0000-0000-0000-000000000000",
    "userNumber": -1,
    "userType": false,
    "hex": "27 13 8E 71 58 00 80 02 01 24 00 00 00 00 00 00",
    "eventType": 88,
    "deviceType": 128,
    "deviceSubType": 36,
    "isEventRestored": true,
    "addressType": false,
    "nodeNumber": 1
  }
]}
### Команды управления разделами
#### /Arm/{guid}
##### Get 
Команда постановки зоны на охрану,
где giud - GUID раздела
#### /Disarm/{guid}
##### Get 
Команда снятия зоны с охраны,
где giud - GUID раздела
#### /Rearm/{guid}
##### Get 
Команда перепостановки зоны на охрану,
где giud - GUID раздела
#### /DropProblems/{guid}
##### Get 
Команда постановки зоны на охрану,
где giud - GUID раздела
### Команды управления браслетами
#### /SendMessage
##### Post
Отправляет сообщение на устройство.
Тело запроса:
{
  "recipients": [
    "string"
  ],
  "params": [
    "string"
  ]
}
где
recipients - список получаетелей сообщения,
params - текст сообщения в качестве первого параметра
#### /SignalWristband/{guid}
##### Get 
Отправляет на браслет команду мигания светодиодами
guid - GUID браслета