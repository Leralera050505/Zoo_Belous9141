using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoo_Belous914.DB;

namespace Zoo_Belous914.HelpClass
{
    public class EFClass
    {
        public static Entities MyContext { get; } = new Entities();
    }
}
