#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["../../web-api/src/jsm.product.manager.api/jsm.product.manager.api.csproj", "jsm.product.manager.api/"]
COPY ["../../web-api/src/jsm.product.manager.aspnetcore.infrastructure/jsm.product.manager.aspnetcore.infrastructure.csproj", "jsm.product.manager.aspnetcore.infrastructure/"]
COPY ["../../web-api/src/jsm.product.manager.application/jsm.product.manager.application.csproj", "jsm.product.manager.application/"]
COPY ["../../web-api/src/jsm.product.manager.contracts/jsm.product.manager.contracts.csproj", "src/jsm.product.manager.contracts/"]
COPY ["../../web-api/src/jsm.product.manager.domain/jsm.product.manager.domain.csproj", "jsm.product.manager.domain/"]
COPY ["../../web-api/src/jsm.product.manager.data/jsm.product.manager.data.csproj", "jsm.product.manager.data/"]
RUN dotnet restore "./src/jsm.product.manager.api/jsm.product.manager.api.csproj"
COPY ./../../web-api/src .
WORKDIR "/src/jsm.product.manager.api"
RUN dotnet build "./jsm.product.manager.api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./jsm.product.manager.api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "jsm.product.manager.api.dll"]