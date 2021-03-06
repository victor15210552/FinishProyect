﻿using System;
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
    public partial class Niños_Bajas : MetroFramework.Forms.MetroForm
    {
        Niños_Menu menuNiños;
        cls_conexion miBD;
        //Hora
        DateTime fecha = DateTime.Now;

        public Niños_Bajas(Niños_Menu menuNiños)
        {
            this.menuNiños = menuNiños;
            miBD = new cls_conexion();
            InitializeComponent();
        }

        private void Niños_Bajas_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                menuNiños.Show();
            }
            catch
            {
                MessageBox.Show("Error: Utilice el constructor sobrecargado de la clase.");
            }
        }

        private void baja_buscar_Click(object sender, EventArgs e)
        {
            try
            {
                miBD.conexion.Close();
                miBD.conexion.Open();

                MySqlCommand command = new MySqlCommand("select nombres, ap_paterno, ap_materno, fecha_nac, fecha_inscripcion, lugar_nac, nacionalidad, estado from ninos_datos where no_miembro = " + baja_noMiembro.Text + ";", miBD.conexion);
                MySqlDataReader lectura;

                //Se ejecuta la lectura
                lectura = command.ExecuteReader();

                //Si existen registros que cumplen las condiciones
                if (lectura.Read())
                {
                    try
                    {
                        limpiar_campo_baja();

                        baja_nombres.Text = lectura.GetString(0);
                        baja_ap_pat.Text = lectura.GetString(1);
                        baja_ap_mat.Text = lectura.GetString(2);
                        baja_fecha_nac.Text = lectura.GetString(3);
                        baja_fecha_inscripcion.Text = lectura.GetString(4);
                        baja_lugar_nac.Text = lectura.GetString(5);
                        baja_nacionalidad.Text = lectura.GetString(6);
                        baja_foto.Image = Image.FromFile("../fotos_ninos/" + baja_noMiembro.Text + ".jpg");
                        btn_dar_baja.Enabled = true;
                    }
                    catch {

                    }
                    if (lectura.GetString(7).Equals("0") || lectura.GetString(7).Equals("NULL"))
                    {
                        MessageBox.Show("El miembro ya se encuentrá inactivo");
                        btn_dar_baja.Enabled = false;
                    }
                }
                else
                {
                    btn_dar_baja.Enabled = false;
                    MessageBox.Show("No se encontrarón resultados");
                }

                lectura.Close();
                miBD.conexion.Close();
            }

            catch (MySqlException) { }
            catch (SqlNullValueException) { }
            finally { miBD.conexion.Close(); }
        }

        private void fecha_ingresaa(object sender, EventArgs e)
        {
            try
            {
                DateTime fecha_ingresada = DateTime.Parse(baja_fecha_nac.Text);

                DateTime zeroTime = new DateTime(1, 1, 1);

                DateTime fecha_actual = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                DateTime fecha_nac = new DateTime(int.Parse(fecha_ingresada.ToString("yyyy")), int.Parse(fecha_ingresada.ToString("MM")), int.Parse(fecha_ingresada.ToString("dd")));

                TimeSpan span = fecha_actual - fecha_nac;
                int edad = (zeroTime + span).Year - 1;
                baja_edad.Text = edad.ToString();
            }
            catch (ArgumentOutOfRangeException) { }
            catch (FormatException) { }
        }

        private void btn_dar_baja_Click(object sender, EventArgs e)
        {
            try
            {
                miBD.conexion.Close();

                string campos = "@no_miembro, @motivo, @fecha_baja";

                MySqlCommand alta = new MySqlCommand("insert into ninos_baja values(" + campos + ");", miBD.conexion);
                alta.Parameters.AddWithValue("no_miembro", baja_noMiembro.Text);
                alta.Parameters.AddWithValue("motivo", baja_motivo.Text);
                alta.Parameters.AddWithValue("fecha_baja", fecha.ToString("yyyy") + "-" + fecha.ToString("MM") + "-" + fecha.ToString("dd"));

                miBD.conexion.Open();

                //Almacena si hubo filas guardadas
                int guardado = alta.ExecuteNonQuery();

                miBD.conexion.Close();

                if (guardado > 0)
                {
                    miBD.conexion.Close();

                    MySqlCommand actualizar = new MySqlCommand("update ninos_datos set estado = @estado where no_miembro = @no_miembro;", miBD.conexion);

                    actualizar.Parameters.AddWithValue("no_miembro", baja_noMiembro.Text);
                    actualizar.Parameters.AddWithValue("estado", "0");

                    miBD.conexion.Open();
                    int datos_actualizados = actualizar.ExecuteNonQuery();

                    if (datos_actualizados > 0)
                    {
                        MessageBox.Show("Se ha cambiado el estado de (" + baja_noMiembro + ") de activo a inactivo");
                    }
                    else
                    {
                        MessageBox.Show("No se modificó el estado del miembro");
                    }
                    miBD.conexion.Close();
                }
                else
                {
                    MessageBox.Show("No se guardo la baja!");
                }
            }
            catch (FormatException sqle)
            {
                MessageBox.Show("Error: " + sqle.Message);
            }
            finally
            {
                miBD.conexion.Close();
            }
        }

        public void limpiar_campo_baja()
        {
            baja_nombres.Text = "";
            baja_ap_pat.Text = "";
            baja_ap_mat.Text = "";
            baja_fecha_nac.Text = "";
            baja_fecha_inscripcion.Text = "";
            baja_lugar_nac.Text = "";
            baja_nacionalidad.Text = "";
            btn_dar_baja.Enabled = false;
            baja_foto.Image = null;
        }

        //EVENTO PARA TEXBOX QUE QUIERA ACEPTAR SOLO NUMEROS
        private void solo_numeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void Niños_Bajas_Load(object sender, EventArgs e)
        {

        }
    }
}

