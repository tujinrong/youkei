#ASP.NET 6.0のベースイメージを使用する
#https://hub.docker.com/r/bitnami/aspnet-core/tags
FROM bitnami/aspnet-core:6 AS base
#著者
LABEL maintainer="AIplus"

#コンテナ内の作業ディレクトリを/appに設定します。
WORKDIR /app

#Dockerコンテナの内部で8000ポートを公開する。
EXPOSE 8000

#アプリケーションはポート8000をリッスンする。
ENV ASPNETCORE_URLS=http://+:8000

#.NET Core SDK 6.0イメージを使用して、ビルドステージのイメージを設定します。
#https://hub.docker.com/r/bitnami/dotnet-sdk/tags
FROM bitnami/dotnet-sdk:6 AS build
#コンテナ内の作業ディレクトリを/srcに設定します。
WORKDIR /src

#プロジェクトファイルをコンテナ内の対応するディレクトリにコピーします。
#これにより、後続のビルド手順でプロジェクトファイルがコンテナ内で利用可能になります。
COPY ["WebService/WebService.csproj", "WebService/"] 
COPY ["BusinessService/BusinessService.csproj", "BusinessService/"] 
COPY ["BatchService/BatchService.csproj", "BatchService/"] 
COPY ["GaibuApiService/GaibuApiService.csproj", "GaibuApiService/"] 
COPY ["DataAccess/DataAccess.csproj", "DataAccess/"] 

#dotnet restoreコマンドを実行して、プロジェクトのNuGet依存関係を復元します。
RUN dotnet restore "WebService/WebService.csproj"

#現在のディレクトリのすべてのファイルをコンテナ内の現在の作業ディレクトリにコピーします。
COPY . .

#コンテナ内の作業ディレクトリを"/src/WebService"に変更します。
WORKDIR "/src/WebService"

#dotnet buildコマンドを実行して、プロジェクトをビルドし、出力ファイルを/app/buildディレクトリに配置します。
RUN dotnet build "WebService.csproj" -c Release -o /app/build

#ビルドステージをベースとしてパブリッシュステージのイメージを設定します。
FROM build AS publish

#dotnet publishコマンドを実行して、プロジェクトを実行可能なファイルとして公開し、
#出力ファイルを/app/publishディレクトリに配置します。UseAppHost=falseパラメータは指定しません。
RUN dotnet publish "WebService.csproj" -c Release -o /app/publish /p:UseAppHost=false

#ベースステージを最終ステージとして設定します。
FROM base AS final

#コンテナ内の作業ディレクトリを/appに変更します。
WORKDIR /app

#前のパブリッシュステージからパブリッシュされたファイルを現在の作業ディレクトリにコピーします。
COPY --from=publish /app/publish .

#タイムゾーン環境変数を "Asia/Tokyo" に設定します。
ENV TZ Asia/Tokyo
RUN ln -snf /usr/share/zoneinfo/$TZ /etc/localtime && echo $TZ > /etc/timezone

#パッケージマネージャを更新し、グラフィックス処理機能をサポートするためにlibgdiplusパッケージをインストールします。
RUN apt-get update && apt-get install -y libgdiplus

#共有ライブラリの検索パスを指定するためにLD\_LIBRARY\_PATH環境変数を設定します。
ENV LD_LIBRARY_PATH=/usr/lib/:$LD_LIBRARY_PATH

#ASP.NET Coreの実行環境を "Production" に設定します。
ENV ASPNETCORE_ENVIRONMENT=Production

#コンテナの起動時に実行されるコマンドを設定します。
ENTRYPOINT ["dotnet", "Jbd.Gjs.WebService.dll"]