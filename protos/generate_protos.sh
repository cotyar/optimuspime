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
PLUGIN_CSHARP=$HOME/.nuget/packages/grpc.tools/2.28.1/tools/${PLATFORM}/grpc_csharp_plugin
WKT_INCLUDE=$HOME/.nuget/packages/google.protobuf.tools/3.11.4/tools
REPO_ROOT=../

PROTO_FILES=./*.proto

CSHARP_PATH=$REPO_ROOT/csharp/ProtosGenerated
mkdir -p $CSHARP_PATH
$PROTOC -I$WKT_INCLUDE -I. \
        --csharp_out $CSHARP_PATH \
        --grpc_out $CSHARP_PATH --plugin=protoc-gen-grpc=$PLUGIN_CSHARP \
        $PROTO_FILES
        #greet.proto moniker.proto cache.proto

#-java_out=src/main/java/