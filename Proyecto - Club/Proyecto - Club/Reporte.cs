using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto___Club
{
    class Reporte
    {
        private List<string> _parts = new List<string>();

        public void Add(string part)
        {
            _parts.Add(part);
        }

        public void crear(Niños_Reportes objReportes) {

            Niños_Reportes2 reporte = new Niños_Reportes2(objReportes,_parts[0],_parts[1]);
            reporte.ShowDialog();

        }

    }
}
