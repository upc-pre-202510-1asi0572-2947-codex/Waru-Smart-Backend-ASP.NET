# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar archivos de solución y proyecto
COPY waru-smart-codex.sln ./
COPY WaruSmart.API/WaruSmart.API.csproj WaruSmart.API/

# Restaurar dependencias
RUN dotnet restore "waru-smart-codex.sln"

# Copiar el resto del código fuente
COPY WaruSmart.API/ WaruSmart.API/

WORKDIR /src/WaruSmart.API

# Publicar la aplicación
RUN dotnet publish "WaruSmart.API.csproj" -c Release -o /app/publish

# Etapa de runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 80
ENV ASPNETCORE_URLS=http://+:80
ENTRYPOINT ["dotnet", "WaruSmart.API.dll"]

