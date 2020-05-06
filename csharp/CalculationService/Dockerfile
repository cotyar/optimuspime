FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 8085

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["CalculationService/CalculationService.csproj", "CalculationService/"]
RUN dotnet restore "CalculationService/CalculationService.csproj"
COPY . .
WORKDIR "/src/CalculationService"
RUN dotnet build "CalculationService.csproj" -c Debug -o /app/build

FROM build AS publish
RUN dotnet publish "CalculationService.csproj" -c Debug -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CalculationService.dll"]
