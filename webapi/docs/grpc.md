#gRPC

### What is gRPC?
Popular open source RPC framework.
    
    - Largest RPC mindshare.
    
    - Cloud Native Computing Foundation Project.

gRPC -> stands for Remote Procedure Calls.

It is built with modern technologies:

    - HTTP/2.

    - Protocol Buffers.

Designed for moderns apps
    
    - High performance (uses binary protocol and also protocol buffers binary).

    - Plataform independent (its supported by .net core, node, java, ruby, c++, python, go, etc).

### Protobuf (aka Protocol Protocol Buffers)
Servers a number of purposes in GRPC:

##### IDL (interface definition language)
Describe once and generate interfaces for any language.
```go
    syntax = "proto3";

    message SubscribeRequest {
        string topic = 1;
    }

    message Event {
        int32 id = 1;
        string details = 2;
    }

```

##### Service model
Service method and structure of the request and the response.
```go
    syntax = "proto3";

    message SubscribeRequest {
        string topic = 1;
    }

    message Event {
        int32 id = 1;
        string details = 2;
    }

    service Topics {
        rpc Subscribe(SubscribeRequest)
            returns (stream Event);
    }

```


##### Wire format
Binary format for network transmission.

It is a the actual serialization and it will take the messages defined in c#, and we'll turn it into this binary format.

It is small and fast and then it will get sent across HTTP 2 to the client and because this is an open standard, you get the benefits of a binary format and that it's very fast, but also because it's standards-based as cross-platform like it's not only .net.

####### Importantto note that because it's binary is not human readable you need need to have both tools to understand the binary. You also need to have the contract because it's not a self descriptor.

##### gRPC vs HTTP APIs

###### gRPC
   - Contract first (proto file)
   
   - Contract is designed for humans
   
###### HTTP APIs
   - Content first (URLs, HTTP method, JSON)
   - Content is designed for humans

