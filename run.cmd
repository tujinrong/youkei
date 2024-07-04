@echo off

:: プロキシを取得する（もしあれば）
for /f "usebackq tokens=2 delims==" %%i in (`echo %http_proxy%`) do set HTTP_PROXY=%%i
for /f "usebackq tokens=2 delims==" %%i in (`echo %https_proxy%`) do set HTTPS_PROXY=%%i

:: docker-compose を実行する
docker-compose -p health up --build -d

:: 未使用のDockerでdanglingなイメージを削除する
docker image prune -f --filter "dangling=true"

pause
