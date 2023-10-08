FROM node:16.13-alpine3.15 as build

WORKDIR /app

COPY . .

RUN npm install
RUN npm run build --delete-output-path

FROM nginx:latest as publish

ARG TEST1=oioioioi

COPY --from=build /app/dist/web-ng-frontend/ /usr/share/nginx/html
COPY --from=build /app/nginx.conf /etc/nginx