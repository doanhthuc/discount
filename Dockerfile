# FROM mcr.microsoft.com/dotnet/core/sdk:3.1

# COPY . /app

# WORKDIR /app

# RUN dotnet restore
# RUN dotnet build
# RUN dotnet ef database update

# CMD ["dotnet", "run", "--project", "MyApp.csproj", "--urls", "http://0.0.0.0:80"]

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /App

# Copy everything
COPY . ./
# Restore as distinct layers
RUN dotnet restore
RUN dotnet build

# Build and publish a release
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /App
COPY --from=build-env /App/out .
EXPOSE 80
ENTRYPOINT ["dotnet", "DotNet.Docker.dll"]