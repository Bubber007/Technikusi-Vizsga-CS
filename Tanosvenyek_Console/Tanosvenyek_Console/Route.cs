using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Tanosvenyek_Console
{
    public class Route
    {
        public int azon { get; set; }
        public string nev { get; set; }
        public double hossz { get; set; }
        public int allomas { get; set; }
        public double ido { get; set; }
        public bool vezetes { get; set; }
        public int telepulesid { get; set; }

        public static List<Route>? LoadFromJSON(string fileName)
        {
            StreamReader sr = new StreamReader(fileName);
            string jsonStr = sr.ReadToEnd();
            List<Route>? routes = JsonSerializer.Deserialize<List<Route>>(jsonStr);
            sr.Close();
            return routes;
        }

    }

}
