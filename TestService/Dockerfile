# To build application into a container from dockerfile:
# docker build
# To build application into a container from .NET (available since .NET 8):
# dotnet publish /p:PublishProfile=DefaultContainer

# To run this container (mapping port 8080 from the host, which might be your computer to 8080 of the container):
# docker run -d -p 8080:8080 hello-container

# First we use the SDK base image to build our application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /App

# Copy everything
COPY ["TestService/TestService.csproj", "TestService/"]
COPY ["TestService.Domain/*.csproj", "TestService.Domain/"]


# Restore as distinct layers
RUN dotnet restore "TestService/TestService.csproj"

COPY . .

WORKDIR "/App/TestService"
RUN dotnet build "TestService.csproj" -c Release -o /App/build

FROM build-env AS publish
RUN dotnet publish "TestService.csproj" -c Release -o /App/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /App
COPY --from=publish /App/publish .
ENTRYPOINT ["dotnet", "TestService.dll"]  

