FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
RUN apt-get update && apt-get install -y --no-install-recommends curl

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY . ./
RUN dotnet restore  --interactive "src/Adapter/Driver/Api/Api.csproj"
COPY . .
WORKDIR "/src/Adapter/Driver/Api"
RUN dotnet build "Api.csproj" -c Release -o /app/build


FROM build AS publish
RUN dotnet publish "Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Api.dll"]