FROM node:20-alpine as build

WORKDIR /app

COPY . /app

RUN npm install -g @angular/cli

RUN npm install

EXPOSE 4200

ENTRYPOINT [ "npm" "start" ]