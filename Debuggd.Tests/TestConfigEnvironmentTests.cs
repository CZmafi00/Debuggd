using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Debuggd.Tests
{
    public class TestConfigEnvironmentTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestConfigEnvironment_Serialize_Valid_Config_Json()
        {
            TestConfigEnvironment test = new TestConfigEnvironment(null);
            test.AddConfiguration(Definitions.TEST_CLASS_CONFIG_JSON);

            var serialized = test.GetConfig<TestConfigSerialization>();

            Assert.IsTrue(IsRegularPropertyCorrect(serialized), Definitions.PROPERTY_NOT_CORRECTLY_SERIALIZED, "RegularProperty");
            Assert.IsTrue(IsRegularSimpleClassCorrect(serialized), Definitions.PROPERTY_NOT_CORRECTLY_SERIALIZED, "RegularSimpleClass");
            Assert.IsTrue(IsArrayOfStructsCorrect(serialized), Definitions.PROPERTY_NOT_CORRECTLY_SERIALIZED, "ArrayOfStructs");
            Assert.IsTrue(IsArrayOfClassesCorrect(serialized), Definitions.PROPERTY_NOT_CORRECTLY_SERIALIZED, "ArrayOfClasses");
        }
        private bool IsRegularPropertyCorrect(TestConfigSerialization serialized)
        {
            return serialized.RegularProperty != null && serialized.RegularProperty != string.Empty;
        }
        private bool IsRegularSimpleClassCorrect(TestConfigSerialization serialized)
        {
            return serialized != null && !string.IsNullOrEmpty(serialized.RegularProperty);
        }
        private bool IsArrayOfStructsCorrect(TestConfigSerialization serialized)
        {
            return serialized.ArrayOfStructs != null && serialized.ArrayOfStructs.Length == 5;
        }
        private bool IsArrayOfClassesCorrect(TestConfigSerialization serialized)
        {
            return serialized.ArrayOfClasses.All(x => x != null) &&
                serialized.ArrayOfClasses.All(x => IsRegularPropertyCorrect(x));
        }

        [Test]
        public void AddConfiguration_Throws_FileNotFoundException_For_Invalid_File_Path()
        {
            Assert.Throws(typeof(System.IO.FileNotFoundException), () =>
            {
                TestConfigEnvironment test = new TestConfigEnvironment(null);
                test.AddConfiguration(Definitions.TEST_CLASS_CONFIG_JSON_INCORRECT_NAME);
            }, Definitions.THROWS_NOT_EXCEPTION, typeof(System.IO.FileNotFoundException));
        }

        [Test]
        public void AddConfiguration_With_Valid_Config_Json_List()
        {
            Assert.DoesNotThrow(() =>
            {
                TestConfigEnvironment test = new TestConfigEnvironment(null);
                test.AddConfiguration(new List<string> { Definitions.TEST_CLASS_CONFIG_JSON, Definitions.EMPTY_CONFIG_JSON });
            }, Definitions.THROWS_EXCEPTION);
        }
    }
}