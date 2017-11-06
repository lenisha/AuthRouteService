

# Cloud Foundry Route Service Example in .NET

This project is an example of a [Cloud Foundry Route Service][r] written with .NET[b].  This application does the following to each request:

1. Intercepts an incoming request
2. Logs information about that incoming request
3. Transforms the incoming request to an outgoing request
4. Logs information about that outgoing request
5. Forwards the request and response

## Requirements
### .NET and Nuget access

## Deployment
_The following instructions assume that you have [created an account][c] and [installed the `cf` command line tool][i]._

In order to automate the deployment process as much as possible, the project contains a Cloud Foundry [manifest][y].  To deploy run the following commands:
```bash
$ cf push
```

Next, create a user provided service that contains the route service configuration information.  To do this, run the following command, substituting the address that the route service is listening on:
```bash
$ cf create-user-provided-service test-route-service -r https://<ROUTE-SERVICE-ADDRESS>
```

The next step assumes that you have an application already running that you'd like to bind this route service to.  To do this, run the following command, substituting the domain and hostname bound to that application:
```bash
$ cf bind-route-service <APPLICATION-DOMAIN> test-route-service --hostname <APPLICATION-HOST>
```

In order to view the interception of the requests, you will need to stream the logs of the route service.  To do this, run the following command:
```bash
$ cf logs route-service-example
```

Finally, start making requests against your test application.  The route service's logs should start returning results that look similar to the following:
```text
OUT 2017-11-06 20:49:03.6196|DEBUG|AuthRouteService.ProxyHandler|Incoming Request Method: GET, RequestUri: 'http://sm-route.cfapps.pez.pivotal.io/', Version: 1.1, Content: System.Web.Http.WebHost.HttpControllerHandler+LazyStreamContent, Headers:
OUT 2017-11-06 20:49:03.6196|DEBUG|AuthRouteService.ProxyHandler|Outgoing Request Method: GET, RequestUri: 'http://sm-route.cfapps.pez.pivotal.io/', Version: 1.1, Content: System.Web.Http.WebHost.HttpControllerHandler+LazyStreamContent, Headers:
```

## License
The project is released under version 2.0 of the [Apache License][a].


[a]: http://www.apache.org/licenses/LICENSE-2.0
[c]: https://console.run.pivotal.io/register
[i]: http://docs.run.pivotal.io/devguide/installcf/install-go-cli.html
[r]: http://docs.cloudfoundry.org/services/route-services.html
[y]: manifest.yml
