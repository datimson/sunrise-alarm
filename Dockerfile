FROM microsoft/dotnet:2.1-sdk as builder
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.config *.csproj ./
RUN dotnet restore --configfile nuget.config

# copy and build everything else
COPY . ./
RUN dotnet publish -c Release -o out -r linux-arm
ENTRYPOINT ["dotnet", "out/sunrise-alarm.dll"]

FROM microsoft/dotnet:2.1-runtime-stretch-slim-arm32v7 as runtime

WORKDIR /app
COPY --from=builder /app/out .

CMD ["dotnet", "./sunrise-alarm.dll"]