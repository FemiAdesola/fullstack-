FROM node:19-alpine
WORKDIR /frontend
COPY package.json ./
RUN npm install --force
COPY ./ ./
EXPOSE 3000
CMD npm run start
