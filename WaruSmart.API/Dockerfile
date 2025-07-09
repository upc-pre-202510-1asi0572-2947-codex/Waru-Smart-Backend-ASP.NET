# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiar archivos de solución y proyectos primero
COPY ../waru-smart-codex.sln ./
COPY ./WaruSmart.API/WaruSmart.API.csproj ./WaruSmart.API/
# Si tienes más proyectos, agrégalos aquí

# Restaurar dependencias
RUN dotnet restore "waru-smart-codex.sln"

# Copiar el resto del código fuente
COPY ../ ./
WORKDIR /app/WaruSmart.API

# Publicar la aplicación
RUN dotnet publish "WaruSmart.API.csproj" -c Release -o /app/publish --no-restore

# Etapa de runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 80
ENV ASPNETCORE_URLS=http://+:80
ENTRYPOINT ["dotnet", "WaruSmart.API.dll"]
