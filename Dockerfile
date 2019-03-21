FROM microsoft/dotnet:sdk as build_images
WORKDIR /app

COPY . .
RUN dotnet restore
WORKDIR ChessWebApp
RUN dotnet publish -o output

FROM microsoft/dotnet:aspnetcore-runtime
WORKDIR /app
COPY --from=build_images app/ChessWebApp/output .

ENTRYPOINT ["dotnet", "ChessWebApp.dll"]