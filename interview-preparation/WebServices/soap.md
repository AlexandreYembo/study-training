# SOAP
```Sample Object Access Protocol```.

- XML-based messaging protocol for exchanging infomation among computers.

- Provides data transport for Web services.

- Can exchange completed documents or call a remove procedure.

- Can be used for broadcasting a message.

- Is the XML way to defining what information is sent and how.

- Enable client applications to easily connect to remote services and invoke remote methods.

- Developed using intermediate la guage so that applications built on various programming language could talk easily to each other.


#### Message Structure
- Envelope -> Start and end of the message. * Mandatory.

- Header -> Contains any optional attribute of the message. *Optional.

- Body -> Contains the XML data comprising. * Mandatory.

- Fault -> Provides information about errors. *Optional.

```xml
<?xml version = "1.0"?>
<SOAP-ENV:Envelope xmlns:SOAP-ENV = "http://www.w3.org/2001/12/soap-envelope" 
   SOAP-ENV:encodingStyle = "http://www.w3.org/2001/12/soap-encoding">

   <SOAP-ENV:Header>
      ...
      ...
   </SOAP-ENV:Header>
   <SOAP-ENV:Body>
      ...
      ...
      <SOAP-ENV:Fault>
         ...
         ...
      </SOAP-ENV:Fault>
      ...
   </SOAP-ENV:Body>
</SOAP_ENV:Envelope>
```