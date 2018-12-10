# Autodesk.Forge.DesignAutomation - the C# client library for Forge Design Automation

Generated by [Forge Swagger Codegen](https://git.autodesk.com/design-automation/forge-rsdk-codegen)

- API version: v3
- SDK version: 1.0.0
- Build date: 2018-12-10T14:15:30.821-08:00

For more information, please visit [https://forge.autodesk.com/en/docs/design-automation/v3/developers_guide/overview/](https://forge.autodesk.com/en/docs/design-automation/v3/developers_guide/overview/)

## Frameworks supported
- .NET Standard >=2.0

## Build
```
dotnet build Autodesk.Forge.DesignAutomation.sln
```

## Overview

For each top level resource 2 API classes are provided: a high level API that completely abstracts the underlying HTTP transport and a low level API that provides access to the http request and reponse details.
Each high level API class uses the corresponding low level API class via the `LowLevelApi` property.

__High level API:__
[ActivitiesApi](src/ActivitiesApi.cs),
[AppBundlesApi](src/AppBundlesApi.cs),
[EnginesApi](src/EnginesApi.cs),
[ForgeAppsApi](src/ForgeAppsApi.cs),
[HealthApi](src/HealthApi.cs),
[SharesApi](src/SharesApi.cs),
[WorkItemsApi](src/WorkItemsApi.cs)

__Low level API:__
[ActivitiesApi](src/Http/ActivitiesApiHttp.cs),
[AppBundlesApi](src/Http/AppBundlesApiHttp.cs),
[EnginesApi](src/Http/EnginesApiHttp.cs),
[ForgeAppsApi](src/Http/ForgeAppsApiHttp.cs),
[HealthApi](src/Http/HealthApiHttp.cs),
[SharesApi](src/Http/SharesApiHttp.cs),
[WorkItemsApi](src/Http/WorkItemsApiHttp.cs)

This SDK depends on the [Autodesk.Forge.Core](https://git.autodesk.com/design-automation/Autodesk.Forge.Core) assembly which provides services such as:
1. Acquisition of [2 legged oauth token](https://forge.autodesk.com/en/docs/oauth/v2/tutorials/get-2-legged-token/) (and refreshing it when it expires)
2. Preconfigurated resiliency patterns (e.g. retry) using [Polly](https://github.com/App-vNext/Polly)

## Getting Started

To use the API you must instantiate one of the API classes and configure it with the valid forge credentials. You can do this in 2 ways:
1. By using dependency injection and [configuration providers](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/#providers
) (PREFERRED)
2. By directly creating instances of one of API classes and the [ForgeConfiguration](https://git.autodesk.com/design-automation/Autodesk.Forge.Core/src/ForgeConfiguration.cs) class and setting is properites

### Configuration

There are 2 classes that you can use to configure the API:
1. [Autodesk.Forge.Core.ForgeConfiguration](https://git.autodesk.com/design-automation/Autodesk.Forge.Core/src/ForgeConfiguration.cs) - Allows the configuration of Forge client credentials and alternative authentication service endpoint (default is https://developer.api.autodesk.com/authentication/v1/authenticate)
2. [Autodesk.Forge.DesignAutomation.Configuration](src/Configuration.cs)- Allows the configuration of non-default API endpoint (default is https://developer.api.autodesk.com/da/us-east).

This SDK integrates with the .netcore configuration system. You can configure the above values via any configuration provider (e.g. `appsettings.json` or environment variables).
For example to set the Forge credentials you could define the following environment variables:
```bash
Forge__ClientId=<your client id>
Forge__ClientSecret=<your client secret>
```
or the following in your `appsettings.json`:
```json
{
    "Forge": {
        "ClientId" : "<your client id>",
        "ClientSecret" : "<your client secret>"
    }
}
```
### Examples
#### Using dependency injection
First you must add Autodesk.Forge.DesignAutomation services. This is usually done in `ConfigureServices(...)` method of your Startup class. [More information](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection)

__NOTE__: This example assumes that you are building an [Asp.Net Core](https://docs.microsoft.com/en-us/aspnet/core/) web api or website. 
If you want to use dependency injection in a console app then follow [this example](https://keestalkstech.com/2018/04/dependency-injection-with-ioptions-in-console-apps-in-net-core-2/).
```csharp
using Autodesk.Forge.DesignAutomation;
using Autodesk.Forge.DesignAutomation.Model;
...
public void ConfigureServices(IServiceCollection services)
{
    services.ConfigureDesignAutomation(this.Configuration);
    services.AddDesignAutomation();
}
```
Then you can use any of the API classes or interfaces in a constructor:
```csharp
using Autodesk.Forge.DesignAutomation;
...
public class SomeApiController : ControllerBase
{
    public SomeApiController(IWorkItemsApi forgeApi)
    {
        //use forgeApi here
    }
```
#### By directly creating API objects

```csharp
using Autodesk.Forge.DesignAutomation;
using System.Net.Http;
using System.Threading.Tasks;
using Autodesk.Forge.Core;

internal class Program
{
    public static void Main(string[] args)
    {
        var service =
            new ForgeService(
                new HttpClient(
                    new ForgeHandler(Microsoft.Extensions.Options.Options.Create(new ForgeConfiguration()
                    {
                        ClientId = "<your client id>",
                        ClientSecret = "<your client secret>"
                    }))
                {
                    InnerHandler = new HttpClientHandler()
                })
            );

        var forgeApi = new WorkItemsApi(service);
    }
}
```
