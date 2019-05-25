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
            nomiembro_staff_tbox.Text = " ";
            nombre_staff_tbox.Text = " ";
            appaterno_staff_tbox.Text = " ";
            apmaterno_staff_tbox.Text = " ";
            carrera_staff_tbox.Text = " ";
            puesto_staff_tbox.Text = " ";
            edocivil_staff_cbox.Text = " ";
            tel1_staff_tbox.Text = " ";
            tel2_staff_tbox.Text = " ";
            fnacimiento_staff_dtime.Text = " ";
            nacionalidad_staff_cbox.Text = " ";
            edo_staff_chbox.Checked = false;
            vol_staff_chbox.Checked = false;
            bus_staff_tbox.Text = " ";
            foto_staff_picbox.Image = null;
            fingreso_staff_dtime.Text = " ";
            dir_staff_tbox.Text = " ";
            entrada_staff_chbox.Checked = false;
            rentr_staff_tbox.Text = " ";
            sexo_staff_cbox.Text = " ";
        }

        public void datos_staff_guardar()
        {
            try
            {
                miBD.conexion.Close();

                string campos = "@no_miembro, @nombre, @ap_paterno, @ap_materno, @carrera, @puesto, @edocivil,"+
                                "@tel1, @tel2, @fecha_naci, @nacionalidad, @estado, @voluntario, @fecha_ingreso,"+ 
                                "@direccion, @entradares, @razon_entrada, @sexo";

                MySqlCommand alta = new MySqlCommand("insert into staff values(" + campos + ");", miBD.conexion);
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

                //Almacena si hubo filas guardadas
                int guardado = alta.ExecuteNonQuery();

                miBD.conexion.Close();

                if (guardado > 0)
                {
                    MessageBox.Show("Se ha guardado");
                    limpiar_datos_staff();
                }
                else
                {
                    MessageBox.Show("No se guardo el usuario");
                }
            }
            catch (MySqlException sqle)
            {
                MessageBox.Show("Error: " + sqle.Message);
            }
            finally
            {
                miBD.conexion.Close();
            }
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

            try
            {
                miBD.conexion.Close();
                miBD.conexion.Open();

                MySqlCommand command = new MySqlCommand("select * from staff where no_miembro = " + nomiembro_staff_tbox.Text + ";", miBD.conexion);
                MySqlDataReader lectura;

                //Se ejecuta la lectura
                lectura = command.ExecuteReader();

                //Si existen registros que cumplen las condiciones
                if (lectura.Read())
                {

                    foto_staff_picbox.ImageLocation = "Fotos\\" + nomiembro_staff_tbox.Text + ".jpg";
                    nombre_staff_tbox.Text = lectura.GetString(1);
                    appaterno_staff_tbox.Text = lectura.GetString(2);
                    apmaterno_staff_tbox.Text = lectura.GetString(3);
                    carrera_staff_tbox.Text = lectura.GetString(4);
                    puesto_staff_tbox.Text = lectura.GetString(5);
                    edocivil_staff_cbox.Text = lectura.GetString(6);
                    tel1_staff_tbox.Text = lectura.GetString(7);
                    tel2_staff_tbox.Text = lectura.GetString(8);
                    fnacimiento_staff_dtime.Text = lectura.GetString(9);
                    nacionalidad_staff_cbox.Text = lectura.GetString(10);
                    if (lectura.GetString(11).Equals("1"))
                        edo_staff_chbox.Checked = true;
                    if (lectura.GetString(12).Equals("1"))
                        vol_staff_chbox.Checked = true;

                    fingreso_staff_dtime.Text = lectura.GetString(13);
                    dir_staff_tbox.Text = lectura.GetString(14);
                    if (lectura.GetString(15).Equals("1"))
                        entrada_staff_chbox.Checked = true;
                    rentr_staff_tbox.Text = lectura.GetString(16);
                    sexo_staff_cbox.Text = lectura.GetString(17);                   
                }
                else
                {
                    MessageBox.Show("No se encontrarón resultados");
                }

                lectura.Close();
                miBD.conexion.Close();
            }
            catch (MySqlException) { }
            catch (SqlNullValueException) { }
            catch (FormatException) { }
            finally { miBD.conexion.Close(); }
        }

        private void foto_staff_btn_Click(object sender, EventArgs e)
        {
         /*   Camara camara = new Camara(nomiembro_staff_tbox.Text, this);
            this.Hide();
            camara.ShowDialog();

            foto_staff_picbox.ImageLocation = "Fotos\\" + nomiembro_staff_tbox.Text + ".jpg";
            */
        }

        private void rg_staff_btn_Click(object sender, EventArgs e)
        {

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
    }
}
