#!/bin/bash

dotnet tool update --global SpecFlow.Plus.LivingDoc.CLI

~/.dotnet/tools/livingdoc \
  feature-folder src/WebShop.Specifications.Specs \
  -t src/WebShop.Specifications.Specs/bin/Debug/net6.0/TestExecution.json \
  --binding-assemblies src/WebShop.Specifications.Specs/bin/Debug/net6.0/WebShop.Specifications.Specs.dll \
  --output livingdoc.html
