# Topics needs to know, to run this project
### <ins>Node Names (Identifiers)</ins>
RabbitMQ nodes are identified by node names. A node name consists of two parts, a prefix (usually rabbit) and hostname. For example, **rabbit@node1.messaging.svc.local** is a node name with the prefix of rabbit and hostname of **node1.messaging.svc.local**

### <ins>Resolving hostnames</ins>
Resolving hostnames refers to the process of converting human-readable domain names (like www.example.com) into IP addresses that computers can understand and use to communicate over a network. In a cluster environment, where multiple computers or nodes are interconnected, it means that each member of the cluster should be capable of translating the hostnames of other cluster members into their respective IP addresses.

### <ins>Hostname Resolution</ins>
every cluster member must be able to resolve hostnames of every other cluster member, its own hostname, as well as machines on which command line tools such as **rabbitmqctl** might be used.Nodes will perform hostname resolution early on node boot. In container-based environments it is important that hostname resolution is ready before the container is started.

### <ins>Port Access</ins>
RabbitMQ nodes [bind to ports](https://www.rabbitmq.com/docs/networking#ports) (open server TCP sockets) in order to accept client and CLI tool connections.

### <ins>Erlang Cookie</ins>
RabbitMQ nodes and CLI tools (e.g. **rabbitmqctl**) use a cookie to determine whether they are allowed to communicate with each other. For two nodes to be able to communicate they must have the same shared secret called the Erlang cookie. The cookie is just a string of alphanumeric characters up to 255 characters in size

### <ins></ins>
