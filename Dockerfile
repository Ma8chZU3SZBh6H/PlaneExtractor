FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app
CMD dotnet build "./App/App.csproj" -c Release -o /app/build && cd build && ./App
