dotnet publish .\src\Producer -o dist/producer
dotnet publish .\src\Consumer -o dist/consumer
docker build -t kafka-producer -f ./package/Producer-Dockerfile .
docker build -t kafka-consumer -f ./package/Consumer-Dockerfile .