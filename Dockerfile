FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY . .

FROM build AS publish
RUN dotnet restore 
RUN dotnet publish "src/ProductCatalog.Api/ProductCatalog.Api.csproj" -c Release -o /out

FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=publish /out .

ENTRYPOINT ["dotnet", "ProductCatalog.Api.dll"]
