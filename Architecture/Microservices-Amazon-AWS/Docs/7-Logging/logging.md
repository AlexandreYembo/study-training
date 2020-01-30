# Loggin AWS

### Log
1- A log entry is the details of an event in the system.

2- A log entry can represent some information or show the details of an error or a change.


### Type of logs
1- Infrastructure Logs      --- >   (AWS Cloud Watch)

2- Change and Audit Logs    --- > (AWS Cloud Trail)

3- Security Logs            --- > (AWS Cloud Trail)

4- Application Logs         ---> (Logging via code)


#### Specs of logging systems for micro services
1- Centralized Loggin Repository.

2- Log entries should have a common format:
```json
    {
        "LogType": "Error",
        "Message": "Test!"
    }
    
    {
        "LogLevel": 1,
        "Message": "Test!"
    }
```

3- Must be scure.

4- Must provide good search and discovery interface.

5- Should provide insights and analytics.