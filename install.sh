#!/usr/bin/env bash

set -e

# Grab base download URL for latest release
BASE_DOWNLOAD_URL=$(curl -Ls https://api.github.com/repos/chunfeilung/slt/releases/latest \
  | grep browser_download_url \
  | grep linux-x64 \
  | sed -re 's/(.+)"(http.+)-linux-x64"/\2/')

# Determine the right postfix for this runtime platform
if [[ "$OSTYPE" == "darwin"* ]]; then
  BINARY_DOWNLOAD_URL="${BASE_DOWNLOAD_URL}-osx-x64"

else
  if [[ $(uname -m) == *"x86_64"* ]]; then
    libc=$(ldd /bin/ls | grep 'musl' | head -1 | cut -d ' ' -f1)
    if [ -z $libc ]; then
      BINARY_DOWNLOAD_URL="${BASE_DOWNLOAD_URL}-linux-x64"
    else
      BINARY_DOWNLOAD_URL="${BASE_DOWNLOAD_URL}-linux-musl-x64"
    fi

  elif [[ $(uname -m) == *"arm64"* ]] || [[ $(uname -m) == *"aarch64"* ]]; then
    BINARY_DOWNLOAD_URL="${BASE_DOWNLOAD_URL}-linux-arm64"

  else
    echo "This runtime platform is currently not supported. :("
    exit 1
  fi
fi

# Download and install the program
curl -sL $BINARY_DOWNLOAD_URL > /tmp/slt
chmod +x /tmp/slt
mv /tmp/slt /usr/local/bin/slt
/usr/local/bin/slt --speed 10
echo 'Installation is complete! :-)';
