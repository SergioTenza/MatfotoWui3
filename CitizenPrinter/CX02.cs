using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitizenPrinter
{
    public static class CX02
    {
        public static string GetName(string name)
        {
            return $"Has llamado a la impresora {name} hoy es {DateTime.Now}";
        }

    }
}
