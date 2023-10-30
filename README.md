# TECH CHALLENGE - FASE 01
For more details, Event Storming: https://miro.com/app/board/uXjVNchi2II=/?share_link_id=831097624598 <br />
<br />
<br />
<br />


## How to
Open the prompt, navigate to solution folder and execute the commands below:

##### Build Docker-Compose

```
 docker-compose up -d  
```
##### Check the page
Swagger: http://localhost/swagger/index.html .<br />
ReDoc: http://localhost/docs

## Test - Postman Collection 
Postman:https://api.postman.com/collections/7616720-4ad36016-4b1a-467d-92a2-9accc798f4df?access_key=PMAT-01HE0RNSXEV7NA0T4697Z17AR0 .<br />

<br />
<br />
<br />
<br />

###  (OR) execute it manually:

##### Publish the project

```
dotnet publish -c Release -o ./app
```

##### Create a Docker image based on Dockerfile
```
docker build -t techchallenge01 .
```

##### Create Docker Network - techbankNet 
```
docker network create --attachable -d bridge mydockernetwork
```
##### Create database container MongoDB
```
Run in Docker:
docker run -it -d --name mongo-container \
-p 27017:27017 --network mydockernetwork \
--restart always \
-v mongodb_data_container:/data/db \
mongo:latest
```


##### Create and start a Docker container in the specified port 8080
```
 docker run -it -d --name api-tech-02 -p 80:80 --network mydockernetwork techchallenge01
```

##### Check the page
Swagger: http://localhost/swagger/index.html .<br />
ReDoc: http://localhost/docs
