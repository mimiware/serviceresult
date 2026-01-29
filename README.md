![build](https://github.com/mimiware/serviceresult/actions/workflows/dotnet.yml/badge.svg)
[![Coverage Status](https://coveralls.io/repos/github/mimiware/serviceresult/badge.svg?branch=main)](https://coveralls.io/github/mimiware/serviceresult?branch=main)
![SonarQube](https://sonarcloud.io/api/project_badges/measure?project=mimiware_serviceresult&metric=sqale_rating)
[![Code smells](https://sonarcloud.io/api/project_badges/measure?project=mimiware_serviceresult&metric=code_smells)](https://sonarcloud.io/dashboard?id=mimiware_serviceresult)

# Service Result

ServiceResult is a minimalistic generic service result library for your service (domain) layer. By using a generic service result, your application will have a clean interface towards the service layer that will easy to unit test.

The library consists of ~150 lines of code, is 100% unit tested, and proven in production since 2008 at multiple large enterprises. It targets **netstandard2.0** and **net8.0**.

## Installation

### .NET CLI

```
dotnet add package Mimiware.ServiceResult
```

### Package Manager

```
Install-Package Mimiware.ServiceResult
```

### PackageReference

```xml
<PackageReference Include="Mimiware.ServiceResult" Version="1.4.1" />
```

NuGet: https://www.nuget.org/packages/Mimiware.ServiceResult/

## Quick start

### Service layer

```csharp
public IServiceResult<UsersViewModel> GetUsers(string searchString)
{
    var result = new ServiceResult<UsersViewModel>();

    try
    {
        var users = _userRepository.GetUsers(searchString);
        var response = UsersViewModelFactory.Create(users);
        return result.Ok(response);
    }
    catch (Exception)
    {
        return result.Error(message: "Failed to get users");
    }
}
```

### Controller layer

```csharp
[HttpGet]
public ActionResult<UsersViewModel> GetUsers(string searchString)
{
    var result = _userService.GetUsers(searchString);

    return result.IsSuccessCode
        ? Ok(result.Data)
        : StatusCode(result.Code, result.Data);
}
```

## Architecture

![Usage Context](docs/usage-context.png)

## License

MIT
