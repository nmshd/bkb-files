#!/bin/bash
set -e
set -u
set -x

docker build --file ./Files.API/Dockerfile --tag acrnmshdprivate.azurecr.io/bkb-files .

if [[ -v TAG ]]; then
    docker tag acrnmshdprivate.azurecr.io/bkb-files acrnmshdprivate.azurecr.io/bkb-files:${TAG}
fi
      