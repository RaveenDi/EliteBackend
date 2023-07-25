#Build stage
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore "./EliteBackend.csproj" --disable-parallel
RUN dotnet publish "EliteBackend.csproj" -c Release -o /app --no-restore

#Serve stage
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
COPY --from=build /app ./

EXPOSE 5000

ENTRYPOINT ["dotnet", "EliteBackend.dll"]