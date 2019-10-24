#!/bin/bash

INAME=dnet:idq4p
INAME_CHECK=$(docker images -q $INAME)

if [ "$INAME_CHECK" == "" ]; then
    docker build --rm -t $INAME .
fi

CNAME=idq4p
if [ "$1" != "" ]; then
	CNAME=$1
fi

echo "> Launch a container($CNAME)"
WORKSPACE=${PWD}/ws
WORKSPACE_MNT=/root/workspace
DOCKER=$(which --skip-alias winpty 2> /dev/null)
DOCKER="$DOCKER docker"
$DOCKER run --rm --name $CNAME -v "$WORKSPACE:$WORKSPACE_MNT" -w "$WORKSPACE_MNT" -it $INAME

exit
