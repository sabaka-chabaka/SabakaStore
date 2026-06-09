FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY SabakaStore.Domain/SabakaStore.Domain.csproj             SabakaStore.Domain/
COPY SabakaStore.Infrastructure/SabakaStore.Infrastructure.csproj SabakaStore.Infrastructure/
COPY SabakaStore.Application/SabakaStore.Application.csproj   SabakaStore.Application/
COPY SabakaStore.API/SabakaStore.API.csproj                   SabakaStore.API/

RUN dotnet restore SabakaStore.API/SabakaStore.API.csproj

COPY . .

RUN dotnet publish SabakaStore.API/SabakaStore.API.csproj \
    -c Release \
    -o /app/publish \
    --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app

COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "SabakaStore.API.dll"]