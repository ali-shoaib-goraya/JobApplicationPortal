FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src
COPY ["src/JobApplicationPortal.Web.Host/JobApplicationPortal.Web.Host.csproj", "src/JobApplicationPortal.Web.Host/"]
COPY ["src/JobApplicationPortal.Web.Core/JobApplicationPortal.Web.Core.csproj", "src/JobApplicationPortal.Web.Core/"]
COPY ["src/JobApplicationPortal.Application/JobApplicationPortal.Application.csproj", "src/JobApplicationPortal.Application/"]
COPY ["src/JobApplicationPortal.Core/JobApplicationPortal.Core.csproj", "src/JobApplicationPortal.Core/"]
COPY ["src/JobApplicationPortal.EntityFrameworkCore/JobApplicationPortal.EntityFrameworkCore.csproj", "src/JobApplicationPortal.EntityFrameworkCore/"]
WORKDIR "/src/src/JobApplicationPortal.Web.Host"
RUN dotnet restore 

WORKDIR /src
COPY ["src/JobApplicationPortal.Web.Host", "src/JobApplicationPortal.Web.Host"]
COPY ["src/JobApplicationPortal.Web.Core", "src/JobApplicationPortal.Web.Core"]
COPY ["src/JobApplicationPortal.Application", "src/JobApplicationPortal.Application"]
COPY ["src/JobApplicationPortal.Core", "src/JobApplicationPortal.Core"]
COPY ["src/JobApplicationPortal.EntityFrameworkCore", "src/JobApplicationPortal.EntityFrameworkCore"]
WORKDIR "/src/src/JobApplicationPortal.Web.Host"
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "JobApplicationPortal.Web.Host.dll"]
