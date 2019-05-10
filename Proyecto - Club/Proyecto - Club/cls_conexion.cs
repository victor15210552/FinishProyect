using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Proyecto___Club
{
    class cls_conexion
    {
        public MySqlConnection conexion = new MySqlConnection(@"server=localhost;userid=root;password=;database=club_ninos_ninas");
        //public MySqlConnection conexion = new MySqlConnection(@"server=localhost;userid=root;password=1234;database=club_ninos_ninas");
    }
}
