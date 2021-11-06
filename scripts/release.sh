#!/bin/bash
mkdir release
dotnet publish -r linux-x64 -p:PublishSingleFile=true --self-contained false --output "release"