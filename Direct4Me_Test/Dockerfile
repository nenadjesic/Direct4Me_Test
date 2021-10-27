FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY Direct4Me_Test.csproj .
RUN dotnet restore Direct4Me_Test.csproj
COPY . .
RUN dotnet build Direct4Me_Test.csproj -c Release -o /app/build

FROM build AS publish
RUN dotnet publish Direct4Me_Test.csproj -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Direct4Me_Test.dll"]
