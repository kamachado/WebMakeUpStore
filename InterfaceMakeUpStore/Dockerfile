### STAGE 1: Build ###
FROM node:16-alpine AS build
WORKDIR /usr/src/app
COPY package.json package-lock.json ./
RUN npm install
COPY . .
RUN npm run build
### STAGE 2: Run ###
FROM nginx:1.17.1-alpine
COPY nginx.conf /etc/nginx/nginx.conf
EXPOSE 80
COPY --from=build /usr/src/app/dist/interface-make-up-store /usr/share/nginx/html
