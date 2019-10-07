ARG REPO=mcr.microsoft.com/dotnet/core/sdk
FROM $REPO:3.0-nanoserver-1903

ARG NUPKG=IDQ.CLAVIS3.IDQ4P.Template.1.0.0.nupkg
ARG TEMPLATE_DST=C:/Program\ Files/dotnet/templates/3.0.0
ADD $NUPKG $TEMPLATE_DST

WORKDIR C:/Users/ContainerUser