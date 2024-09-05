using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

public class IniFileReaderDemo
{
    private Dictionary<string, Dictionary<string, string>> sections = new Dictionary<string, Dictionary<string, string>>();

    public IniFileReaderDemo(string filePath)
    {
        var lines = File.ReadAllLines(filePath, Encoding.UTF8);
        Dictionary<string, string> currentSection = null;
        string currentSectionName = null;
      
        foreach (var line in lines)
        {
            var trimmedLine = line.Trim();
            if (string.IsNullOrEmpty(trimmedLine) || trimmedLine.StartsWith(";")) continue;

            if (trimmedLine.StartsWith("[") && trimmedLine.EndsWith("]"))
            {
                currentSectionName = trimmedLine.Trim('[', ']');
                currentSection = new Dictionary<string, string>();
                sections[currentSectionName] = currentSection;
            }
            else if (currentSection != null)
            {
                var parts = trimmedLine.Split(new[] { '=' }, 2);
                if (parts.Length == 2)
                {
                    currentSection[parts[0].Trim()] = parts[1].Trim();
                }
            }
        }
    }

    public string GetValue(string section, string key)
    {
        if (sections.TryGetValue(section, out var sectionDict))
        {
            sectionDict.TryGetValue(key, out var value);
            return value;
        }
        return null;
    }
}

// 使用示例
//class Program
//{
//    static void Main()
//    {
//        var iniReader = new IniFileReader("QualityAdjustControlType.ini");
//        var lisFileLis = iniReader.GetValue("Lis", "LisFileLis");
//        Console.WriteLine(lisFileLis);
//        // 其他配置项读取...
//    }
//}
