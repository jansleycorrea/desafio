ARG APP_UID=1000

# Acesse https://aka.ms/customizecontainer para saber como personalizar seu contêiner de depuração e como o Visual Studio usa este Dockerfile para criar suas imagens para uma depuração mais rápida.

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
ARG APP_UID
ENV ASPNETCORE_URLS=http://+:8080
USER ${APP_UID}
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copia apenas os .csproj necessários para cache de camadas e para que o restore encontre referências de projeto
COPY ["Desafio.Api/Desafio.Api.csproj", "Desafio.Api/"]
COPY ["Desafio.Infrastructure/Desafio.Infrastructure.csproj", "Desafio.Infrastructure/"]
COPY ["Desafio.Application/Desafio.Application.csproj", "Desafio.Application/"]
COPY ["Desafio.Domain/Desafio.Domain.csproj", "Desafio.Domain/"]

RUN dotnet restore "Desafio.Api/Desafio.Api.csproj"

# Copia o resto do código
COPY . .
WORKDIR "/src/Desafio.Api"
RUN dotnet build "./Desafio.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Desafio.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Desafio.Api.dll"]