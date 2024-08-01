#!/bin/bash

# Docker イメージ名（変更可能ですが、英語は小文字にする必要がある）
IMAGE_NAME='aiplus/webservice'

# Docker コンテナ名（自由に変更できる）
CONTAINER_NAME='webservice'

# プロキシー
HTTP_PROXY=$(env | grep -i '^http_proxy' | awk -F '=' '{print $2}')
HTTPS_PROXY=$(env | grep -i '^https_proxy' | awk -F '=' '{print $2}')

# プロキシーパラメータ
DOCKER_PROXY_ARGS=""
if [ -n "$HTTP_PROXY" ]; then
  DOCKER_PROXY_ARGS+="--build-arg http_proxy=$HTTP_PROXY "
fi
if [ -n "$HTTPS_PROXY" ]; then
  DOCKER_PROXY_ARGS+="--build-arg https_proxy=$HTTPS_PROXY "
fi

# コンソールメッセージの色
BLUE='\033[0;34m'
GREEN='\033[0;32m'
RED='\033[0;31m'
NC='\033[0m'

echo -e "${BLUE}最新バージョンのコードの取得を開始します......${NC}"

sudo chmod -x run.sh

pull_output=$(sudo git pull)

sudo chmod +x run.sh

if [[ $pull_output =~ "Already up to date" ]] && docker ps --filter "name=${CONTAINER_NAME}" --format "{{.Names}}" | grep -q "${CONTAINER_NAME}"; then
  echo -e "${BLUE}現在のバージョン コードは最新であるため、再実行する必要はありません！${NC}"
else
  if [[ $pull_output =~ "git: command not found" ]]; then
    echo -e "${RED}git がインストールされていないため、${BLUE}現在のコードを使用して実行します！${NC}"
  elif [[ $pull_output =~ "fatal:" ]]; then
    echo -e "${RED}最新バージョンのコードを取得できませんでした、${BLUE}現在のコードを使用して実行します！${NC}"
  else
    echo -e "${GREEN}最新バージョンのコードを正常に取得しました！${NC}"
  fi
  # Docker ビルド キャッシュをクリーンアップする
  sudo docker builder prune -f
  echo -e "${BLUE}Docker イメージの構築を開始します......${NC}"
  cd ..
  echo -e "${GREEN}sudo docker build ${DOCKER_PROXY_ARGS} -f ./WebService/Dockerfile -t ${IMAGE_NAME}:latest .${NC}"
  # Docker イメージのビルド
  if sudo docker build ${DOCKER_PROXY_ARGS} -f ./WebService/Dockerfile -t ${IMAGE_NAME}:latest .; then
    echo -e "${GREEN}Docker イメージ（${IMAGE_NAME}:latest）が正常にビルドされました！${NC}"

    # 実行中の最新バージョンではないプログラムを停止する
    sudo docker stop ${CONTAINER_NAME}

    # 実行中の最新バージョンではないプログラムを削除する
    sudo docker rm ${CONTAINER_NAME}

    # 最新バージョンのプログラムを実行する
    if sudo docker run --name ${CONTAINER_NAME} -d -p 7168:80 --restart always ${IMAGE_NAME}:latest; then

      # 未使用のDockerでdanglingなイメージを削除する
      sudo docker image prune -f --filter "dangling=true"

      echo -e "${GREEN}Docker コンテナ（${CONTAINER_NAME}）は正常に起動しました！${NC}"
    else
      echo -e "${RED}Docker コンテナ（${CONTAINER_NAME}）の起動に失敗しました！${NC}"
    fi
  else
    echo -e "${RED}Docker イメージ（${IMAGE_NAME}:latest）のビルドに失敗しました！${NC}"
  fi
fi