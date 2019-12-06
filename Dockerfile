FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Technology Tp1 React.csproj", ""]
RUN dotnet restore "./Technology Tp1 React.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "Technology Tp1 React.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Technology Tp1 React.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Technology Tp1 React.dll"]