# Test - Distribusi Inovasi Teknologi

## Recipe

- [Dotnet Core](https://dotnet.microsoft.com/en-us/download)
- [EntityFramework Core ORM](https://learn.microsoft.com/en-us/ef/core/)
- [Docker](https://docs.docker.com/install/)

## Project Running

1. Open via Visual Studio
2. Build all Project
3. Running Project WebAPI

## EntityFramework ORM

1. Edit Connection String on appsettings.json in WebAPI
2. Open Tab Package Manager Console
3. Set Default Project to Context Project
4. Running Migration

```
add-migration initial-context
```

5. Running Executor
```
update-database
```


