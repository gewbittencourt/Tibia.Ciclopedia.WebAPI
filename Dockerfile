
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app


FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src


COPY ["Tibia.Ciclopedia.API/Tibia.Ciclopedia.API.csproj", "Tibia.Ciclopedia.API/"]
COPY ["Tibia.Ciclopedia.Application/Tibia.Ciclopedia.Application.csproj", "Tibia.Ciclopedia.Application/"]
COPY ["Tibia.Ciclopedia.Domain/Tibia.Ciclopedia.Domain.csproj", "Tibia.Ciclopedia.Domain/"]
COPY ["Tibia.Ciclopedia.Infrastructure.MongoDb/Tibia.Ciclopedia.Infrastructure.MongoDb.csproj", "Tibia.Ciclopedia.Infrastructure.MongoDb/"]
COPY ["Tibia.Ciclopedia.Infrastructure.MongoDb/Tibia.Ciclopedia.Infrastructure.CrossCutting.csproj", "Tibia.Ciclopedia.Infrastructure.CrossCutting/"]
COPY ["Tibia.Ciclopedia.Tests/Tibia.Ciclopedia.Tests.csproj", "Tibia.Ciclopedia.Tests/"]


RUN dotnet restore "Tibia.Ciclopedia.API/Tibia.Ciclopedia.API.csproj"

COPY . .
WORKDIR "/src/Tibia.Ciclopedia.API"
RUN dotnet build "Tibia.Ciclopedia.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Tibia.Ciclopedia.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /runtime-app
COPY --from=publish /app/publish .

EXPOSE 8080
ENTRYPOINT ["dotnet", "Tibia.Ciclopedia.API.dll"]