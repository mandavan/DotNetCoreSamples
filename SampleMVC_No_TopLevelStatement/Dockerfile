#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["SampleMVC_No_TopLevelStatement/SampleMVC_No_TopLevelStatement.csproj", "SampleMVC_No_TopLevelStatement/"]
RUN dotnet restore "SampleMVC_No_TopLevelStatement/SampleMVC_No_TopLevelStatement.csproj"
COPY . .
WORKDIR "/src/SampleMVC_No_TopLevelStatement"
RUN dotnet build "SampleMVC_No_TopLevelStatement.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SampleMVC_No_TopLevelStatement.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SampleMVC_No_TopLevelStatement.dll"]