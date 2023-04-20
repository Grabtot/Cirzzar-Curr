# ��������� Node.js
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
RUN curl -sL https://deb.nodesource.com/setup_18.x | bash -
RUN apt-get install -y nodejs

# �������� ���� �� ������������ ����� npm � ���������� ����� PATH
ENV PATH="/usr/local/bin:${PATH}"

EXPOSE 80

# ����� ����������� � ��������� ������ ������ Dockerfile
WORKDIR /src
COPY . .
RUN dotnet restore
RUN dotnet publish -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "CizzarCurr.dll"]
