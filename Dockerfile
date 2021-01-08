FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /source

COPY *.csproj ./aspnetdocker/
WORKDIR /source/aspnetdocker
RUN dotnet restore

COPY /. ./aspnetdocker/

RUN dotnet publish -c release -o /app --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS runtime
WORKDIR /app
COPY --from=build /app ./

ENV ASPNETCORE_URLS=http://+:5000

ENTRYPOINT ["dotnet", "LocadoraAspNet.dll"]