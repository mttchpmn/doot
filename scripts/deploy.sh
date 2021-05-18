#!/usr/bin/env bash

echo "Stashing changes..."

git stash --force

echo "Deploying in PRODUCTION mode..."

docker-compose up --build

echo "Migrating DB..."

docker-compose -f ./docker-compose.migrate.yml build migrate
docker-compose -f ./docker-compose.migrate.yml run migrate

echo "Done."