#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
RUN mkdir TestAWSbatch
COPY ["TestAWSbatch/TestAWSbatch.csproj", "TestAWSbatch/"]
RUN dotnet restore "TestAWSbatch/TestAWSbatch.csproj"
COPY . .
WORKDIR "/src/TestAWSbatch"
RUN dotnet build "TestAWSbatch.csproj" -c Release --no-restore

FROM build AS publish
RUN dotnet publish --no-restore "TestAWSbatch.csproj" -c Release -o /app/publish /p:UseAppHost=false --no-restore

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TestAWSbatch.dll"]