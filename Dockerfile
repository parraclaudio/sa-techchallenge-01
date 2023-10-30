# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0
EXPOSE 80
WORKDIR /app
COPY  ./app /app
ENTRYPOINT ["dotnet", "Api.dll"]
