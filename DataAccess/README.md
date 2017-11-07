

# DB2 .NET Core DataAccess

This project is an example of a [.NET Core NuGet Package][r] being consumed by a .NET Core App and a .NET Full App

1. Example.Data.Standard - holds refernce to IBM DB2 .NET Core NuGet Package
2. Example.Data.Full - holds references to NuGet Packages for Sybase and Oracle Drivers (Full .NET Framework), as well as DB2Wrpper (wraps Example.Data.Standard)
3. Example.CoreConsole - Console app to 'exercise' Example.Data.Standard (.NET Core app references .NET Standard App)
4. Example.FullConsole - - Console app to 'exercise' Example.Data.Full (.NET Full app references .NET Standard App)


## Requirements
### .NET and Nuget access


## License
The project is released under version 2.0 of the [Apache License][a].


[a]: http://www.apache.org/licenses/LICENSE-2.0
[c]: https://console.run.pivotal.io/register
[i]: http://docs.run.pivotal.io/devguide/installcf/install-go-cli.html
[r]: http://docs.cloudfoundry.org/services/route-services.html
[y]: AuthRouteService/manifest.yml
