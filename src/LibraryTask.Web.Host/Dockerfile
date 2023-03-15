FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /src
COPY ["src/LibraryTask.Web.Host/LibraryTask.Web.Host.csproj", "src/LibraryTask.Web.Host/"]
COPY ["src/LibraryTask.Web.Core/LibraryTask.Web.Core.csproj", "src/LibraryTask.Web.Core/"]
COPY ["src/LibraryTask.Application/LibraryTask.Application.csproj", "src/LibraryTask.Application/"]
COPY ["src/LibraryTask.Core/LibraryTask.Core.csproj", "src/LibraryTask.Core/"]
COPY ["src/LibraryTask.EntityFrameworkCore/LibraryTask.EntityFrameworkCore.csproj", "src/LibraryTask.EntityFrameworkCore/"]
WORKDIR "/src/src/LibraryTask.Web.Host"
RUN dotnet restore 

WORKDIR /src
COPY ["src/LibraryTask.Web.Host", "src/LibraryTask.Web.Host"]
COPY ["src/LibraryTask.Web.Core", "src/LibraryTask.Web.Core"]
COPY ["src/LibraryTask.Application", "src/LibraryTask.Application"]
COPY ["src/LibraryTask.Core", "src/LibraryTask.Core"]
COPY ["src/LibraryTask.EntityFrameworkCore", "src/LibraryTask.EntityFrameworkCore"]
WORKDIR "/src/src/LibraryTask.Web.Host"
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:7.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "LibraryTask.Web.Host.dll"]
