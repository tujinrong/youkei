# nginxのバージョン（ビルドパラメータで変更可能：docker build --build-arg nginx_version=1.25.4 ...）
ARG nginx_version=1.25.4
# 公式ノード画像をベース画像として使用する
FROM node:18.18.2-slim AS node_builder
# 作業ディレクトリの設定
WORKDIR /app
# package.jsonを作業ディレクトリにコピーする
COPY package.json ./
# プロジェクトの依存関係をインストールする
RUN yarn install
# プロジェクトのソースコードを作業ディレクトリにコピーする
COPY . .
# プロジェクトの構築
RUN yarn build

# brotli圧縮モジュールのコンパイル
FROM nginx:${nginx_version} AS nginx_builder
ARG nginx_version
# 作業ディレクトリの指定
WORKDIR /root/
# 依存関係をダウンロードし、brotliをコンパイルする
RUN apt-get update && apt-get install -y \
    wget \
    build-essential \
    git \
    libpcre3-dev \
    libssl-dev \
    zlib1g-dev \
    libbrotli-dev \
    && wget https://nginx.org/download/nginx-${nginx_version}.tar.gz \
    && tar zxf nginx-${nginx_version}.tar.gz \
    && git clone https://github.com/google/ngx_brotli.git \
    && cd ngx_brotli \
    && git submodule update --init --recursive \
    && cd ../nginx-${nginx_version} \
    && ./configure \
    --add-dynamic-module=../ngx_brotli \
    --prefix=/etc/nginx \
    --sbin-path=/usr/sbin/nginx \
    --modules-path=/usr/lib/nginx/modules \
    --conf-path=/etc/nginx/nginx.conf \
    --error-log-path=/var/log/nginx/error.log \
    --http-log-path=/var/log/nginx/access.log \
    --pid-path=/var/run/nginx.pid \
    --lock-path=/var/run/nginx.lock \
    --http-client-body-temp-path=/var/cache/nginx/client_temp \
    --http-proxy-temp-path=/var/cache/nginx/proxy_temp \
    --http-fastcgi-temp-path=/var/cache/nginx/fastcgi_temp \
    --http-uwsgi-temp-path=/var/cache/nginx/uwsgi_temp \
    --http-scgi-temp-path=/var/cache/nginx/scgi_temp \
    --with-perl_modules_path=/usr/lib/perl5/vendor_perl \
    --user=nginx \
    --group=nginx \
    --with-compat \
    --with-file-aio \
    --with-threads \
    --with-http_addition_module \
    --with-http_auth_request_module \
    --with-http_dav_module \
    --with-http_flv_module \
    --with-http_gunzip_module \
    --with-http_gzip_static_module \
    --with-http_mp4_module \
    --with-http_random_index_module \
    --with-http_realip_module \
    --with-http_secure_link_module \
    --with-http_slice_module \
    --with-http_ssl_module \
    --with-http_stub_status_module \
    --with-http_sub_module \
    --with-http_v2_module \
    --with-mail \
    --with-mail_ssl_module \
    --with-stream \
    --with-stream_realip_module \
    --with-stream_ssl_module \
    --with-stream_ssl_preread_module \
    --with-cc-opt='-Os -fomit-frame-pointer -g' \
    --with-ld-opt=-Wl,--as-needed,-O1,--sort-common \
    && make modules

# 公式nginxイメージをベースイメージとして使用する
FROM nginx:${nginx_version}-alpine
# 著者
LABEL maintainer="AIplus"
ARG nginx_version
#タイムゾーン環境変数を "Asia/Tokyo" に設定します
ENV TZ Asia/Tokyo
RUN ln -snf /usr/share/zoneinfo/$TZ /etc/localtime && echo $TZ > /etc/timezone
# コンパイルしたbrotliモジュールファイルをnginxイメージのmoduleディレクトリにコピーします
COPY --from=nginx_builder /root/nginx-${nginx_version}/objs/ngx_http_brotli_filter_module.so /usr/lib/nginx/modules/
COPY --from=nginx_builder /root/nginx-${nginx_version}/objs/ngx_http_brotli_static_module.so /usr/lib/nginx/modules/
# Nginx設定テンプレートのコピー
COPY nginx.template.conf /etc/nginx/nginx.conf
# リソースファイルのコピー
COPY --from=node_builder /app/dist /usr/share/nginx/html
# APIホスト
ENV API_HOST=http://backend:8000
# CORS
ENV CORS=*
# ポート80を公開
EXPOSE 80
# envsubstを使って実際のnginx confファイルを生成し、Nginxを起動する
CMD ["/bin/sh", "-c", "envsubst '${API_HOST} ${CORS}' < /etc/nginx/nginx.conf > /etc/nginx/nginx.conf.tmp && mv /etc/nginx/nginx.conf.tmp /etc/nginx/nginx.conf && rm -rf /etc/nginx/conf.d/ && nginx -g 'daemon off;'"]
