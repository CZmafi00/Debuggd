using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Debuggd
{
    public class TestConfigEnvironment
    {
        IConfiguration _configuration;
        IConfigurationBuilder _configurationBuilder;

        /// <summary>
        /// Initializes new instance of TestConfigEnvironment.
        /// </summary>
        /// <param name="configDirectoryPath">Directory with associated configuration files.</param>
        public TestConfigEnvironment(string configDirectoryPath)
        {
            SetConfigurationBuilder(configDirectoryPath);
        }
        /// <summary>
        /// Initializes new instance of TestConfigEnvironment with associated config files.
        /// </summary>
        /// <param name="configDirectoryPath">Directory with associated configuration files.</param>
        /// <param name="configFiles">Configuration files.</param>
        public TestConfigEnvironment(string configDirectoryPath, IEnumerable<string> configFiles) : this (configDirectoryPath)
        {
            foreach (var configFile in configFiles)
                _configurationBuilder.AddJsonFile(configFile, true, true);
        }
        protected void SetConfigurationBuilder(string path = null)
        {
            if (path == null || path == string.Empty)
                path = Directory.GetCurrentDirectory();

            _configurationBuilder = new ConfigurationBuilder()
                    .SetBasePath(path);
        }

        /// <summary>
        /// Adds configuration files.
        /// </summary>
        /// <param name="filePaths">Use file names e.g.: "testSettings.json".</param>
        public void AddConfiguration(IEnumerable<string> filePaths)
        {
            foreach (var path in filePaths)
                _configurationBuilder.AddJsonFile(path, true, true);

            _configuration = _configurationBuilder.Build();
        }
        /// <summary>
        /// Adds configuration file.
        /// </summary>
        /// <param name="filePath">Use file names e.g.: "testSettings.json".</param>
        public void AddConfiguration(string filePath)
        {
            _configurationBuilder.AddJsonFile(filePath);
            _configuration = _configurationBuilder.Build();
        }

        /// <summary>
        /// Creates instance of serialized configuration class. If class is not bindable, returns default(T)
        /// </summary>
        /// <typeparam name="T">Type of configuration class.</typeparam>
        /// <returns></returns>
        public T GetConfig<T>() where T : class
        {
            return _configuration.Get<T>();
        }
    }
}
