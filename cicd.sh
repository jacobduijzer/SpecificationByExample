#!/bin/bash

dotnet tool update --global SpecFlow.Plus.LivingDoc.CLI

dotnet build src/ProductCatalog.Specs/ProductCatalog.Specs.csproj
dotnet test src/ProductCatalog.Specs/ProductCatalog.Specs.csproj

~/.dotnet/tools/livingdoc \
  feature-folder src/ProductCatalog.Specs \
  -t src/ProductCatalog.Specs/bin/Debug/net7.0/TestExecution.json \
  --binding-assemblies src/ProductCatalog.Specs/bin/Debug/net7.0/ProductCatalog.Specs.Runner.dll \
  --output livingdoc.html
