#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["project.api/project.api.csproj", "project.api/"]
COPY ["project.aspnetcore.infrastructure/project.aspnetcore.infrastructure.csproj", "project.aspnetcore.infrastructure/"]
COPY ["project.application/project.application.csproj", "project.application/"]
COPY ["project.domain/project.domain.csproj", "project.domain/"]
COPY ["project.data/project.data.csproj", "project.data/"]
RUN dotnet restore "project.api/project.api.csproj"
COPY . .
WORKDIR "/src/project.api"
RUN dotnet build "project.api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "project.api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "project.api.dll"]