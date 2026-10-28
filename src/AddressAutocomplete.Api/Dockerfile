# Etapa 1: ambiente de compilação
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copia os arquivos de projeto para restaurar os pacotes
COPY ["src/AddressAutocomplete.Api/AddressAutocomplete.Api.csproj", "src/AddressAutocomplete.Api/"]
COPY ["src/AddressAutocomplete.Application/AddressAutocomplete.Application.csproj", "src/AddressAutocomplete.Application/"]
COPY ["src/AddressAutocomplete.Infrastructure/AddressAutocomplete.Infrastructure.csproj", "src/AddressAutocomplete.Infrastructure/"]

RUN dotnet restore "src/AddressAutocomplete.Api/AddressAutocomplete.Api.csproj"

# Copia o restante do código-fonte
COPY . .

# Compila e publica a API
WORKDIR /src/src/AddressAutocomplete.Api
RUN dotnet publish "AddressAutocomplete.Api.csproj" \
    --configuration Release \
    --output /app/publish \
    /p:UseAppHost=false

# Etapa 2: ambiente de execução
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app

COPY --from=build /app/publish .

ENV ASPNETCORE_HTTP_PORTS=8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "AddressAutocomplete.Api.dll"]