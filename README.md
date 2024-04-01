# Desafio CB

Criar um docker-compose.yaml para SQL server :

version: "3.7"
services:
  sql-server-db:
    container_name: sql-server-db
    image: mcr.microsoft.com/mssql/server:2019-latest
    ports:
      - "1433:1433"
    environment:
      SA_PASSWORD: "SuperSenh@1234"
      ACCEPT_EULA: "Y"

Executar docker-compose up -d

Criar um docker-compose.yaml para Kafka :

version: '2'
services:
  zookeeper:
    image: wurstmeister/zookeeper
    ports:
      - "2181:2181"
  kafka:
    image: wurstmeister/kafka:0.10.2.0
    ports:
      - "9092:9092"
    environment:
      KAFKA_ADVERTISED_HOST_NAME: 127.0.0.1
      KAFKA_CREATE_TOPICS: "estoque:1:1"
      KAFKA_ZOOKEEPER_CONNECT: zookeeper:2181
    volumes:
      - /var/run/docker.sock:/var/run/docker.sock

Executar docker-compose up -d
