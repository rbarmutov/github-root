FROM node:20.12.0

WORKDIR /app

COPY package*.json ./

COPY . ./

RUN npm install

EXPOSE 3000

CMD ["node", "app.js"]