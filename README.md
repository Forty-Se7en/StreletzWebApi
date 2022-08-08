# Streletz Web Api

## Web api для отправки команд по http на сервер ПО стрелец. Содержит ASP NET CORE Web server и клиент для общения с сервером ПО Стрелец. Присоединяется к серверу "ПО Стрелец" и транслирует web запросы в команды сервера. <br />
[Подробнее о "ПО Стрелец"](https://soft.streletz.ru/articles/intro.html)

> ## Соединение и вход
Перед началом работы требуется выполнить соединение с сервером и пройти процедуру аутентификации. Для этого необходимо выполнить следующие запросы:

### /Connect
##### *Post*
Отправляет запрос на соединение с сервером. <br />
Вид запроса: <br />
```
{ <br />
  "address": "http://DESKTOP-KILC044:8030" <br />
} <br />
```
При успешном соединении возвращает код 200, в противном случае код 500 с описанием ошибки.

### /Login
##### *Post*
Процедура авторизации и аутентификации. <br />
Вид запроса: <br />
```
{ <br />
  "userName": "web1", <br />
  "password": "a1a1a1a1" <br />
} <br />
```
Вид ответа: <br />
```
{ <br />
  "authenticated": true, <br />
  "userName": "web1", <br />
  "userRole": "admin", <br />
  "errorMessage": "null" <br />
} <br />
```
При успешной аутентификации в поле authenticated устанавливается флаг true и поле errorMessage содержит null. В противном случае поле authenticated будет содержать флаг false, а поле errorMessage - описание ошибки. <br />

> ## Получение информации с сервера
Существует возможность выполнить несколько get запросов на сервер для получения информации об устройствах и их состояниях, а именно:

### /GetGeoDevices
##### *Get*
Запрашивает информацию об имеющихся браслетах.  <br />
Пример ответа: <br />
```
[ <br />
  { <br />
    "objectGuid": "9c657747-8330-4943-ac22-996e0de000b5", <br />
    "number": 1792, <br />
    "name": "Браслет-ПРО исп. Д", <br />
    "description": "", <br />
    "type": 128, <br />
    "subtype": 117, <br />
    "icon": null <br />
  }, <br />
  { <br />
    "objectGuid": "42ff11f3-5625-4548-b09c-c510f2f18817", <br />
    "number": 1793, <br />
    "name": "Браслет-ПРО исп. Д", <br />
    "description": "", <br />
    "type": 128, <br />
    "subtype": 117, <br />
    "icon": null <br />
  } <br />
] <br />
```

### /GetAllGeoDevicesStatus
##### *Get*
Запрашивает текущее состояние всех браслетов. <br />
Пример ответа: <br />
```
[ <br />
  { <br />
    "info": { <br />
      "number": 1792, <br />
      "name": "Браслет-ПРО исп. Д", <br />
      "description": "", <br />
      "type": 128, <br />
      "subtype": 117, <br />
      "icon": null, <br />
      "objectGuid": "9c657747-8330-4943-ac22-996e0de000b5" <br />
    }, <br />
    "state": { <br />
      "flags": { <br />
        "warningGuard": false, <br />
        "warningPanic": false, <br />
        "warningCompulsion": false, <br />
        "warningFire": false, <br />
        "warningFireAttension": false, <br />
        "warningTechnological": false, <br />
        "break": false, <br />
        "delaysGuardOn": false, <br />
        "delaysDelay": false, <br />
        "delaysReGuard": false, <br />
        "disrepairsDisrepair": true, <br />
        "disrepairsBreaking": false, <br />
        "disrepairsRound": false, <br />
        "activation": false, <br />
        "block": false, <br />
        "extiguisherZoneFire": false, <br />
        "successfulStart": false <br />
      }, <br />
      "objectState": "", <br />
      "objectStateCode": 4, <br />
      "objectStateCssColor": "rgb(255,204,102)", <br />
      "objectGuid": "9c657747-8330-4943-ac22-996e0de000b5" <br />
    } <br />
  }, <br />
  { <br />
    "info": { <br />
      "number": 1793, <br />
      "name": "Браслет-ПРО исп. Д", <br />
      "description": "", <br />
      "type": 128, <br />
      "subtype": 117, <br />
      "icon": null, <br />
      "objectGuid": "42ff11f3-5625-4548-b09c-c510f2f18817" <br />
    }, <br />
    "state": { <br />
      "flags": { <br />
        "warningGuard": false, <br />
        "warningPanic": false, <br />
        "warningCompulsion": false, <br />
        "warningFire": false, <br />
        "warningFireAttension": false, <br />
        "warningTechnological": false, <br />
        "break": false, <br />
        "delaysGuardOn": false, <br />
        "delaysDelay": false, <br />
        "delaysReGuard": false, <br />
        "disrepairsDisrepair": false, <br />
        "disrepairsBreaking": false, <br />
        "disrepairsRound": false, <br />
        "activation": false, <br />
        "block": false, <br />
        "extiguisherZoneFire": false, <br />
        "successfulStart": false <br />
      }, <br />
      "objectState": "", <br />
      "objectStateCode": 2, <br />
      "objectStateCssColor": "rgb(127,127,127)", <br />
      "objectGuid": "42ff11f3-5625-4548-b09c-c510f2f18817" <br />
    } <br />
  } <br />
] <br />
```

### /GetAnalogDevices
##### *Get*
Запрашивает инфаормацию об аналоговых устройствах: <br />
Пример ответа: <br />
```
[ <br />
  { <br />
    "avInfo": { <br />
      "segment": "Сегмент 1", <br />
      "device": "1.1 КСГ РР-И-ПРО 2×S2", <br />
      "sensor": "1.1 КСГ РР-И-ПРО 2×S2", <br />
      "sensorType": "КСГ РР-И-ПРО 2×S2", <br />
      "partition": "001: Зона", <br />
      "radioParent": "", <br />
      "typeAnalog1": null, <br />
      "typeAnalog2": null, <br />
      "typeAnalog3": null, <br />
      "typeAnalog4": null, <br />
      "number": 1, <br />
      "name": "", <br />
      "description": "Контроллер сегмента с поддержкой ПРО-устройств", <br />
      "type": 28, <br />
      "subtype": 0, <br />
      "icon": "ks", <br />
      "objectGuid": "fd2e93ea-6c4d-4fe5-b213-4da1afa6e529" <br />
    }, <br />
    "avState": { <br />
      "actuality": "63795560764", <br />
      "actualityColor": "orangeredColor", <br />
      "op": "0 В", <br />
      "oPcolor": "orangeredColor", <br />
      "rp": "", <br />
      "rPcolor": "transparentColor", <br />
      "fault": "Взлом, Неисправность ОП, Неисправность РП", <br />
      "faultColor": "orangeredColor", <br />
      "dv": "Вскрыт", <br />
      "dVcolor": null, <br />
      "temp": "25° C", <br />
      "analog1": "", <br />
      "analog1ForeColor": "foreColorGray", <br />
      "analog2": "", <br />
      "analog2ForeColor": "foreColorGray", <br />
      "analog3": "", <br />
      "analog3ForeColor": "foreColorGray", <br />
      "analog4": "", <br />
      "analog4ForeColor": "foreColorGray", <br />
      "timePoint": "0001-01-01T00:00:00", <br />
      "objectGuid": "fd2e93ea-6c4d-4fe5-b213-4da1afa6e529" <br />
    } <br />
  }, <br />
  { <br />
    "avInfo": { <br />
      "segment": "Сегмент 1", <br />
      "device": "1.1 КСГ РР-И-ПРО 2×S2", <br />
      "sensor": "5 Аврора-ДТ-ПРО", <br />
      "sensorType": "Аврора-ДТ-ПРО", <br />
      "partition": "002: Зона", <br />
      "radioParent": "1.1 КСГ РР-И-ПРО 2×S2", <br />
      "typeAnalog1": "Дым", <br />
      "typeAnalog2": "Температура", <br />
      "typeAnalog3": "Запыленность", <br />
      "typeAnalog4": null, <br />
      "number": 5, <br />
      "name": "", <br />
      "description": "Комбинированный извещатель радиоканальный", <br />
      "type": 128, <br />
      "subtype": 16, <br />
      "icon": "Avrora-DTR", <br />
      "objectGuid": "c77d5234-9c66-486c-8e87-6060ec71a487" <br />
    }, <br />
    "avState": { <br />
      "actuality": "63795560764", <br />
      "actualityColor": "orangeredColor", <br />
      "op": "3,1 В", <br />
      "oPcolor": "transparentColor", <br />
      "rp": "3,3 В", <br />
      "rPcolor": "transparentColor", <br />
      "fault": "", <br />
      "faultColor": "transparentColor", <br />
      "dv": "Закрыт", <br />
      "dVcolor": "transparentColor", <br />
      "temp": "-5° C", <br />
      "analog1": "25", <br />
      "analog1ForeColor": "foreColorBlack", <br />
      "analog2": "25,2° С", <br />
      "analog2ForeColor": "foreColorBlack", <br />
      "analog3": "0", <br />
      "analog3ForeColor": "foreColorBlack", <br />
      "analog4": "", <br />
      "analog4ForeColor": "foreColorGray", <br />
      "timePoint": "0001-01-01T00:00:00", <br />
      "objectGuid": "c77d5234-9c66-486c-8e87-6060ec71a487" <br />
    } <br />
  }, <br />
  ... и т.д. <br />
] <br />
```

### /GetSegments
##### *Get*
Запрашивает информацию о сегментах: <br />
Пример ответа: <br />
```
[ <br />
  { <br />
    "objectGuid": "418ec8eb-2acc-4f88-8971-2fb1ae5ca8df", <br />
    "number": 1, <br />
    "name": "", <br />
    "description": "", <br />
    "type": 0, <br />
    "subtype": 0, <br />
    "icon": "" <br />
  } <br />
] <br />
```

### /GetPartitions
##### *Get*
Запрашивает информацию о разделах: <br />
Пример ответа: <br />
```
{ <br />
  "type": "https://tools.ietf.org/html/rfc7231#section-6.5.1", <br />
  "title": "One or more validation errors occurred.", <br />
  "status": 400, <br />
  "traceId": "00-644d4e98687253e9a38b593592b5d4c7-7370f41da2faad1a-00", <br />
  "errors": { <br />
    "segmentGuid": [ <br />
      "The segmentGuid field is required." <br />
    ] <br />
  } <br />
} <br />
```

> ## Общее
В данном разделе представлены некоторые общие запросы, которые не вошли в другие разделы:

### /ExecuteCommand
##### *Post*
Отправляет запрос на выполнение команды по ее GUID. <br />
*[Пример команд](https://soft.streletz.ru/articles/commands.html)* <br />
Тело запроса: <br />
```
{ <br />
  "commandGuid": "string", <br />
  "recipients": [ <br />
    "string" <br />
  ], <br />
  "params": [ <br />
    "string" <br />
  ] <br />
} <br />
где  <br />
```
- commandGuid - GUIG команды, <br />
- recipients - массив GUID-ов получателей, <br />
- params - дополнительные параметры (например, при отправке сообщения на браслет в качестве первого параметра указывается текст сообщения). <br />
Ответ: код 200, если команда была обработана и отправлена.  <br />

### /GetLastEvent
##### *Get*
Запрашивает последнее произошедшее событие. <br />
Пример ответа: <br />
```
{[ <br />
  { <br />
    "eventId": 141, <br />
    "eventTime": "03.08.2022 14:14:49", <br />
    "eventDescr": "Корпус закрыт", <br />
    "segmentDescr": "Сегмент 1", <br />
    "partitionDescr": "Зона 2", <br />
    "deviceDescr": "1.1 КСГ РР-И-ПРО 2×S2", <br />
    "pathDescr": "3 Икар-ПРО", <br />
    "eventClassType": 0, <br />
    "color": "white", <br />
    "partitionGuid": "cf7240f9-4fbc-478c-841e-21b635b0d0c3", <br />
    "sensorGuid": "b047831a-4a21-468e-b10a-54b99bfe55f1", <br />
    "sensorNumber": 128, <br />
    "sensorAddress": 128, <br />
    "UserGuid": "00000000-0000-0000-0000-000000000000", <br />
    "userNumber": -1, <br />
    "userType": false, <br />
    "hex": "27 13 8E 71 58 00 80 02 01 24 00 00 00 00 00 00", <br />
    "eventType": 88, <br />
    "deviceType": 128, <br />
    "deviceSubType": 36, <br />
    "isEventRestored": true, <br />
    "addressType": false, <br />
    "nodeNumber": 1 <br />
  } <br />
]} <br />
```

> ## Команды управления разделами

### /Arm/{guid}
##### *Get* 
Команда постановки зоны на охрану, <br />
где 
- giud - GUID раздела

### /Disarm/{guid}
##### *Get*
Команда снятия зоны с охраны, <br />
где 
- giud - GUID раздела

### /Rearm/{guid}
##### *Get* 
Команда перепостановки зоны на охрану, <br />
где 
- giud - GUID раздела

### /DropProblems/{guid}
##### *Get* 
Команда постановки зоны на охрану, <br />
где 
- giud - GUID раздела

> ## Команды управления браслетами

### /SendMessage
##### *Post*
Отправляет сообщение на устройство. <br />
Тело запроса: <br />
```
{ <br />
  "recipients": [ <br />
    "string" <br />
  ], <br />
  "params": [ <br />
    "string" <br />
  ] <br />
} <br />
```
где <br />
- recipients - список получаетелей сообщения, <br />
- params - текст сообщения в качестве первого параметра <br />

### /SignalWristband/{guid}
##### *Get* 
Отправляет на браслет команду мигания светодиодами, <br />
где 
- guid - GUID браслета
