#!/bin/bash
mkdir release
dotnet publish -r osx-x64 -p:PublishSingleFile=true --self-contained false --output "release"