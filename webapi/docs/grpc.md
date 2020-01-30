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