using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data.SqlTypes;

namespace Proyecto___Club
{
    public partial class Staff : MetroFramework.Forms.MetroForm
    {
        cls_conexion miBD;
        Menu_Staff menu_Staff;

        public Staff(Menu_Staff menu_Staff)
        {
            miBD = new cls_conexion();
            
            this.menu_Staff = menu_Staff;
            InitializeComponent();

        }

        private void Staff_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                menu_Staff.Show();
            }
            catch
            {

                MessageBox.Show("Error: Utilice el constructor sobrecargado de la clase.");
            }
        }

        public void limpiar_datos_staff()
        {
                        
        }

        public void datos_staff_guardar()
        {
            
        }

        public void actualizar_datos_staff()
        {
            try
            {
                miBD.conexion.Close();

                string campos = "nombre = @nombre, ap_paterno = @ap_paterno, ap_materno=@ap_materno, carrera=@carrera, pueto=@puesto, edocivil = @edocivil," +
                   "tel1=@tel1, tel2=@tel2, fecha_naci=@fecha_naci, nacionalidad=@nacionalidad, estado=@estado, voluntario=@voluntario, fecha_ingreso=@fecha_ingreso," +
                   "direccion=@direccion, entradares=@entradares, razon_entrada=@razon_entrada, sexo=@sexo";

                MySqlCommand alta = new MySqlCommand("update staff set " + campos + " where no_miembro = @no_miembro;", miBD.conexion);

                alta.Parameters.AddWithValue("no_miembro", nomiembro_staff_tbox.Text);
                alta.Parameters.AddWithValue("nombre", nombre_staff_tbox.Text);
                alta.Parameters.AddWithValue("ap_paterno", appaterno_staff_tbox.Text);
                alta.Parameters.AddWithValue("ap_materno", apmaterno_staff_tbox.Text);
                alta.Parameters.AddWithValue("carrera", carrera_staff_tbox.Text);
                alta.Parameters.AddWithValue("puesto", puesto_staff_tbox.Text);
                alta.Parameters.AddWithValue("edocivil", edocivil_staff_cbox.Text); 
                alta.Parameters.AddWithValue("tel1", tel1_staff_tbox.Text);
                alta.Parameters.AddWithValue("tel2", tel2_staff_tbox.Text);

                alta.Parameters.AddWithValue("fecha_naci", fnacimiento_staff_dtime.Text);
                alta.Parameters.AddWithValue("nacionalidad", nacionalidad_staff_cbox.Text);
                alta.Parameters.AddWithValue("estado", bool.Parse(edo_staff_chbox.Checked.ToString()));
                alta.Parameters.AddWithValue("voluntario", bool.Parse(vol_staff_chbox.Checked.ToString()));
                alta.Parameters.AddWithValue("fecha_ingreso", fingreso_staff_dtime.Text);

                alta.Parameters.AddWithValue("direccion", dir_staff_tbox.Text);
                alta.Parameters.AddWithValue("entradares", bool.Parse(entrada_staff_chbox.Checked.ToString()));
                alta.Parameters.AddWithValue("razon_entrada", rentr_staff_tbox.Text);
                alta.Parameters.AddWithValue("sexo", sexo_staff_cbox.Text);
                miBD.conexion.Open();

                int datos_actualizados = alta.ExecuteNonQuery();

                if (datos_actualizados > 0)
                {
                    MessageBox.Show("Se han modificado los datos");
                    limpiar_datos_staff();
                }
                else
                {
                    MessageBox.Show("No se modificó los datos");
                }
                miBD.conexion.Close();
            }
            catch (MySqlException mysqlex)
            {
                MessageBox.Show("Error: " + mysqlex.Message);
            }
            finally
            {
                miBD.conexion.Close();
            }
        }

        private void busq_staff_btn_Click(object sender, EventArgs e)
        {

           g
        }

        private void foto_staff_btn_Click(object sender, EventArgs e)
        {
         
        }

        private void rg_staff_btn_Click(object sender, EventArgs e)
        {
            if (mod_staff_rbtn.Checked)
            {
                actualizar_datos_staff();
            }
        }

        private void Staff_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            try
            {
                menu_Staff.Show();
            }
            catch
            {
                MessageBox.Show("Error: Utilice el constructor sobrecargado de la clase.");
            }
        }

        private void agreg_staff_rbtn_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void mod_staff_rbtn_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rentr_staff_label_Click(object sender, EventArgs e)
        {

        }

        private void entrada_staff_label_Click(object sender, EventArgs e)
        {

        }

        private void dir_staff_tbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void rentr_staff_tbox_Click(object sender, EventArgs e)
        {

        }
    }
}
