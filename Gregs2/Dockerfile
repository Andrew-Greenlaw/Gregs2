FROM mcr.microsoft.com/dotnet/sdk:6.0 AS base
WORKDIR /app
EXPOSE 80/tcp

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Gregs2.csproj", "./"]
RUN dotnet restore "Gregs2.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "Gregs2.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Gregs2.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Gregs2.dll"]
