using System.Collections.Generic;
using System.Data;
using System.IO;
using ExcelDataReader;

namespace FynxAutomationProject
{
    public static class ExcelHelper
    {
        public static IEnumerable<object[]> GetRegistrationData(string filePath)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    reader.Read(); 

                    while (reader.Read())
                    {
                        var user = reader.GetValue(0)?.ToString(); 
                        var email = reader.GetValue(1)?.ToString(); 
                        var pass = reader.GetValue(2)?.ToString();  

                        System.Console.WriteLine($"Excel Row: User={user}, Email={email}, Pass={pass}");

                        yield return new object[] { user, email, pass };
                    }
                }
            }
        }
    }
    
}