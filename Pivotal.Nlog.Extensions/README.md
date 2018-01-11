This project helps override Nlog minLevel setting based on the environment variables
(there is no simple way to do that in current NLog library, another way is to create custom condiftion to be used in filters)

```
> cf set-env <app-name> LOG_MINLEVEL_<LoggerName> <Level>
```
Where Level could be Trace, Debug, Error, Info, Warn, Fatal


To use add following on the startup of the application (e.g Global.asax.cs or Startup.cs class)

```
	Pivotal.Nlog.Extensions.StartupConfiguration.ConfigureEnvironment();
```
example NLog.config
```
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="http://www.nlog-project.org/schemas/NLog.xsd"
      xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
      xsi:schemaLocation="http://www.nlog-project.org/schemas/NLog.xsd NLog.xsd"
      autoReload="true"
      throwExceptions="false"
      internalLogLevel="Error" internalLogFile="c:\temp\nlog-internal.log">


  <targets>

		  <target xsi:type="Console" name="console"  
			layout="${longdate} ${uppercase:${level}} ${logger} ${message}" >
  
		  </target>
  </targets>

  <rules>
 
	  <logger name="TestNLog.Mind" minlevel="Trace" writeTo="console">
		  
	  </logger>
	  
  </rules>
</nlog>
```

To override set following environment variable
```
cf set-env <app-name> LOG_MINLEVEL_TestNLog.Mind Info
```
