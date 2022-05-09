FROM mcr.microsoft.com/dotnet/aspnet:5.0.407-bullseye-slim-arm64v8 AS base
LABEL maintainer="Dmytro Shymanskyi <dmytro.shymanskyi@pollub.edu.pl>"
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["zad1.csproj", "./"]
RUN dotnet restore "zad1.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "zad1.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "zad1.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "zad1.dll"]
