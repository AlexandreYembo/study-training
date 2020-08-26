# Web Services
Is software module designed to perform a certain set of tasks.

- The requests are make via procedure calls. (RPC - Remote procedure Calls).

- Uses SOAP for sending the XML data between applications.

-- Syncronous or Async functionalitty


### Type of Web Service
1- SOAP web services.

2- RESTFull web services.


### WSDL - Web Services Description Language
1- The client invoking the web service should know where the web service actually resides.

2- The client needs to know what the webservice actually does, it can invoke the rigth web service.

### Advantages
- Exposing business functionality on the network.

- Interoperability anongst application.

- Standardized Protocol for communication. All 4 layers (Service transport, XML Messaging, service desctiption and Service discovery layers).

### Architecture
1- Provider -> Creates and makes it avvailable to client to use it.

2- Requestor -> Client application that needs to contact a web service.

3- Broker -> Provides access to the UDDI (enables de client application to localte the web service).

4- Publish -> A Provider informs the broker (service registry) about the existence of the web service, using broker's publish.

5- Find -> Requestor consults the broker to localte a published web service.

6- Bind -> Invoke the web service.