using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto___Club
{
    public partial class Menu_Opciones : MetroFramework.Forms.MetroForm
    {
        Form form;

        public Menu_Opciones()
        {
            InitializeComponent();
        }

        public Menu_Opciones(Form form)
        {
            this.form = form;
            InitializeComponent();
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Niños_Menu nm = new Niños_Menu(this);
            nm.ShowDialog();
        }



        private void metroTile2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu_Staff ms = new Menu_Staff(this);
            ms.ShowDialog();
        }

        private void metroTile3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_Asistencias fa = new Form_Asistencias(this);
            fa.ShowDialog();
        }

        private void metroTile3_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form_Asistencias fa = new Form_Asistencias(this);
            fa.ShowDialog();
        }

        private void Menu_Opciones_Load(object sender, EventArgs e)
        {

        }

        private void Menu_Opciones_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                form.Show();
            }
            catch
            {

             //   MessageBox.Show("Error: Utilice el constructor sobrecargado de la clase.");
            }
        }
    }
}
