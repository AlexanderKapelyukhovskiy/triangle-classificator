FROM microsoft/dotnet:2.0-sdk AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.sln .
COPY Demo.Tradeshift.Math.Triangles.DemoApp/*.csproj ./Demo.Tradeshift.Math.Triangles.DemoApp/
COPY Demo.Tradeshift.Math.Triangles/*.csproj ./Demo.Tradeshift.Math.Triangles/
COPY Demo.Tradeshift.Math.Triangles.Tests/*.csproj ./Demo.Tradeshift.Math.Triangles.Tests/
RUN dotnet restore

# copy and build everything else
COPY Demo.Tradeshift.Math.Triangles.DemoApp/. ./Demo.Tradeshift.Math.Triangles.DemoApp/
COPY Demo.Tradeshift.Math.Triangles/. ./Demo.Tradeshift.Math.Triangles/
COPY Demo.Tradeshift.Math.Triangles.Tests/. ./Demo.Tradeshift.Math.Triangles.Tests/

RUN dotnet build

FROM build AS testrunner
WORKDIR /app/Demo.Tradeshift.Math.Triangles.Tests
ENTRYPOINT ["dotnet", "test","--logger:trx"]

FROM build AS test
WORKDIR /app/Demo.Tradeshift.Math.Triangles.Tests
RUN dotnet test

FROM test AS publish
WORKDIR /app/Demo.Tradeshift.Math.Triangles.DemoApp
RUN dotnet publish -o out

FROM microsoft/dotnet:2.0-runtime AS runtime
WORKDIR /app
COPY --from=publish /app/Demo.Tradeshift.Math.Triangles.DemoApp/out ./
ENTRYPOINT ["dotnet", "Demo.Tradeshift.Math.Triangles.DemoApp.dll"]