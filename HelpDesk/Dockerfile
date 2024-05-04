FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

RUN apt-get update && apt-get install -y wget \
    && wget https://storage.googleapis.com/cloud-sql-connectors/cloud-sql-proxy/v2.11.0/cloud-sql-proxy.linux.amd64 -O /usr/local/bin/cloud-sql-proxy \
    && chmod +x /usr/local/bin/cloud-sql-proxy

ENV ASPNETCORE_URLS=http://+:8080


FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["./", "HelpDesk/"]
RUN dotnet restore "HelpDesk/HelpDesk.csproj"
COPY . .
WORKDIR "/src/HelpDesk"
RUN dotnet build "HelpDesk.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "HelpDesk.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY entrypoint.sh /app/
RUN chmod +x /app/entrypoint.sh
USER app
ENTRYPOINT ["/app/entrypoint.sh"]

