FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["HemaWebApi/HemaWebApi.csproj", "HemaWebApi/"]
RUN dotnet restore "HemaWebApi/HemaWebApi.csproj"
COPY . .
WORKDIR "/src/HemaWebApi"
RUN dotnet build "HemaWebApi.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "HemaWebApi.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "HemaWebApi.dll"]