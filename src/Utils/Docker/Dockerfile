FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /
EXPOSE 443
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /
COPY . .
RUN dotnet restore "src/Server/SSDCPortal.Server/SSDCPortal.Server.csproj"
WORKDIR "/src/Server/SSDCPortal.Server"
RUN dotnet build "SSDCPortal.Server.csproj" -c Release -o /app/build --no-restore

FROM build AS publish
RUN dotnet publish "SSDCPortal.Server.csproj" -c Release -o /app/publish
RUN dotnet dev-certs https --clean
RUN dotnet dev-certs https -ep /app/publish/aspnetapp.pfx -p MyCujo23
#if .pfx was provided from certificate authority uncomment the below
#COPY src/Server/SSDCPortal.Server/AuthSample.pfx /app/publish/aspnetapp.pfx

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY --from=publish /app/publish/aspnetapp.pfx ./AuthSample.pfx
ENTRYPOINT ["dotnet", "SSDCPortal.Server.dll"]
