#!/bin/bash

# コンソールメッセージの色
BLUE='\033[0;34m'
GREEN='\033[0;32m'
RED='\033[0;31m'
NC='\033[0m'

echo -e "${BLUE}最新バージョンのコードの取得を開始します......${NC}"

sudo chmod -x run.sh
pull_output=$(sudo git pull)
sudo chmod +x run.sh

if [[ $pull_output =~ "Already up to date" ]]; then
  echo -e "${BLUE}現在のバージョン コードは最新であるため、再実行する必要はありません！${NC}"
else
  if [[ $pull_output =~ "git: command not found" ]]; then
    echo -e "${RED}git がインストールされていないため、${BLUE}現在のコードを使用して実行します！${NC}"
  elif [[ $pull_output =~ "fatal:" ]]; then
    echo -e "${RED}最新バージョンのコードを取得できませんでした、${BLUE}現在のコードを使用して実行します！${NC}"
  else
    echo -e "${GREEN}最新バージョンのコードを正常に取得しました！${NC}"
  fi
  echo -e "${BLUE}依存関係のインストールを開始します......${NC}"

  # 依存関係のインストール
  if sudo yarn; then
    echo -e "${GREEN}依存関係が正常にインストールされました！${NC}"
    echo -e "${BLUE}フロントエンド ページの構築を開始します......${NC}"
    # フロントエンド ページのビルド
    if sudo NODE_OPTIONS="--max-old-space-size=4096" yarn build; then
      echo -e "${GREEN}フロントエンド ページが正常にビルドされました！${NC}"
      if sudo sudo systemctl restart nginx || sudo docker restart nginx; then
        echo -e "${GREEN}Nginxが正常に再起動されました！${NC}"
      fi
    else
      echo -e "${RED}フロントエンド ページのビルドに失敗しました！${NC}"
    fi
  else
    echo -e "${RED}依存関係のインストールに失敗しました！${NC}"
  fi
fi