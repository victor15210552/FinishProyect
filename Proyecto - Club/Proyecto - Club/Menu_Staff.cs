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
 
    public partial class Menu_Staff : MetroFramework.Forms.MetroForm
    {
        Menu_Opciones menuGeneral;
        public Menu_Staff(Menu_Opciones menuGeneral)
        {
            InitializeComponent();
            this.menuGeneral = menuGeneral;
        }

        private void Menu_Staff_Load(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Staff n = new Staff(this);
            n.ShowDialog();

        }
        private void Menu_Staff_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                menuGeneral.Show();
            }
            catch
            {

                MessageBox.Show("Error: Utilice el constructor sobrecargado de la clase.");
            }
        }

        private void bajas_staff_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Staff n = new Staff(this);
            n.ShowDialog();

        }

        private void Menu_Staff_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            try
            {
                menuGeneral.Show();
            }
            catch
            {
                MessageBox.Show("Error: Utilice el constructor sobrecargado de la clase.");
            }
        }
    }
}
