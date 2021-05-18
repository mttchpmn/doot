#!/usr/bin/bash

echo "Launching Database service..."

docker-compose up db --build

echo "Done."