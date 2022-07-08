FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TelepathyLabs.ShowReels.Api/TelepathyLabs.ShowReels.Api.csproj", "TelepathyLabs.ShowReels.Api/"]
COPY ["TelepathyLabs.ShowReels.Domain/TelepathyLabs.ShowReels.Domain.csproj", "TelepathyLabs.ShowReels.Domain/"]
COPY ["TelepathyLabs.ShowReels.DataAccess/TelepathyLabs.ShowReels.DataAccess.csproj", "TelepathyLabs.ShowReels.DataAccess/"]
RUN dotnet restore "TelepathyLabs.ShowReels.Api/TelepathyLabs.ShowReels.Api.csproj"
COPY . .
WORKDIR "/src/TelepathyLabs.ShowReels.Api"
RUN dotnet build "TelepathyLabs.ShowReels.Api.csproj" -c Debug -o /app/build

FROM build AS publish
RUN dotnet publish "TelepathyLabs.ShowReels.Api.csproj" -c Debug -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TelepathyLabs.ShowReels.Api.dll"]
