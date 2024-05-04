#!/bin/bash

# Start Cloud SQL Proxy
./cloud-sql-proxy --address 0.0.0.0 --port 5432 red-charger-414817:us-central1:crdb&

# Wait for the proxy to spin up
sleep 10

# Start the application
dotnet HelpDesk.dll