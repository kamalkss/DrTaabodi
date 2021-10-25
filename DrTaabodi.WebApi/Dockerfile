#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["DrTaabodi.WebApi/DrTaabodi.WebApi.csproj", "DrTaabodi.WebApi/"]
COPY ["DrTaabodi.Data/DrTaabodi.Data.csproj", "DrTaabodi.Data/"]
COPY ["DrTaabodi.Services/DrTaabodi.Services.csproj", "DrTaabodi.Services/"]
RUN dotnet restore "DrTaabodi.WebApi/DrTaabodi.WebApi.csproj"
COPY . .
WORKDIR "/src/DrTaabodi.WebApi"
RUN dotnet build "DrTaabodi.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DrTaabodi.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DrTaabodi.WebApi.dll"]