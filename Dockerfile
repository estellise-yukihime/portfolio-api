
ARG VERSION

FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:10.0-alpine AS build
COPY . /src
WORKDIR /src
RUN --mount=type=cache,id=nuget,target=/root/.nuget/packages dotnet publish PortfolioApi/PortfolioApi.csproj --os linux --arch x64 --output /app -p:Version=$VERSION

FROM mcr.microsoft.com/dotnet/aspnet:10.0-alpine AS runner
WORKDIR /app
COPY --from=build /app .
RUN adduser \
    --disabled-password \
    --gecos "" \
    --home "/nonexistent" \
    --shell "/sbin/nologin" \
    --no-create-home \
    --uid "10001" \
USER appuser
EXPOSE 8080
ENTRYPOINT ["dotnet", "PortfolioApi.dll"]