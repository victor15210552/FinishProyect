using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto___Club
{
    abstract class Builder
    {
        public abstract void BuildPartA(String comando);
        public abstract void BuildPartB(String tipo);
        public abstract Reporte GetResult();

    }
}
