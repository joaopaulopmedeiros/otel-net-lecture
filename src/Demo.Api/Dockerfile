FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5252

ENV ASPNETCORE_URLS=http://+:5252

USER app
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["src/Demo.Api/Demo.Api.csproj", "src/Demo.Api/"]
RUN dotnet restore "src/Demo.Api/Demo.Api.csproj"
COPY . .
WORKDIR "/src/src/Demo.Api"
RUN dotnet build "Demo.Api.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "Demo.Api.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Demo.Api.dll"]
