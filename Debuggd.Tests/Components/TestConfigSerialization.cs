using System;
using System.Collections.Generic;
using System.Text;

namespace Debuggd.Tests
{
    class TestConfigSerialization
    {
        public string RegularProperty { get; set; }
        public TestConfigSerialization RegularSimpleClass { get; set; }
        public int[] ArrayOfStructs { get; set; }
        public List<TestConfigSerialization> ArrayOfClasses { get; set; }
    }
}
