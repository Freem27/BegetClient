# Unofficial API client for Beget.com API
#### .net API wrapper for https://beget.com/

official api docs: https://beget.com/ru/kb/api/beget-api

## Install
Build the project yourself and connect it to the project as a .dll or install the nuget package ```TDV.BegetClient```



## Configuring
```csharp
using TDV.BegetClient;

var _client = new BegetClient(user, passwd)
```
where
 ```user``` - user name
```passwd``` - API password

## Domain
### Returns all zones list
```csharp
var zones = await _client.Domain.GetZoneList();
```

### Check domain is available for register
```csharp
var resp = await _client.Domain.CheckDomainToRegister("wwww", 1)
```


## Tests
To run tests, set the ```user``` and ```passwd``` enviromen variables for  ```TDV.BegetClient.Test``` project