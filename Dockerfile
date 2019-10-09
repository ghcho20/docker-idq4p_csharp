ARG REPO=mcr.microsoft.com/dotnet/core/sdk
FROM $REPO:3.0-alpine3.9

ARG NUPKG=IDQ.CLAVIS3.IDQ4P.Template.1.0.0.nupkg
ARG TEMPLATE_DST=/usr/share/dotnet/templates/3.0.0
ADD $NUPKG $TEMPLATE_DST
