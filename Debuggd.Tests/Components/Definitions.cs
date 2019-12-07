using System;
using System.Collections.Generic;
using System.Text;

namespace Debuggd.Tests
{
    class Definitions
    {
        #region Test config files
        public const string EMPTY_CONFIG_JSON = "config files/emptyConfig.json";
        public const string TEST_CLASS_CONFIG_JSON = "config files/testClassConfig.json";
        public const string TEST_CLASS_CONFIG_JSON_INCORRECT_NAME = "testConfigdsa.json"; 
        #endregion

        #region Assertion messages
        public const string PROPERTY_NOT_CORRECTLY_SERIALIZED = "{0} property is not correctly serialized";
        public const string THROWS_EXCEPTION = "Method throws exception";
        public const string THROWS_NOT_EXCEPTION = "Method does not throw {0}"; 
        #endregion
    }
}
