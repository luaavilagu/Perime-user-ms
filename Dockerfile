FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 5001
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["userService.csproj", "./"]
RUN dotnet restore "./userService.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "userService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "userService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "userService.dll"]
