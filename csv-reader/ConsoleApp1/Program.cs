using System.Reflection;
using Testing;

namespace Converter;
public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Testing.Debug.Log("Test");
        //get current directory
        string? strExeFilePath = Assembly.GetExecutingAssembly().Location;
        string? strWorkPath = System.IO.Path.GetDirectoryName(strExeFilePath);
        if (strWorkPath != null)//if file path exist
        {
            string?[] files = Directory.GetFiles(strWorkPath, "*.csv");
            files.ToList().ForEach(f => Read.File(f));
        }
        //Console.WriteLine(strWorkPath);
        Console.Read();
    }
}