# Gamitin ang .NET SDK para i-build ang project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# I-copy ang project file at i-restore ang dependencies
COPY *.csproj ./
RUN dotnet restore

# I-copy ang lahat ng files at i-publish ang app
COPY . ./
RUN dotnet publish -c Release -o out

# Gamitin ang ASP.NET runtime para patakbuhin ang app
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .

# Sabihin sa Render kung anong port ang gagamitin (Default for ASP.NET is 80 or 8080)
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "HelicalToroidFrustum.dll"]
