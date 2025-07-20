FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 5050
EXPOSE 5432
ENV ASPNETCORE_HTTP_PORTS = 5050
ENV ASPNETCORE_URLS = http://0.0.0.0:5050

# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["BackendStrongmanDudlBLOG/BackendStrongmanDudlBLOG.csproj", "BackendStrongmanDudlBLOG/"]
COPY ["Entity/Entity.csproj", "Entity/"]
RUN dotnet restore "./BackendStrongmanDudlBLOG/BackendStrongmanDudlBLOG.csproj"
COPY . .
WORKDIR "/src/BackendStrongmanDudlBLOG"
RUN dotnet build "./BackendStrongmanDudlBLOG.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./BackendStrongmanDudlBLOG.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BackendStrongmanDudlBLOG.dll"]