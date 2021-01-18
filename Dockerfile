FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY ./SwapiMovies.sln ./ ./
COPY ./SwapiMovies.Mvc/SwapiMovies.Mvc.csproj ./app/SwapiMovies.Mvc/SwapiMovies.Mvc.csproj
COPY ./SwapiMovies.Core/SwapiMovies.Core.csproj ./app/SwapiMovies/SwapiMovies.Core.csproj
COPY ./SwapiMovies.Infrastructure/SwapiMovies.Infrastructure.csproj ./app/SwapiMovies.Infrastructure/SwapiMovies.Infrastructure.csproj

RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

EXPOSE 5432

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "SwapiMovies.Mvc.dll"]