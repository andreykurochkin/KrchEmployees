FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["KrchEmployees/KrchEmployees.csproj", "KrchEmployees/"]
RUN dotnet restore "KrchEmployees/KrchEmployees.csproj"
COPY . .
WORKDIR "/src/KrchEmployees"
RUN dotnet build "KrchEmployees.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "KrchEmployees.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "KrchEmployees.dll"]
