#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["api.multitracks.com/api.multitracks.com.csproj", "api.multitracks.com/"]
RUN dotnet restore "api.multitracks.com/api.multitracks.com.csproj"
COPY . .
WORKDIR "/src/api.multitracks.com"
RUN dotnet build "api.multitracks.com.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "api.multitracks.com.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "api.multitracks.com.dll"]