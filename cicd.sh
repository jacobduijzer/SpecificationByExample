#!/bin/bash

dotnet tool update --global SpecFlow.Plus.LivingDoc.CLI

dotnet build specifications/src/WebShop.Specifications.Specs/WebShop.Specifications.Specs.csproj
dotnet test specifications/src/WebShop.Specifications.Specs/WebShop.Specifications.Specs.csproj

~/.dotnet/tools/livingdoc \
  feature-folder specifications/src/WebShop.Specifications.Specs \
  -t specifications/src/WebShop.Specifications.Specs/bin/Debug/net6.0/TestExecution.json \
  --binding-assemblies specifications/src/WebShop.Specifications.Specs/bin/Debug/net6.0/WebShop.Specifications.Specs.dll \
  --output livingdoc.html
