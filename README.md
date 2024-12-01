# Aspire custom YARP Gateway

Next example shows how to use your custom YARP Gateway project in Aspire. Since service discovery does not see `appsettings.json` destinations, there is an option load configuration using `.LoadFromMemory`, where we can get connection strings directly from environment variables.

### Quick sample test

1. Run Aspire.
2. Send requests using `Test.http` in AppHost project.
