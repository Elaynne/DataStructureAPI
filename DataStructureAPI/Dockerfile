FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY [".", "DataStructureAPI/"]
RUN dotnet restore "DataStructureAPI/DataStructureAPI.csproj"
COPY . .
WORKDIR "/src/DataStructureAPI"
RUN dotnet build "DataStructureAPI.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "DataStructureAPI.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "DataStructureAPI.dll"]