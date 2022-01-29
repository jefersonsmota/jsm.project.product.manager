FROM node:16.13 as build

WORKDIR /app

COPY . .

RUN npm install -g npm@8.4.0
RUN npm i 
RUN ng build --configuration=production


FROM nginx:latest as publish

COPY --from=build /app/dist/WebNgFrontend/ /usr/share/nginx/html

EXPOSE 4200