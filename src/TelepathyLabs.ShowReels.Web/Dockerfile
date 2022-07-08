FROM node:16-alpine3.15 As builder
WORKDIR /usr/src/app
COPY TelepathyLabs.ShowReels.Web/package.json TelepathyLabs.ShowReels.Web/package-lock.json ./
COPY . .
WORKDIR /usr/src/app/TelepathyLabs.ShowReels.Web
RUN rm ./src/assets/config.json
RUN cp ./src/assets/config-docker-compose.json ./src/assets/config.json
RUN npm install
RUN npm run build --prod
FROM nginx:1.15.8-alpine
COPY --from=builder /usr/src/app/TelepathyLabs.ShowReels.Web/dist/telepathy-labs.show-reels.web/ /usr/share/nginx/html