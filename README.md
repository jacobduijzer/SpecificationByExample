# Specification By Example Demo

## Introduction

I have a small API, running as a Docker container. It is a basic sample of a REST API which can be used in a web shop. 

## Build & Test in the IDE

1. Open the solution in your favorite API.
2. Build and run all tests.

## Test locally and generate the living documentation

1. Go to the folder `webshop`.
2. Run the API in Docker: `docker-compose up`.
3. Test if the API is working, go to the  [Swagger page](http://localhost:8000/swagger).
4. Run the `cicd.sh` script to test and generate the living documentation.

## Testing in Docker

1. Run the API in Docker: `docker-compose up`.
2. Check if the API is running, go to: `http://localhost:8000/swagger'.
3. Test against the API In Docker: `dotnet test -e ApplicationUrl=http://localhost:8000`
