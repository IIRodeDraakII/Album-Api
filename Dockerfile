  # syntax=docker/dockerfile:1
  FROM mcr.microsoft.com/dotnet/aspnet:5.0
  COPY ./Release/ App/
  WORKDIR /App
  ENTRYPOINT ["dotnet", "aspnetapp.dll"]    