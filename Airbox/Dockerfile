#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Airbox/Airbox.csproj", "Airbox/"]
RUN dotnet restore "Airbox/Airbox.csproj"
COPY . .
WORKDIR "/src/Airbox"
RUN dotnet build "Airbox.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Airbox.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Airbox.dll"]