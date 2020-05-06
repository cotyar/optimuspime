FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8082

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["Orleans/Orleans.Grains.Interfaces/Orleans.Grains.Interfaces.csproj", "Orleans/Orleans.Grains.Interfaces/"]
COPY ["Orleans/Orleans.Grains/Orleans.Grains.csproj", "Orleans/Orleans.Grains/"]
COPY ["Orleans/Orleans.SiloGrpc/Orleans.SiloGrpc.csproj", "Orleans/Orleans.SiloGrpc/"]
RUN dotnet restore "Orleans/Orleans.SiloGrpc/Orleans.SiloGrpc.csproj"
COPY . .
WORKDIR "/src/Orleans/Orleans.SiloGrpc"
RUN dotnet build "Orleans.SiloGrpc.csproj" -c Debug -o /app/build

FROM build AS publish
RUN dotnet publish "Orleans.SiloGrpc.csproj" -c Debug -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Orleans.SiloGrpc.dll"]
