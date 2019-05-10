using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto___Club
{
    class Director
    {
        public void Construct(Builder builder, String comando, String tipo)
        {
            builder.BuildPartA(comando);
            builder.BuildPartB(tipo);
        }
    }
}
