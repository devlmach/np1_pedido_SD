# syntax=docker/dockerfile:1

# Etapa 1: 
# build/publish
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# copiar apenas .csproj para aproveitar o cache do "dotnet restore"
COPY trabalho_np1_pedido/trabalho_np1_pedido.csproj trabalho_np1_pedido/
RUN dotnet restore trabalho_np1_pedido/trabalho_np1_pedido.csproj

# copiar restante do código fonte e publicar em modo release
COPY trabalho_np1_pedido/ trabalho_np1_pedido/
WORKDIR /src/trabalho_np1_pedido
RUN dotnet publish -c Release -o /app/publish --no-restore

# Etapa 2:
# Etapa final - Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "trabalho_np1_pedido.dll"]