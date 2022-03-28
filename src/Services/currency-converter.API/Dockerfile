FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["Services/currency-converter.API/currency-converter.API.csproj", "Services/currency-converter.API/"]
COPY ["Adapters/currency-converter.Adapters.DataAccess/currency-converter.Adapters.DataAccess.csproj", "Adapters/currency-converter.Adapters.DataAccess/"]
COPY ["Modules/currency-converter.Modules.Domain/currency-converter.Modules.Domain/currency-converter.Modules.Domain.csproj", "Modules/currency-converter.Modules.Domain/currency-converter.Modules.Domain/"]
COPY ["Modules/currency-converter.Modules.Infrastructure/currency-converter.Modules.Infrastructure.csproj", "Modules/currency-converter.Modules.Infrastructure/"]
COPY ["Modules/currency-converter.Modules.Application/currency-converter.Modules.Application.csproj", "Modules/currency-converter.Modules.Application/"]
COPY ["Adapters/currency-converter.Adapters.Provider/currency-converter.Adapters.Provider.csproj", "Adapters/currency-converter.Adapters.Provider/"]
COPY ["Adapters/currency-converter.Adapters.DataRead/currency-converter.Adapters.DataRead.csproj", "Adapters/currency-converter.Adapters.DataRead/"]
COPY ["Services/currency-converter.Services.Provider/currency-converter.Services.Provider.csproj", "Services/currency-converter.Services.Provider/"]
RUN dotnet restore "Services/currency-converter.API/currency-converter.API.csproj"
COPY . .

WORKDIR "/src/Services/currency-converter.API"
RUN dotnet build "currency-converter.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "currency-converter.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "currency-converter.API.dll"]