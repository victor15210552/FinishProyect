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
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void metroTile2_Click(object sender, EventArgs e)
        {
            
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            /*this.Hide();
            Menu_Opciones fa = new Menu_Opciones(this);
            fa.ShowDialog();*/

            this.Hide();

            SingletonMenu singleton = SingletonMenu.getInstance();
            singleton.abrirMenuOpciones();

            this.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
