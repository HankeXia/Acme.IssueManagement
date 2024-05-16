#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
 

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["NuGet.Config", "."]
COPY ["host/Acme.IssueManagement.HttpApi.Host/Acme.IssueManagement.HttpApi.Host.csproj", "host/Acme.IssueManagement.HttpApi.Host/"]
COPY ["src/Acme.IssueManagement.HttpApi/Acme.IssueManagement.HttpApi.csproj", "src/Acme.IssueManagement.HttpApi/"]
COPY ["src/Acme.IssueManagement.Application.Contracts/Acme.IssueManagement.Application.Contracts.csproj", "src/Acme.IssueManagement.Application.Contracts/"]
COPY ["src/Acme.IssueManagement.Domain.Shared/Acme.IssueManagement.Domain.Shared.csproj", "src/Acme.IssueManagement.Domain.Shared/"]
COPY ["src/Acme.IssueManagement.Application/Acme.IssueManagement.Application.csproj", "src/Acme.IssueManagement.Application/"]
COPY ["src/Acme.IssueManagement.Domain/Acme.IssueManagement.Domain.csproj", "src/Acme.IssueManagement.Domain/"]
COPY ["src/Acme.IssueManagement.EntityFrameworkCore/Acme.IssueManagement.EntityFrameworkCore.csproj", "src/Acme.IssueManagement.EntityFrameworkCore/"]
COPY ["host/Acme.IssueManagement.Host.Shared/Acme.IssueManagement.Host.Shared.csproj", "host/Acme.IssueManagement.Host.Shared/"]
RUN dotnet restore "./host/Acme.IssueManagement.HttpApi.Host/Acme.IssueManagement.HttpApi.Host.csproj"
COPY . .
WORKDIR "/src/host/Acme.IssueManagement.HttpApi.Host"
RUN dotnet build "./Acme.IssueManagement.HttpApi.Host.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Acme.IssueManagement.HttpApi.Host.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

COPY --from=publish /app/publish/fonts/ /usr/share/fonts/
RUN chmod -R 777 /usr/share/fonts/

RUN sed -i 's/http:\/\/deb.debian.org/http:\/\/mirrors.aliyun.com/g' /etc/apt/sources.list

RUN ln -s /lib/x86_64-linux-gnu/libdl-2.24.so /lib/x86_64-linux-gnu/libdl.so
RUN apt-get update \
 && apt-get install -y --allow-unauthenticated fontconfig \
# libc6-dev \
#libgdiplus \
# libx11-dev \
 && rm -rf /var/lib/apt/lists/*
# RUN ln -s /usr/lib/libgdiplus.so /usr/lib/gdiplus.dll
RUN fc-cache -fv

ENV LANG zh_CN.utf8
ENV ASPNETCORE_URLS=http://+:80
ENV TZ Asia/shanghai


ENTRYPOINT ["dotnet", "Acme.IssueManagement.HttpApi.Host.dll"]