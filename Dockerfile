FROM mcr.microsoft.com/dotnet/core/sdk:3.1

COPY . /app

WORKDIR /app

RUN dotnet restore
RUN dotnet build
RUN dotnet ef database update

CMD ["dotnet", "run", "--project", "MyApp.csproj", "--urls", "http://0.0.0.0:80"]