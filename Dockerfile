#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0-alpine3.18-arm64v8 AS build
ARG TARGETARCH
WORKDIR /src
COPY . .
RUN dotnet publish "./NitroBoostConsoleService.Web/NitroBoostConsoleService.Web.csproj" -a ${TARGETARCH} -c Release -o /app/publish

FROM build AS final
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 7000
EXPOSE 7001
ENTRYPOINT ["dotnet", "NitroBoostConsoleService.Web.dll"]