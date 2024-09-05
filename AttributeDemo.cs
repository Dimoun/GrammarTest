using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GrammarTest
{
    public class AttributeDemo
    {
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class MyCustomAttribute : Attribute
    {
        public string Description { get; }
        public int Version { get; }

        public MyCustomAttribute(string description, int version)
        {
            Description = description;
            Version = version;
        }
    }


    [MyCustomAttribute("This is a sample class", 1)]
    public class SampleClass
    {
        [MyCustomAttribute("This is a sample method", 2)]
        public void SampleMethod()
        {

        }
    }
}
