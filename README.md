# Debuggd
**Debuggd** is set of utilities for unit testing. Idea is to avoid hardcoded values in Test clases, create in-memory databases, provide basic interfaces for testing databases and many more good practices.

## Release 1.00
Provides **TestConfigEnvironment** class for reading configuration data and test data from .json files. You can use class as singleton if you want to initialize all config files for the first time, or initialize instance for each Test class with associated config files.

### How to use
```csharp
// Initialize TestConfigEnvironment class
// If you pass null or empty string, the config directory is current output directory
TestConfigEnvironment testConfigEnvironment = new TestConfigEnvironment(configsDirectory); 

// TestConfigEnvironment.AddConfiguration adds config file to test environment
testConfigEnvironment.Add("mockData.json");
testConfigEnvironment.Add("smtpSettings.json");
testConfigEnvironment.Add("testDbSettings.json");

// Get instance of serialized configuration class 
var mocData = testConfigEnvironment.Get<MockData>();
var smtpSettings = testConfigEnvironment.Get<SmtpSettings>();
var testDbSettings = testConfigEnvironment.Get<DbSettings>();
```

### Release notes
Property names in configuration classes:

Property names in .json configuration files should be named exactly as Property values of Configuration classes. 
Decorating properties with attributes [DataMember] and [JsonProperty] are not valid. (see answer from 'poke')
There is possible workaround, but it is not recommended to use because of good coding practices and code maintenance. (answer from 'Veikedo')
https://stackoverflow.com/questions/45856136/customize-json-property-name-for-options-in-asp-net-core