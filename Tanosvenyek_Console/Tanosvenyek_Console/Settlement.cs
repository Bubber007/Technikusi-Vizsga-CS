using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Tanosvenyek_Console
{
    public class Settlement
    {
        public int id { get; set; }
        public string nev { get; set; }

        public static List<Settlement>? LoadFromJSON(string fileName)
        {
            StreamReader sr = new StreamReader(fileName);
            string jsonStr = sr.ReadToEnd();
            List<Settlement>? settlements = JsonSerializer.Deserialize<List<Settlement>>(jsonStr);
            sr.Close();
            return settlements;
        }

    }

}
