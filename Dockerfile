#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS base
USER app
WORKDIR /app
EXPOSE 7211
EXPOSE 5239

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["./Api/Api.csproj", "Api/"]
COPY . .
WORKDIR "/src/Api"


