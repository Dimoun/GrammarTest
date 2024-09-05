
using GrammarTest;
using System;
using System.Reflection;

class Program
{
    static void Main()
    {
        //IniFileReaderTest();
        //TupleTest();
        //BitTest();
        //SetLedCtrl(true, true);
        //new InterlockedDemo().InterlockedTest();
        IteratorTest();
    }
    public void AttributeTest()
    {
        // 获取类上的Attribute
        Type type = typeof(SampleClass);
        var classAttribute = (MyCustomAttribute)Attribute.GetCustomAttribute(type, typeof(MyCustomAttribute));
        if (classAttribute != null)
        {
            Console.WriteLine($"Class Attribute: Description={classAttribute.Description}, Version={classAttribute.Version}");
        }

        // 获取方法上的Attribute
        MethodInfo method = type.GetMethod("SampleMethod");
        var methodAttribute = (MyCustomAttribute)Attribute.GetCustomAttribute(method, typeof(MyCustomAttribute));
        if (methodAttribute != null)
        {
            Console.WriteLine($"Method Attribute: Description={methodAttribute.Description}, Version={methodAttribute.Version}");
        }
    }
    public static void IniFileReaderTest()
    {   
        var iniReader = new IniFileReaderDemo("D:\\Project\\DocumentControl\\01_Pylon2\\Software Design\\Software Code\\Pylon3\\WPFInterface\\bin\\x64\\Debug\\QualityAdjustControlType.ini");
        var lisFileLis = iniReader.GetValue("Lis", "LisFileLis");
        Console.WriteLine(lisFileLis);
    }

    public static void TupleTest()
    {
        var primes = Tuple.Create(2, 3, 5, 7, 11, 13, 17, 19);
        Console.WriteLine("Prime numbers less than 20: " +
                          "{0}, {1}, {2}, {3}, {4}, {5}, {6}, and {7}",
                          primes.Item1, primes.Item2, primes.Item3,
                          primes.Item4, primes.Item5, primes.Item6,
                          primes.Item7, primes.Rest.Item1);

       var test = Tuple.Create(2, 3, 5, 7, 11, 13, 17, Tuple.Create(19, 21, 22));
        Console.WriteLine("test numbers: " + "{0},{1},{2}", test.Rest.Item1.Item1,
            test.Rest.Item1.Item2, test.Rest.Item1.Item3);
        
    }

    public static void BitTest()
    {
        Byte[] bytes = new byte[] { 0x01 };
        Console.WriteLine(bytes[0]);
        Console.WriteLine(bytes[0] << 7);
    }
    public static void SetLedCtrl(bool whEnable, bool irEnable)
    {
        byte[] messageBody = new byte[2];


        if (whEnable)
        {
            messageBody[0] |= 0x01;
        }

        if (irEnable)
        {
            messageBody[1] |= 0x01;
        }
    

        Console.WriteLine(messageBody);
    }

    public static void IteratorTest()
    {
        var numbers = new NumberEnumerable(5);

        foreach (var number in numbers)
        {
            Console.WriteLine(number);
        }

        var yieldNumber = new IteratorDemo().GetNumbers(5);

        foreach (var number in yieldNumber)
        {
            Console.WriteLine("yield: "+ number);
        }
    }
}



