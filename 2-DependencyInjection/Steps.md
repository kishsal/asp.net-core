# DEPENDENCY INJECTION in ASP.NET Core (https://www.youtube.com/watch?v=YR6HkvNBpX4&list=PL59L9XrzUa-nqfCHIKazYMFRKapPNI4sP&index=2)
## Repo: https://rahulpnath.visualstudio.com/DefaultCollection/YouTube%20Samples/_git/dependencyinjection

1) Create folder called '2-DependencyInjection'
2) Type `dotnet new webapi`
3) Review the files

Service Lifetimes:
- Transient: A new instance of the service is created every time it is requested.
- Scoped: A new instance of the service is created when the first instance is requested and is reused for subsequent requests.
- Singleton: A single instance of the service is created when the application starts and is reused for subsequent requests.





