#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["AssecorAssessmentTest.csproj", "./"]
RUN dotnet restore "./AssecorAssessmentTest.csproj"
COPY . .
RUN dotnet build "AssecorAssessmentTest.csproj" -c Release -o /app/

FROM build AS publish
RUN dotnet publish "AssecorAssessmentTest.csproj" -c Release -o /app/

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "AssecorAssessmentTest.dll"]