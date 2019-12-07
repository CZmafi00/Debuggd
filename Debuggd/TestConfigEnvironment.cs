using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Debuggd
{
    class TestConfigEnvironment
    {
        IConfiguration _configuration;
        IConfigurationBuilder _configurationBuilder;

        public TestConfigEnvironment(string configDirectoryPath)
        {
            SetConfigurationBuilder(configDirectoryPath);
        }
        public TestConfigEnvironment(string configDirectoryPath, IEnumerable<string> configFiles)
        {
            foreach (var configFile in configFiles)
                _configurationBuilder.AddJsonFile(configFile, true, true);
        }
        private void SetConfigurationBuilder(string path = null)
        {
            if (path == null)
                path = Directory.GetCurrentDirectory();

            _configurationBuilder = new ConfigurationBuilder()
                    .SetBasePath(path);
        }

        public void AddConfiguration(IEnumerable<string> filePaths)
        {
            foreach (var path in filePaths)
                _configurationBuilder.AddJsonFile(path, true, true);

            _configuration = _configurationBuilder.Build();
        }
        public void AddConfiguration(string filePath)
        {
            _configurationBuilder.AddJsonFile(filePath);
            _configuration = _configurationBuilder.Build();
        }
        public object GetConfig<T>()
        {
            return _configuration.Get<T>();
        }
    }
}
