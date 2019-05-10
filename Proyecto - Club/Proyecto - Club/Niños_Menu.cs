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
    public partial class Niños_Menu : MetroFramework.Forms.MetroForm
    {

        Menu_Opciones menuGeneral;


        public Niños_Menu(Menu_Opciones menuGeneral)
        {

            this.menuGeneral = menuGeneral;
            InitializeComponent();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Niños n = new Niños(this);
            n.ShowDialog();

        }

        private void Niños_Menu_Load(object sender, EventArgs e)
        {

        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Niños_Modificaciones n = new Niños_Modificaciones(this);
            n.ShowDialog();
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Niños_Reportes n = new Niños_Reportes(this);
            n.ShowDialog();
        }

        private void Niños_Menu_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                menuGeneral.Show();
            }
            catch {
                MessageBox.Show("Error: Utilice el constructor sobrecargado de la clase.");
            }
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Niños_Bajas n = new Niños_Bajas(this);
            n.ShowDialog();
        }
    }
}
