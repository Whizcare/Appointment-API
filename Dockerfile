#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Appointment_ServiceLayer/Appointment_Service.csproj", "Appointment_ServiceLayer/"]
COPY ["Appointment_BussinessLogic/Appointment_BussinessLogic.csproj", "Appointment_BussinessLogic/"]
COPY ["Appointment_DataEntities/Appointment_DataEntities.csproj", "Appointment_DataEntities/"]
COPY ["Appointment_Models/Appointment_Models.csproj", "Appointment_Models/"]
RUN dotnet restore "Appointment_ServiceLayer/Appointment_Service.csproj"
COPY . .
WORKDIR "/src/Appointment_ServiceLayer"
RUN dotnet build "Appointment_Service.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Appointment_Service.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Appointment_Service.dll"]