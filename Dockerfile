FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["CompanyWebApi.csproj", "."]
RUN dotnet restore "./CompanyWebApi.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "CompanyWebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CompanyWebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

RUN dotnet tool install --global dotnet-ef


#Build runtime images
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CompanyWebApi.dll"]