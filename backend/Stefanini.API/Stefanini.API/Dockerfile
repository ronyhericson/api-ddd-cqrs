#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

ENV ASPNETCORE_URLS=http://+:80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Stefanini.API/Stefanini.API/Stefanini.API.csproj", "Stefanini.API/"]
COPY ["Stefanini.Application/Stefanini.Application.csproj", "Stefanini.Application/"]
COPY ["Stefanini.Domain/Stefanini.Domain.csproj", "Stefanini.Application/"]
COPY ["Stefanini.Infrastructure/Stefanini.Infrastructure.csproj", "Stefanini.Application/"]
RUN dotnet restore "Stefanini.API/Stefanini.API.csproj"
COPY . .
WORKDIR "/src/Stefanini.API"
RUN dotnet build "Stefanini.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Stefanini.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Stefanini.API.dll"]