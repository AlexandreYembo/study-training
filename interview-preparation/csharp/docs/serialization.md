# Serialization
Is a process to convert an object into a stream of bytes to storage the object or transmit it to a memory, a database or a file.

#### Uses
- Sending the object to a remote application.

- Passing an object from one domain to another.

- Passing an object through a firewal as Json or XML string.

- Maintaning security or user-specific information across application.

#### Types of serialization
- ```JSON``` (Javascript Object Notation).

- ```Binary``` -> uses binary encoding to produce compact serialization for uses: storage or socked-based network streams. All members, inclusing readonly are serializable. 
###### Binary deserialization is also when the input is untrusted due that attackers are able to run code within the context of the target process.

- ```XML``` (Extensible Markup Language). -> XML streams that conforms to a specific XML Schema definition language (XSD) document.


#### Making serializable.
Apply the attribute ```serializable``` to serialize the object.

Apply the attribute ```NonSerialized``` to prevent a field from being serialized.