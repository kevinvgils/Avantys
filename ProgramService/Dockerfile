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
COPY ["ProgramService/ProgramService.csproj", "ProgramService/"]
COPY ["ProgramService.Domain/*.csproj", "ProgramService.Domain/"]
COPY ["EventLibrary/*.csproj", "EventLibrary/"]


# Restore as distinct layers
RUN dotnet restore "ProgramService/ProgramService.csproj"

COPY . .

WORKDIR "/App/ProgramService"
RUN dotnet build "ProgramService.csproj" -c Release -o /App/build

FROM build-env AS publish
RUN dotnet publish "ProgramService.csproj" -c Release -o /App/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /App
COPY --from=publish /App/publish .
ENTRYPOINT ["dotnet", "ProgramService.dll"]  

