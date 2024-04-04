#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["NitroBoostConsoleService.Web/NitroBoostConsoleService.Web.csproj", "NitroBoostConsoleService.Web/"]
COPY ["NitroBoostConsoleService.Core/NitroBoostConsoleService.Core.csproj", "NitroBoostConsoleService.Core/"]
COPY ["NitroBoostConsoleService.Data/NitroBoostConsoleService.Data.csproj", "NitroBoostConsoleService.Data/"]
COPY ["NitroBoostConsoleService.Dependency/NitroBoostConsoleService.Dependency.csproj", "NitroBoostConsoleService.Dependency/"]
RUN dotnet restore "NitroBoostConsoleService.Web/NitroBoostConsoleService.Web.csproj"
COPY . .
WORKDIR "/src/NitroBoostConsoleService.Web"
RUN dotnet build "NitroBoostConsoleService.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NitroBoostConsoleService.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NitroBoostConsoleService.Web.dll"]