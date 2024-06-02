# Topic you needs to know, to run this project

### <ins>Node Names (Identifiers)</ins>
RabbitMQ nodes are identified by node names. A node name consists of two parts, a prefix (usually rabbit) and hostname. For example, **rabbit@node1.messaging.svc.local** is a node name with the prefix of rabbit and hostname of **node1.messaging.svc.local**

### <ins>Resolving hostnames</ins>
Resolving hostnames refers to the process of converting human-readable domain names (like www.example.com) into IP addresses that computers can understand and use to communicate over a network. In a cluster environment, where multiple computers or nodes are interconnected, it means that each member of the cluster should be capable of translating the hostnames of other cluster members into their respective IP addresses.

### <ins>Hostname Resolution</ins>
Every cluster member must be able to resolve hostnames of every other cluster member, its own hostname, as well as machines on which command line tools such as **rabbitmqctl** might be used.Nodes will perform hostname resolution early on node boot. In container-based environments it is important that hostname resolution is ready before the container is started.

### <ins> Why need a network in docker? </ins>
This is very important for **rabbitmq** instances to communicate with one another and they must be able to resolve DNS. So if you're running inside docker you use the container names to create a docker network make sure they can resolve each other's host names to connect and form a cluster.

### <ins>Port Access</ins>
RabbitMQ nodes [bind to ports](https://www.rabbitmq.com/docs/networking#ports) (open server TCP sockets) in order to accept client and CLI tool connections.

### <ins>Erlang Cookie</ins>
RabbitMQ nodes and CLI tools (e.g. **rabbitmqctl**) use a cookie to determine whether they are allowed to communicate with each other. For two nodes to be able to communicate they must have the same shared secret called the Erlang cookie. The cookie is just a string of alphanumeric characters up to 255 characters in size

### <ins>volumes</ins>
This section specifies the volumes to mount into the container. Volumes are used for persisting data or configuration outside of the container<br>
- **`./rabbitmq.config`** into **`/etc/rabbitmq/rabbitmq.config`**: This is likely a custom RabbitMQ configuration file that overrides default settings.
- **`./definitions.json`** into **`/etc/rabbitmq/definitions.json`** : This is likely a JSON file containing RabbitMQ definitions, such as queues, exchanges, and bindings.

### <ins>Queue Leader Replica Placement</ins>
Queue leaders can be distributed between nodes using several strategies. Which strategy is used is controlled in three ways, namely, using the `x-queue-master-locator`. You can read this from [here](https://www.rabbitmq.com/docs/clustering#replica-placement)

### <ins>Publisher Confirms</ins>
To sent acknowledgment after sync in mirrored queues `ha-sync-mode: manual`

### <ins>Restart Node</ins>
`restart: unless-stopped`: Restart the container unless it is explicitly stopped by the user (e.g., using `docker stop`). The container will be restarted on Docker daemon restarts, system reboots, or if the container exits unexpectedly, but not if the user stopped it.

# Setup Highly Available Cluster
Go to the Folder **RabbitMq**, open command Shell and run the commands
```bash
docker network create rabbitmq-HAC
```
```bash
docker-compose up -d
```

# Run Producer & Consumer
From **Consumer** folder open cmd and run the command
```bash
dotnet run
```
same for the **Producer**
```bash
dotnet run
```
