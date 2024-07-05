# Use the official .NET SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /server

# Copy everything
COPY . ./
# Restore as distinct layers
RUN dotnet restore
# Build and publish a release
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /server
COPY --from=build /server/out .
ENTRYPOINT [ "dotnet", "server.dll" ]

# Expose the necessary ports
EXPOSE 8080