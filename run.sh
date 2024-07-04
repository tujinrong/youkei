#!/bin/bash

# コンソールメッセージの色
BLUE='\033[0;34m'
GREEN='\033[0;32m'
RED='\033[0;31m'
NC='\033[0m'

# リモートブランチ名
BRANCH="main"

# プロジェクト名
PROJECT_NAME='health'

if [ -z "$1" ]; then
    # 環境選択
    echo -e "${GREEN}環境を選択してください:${NC}"
    echo -e "  ${GREEN}1.${NC} ${BLUE}開発環境 (Development)${NC}"
    echo -e "  ${GREEN}2.${NC} ${BLUE}テスト環境 (Test)${NC}"
    echo -e "  ${GREEN}3.${NC} ${BLUE}生産環境 (Production)${NC}"
    read -r -p "$(tput setaf 2)環境オプション番号を入力してください [1-3]:$(tput sgr0) " env_choice
    
    # ユーザー入力の処理
    case $env_choice in
        1)
            env="Development"
            env_name="開発環境"
            ;;
        2)
            env="Test"
            env_name="テスト環境"
            ;;
        3)
            env="Production"
            env_name="生産環境"
            ;;
        *)
            echo -e "${RED}環境オプション[$env_choice]は無効なオプションである！${NC}"
            exit 1
            ;;
    esac
else 
    param=$(echo "$1" | tr '[:upper:]' '[:lower:]')
    case $param in
        dev)
            env="Development"
            env_name="開発環境"
            ;;
        test)
            env="Test"
            env_name="テスト環境"
            ;;
        prod)
            env="Production"
            env_name="生産環境"
            ;;
        *)
            echo -e "${RED}環境[$1]は無効です！${NC}"
            exit 1
            ;;
    esac
fi

# 開始時間の記録
start_time=$(date +%s)

echo -e "${BLUE}$(date +"%Y-%m-%d %H:%M:%S"):${NC} ${GREEN}$env_name ($env)${NC}${BLUE} 環境の構築とリリースを開始......${NC}"

# プロキシー
HTTP_PROXY=$(env | grep -i '^http_proxy' | awk -F '=' '{print $2}')
HTTPS_PROXY=$(env | grep -i '^https_proxy' | awk -F '=' '{print $2}')

if [ -n "$HTTP_PROXY" ]; then
    # HTTPプロキシの設定
    export http_proxy="$HTTP_PROXY"
    echo -e "${GREEN}HTTP_PROXY: $HTTP_PROXY${NC}"
fi
if [ -n "$HTTPS_PROXY" ]; then
    # HTTPSプロキシの設定
    export https_proxy="$HTTPS_PROXY"
    echo -e "${GREEN}HTTPS_PROXY: $HTTPS_PROXY${NC}"
fi

echo -e "${BLUE}最新バージョンのコードの取得を開始します......${NC}"

# ローカルリポジトリ情報を更新しようとしています
fetch_output=$(sudo git fetch origin 2>&1)

update_needed=true

# git fetchの結果をチェックする
if [[ $fetch_output =~ "command not found" ]]; then
  echo -e "${RED}警告: git がインストールされていません！${NC}\n${BLUE}現在のコードを使用して実行します......${NC}"
  update_needed=false
elif [[ $fetch_output =~ "fatal:" ]]; then
  echo -e "${RED}警告: git リポジトリの更新に失敗しました！理由: $fetch_output${NC}\n${BLUE}現在のコードを使用して実行します......${NC}"
  update_needed=false
elif [[ $fetch_output =~ "Could not resolve host" ]]; then
  echo -e "${RED}警告: ネットワーク接続に問題があります！${NC}\n${BLUE}現在のコードを使用して実行します......${NC}"
  update_needed=false
fi

# アップデートが必要な場合は、リモートブランチと現在のブランチの差分をチェックします
if [[ $update_needed == "true" ]]; then
  # リモートブランチとカレントブランチの違いや、コンテナの状態をチェックする
  if sudo git diff --quiet origin/$BRANCH &&
     docker ps --filter "ancestor=${PROJECT_NAME}_frontend" --format "{{.Names}}" | grep -q "${PROJECT_NAME}_frontend" &&
     docker ps --filter "ancestor=${PROJECT_NAME}_backend" --format "{{.Names}}" | grep -q "${PROJECT_NAME}_backend"; then
      echo -e "${GREEN}$(date +"%Y-%m-%d %H:%M:%S"): 現在のバージョン コードは最新であるため、再実行する必要はありません！${NC}"
      echo -e "${GREEN}スクリプトの実行時間: $(( $(date +%s) - start_time )) 秒。${NC}"
      exit 0
  fi
  echo -e "${BLUE}最新バージョンのコードを取得します......${NC}"
  sudo git reset --hard origin/$BRANCH
  echo -e "${GREEN}最新バージョンのコードを正常に取得しました！${NC}"
fi

echo -e "${GREEN}実行コマンド:${NC} ${BLUE}sudo env COMPOSE_DOCKER_CLI_BUILD=1 HTTP_PROXY=\"$HTTP_PROXY\" HTTPS_PROXY=\"$HTTPS_PROXY\" docker-compose -p ${PROJECT_NAME} build --parallel && sudo env ASPNETCORE_ENVIRONMENT=\"$env\" docker-compose -p ${PROJECT_NAME} up -d${NC}"

# docker-compose を実行する
if sudo env COMPOSE_DOCKER_CLI_BUILD=1 HTTP_PROXY="$HTTP_PROXY" HTTPS_PROXY="$HTTPS_PROXY" docker-compose -p ${PROJECT_NAME} build --parallel && sudo env ASPNETCORE_ENVIRONMENT="$env" docker-compose -p ${PROJECT_NAME} up -d; then
  # 未使用のDockerでdanglingなイメージを削除する
  sudo docker image prune -f --filter "dangling=true"
  echo -e "${GREEN}$(date +"%Y-%m-%d %H:%M:%S"): Docker コンテナ（${PROJECT_NAME}）は正常に起動しました！${NC}"
else
  echo -e "${RED}$(date +"%Y-%m-%d %H:%M:%S"): Docker コンテナ（${PROJECT_NAME}）の起動に失敗しました！${NC}"
fi

echo -e "${GREEN}スクリプトの実行時間: $(( $(date +%s) - start_time )) 秒。${NC}"
