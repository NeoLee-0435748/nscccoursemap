#!/usr/bin/env bash
# exit on error
set -o errexit

# Download
wget https://download.visualstudio.microsoft.com/download/pr/64a6b4b9-a92e-4efc-a588-569d138919c6/a97f4be78d7cc237a4f5c306866f7a1c/dotnet-sdk-5.0.200-linux-x64.tar.gz

# Extract
mkdir -p $XDG_CACHE_HOME/dotnet && tar zxf dotnet-sdk-5.0.200-linux-x64.tar.gz -C $XDG_CACHE_HOME/dotnet;

# Set vars
export DOTNET_ROOT=$XDG_CACHE_HOME/dotnet;
export PATH=$PATH:$XDG_CACHE_HOME/dotnet; 

# verify installation
# dotnet --version 

# run commands to build static site
dotnet publish -c release -o app/ .

pwd

ASPNETCORE_URLS=http://*:$PORT
dotnet app/NsccCourseMap_Neo.dll