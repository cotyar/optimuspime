#!/bin/bash

OS=""
if [ "$(uname)" == "Darwin" ]; then
   OS="macosx"
elif [ "$(uname)" == "Linux" ]; then
   OS="linux"
else
   OS="windows"
fi

MACHINE=""
if [ "$(uname -m)" == "x86_64" ]; then
   MACHINE="x64"
else
   MACHINE="x86"
fi

PLATFORM=${OS}_${MACHINE}
PROTOC=$HOME/.nuget/packages/google.protobuf.tools/3.11.4/tools/${PLATFORM}/protoc
PLUGIN=$HOME/.nuget/packages/grpc.tools/2.28.1/tools/${PLATFORM}/grpc_csharp_plugin
WKT_INCLUDE=$HOME/.nuget/packages/google.protobuf.tools/3.11.4/tools

mkdir -p generated
mkdir -p generated/csharp
$PROTOC -I$WKT_INCLUDE -I. --csharp_out generated/csharp --grpc_out generated/csharp --plugin=protoc-gen-grpc=$PLUGIN \
        greet.proto moniker.proto cache.proto