using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanosvenyek_Console
{
    public static class Solution
    {
        public static List<Route>? Routes { get; set; } = Route.LoadFromJSON("utak.json");
        public static List<Settlement>? Settlements { get; set; } = Settlement.LoadFromJSON("telepulesek.json");
        public static List<Route>? GetRoutes => Routes?.Where(x => x.nev.Contains("hegy") || x.nev.Contains("völgy")).ToList();
        
        public static Dictionary<Settlement, double[]>? GetDictionary()
        {
            Dictionary<Settlement, double[]> stat = new Dictionary<Settlement, double[]>();
            foreach (var settlement in Settlements)
            {
                if (!stat.Keys.Contains(settlement))
                {
                    stat.Add(settlement, new double[2]);
                }
            }
            foreach (var route in Routes)
            {
                foreach (var item in stat)
                {
                    if(item.Key.id == route.telepulesid)
                    {
                        item.Value[0] += 1;
                        if (item.Value[1] < route.hossz)
                            item.Value[1] = route.hossz;
                    }
                }
            }
            return stat;
        }

    }
}
