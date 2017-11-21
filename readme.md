# Web API Client Manager

## Generate Client Ids and Client Secrets for your Web APIs.
1. Only Client Secret:

````C#
using WebAPIClientManager;
...
//64 is length of random input.
string clientSecret = Generator.GetNewClientSecret(64);
...
````


2. Both Client Id and Client Secret:

````C#
using WebAPIClientManager;
...
//64 is length of random input.
var idSecretPair = Generator.GetNewClientIdAndClientSecret(64);       
Guid clientId = idSecretPair.ClientId;
string clientSecret = idSecretPair.ClientSecret;
...
````
