FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

COPY ./publish /app

CMD ["dotnet", "MyApp.dll"]
