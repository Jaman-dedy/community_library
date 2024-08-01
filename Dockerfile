FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/CommunityLibrary.Api/CommunityLibrary.Api.csproj", "src/CommunityLibrary.Api/"]
COPY ["src/CommunityLibrary.Application/CommunityLibrary.Application.csproj", "src/CommunityLibrary.Application/"]
COPY ["src/CommunityLibrary.Core/CommunityLibrary.Core.csproj", "src/CommunityLibrary.Core/"]
COPY ["src/CommunityLibrary.Infrastructure/CommunityLibrary.Infrastructure.csproj", "src/CommunityLibrary.Infrastructure/"]
RUN dotnet restore "src/CommunityLibrary.Api/CommunityLibrary.Api.csproj"
COPY . .
WORKDIR "/src/src/CommunityLibrary.Api"
RUN dotnet build "CommunityLibrary.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CommunityLibrary.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CommunityLibrary.Api.dll"]