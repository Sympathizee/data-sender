using CsvHelper;
using System.IO;
using System;
using System.Globalization;
using System.ComponentModel;

namespace Testing;

public class Debug
{
    public static void Log(string content)
    {
        Console.WriteLine(content);
    }
}

public class Read
{
    public static void File(string file_path)
    {
        using (var reader = new StreamReader(file_path))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            csv.Read();
            csv.ReadHeader();
            while (csv.Read())
            {
                var record = csv.GetRecord<dynamic>();
                // Do something with the record.
                var recordArr = new string[] { record.id, record.name, record.age };

                //Console.WriteLine(recordArr[0] + ", " + recordArr[1] + ", " + recordArr[2]);
            }
        }
    }
}

public class Write
{
    public static void File(string file_path)
    {

    }
}