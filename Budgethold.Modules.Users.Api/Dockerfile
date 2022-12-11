FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Budgethold.Modules.Users.Api/Budgethold.Modules.Users.Api.csproj", "Budgethold.Modules.Users.Api/"]
RUN dotnet restore "Budgethold.Modules.Users.Api/Budgethold.Modules.Users.Api.csproj"
COPY . .
WORKDIR "/src/Budgethold.Modules.Users.Api"
RUN dotnet build "Budgethold.Modules.Users.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Budgethold.Modules.Users.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Budgethold.Modules.Users.Api.dll"]
