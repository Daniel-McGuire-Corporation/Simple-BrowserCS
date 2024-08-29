#!/bin/bash

# Check if any command was provided
if [ $# -eq 0 ]; then
    echo "Usage: $0 <command> [arguments...]"
    exit 1
fi

# Loop until the command exits with a success code (0)
while true; do
    "$@"
    if [ $? -eq 0 ]; then
        echo "Command succeeded."
        break
    else
        echo "Command failed. Retrying..."
        sleep 1 # Optional delay between retries
    fi
done
