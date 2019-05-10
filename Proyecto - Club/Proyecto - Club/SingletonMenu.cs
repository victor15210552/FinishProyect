using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto___Club
{
    class SingletonMenu
    {
        private static SingletonMenu uniqueInstance;


        private SingletonMenu() {

        }

        public static SingletonMenu getInstance()
        {
            if (uniqueInstance == null)
            {
                uniqueInstance = new SingletonMenu();
            }
            return uniqueInstance;
        }

        public void  abrirMenuOpciones()
        {
            IniciarSesion obj = new IniciarSesion();
            obj.ShowDialog();

        }

    }
}
