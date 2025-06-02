using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Tanosvenyek_GUI.Models
{
    public class Utvonal
    {
        [Key]
        public int azon { get; set; }
        public string nev { get; set; }
        public double hossz { get; set; }
        public int allomas { get; set; }
        public double ido { get; set; }
        public bool vezetes { get; set; }

        public string vezetes_szoveg { get { return vezetes ? "igen" : "nem" ; } }

        public int telepulesid { get; set; }

    }

}
