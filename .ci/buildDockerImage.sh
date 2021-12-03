#!/bin/bash
set -e
set -u
set -x

docker build --file ./Files.API/Dockerfile --tag ghcr.io/nmshd/bkb-files:${TAG-temp} .
