# Use a imagem base do .NET 6
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

# Use a imagem do SDK para construir a aplicação
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TodoAngularApi.csproj", "./"]
RUN dotnet restore "TodoAngularApi.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "TodoAngularApi.csproj" -c Release -o /app/build

# Publicar a aplicação
FROM build AS publish
RUN dotnet publish "TodoAngularApi.csproj" -c Release -o /app/publish

# Criar a imagem final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TodoAngularApi.dll"]
