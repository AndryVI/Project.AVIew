#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Project.AVIew/Project.AVIew.csproj", "Project.AVIew/"]
COPY ["Project.AVIew.EF/Project.AVIew.EF.csproj", "Project.AVIew.EF/"]
COPY ["Project.AVIew.OtherAPI/Project.AVIew.OtherAPI.csproj", "Project.AVIew.OtherAPI/"]
RUN dotnet restore "Project.AVIew/Project.AVIew.csproj"
COPY . .
WORKDIR "/src/Project.AVIew"
RUN dotnet build "Project.AVIew.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Project.AVIew.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Project.AVIew.dll"]