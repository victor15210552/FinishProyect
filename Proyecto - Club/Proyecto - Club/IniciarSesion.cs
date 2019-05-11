using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Proyecto___Club
{
    public partial class IniciarSesion : MetroFramework.Forms.MetroForm
    {
        public IniciarSesion()
        {
            InitializeComponent();
        }


        private void btn_buscar_Click(object sender, EventArgs e)
        {
            cls_conexion miBD = new cls_conexion();

            MySqlCommand consulta = new MySqlCommand("select * from usuarios where nombre = '" + nombre.Text + "' AND password = '" + password.Text + "' ;", miBD.conexion);
            miBD.conexion.Open();

            MySqlDataReader lectura = consulta.ExecuteReader();

            if (lectura.Read())
            {

                this.Hide();
                Menu_Opciones fa = new Menu_Opciones(this);
                fa.ShowDialog();
                password.Text = "";
                nombre.Text = "";

            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrecta.");
            }
        }

        private void password_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btn_buscar_Click(sender, e);
            }
        }
    }
}
