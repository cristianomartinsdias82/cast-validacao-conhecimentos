#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Assinaturas.WebApi/Assinaturas.WebApi.csproj", "src/Assinaturas.WebApi/"]
COPY ["src/Assinaturas.WebApi.Presentation/Assinaturas.WebApi.Presentation.csproj", "src/Assinaturas.WebApi.Presentation/"]
COPY ["src/Assinaturas.Application/Assinaturas.Application.csproj", "src/Assinaturas.Application/"]
COPY ["src/Assinaturas.Domain/Assinaturas.Domain.csproj", "src/Assinaturas.Domain/"]
COPY ["src/Assinaturas.SharedKernel/Assinaturas.SharedKernel.csproj", "src/Assinaturas.SharedKernel/"]
COPY ["src/Assinaturas.Infrastructure.IoC/Assinaturas.Infrastructure.IoC.csproj", "src/Assinaturas.Infrastructure.IoC/"]
COPY ["src/Assinaturas.Infrastructure.Integrations.ViaCep/Assinaturas.Infrastructure.Integrations.ViaCep.csproj", "src/Assinaturas.Infrastructure.Integrations.ViaCep/"]
COPY ["src/Assinaturas.Infrastructure.Persistence.Ef/Assinaturas.Infrastructure.Persistence.Ef.csproj", "src/Assinaturas.Infrastructure.Persistence.Ef/"]
RUN dotnet restore "src/Assinaturas.WebApi/Assinaturas.WebApi.csproj"
COPY . .
WORKDIR "/src/src/Assinaturas.WebApi"
RUN dotnet build "Assinaturas.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Assinaturas.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Assinaturas.WebApi.dll"]