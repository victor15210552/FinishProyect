using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto___Club
{
    class ReporteBuilder : Builder
    {
        private Reporte _product = new Reporte();

        public override void BuildPartA(String nombre)
        {
            _product.Add(nombre);
        }

        public override void BuildPartB(String apellido)
        {
            _product.Add(apellido);
        }

        public override Reporte GetResult()
        {
            return _product;
        }
    }
}
