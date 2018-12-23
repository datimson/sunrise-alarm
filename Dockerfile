FROM microsoft/dotnet:2.2-sdk as builder
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# copy and build everything else
COPY . ./
RUN dotnet publish -c Release -o out -r linux-arm
ENTRYPOINT ["dotnet", "out/sunrise-alarm.dll"]

FROM microsoft/dotnet:2.2-runtime-stretch-slim-arm32v7

WORKDIR /app
COPY --from=builder /app/out .

CMD ["dotnet", "./sunrise-alarm.dll"]

##################################################
# FROM microsoft/dotnet:2.0-sdk as builder  
# ENV DOTNET_CLI_TELEMETRY_OPTOUT 1

# RUN mkdir -p /root/src/app
# WORKDIR /root/src/
# COPY sunrise-alarm    sunrise-alarm
# WORKDIR /root/src/app/sunrise-alarm

# RUN dotnet restore ./sunrise-alarm.csproj  
# RUN dotnet publish -c release -o published -r linux-arm

# FROM microsoft/dotnet:2.1-runtime-stretch-arm32v7

# WORKDIR /root/  
# COPY --from=builder /root/src/app/sunrise-alarm/published .

# CMD ["dotnet", "./sunrise-alarm.dll"]