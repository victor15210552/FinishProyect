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
    public partial class Niños : MetroFramework.Forms.MetroForm
    {
        Niños_Menu menuNiños;
        cls_conexion miBD;

        DateTime fecha = DateTime.Now;

        public Niños(Niños_Menu menuNiños)
        { 
         miBD = new cls_conexion();

        
            this.menuNiños = menuNiños;
            InitializeComponent();
            obtener_ultimo_miembro("miembros", "no_miembro", dg_noMiembro);
            obtener_ultimo_miembro("miembros", "no_miembro", es_noMiembro);
            obtener_ultimo_miembro("miembros", "no_miembro", dm_noMiembro);
            obtener_ultimo_miembro("miembros", "no_miembro", nf_noMiembro);
        }

        private void Niños_FormClosed(object sender, FormClosedEventArgs e)
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
            else
            {
                e.Handled = true;
            }

        }

        //-------------------- INICIO Métodos para limpiar campos--------------------
        public void limpiar_datos_generales()
        {
            dg_foto.Image = null;
            dg_noMiembro.Text = "";
            dg_noMiembro.Text = "";
            dg_nombres.Text = "";
            dg_ap_pat.Text = "";
            dg_ap_mat.Text = "";
            dg_fecha_nac.Text = "";
            dg_lugar_nac.Text = "";
            dg_nacionalidad.Text = "";
            dg_sexo.Text = "";

            dg_vive_con.Text = "";
            dg_telefono.Text = "";
            dg_calle.Text = "";
            dg_numero.Text = "";
            dg_colonia.Text = "";
            dg_codPost.Text = "";
            dg_delegacion.Text = "";

            dg_municipio.Text = "";
            dg_nombre_escuela.Text = "";
            dg_turno.Text = "";
            dg_recoge1_nino.Text = "";
            dg_parent_recoge1.Text = "";
            dg_recoge2_nino.Text = "";
            dg_parent_recoge2.Text = "";
            dg_recoge3_nino.Text = "";

            dg_parent_recoge3.Text = "";
            dg_aviso_emergencia1.Text = "";
            dg_aviso_emergencia2.Text = "";
            dg_aviso_emergencia3.Text = "";
            dg_fecha_inscripcion.Text = "";

            dg_imss.Checked = false;
            dg_isste.Checked = false;
            dg_isstecali.Checked = false;
            dg_seg_popular.Checked = false;
            dg_particular.Checked = false;

        }

        public void limpiar_datos_socioeconomicos()
        {
            es_noMiembro.Text = "";
            es_transporte.Text = "";
            es_casa_habita.Text = "";
            es_cocina.Text = "";
            es_comedor.Text = "";
            es_sala.Text = "";
            es_baño.Text = "";
            es_dormitorio.Text = "";

            es_lavado.Text = "";
            es_jardin.Text = "";
            es_patio.Text = "";
            es_terraza.Text = "";
            es_alberca.Text = "";
            es_estacionamiento.Text = "";
            es_contruccion_de.Text = "";
            es_techo_de.Text = "";

            es_piso_de.Text = "";
            es_luz.Checked = false;
            es_agua.Checked = false;
            es_drenaje.Checked = false;
            es_gas.Checked = false;
            es_rec_basura.Checked = false;
            es_alumbrado.Checked = false;
            es_telefono.Checked = false;

            es_tv.Checked = false;
            es_area_recreativa.Checked = false;
            es_gasto_vivienda.Text = "";
            es_gasto_luz.Text = "";
            es_gasto_agua.Text = "";
            es_gasto_basura.Text = "";
            es_gasto_telefono.Text = "";
            es_gasto_tv.Text = "";

            es_gasto_transporte.Text = "";
            es_gasto_despensa.Text = "";
            es_gasto_deudas.Text = "";
            es_gasto_entretenimiento.Text = "";
            es_gasto_total.Text = "";
            es_tipo_familia.Text = "";
            es_nivel_ingresos.Text = "";
        }

        public void limpiar_datos_nucleoFamiliar()
        {

            nf_rb1.Select();
            nf_rb7.Select();
            nf_rb10.Select();
            nf_rb13.Select();
            nf_rb16.Select();
            nf_rb19.Select();
            nf_rb22.Select();
            nf_txtb1.Text = "";
            nf_txtb2.Text = "";
            nf_txtb3.Text = "";
            nf_txtb4.Text = "";
            nf_txtb5.Text = "";
            nf_txtb6.Text = "";
            nf_txtb7.Text = "";
            nf_txtb8.Text = "";
            nf_txtb9.Text = "";
            nf_txtb10.Text = "";
            nf_txtb11.Text = "";
            nf_txtb12.Text = "";
            nf_txtb13.Text = "";
            nf_txtb14.Text = "";
            nf_txtb15.Text = "";
            nf_txtb16.Text = "";
            nf_txtb17.Text = "";
            nf_txtb18.Text = "";
            nf_txtb19.Text = "";
            nf_txtb20.Text = "";
            nf_txtb21.Text = "";

            nf_cb1.Text = "";
            nf_cb2.Text = "";
            nf_cb3.Text = "";
            nf_cb4.Text = "";

            nf_dt1.Value = DateTime.Now;
            nf_dt2.Value = DateTime.Now;
            nf_chb1.Checked = false;
            nf_chb2.Checked = false;
            nf_chb3.Checked = false;
            nf_chb4.Checked = false;
            nf_chb5.Checked = false;
            nf_chb6.Checked = false;

        }

        public void limpiar_datos_datosMedicos()
        {
            dm_txtb1.Text = "";
            dm_chb1.Checked = false;
            dm_txtb2.Text = "";
            dm_chb2.Checked = false;
            dm_txtb3.Text = "";
            dm_chb3.Checked = false;
            dm_chb4.Checked = false;
            dm_chb5.Checked = false;
            dm_chb6.Checked = false;
            dm_chb7.Checked = false;
            dm_chb8.Checked = false;
            dm_chb9.Checked = false;
            dm_chb10.Checked = false;
            dm_txtb4.Text = "";
            dm_chb11.Checked = false;
            dm_chb10.Checked = false;
            dm_txtb5.Text = "";
            dm_chb12.Checked = false;
            dm_chb13.Checked = false;
            dm_chb14.Checked = false;
            dm_chb15.Checked = false;
            dm_chb16.Checked = false;
            dm_chb17.Checked = false;
            dm_chb18.Checked = false;
            dm_chb19.Checked = false;
            dm_chb20.Checked = false;
            dm_chb21.Checked = false;
            dm_chb22.Checked = false;
            dm_chb23.Checked = false;
            dm_txtb6.Text = "";
            dm_txtb7.Text = "";
            dm_txtb8.Text = "";
            dm_txtb9.Text = "0";
            dm_txtb10.Text = "";
            dm_txtb11.Text = "";
            dm_txtb12.Text = "";

        }

        public void limpiar_desarrollo_humano1()
        {
            dh_Nomiembro.Text = "";
            dh_cb1.Text = "";
            dh_cb2.Text = "";
            dh_cb3.Text = "";
            dh_cb4.Text = "";
            dh_cb5.Text = "";
            dh_cb6.Text = "";
            dh_cb7.Text = "";
            dh_cb8.Text = "";
            dh_cb9.Text = "";
            dh_cb10.Text = "";
            dh_cb11.Text = "";
            dh_cb12.Text = "";
            dh_cb13.Text = "";
            dh_cb14.Text = "";
            dh_cb15.Text = "";
            dh_cb16.Text = "";
            dh_cb17.Text = "";
            dh_cb18.Text = "";
            dh_cb19.Text = "";
            dh_cb20.Text = "";
            dh_cb21.Text = "";
            dh_cb22.Text = "";
            dh_cb23.Text = "";
            dh_tb1.Text = "";
            dh_tb2.Text = "";
            dh_tb3.Text = "";
            dh_tb4.Text = "";
            dh_tb5.Text = "";
            dh_cb24.Text = "";
            dh_chb1.Checked = false;
            dh_chb2.Checked = false;
            dh_chb3.Checked = false;

            dh_tb7.Text = "";
            dh_tb8.Text = "";
            dh_tb9.Text = "";
            dh_tb10.Text = "";
            dh_tb11.Text = "";
            dh_tb12.Text = "";
            dh_tb13.Text = "";
            dh_tb14.Text = "";
            dh_tb15.Text = "";
            dh_tb16.Text = "";
            dh_tb17.Text = "";

            dh_chb4.Checked = false;
            dh_chb5.Checked = false;
            dh_chb6.Checked = false;
            dh_chb7.Checked = false;
            dh_chb8.Checked = false;
            dh_chb9.Checked = false;
            dh_chb10.Checked = false;
            dh_chb11.Checked = false;
            dh_chb12.Checked = false;
            dh_chb13.Checked = false;
            dh_chb14.Checked = false;
            dh_chb16.Checked = false;
            dh_chb17.Checked = false;
            dh_chb18.Checked = false;
            dh_chb19.Checked = false;
            dh_chb20.Checked = false;
            dh_chb21.Checked = false;
            dh_chb22.Checked = false;
            dh_chb23.Checked = false;
            dh_chb24.Checked = false;
            dh_chb25.Checked = false;
            dh_chb26.Checked = false;
            dh_chb27.Checked = false;
            dh_chb28.Checked = false;
            dh_chb29.Checked = false;
            dh_chb30.Checked = false;
            dh_chb31.Checked = false;
            dh_chb32.Checked = false;
            dh_chb33.Checked = false;
            dh_chb34.Checked = false;
            dh_chb35.Checked = false;
            dh_chb36.Checked = false;
            dh_chb37.Checked = false;

        }


        //-------------------- GUARDAR EL MIEMBRO EN LA TABLA (MIEMBROS)--------------------
        public void obtener_ultimo_miembro(string tabla, string identificador, MetroFramework.Controls.MetroTextBox TextBox)
        {
            try
            {
                miBD.conexion.Close();
                miBD.conexion.Open();

                MySqlCommand consulta = new MySqlCommand("select max(" + identificador + ") + 1 as " + identificador + " from " + tabla + ";", miBD.conexion);
                MySqlDataReader lectura;

                lectura = consulta.ExecuteReader();

                if (lectura.Read())
                {
                    int nuevo_numero_miembro = lectura.GetInt32(0);

                    //Cerrando la lectura del último registro
                    lectura.Close();
                    miBD.conexion.Close();

                    //Obtiene el último registro y sumando un valor
                    TextBox.Text = nuevo_numero_miembro.ToString();
                }
                else
                {
                    TextBox.Text = "ERROR";
                }
            }
            catch (MySqlException sqle)
            {
                MessageBox.Show("Error: " + sqle.Message);
                TextBox.Text = "ERROR";
            }
            catch (SqlNullValueException) { TextBox.Text = "1"; }
            finally
            {
                miBD.conexion.Close();
            }
        }

        public void guardar_miembro()
        {
            try
            {
                miBD.conexion.Close();

                string campos = "@no_miembro, @tipo";

                MySqlCommand alta = new MySqlCommand("insert into miembros values (" + campos + ");", miBD.conexion);
                alta.Parameters.AddWithValue("no_miembro", dg_noMiembro.Text);
                alta.Parameters.AddWithValue("tipo", "infante");

                miBD.conexion.Open();

                //Almacena si hubo filas guardadas
                int guardado = alta.ExecuteNonQuery();

                miBD.conexion.Close();

                if (guardado > 0)
                {
                    MessageBox.Show("Miembro registrado");
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

        
        //-------------------- INICIO Métodos utilizados en datos GENERALES--------------------
        private void dg_accion_cambiada(object sender, EventArgs e)
        {
            MetroFramework.Controls.MetroRadioButton radio = sender as MetroFramework.Controls.MetroRadioButton;
            if (radio.Name.Equals("dg_accion_nuevo"))
            {
                obtener_ultimo_miembro("ninos_datos", "no_miembro", dg_noMiembro);
                dg_noMiembro.ReadOnly = true;
                dg_noMiembro.Enabled = false;
                dg_btn_guardar.Enabled = true;
                dg_btn_buscar.Enabled = false;
                dg_btnFoto.Select();

                limpiar_datos_generales();
                obtener_ultimo_miembro("miembros", "no_miembro", dg_noMiembro);
            }
            else if (radio.Name.Equals("dg_accion_modificar"))
            {
                dg_noMiembro.Enabled = true;
                dg_noMiembro.ReadOnly = false;
                dg_btn_guardar.Enabled = true;
                dg_btn_buscar.Enabled = true;
                dg_noMiembro.Text = "";
                dg_noMiembro.Select();
            }
            else if (radio.Name.Equals("dg_accion_consultar"))
            {
                dg_noMiembro.ReadOnly = false;
                dg_noMiembro.Select();
                dg_btn_buscar.Enabled = true;
                dg_btn_guardar.Enabled = false;
            }
        }

        private void dg_btn_guardar_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("¿Seguro que desea continuar?", "Continuar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (dg_accion_nuevo.Checked)
                {
                    dg_guardar_datos_generales();
                }
                else if (dg_accion_modificar.Checked)
                {
                    dg_actualizar_datos_generales();
                }
            }
        }

        public void dg_guardar_datos_generales()
        {
            try
            {
                guardar_miembro();

                miBD.conexion.Close();

                string campos = "@no_miembro, @nombres, @ap_paterno, @ap_materno, @fecha_nac, @lugar_nac, @nacionalidad, @sexo," +
                    "@vive_con, @telefono, @dom_calle, @dom_numero, @dom_colonia, @dom_codpost, @dom_delegacion," +
                    "@dom_municipio, @escuela, @esc_turno, @recoge1_nino, @parent_recoge1, @recoge2_nino, @parent_recoge2, @recoge3_nino," +
                    "@parent_recoge3, @aviso_emergencia1, @aviso_emergencia2, @aviso_emergencia3, @fecha_inscripcion, @estado, @imss, @isste, @isstecali," +
                    "@seguro_popular, @particular";

                MySqlCommand alta = new MySqlCommand("insert into ninos_datos values(" + campos + ");", miBD.conexion);
                alta.Parameters.AddWithValue("no_miembro", dg_noMiembro.Text);
                alta.Parameters.AddWithValue("nombres", dg_nombres.Text);
                alta.Parameters.AddWithValue("ap_paterno", dg_ap_pat.Text);
                alta.Parameters.AddWithValue("ap_materno", dg_ap_mat.Text);
                alta.Parameters.AddWithValue("fecha_nac", dg_fecha_nac.Text);
                alta.Parameters.AddWithValue("lugar_nac", dg_lugar_nac.Text);
                alta.Parameters.AddWithValue("nacionalidad", dg_nacionalidad.Text);
                alta.Parameters.AddWithValue("sexo", dg_sexo.Text);

                alta.Parameters.AddWithValue("vive_con", dg_vive_con.Text);
                alta.Parameters.AddWithValue("telefono", dg_telefono.Text);
                alta.Parameters.AddWithValue("dom_calle", dg_calle.Text);
                alta.Parameters.AddWithValue("dom_numero", dg_numero.Text);
                alta.Parameters.AddWithValue("dom_colonia", dg_colonia.Text);
                alta.Parameters.AddWithValue("dom_codpost", dg_codPost.Text);
                alta.Parameters.AddWithValue("dom_delegacion", dg_delegacion.Text);

                alta.Parameters.AddWithValue("dom_municipio", dg_municipio.Text);
                alta.Parameters.AddWithValue("escuela", dg_nombre_escuela.Text);
                alta.Parameters.AddWithValue("esc_turno", dg_turno.Text);
                alta.Parameters.AddWithValue("recoge1_nino", dg_recoge1_nino.Text);
                alta.Parameters.AddWithValue("parent_recoge1", dg_parent_recoge1.Text);
                alta.Parameters.AddWithValue("recoge2_nino", dg_recoge2_nino.Text);
                alta.Parameters.AddWithValue("parent_recoge2", dg_parent_recoge2.Text);
                alta.Parameters.AddWithValue("recoge3_nino", dg_recoge3_nino.Text);

                alta.Parameters.AddWithValue("parent_recoge3", dg_parent_recoge3.Text);
                alta.Parameters.AddWithValue("aviso_emergencia1", dg_aviso_emergencia1.Text);
                alta.Parameters.AddWithValue("aviso_emergencia2", dg_aviso_emergencia2.Text);
                alta.Parameters.AddWithValue("aviso_emergencia3", dg_aviso_emergencia3.Text);
                alta.Parameters.AddWithValue("fecha_inscripcion", dg_fecha_inscripcion.Text);
                alta.Parameters.AddWithValue("estado", bool.Parse(dg_estado.Checked.ToString()));

                alta.Parameters.AddWithValue("imss", bool.Parse(dg_imss.Checked.ToString()));
                alta.Parameters.AddWithValue("isste", bool.Parse(dg_isste.Checked.ToString()));
                alta.Parameters.AddWithValue("isstecali", bool.Parse(dg_isstecali.Checked.ToString()));
                alta.Parameters.AddWithValue("seguro_popular", bool.Parse(dg_seg_popular.Checked.ToString()));
                alta.Parameters.AddWithValue("particular", bool.Parse(dg_particular.Checked.ToString()));

                miBD.conexion.Open();

                //Almacena si hubo filas guardadas
                int guardado = alta.ExecuteNonQuery();

                miBD.conexion.Close();

                if (guardado > 0)
                {
                    MessageBox.Show("Se ha guardado");
                    limpiar_datos_generales();
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

        public void dg_actualizar_datos_generales()
        {
            try
            {
                miBD.conexion.Close();

                string campos = "nombres = @nombres, ap_paterno = @ap_paterno, ap_materno=@ap_materno, fecha_nac=@fecha_nac, lugar_nac=@lugar_nac, nacionalidad = @nacionalidad, sexo=@sexo," +
                   "vive_con=@vive_con, telefono=@telefono, dom_calle=@dom_calle, dom_numero=@dom_numero, dom_colonia=@dom_colonia, dom_codpost=@dom_codpost, dom_delegacion=@dom_delegacion," +
                   "dom_municipio=@dom_municipio, escuela=@escuela, esc_turno=@esc_turno, recoge1_nino=@recoge1_nino, parent_recoge1=@parent_recoge1, recoge2_nino=@recoge2_nino, parent_recoge2=@parent_recoge2, recoge3_nino=@recoge3_nino," +
                   "parent_recoge3=@parent_recoge3, aviso_emergencia1=@aviso_emergencia1, aviso_emergencia2=@aviso_emergencia2, aviso_emergencia3=@aviso_emergencia3, fecha_inscripcion=@fecha_inscripcion, estado=@estado," +
                   "imss=@imss, isste=@isste, isstecali=@isstecali, seguro_popular=@seguro_popular, particular = @particular";

                MySqlCommand alta = new MySqlCommand("update ninos_datos set " + campos + " where no_miembro = @no_miembro;", miBD.conexion);

                alta.Parameters.AddWithValue("no_miembro", dg_noMiembro.Text);
                alta.Parameters.AddWithValue("nombres", dg_nombres.Text);
                alta.Parameters.AddWithValue("ap_paterno", dg_ap_pat.Text);
                alta.Parameters.AddWithValue("ap_materno", dg_ap_mat.Text);
                alta.Parameters.AddWithValue("fecha_nac", dg_fecha_nac.Text);
                alta.Parameters.AddWithValue("lugar_nac", dg_lugar_nac.Text);
                alta.Parameters.AddWithValue("nacionalidad", dg_nacionalidad.Text);
                alta.Parameters.AddWithValue("sexo", dg_sexo.Text);

                alta.Parameters.AddWithValue("vive_con", dg_vive_con.Text);
                alta.Parameters.AddWithValue("telefono", dg_telefono.Text);
                alta.Parameters.AddWithValue("dom_calle", dg_calle.Text);
                alta.Parameters.AddWithValue("dom_numero", dg_numero.Text);
                alta.Parameters.AddWithValue("dom_colonia", dg_colonia.Text);
                alta.Parameters.AddWithValue("dom_codpost", dg_codPost.Text);
                alta.Parameters.AddWithValue("dom_delegacion", dg_delegacion.Text);

                alta.Parameters.AddWithValue("dom_municipio", dg_municipio.Text);
                alta.Parameters.AddWithValue("escuela", dg_nombre_escuela.Text);
                alta.Parameters.AddWithValue("esc_turno", dg_turno.Text);
                alta.Parameters.AddWithValue("recoge1_nino", dg_recoge1_nino.Text);
                alta.Parameters.AddWithValue("parent_recoge1", dg_parent_recoge1.Text);
                alta.Parameters.AddWithValue("recoge2_nino", dg_recoge2_nino.Text);
                alta.Parameters.AddWithValue("parent_recoge2", dg_parent_recoge2.Text);
                alta.Parameters.AddWithValue("recoge3_nino", dg_recoge3_nino.Text);

                alta.Parameters.AddWithValue("parent_recoge3", dg_parent_recoge3.Text);
                alta.Parameters.AddWithValue("aviso_emergencia1", dg_aviso_emergencia1.Text);
                alta.Parameters.AddWithValue("aviso_emergencia2", dg_aviso_emergencia2.Text);
                alta.Parameters.AddWithValue("aviso_emergencia3", dg_aviso_emergencia3.Text);
                alta.Parameters.AddWithValue("fecha_inscripcion", dg_fecha_inscripcion.Text); //Año-Mes-Dia
                alta.Parameters.AddWithValue("estado", bool.Parse(dg_estado.Checked.ToString()));

                alta.Parameters.AddWithValue("imss", bool.Parse(dg_imss.Checked.ToString()));
                alta.Parameters.AddWithValue("isste", bool.Parse(dg_isste.Checked.ToString()));
                alta.Parameters.AddWithValue("isstecali", bool.Parse(dg_isstecali.Checked.ToString()));
                alta.Parameters.AddWithValue("seguro_popular", bool.Parse(dg_seg_popular.Checked.ToString()));
                alta.Parameters.AddWithValue("particular", bool.Parse(dg_particular.Checked.ToString()));

                miBD.conexion.Open();
                int datos_actualizados = alta.ExecuteNonQuery();

                if (datos_actualizados > 0)
                {
                    MessageBox.Show("Se han modificado los datos");
                    limpiar_datos_generales();
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

        private void dg_btnbuscar(object sender, EventArgs e)
        {

            try
            {
                miBD.conexion.Close();
                miBD.conexion.Open();

                MySqlCommand command = new MySqlCommand("select * from ninos_datos where no_miembro = " + dg_noMiembro.Text + ";", miBD.conexion);
                MySqlDataReader lectura;

                //Se ejecuta la lectura
                lectura = command.ExecuteReader();

                //Si existen registros que cumplen las condiciones
                if (lectura.Read())
                {

                    dg_foto.ImageLocation = "Fotos\\" + dg_noMiembro.Text + ".jpg";
                    dg_nombres.Text = lectura.GetString(1);
                    dg_ap_pat.Text = lectura.GetString(2);
                    dg_ap_mat.Text = lectura.GetString(3);
                    dg_fecha_nac.Text = lectura.GetString(4);
                    dg_lugar_nac.Text = lectura.GetString(5);
                    dg_nacionalidad.Text = lectura.GetString(6);
                    dg_sexo.Text = lectura.GetString(7);
                    dg_vive_con.Text = lectura.GetString(8);
                    dg_telefono.Text = lectura.GetString(9);
                    dg_calle.Text = lectura.GetString(10);
                    dg_numero.Text = lectura.GetString(11);
                    dg_colonia.Text = lectura.GetString(12);
                    dg_codPost.Text = lectura.GetString(13);
                    dg_delegacion.Text = lectura.GetString(14);
                    dg_municipio.Text = lectura.GetString(15);
                    dg_nombre_escuela.Text = lectura.GetString(16);
                    dg_turno.Text = lectura.GetString(17);
                    dg_recoge1_nino.Text = lectura.GetString(18);
                    dg_parent_recoge1.Text = lectura.GetString(19);
                    dg_recoge2_nino.Text = lectura.GetString(20);
                    dg_parent_recoge2.Text = lectura.GetString(21);
                    dg_recoge3_nino.Text = lectura.GetString(22);

                    dg_parent_recoge3.Text = lectura.GetString(23);
                    dg_aviso_emergencia1.Text = lectura.GetString(24);
                    dg_aviso_emergencia2.Text = lectura.GetString(25);
                    dg_aviso_emergencia3.Text = lectura.GetString(26);
                    dg_fecha_inscripcion.Text = lectura.GetString(27);

                    if (lectura.GetString(28).Equals("1"))
                        dg_estado.Checked = true;
                    if (lectura.GetString(29).Equals("1"))
                        dg_imss.Checked = true;
                    if (lectura.GetString(30).Equals("1"))
                        dg_isste.Checked = true;
                    if (lectura.GetString(31).Equals("1"))
                        dg_isstecali.Checked = true;
                    if (lectura.GetString(32).Equals("1"))
                        dg_seg_popular.Checked = true;
                    if (lectura.GetString(33).Equals("1"))
                        dg_particular.Checked = true;
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

        private void dg_btnFoto_Click(object sender, EventArgs e)
        {
            Camara camara = new Camara(dg_noMiembro.Text, this);
            this.Hide();
            camara.ShowDialog();

            dg_foto.ImageLocation = "Fotos\\" + dg_noMiembro.Text + ".jpg";
        }

        private void fecha_nacimiento_seleccionaa(object sender, EventArgs e)
        {
            try
            {
                DateTime fecha_ingresada = DateTime.Parse(dg_fecha_nac.Text);

                DateTime zeroTime = new DateTime(1, 1, 1);

                DateTime fecha_actual = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                DateTime fecha_nac = new DateTime(int.Parse(fecha_ingresada.ToString("yyyy")), int.Parse(fecha_ingresada.ToString("MM")), int.Parse(fecha_ingresada.ToString("dd")));

                TimeSpan span = fecha_actual - fecha_nac;
                int edad = (zeroTime + span).Year - 1;
                dg_edad.Text = edad.ToString();
            }
            catch (ArgumentOutOfRangeException) { }
        }


        //-------------------- INICIO Métodos utilizados en datos SOCIOECONOMICOS--------------------

        private void es_accion_cambiada(object sender, EventArgs e)
        {
            MetroFramework.Controls.MetroRadioButton radio = sender as MetroFramework.Controls.MetroRadioButton;
            if (radio.Name.Equals("es_accion_nuevo"))
            {
                es_btn_buscar.Enabled = false;
                es_noMiembro.Select();
               // es_noMiembro.Enabled = false;
                es_btn_guardar_datos.Enabled = true;
                limpiar_datos_socioeconomicos();
            }
            else if (radio.Name.Equals("es_accion_modificar"))
            {
                es_noMiembro.Enabled = true;
                es_btn_buscar.Enabled = true;
                es_noMiembro.Select();
                es_btn_guardar_datos.Enabled = true;
                limpiar_datos_socioeconomicos();
            }
            else if (radio.Name.Equals("es_accion_consultar"))
            {
                es_btn_buscar.Enabled = true;
                es_noMiembro.Select();
                es_btn_guardar_datos.Enabled = false;
                limpiar_datos_socioeconomicos();
            }
        }

        private void es_btn_guardar_datos_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea continuar?", "Continuar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (es_accion_nuevo.Checked)
                {
                    es_guardar_datos_socioeconomicos();
                }
                else if (es_accion_modificar.Checked)
                {
                    es_actualizar_datos_socioeconomicos();
                }
            }
        }

        public void es_guardar_datos_socioeconomicos()
        {
            try
            {
                miBD.conexion.Close();

                string campos = "@no_miembro, @transporte, @vivienda, @cocina, @comedor, @sala, @bano, @dormitorio," +
                    "@lavado, @jardin, @patio, @terraza, @alberca, @estacionamiento, @tipo_vivienda, @techo_vivienda," +
                    "@piso_vivienda, @serv_luz, @serv_agua, @serv_drenaje, @serv_gas, @serv_rec_basura, @serv_alumbrado_publico, @serv_telefono," +
                    "@serv_tv, @serv_area_recreativa, @gasto_vivienda, @gasto_luz, @gasto_agua, @gasto_rec_basura, @gasto_telefono, @gasto_tv," +
                    "@gasto_vehiculos, @gasto_despensa, @gasto_deudas, @gasto_entretenimiento, @gasto_mensual, @tipo_familia, @nivel_ingreso_mensual";

                MySqlCommand alta = new MySqlCommand("insert into ninos_socioeconomico values(" + campos + ");", miBD.conexion);
                alta.Parameters.AddWithValue("no_miembro", int.Parse(es_noMiembro.Text));
                alta.Parameters.AddWithValue("transporte", es_transporte.Text);
                alta.Parameters.AddWithValue("vivienda", es_casa_habita.Text);
                alta.Parameters.AddWithValue("cocina", int.Parse(es_cocina.Text));
                alta.Parameters.AddWithValue("comedor", int.Parse(es_comedor.Text));
                alta.Parameters.AddWithValue("sala", int.Parse(es_sala.Text));
                alta.Parameters.AddWithValue("bano", int.Parse(es_baño.Text));
                alta.Parameters.AddWithValue("dormitorio", int.Parse(es_dormitorio.Text));

                alta.Parameters.AddWithValue("lavado", int.Parse(es_lavado.Text));
                alta.Parameters.AddWithValue("jardin", int.Parse(es_jardin.Text));
                alta.Parameters.AddWithValue("patio", int.Parse(es_patio.Text));
                alta.Parameters.AddWithValue("terraza", int.Parse(es_terraza.Text));
                alta.Parameters.AddWithValue("alberca", int.Parse(es_alberca.Text));
                alta.Parameters.AddWithValue("estacionamiento", int.Parse(es_estacionamiento.Text));
                alta.Parameters.AddWithValue("tipo_vivienda", es_contruccion_de.Text);
                alta.Parameters.AddWithValue("techo_vivienda", es_techo_de.Text);

                alta.Parameters.AddWithValue("piso_vivienda", es_piso_de.Text);
                alta.Parameters.AddWithValue("serv_luz", bool.Parse(es_luz.Checked.ToString()));
                alta.Parameters.AddWithValue("serv_agua", bool.Parse(es_agua.Checked.ToString()));
                alta.Parameters.AddWithValue("serv_drenaje", bool.Parse(es_drenaje.Checked.ToString()));
                alta.Parameters.AddWithValue("serv_gas", bool.Parse(es_gas.Checked.ToString()));
                alta.Parameters.AddWithValue("serv_rec_basura", bool.Parse(es_rec_basura.Checked.ToString()));
                alta.Parameters.AddWithValue("serv_alumbrado_publico", bool.Parse(es_alumbrado.Checked.ToString()));
                alta.Parameters.AddWithValue("serv_telefono", bool.Parse(es_telefono.Checked.ToString()));

                alta.Parameters.AddWithValue("serv_tv", bool.Parse(es_tv.Checked.ToString()));
                alta.Parameters.AddWithValue("serv_area_recreativa", bool.Parse(es_area_recreativa.Checked.ToString()));
                alta.Parameters.AddWithValue("gasto_vivienda", Single.Parse(es_gasto_vivienda.Text));
                alta.Parameters.AddWithValue("gasto_luz", Single.Parse(es_gasto_luz.Text));
                alta.Parameters.AddWithValue("gasto_agua", Single.Parse(es_gasto_agua.Text));
                alta.Parameters.AddWithValue("gasto_rec_basura", Single.Parse(es_gasto_basura.Text));
                alta.Parameters.AddWithValue("gasto_telefono", Single.Parse(es_gasto_telefono.Text));
                alta.Parameters.AddWithValue("gasto_tv", Single.Parse(es_gasto_tv.Text));

                alta.Parameters.AddWithValue("gasto_vehiculos", Single.Parse(es_gasto_transporte.Text));
                alta.Parameters.AddWithValue("gasto_despensa", Single.Parse(es_gasto_despensa.Text));
                alta.Parameters.AddWithValue("gasto_deudas", Single.Parse(es_gasto_deudas.Text));
                alta.Parameters.AddWithValue("gasto_entretenimiento", Single.Parse(es_gasto_entretenimiento.Text));
                alta.Parameters.AddWithValue("gasto_mensual", Single.Parse(es_gasto_total.Text));
                alta.Parameters.AddWithValue("tipo_familia", es_tipo_familia.Text);
                alta.Parameters.AddWithValue("nivel_ingreso_mensual", es_nivel_ingresos.Text);

                bool aceptado = es_luz.Checked;
                miBD.conexion.Open();

                //Almacena si hubo filas guardadas
                int guardado = alta.ExecuteNonQuery();

                miBD.conexion.Close();

                if (guardado > 0)
                {
                    MessageBox.Show("Se ha guardado");
                    limpiar_datos_socioeconomicos();
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
            catch (FormatException fe)
            {
                MessageBox.Show("Error: " + fe.Message);
            }
            finally
            {
                miBD.conexion.Close();
            }
        }

        public void es_actualizar_datos_socioeconomicos()
        {
            try
            {
                miBD.conexion.Close();

                string campos = "transporte = @transporte, vivienda = @vivienda, cocina=@cocina, comedor=@comedor, sala=@sala, bano=@bano, dormitorio = @dormitorio, lavado=@lavado," +
                   "jardin=@jardin, patio=@patio, terraza=@terraza, alberca=@alberca, estacionamiento=@estacionamiento, tipo_vivienda=@tipo_vivienda, techo_vivienda=@techo_vivienda," +
                   "piso_vivienda=@piso_vivienda, serv_luz=@serv_luz, serv_agua=@serv_agua, serv_drenaje=@serv_drenaje, serv_gas=@serv_gas, serv_rec_basura=@serv_rec_basura, serv_alumbrado_publico=@serv_alumbrado_publico, serv_telefono=@serv_telefono," +
                   "serv_tv=@serv_tv, serv_area_recreativa=@serv_area_recreativa, gasto_vivienda=@gasto_vivienda, gasto_luz=@gasto_luz, gasto_agua=@gasto_agua, gasto_rec_basura=@gasto_rec_basura,gasto_telefono=@gasto_telefono," +
                   "gasto_tv=@gasto_tv, gasto_vehiculos=@gasto_vehiculos, gasto_despensa=@gasto_despensa, gasto_deudas=@gasto_deudas, gasto_entretenimiento = @gasto_entretenimiento, gasto_mensual=@gasto_mensual," +
                   "tipo_familia=@tipo_familia, nivel_ingreso_mensual=@nivel_ingreso_mensual";

                MySqlCommand alta = new MySqlCommand("update ninos_socioeconomico set " + campos + " where num_miembro = @num_miembro;", miBD.conexion);

                alta.Parameters.AddWithValue("num_miembro", int.Parse(es_noMiembro.Text));
                alta.Parameters.AddWithValue("transporte", es_transporte.Text);
                alta.Parameters.AddWithValue("vivienda", es_casa_habita.Text);
                alta.Parameters.AddWithValue("cocina", int.Parse(es_cocina.Text));
                alta.Parameters.AddWithValue("comedor", int.Parse(es_comedor.Text));
                alta.Parameters.AddWithValue("sala", int.Parse(es_sala.Text));
                alta.Parameters.AddWithValue("bano", int.Parse(es_baño.Text));
                alta.Parameters.AddWithValue("dormitorio", int.Parse(es_dormitorio.Text));
                alta.Parameters.AddWithValue("lavado", int.Parse(es_lavado.Text));

                alta.Parameters.AddWithValue("jardin", int.Parse(es_jardin.Text));
                alta.Parameters.AddWithValue("patio", int.Parse(es_patio.Text));
                alta.Parameters.AddWithValue("terraza", int.Parse(es_terraza.Text));
                alta.Parameters.AddWithValue("alberca", int.Parse(es_alberca.Text));
                alta.Parameters.AddWithValue("estacionamiento", int.Parse(es_estacionamiento.Text));
                alta.Parameters.AddWithValue("tipo_vivienda", es_contruccion_de.Text);
                alta.Parameters.AddWithValue("techo_vivienda", es_techo_de.Text);

                alta.Parameters.AddWithValue("piso_vivienda", es_piso_de.Text);
                alta.Parameters.AddWithValue("serv_luz", bool.Parse(es_luz.Checked.ToString()));
                alta.Parameters.AddWithValue("serv_agua", bool.Parse(es_agua.Checked.ToString()));
                alta.Parameters.AddWithValue("serv_drenaje", bool.Parse(es_drenaje.Checked.ToString()));
                alta.Parameters.AddWithValue("serv_gas", bool.Parse(es_gas.Checked.ToString()));
                alta.Parameters.AddWithValue("serv_rec_basura", bool.Parse(es_rec_basura.Checked.ToString()));
                alta.Parameters.AddWithValue("serv_alumbrado_publico", bool.Parse(es_alumbrado.Checked.ToString()));
                alta.Parameters.AddWithValue("serv_telefono", bool.Parse(es_telefono.Checked.ToString()));

                alta.Parameters.AddWithValue("serv_tv", bool.Parse(es_tv.Checked.ToString()));
                alta.Parameters.AddWithValue("serv_area_recreativa", bool.Parse(es_area_recreativa.Checked.ToString()));
                alta.Parameters.AddWithValue("gasto_vivienda", Single.Parse(es_gasto_vivienda.Text));
                alta.Parameters.AddWithValue("gasto_luz", Single.Parse(es_gasto_luz.Text));
                alta.Parameters.AddWithValue("gasto_agua", Single.Parse(es_gasto_agua.Text));
                alta.Parameters.AddWithValue("gasto_rec_basura", Single.Parse(es_gasto_basura.Text));
                alta.Parameters.AddWithValue("gasto_telefono", Single.Parse(es_gasto_telefono.Text));

                alta.Parameters.AddWithValue("gasto_tv", Single.Parse(es_gasto_tv.Text));
                alta.Parameters.AddWithValue("gasto_vehiculos", Single.Parse(es_gasto_transporte.Text));
                alta.Parameters.AddWithValue("gasto_despensa", Single.Parse(es_gasto_despensa.Text));
                alta.Parameters.AddWithValue("gasto_deudas", Single.Parse(es_gasto_deudas.Text));
                alta.Parameters.AddWithValue("gasto_entretenimiento", Single.Parse(es_gasto_entretenimiento.Text));
                alta.Parameters.AddWithValue("gasto_mensual", Single.Parse(es_gasto_total.Text));
                alta.Parameters.AddWithValue("tipo_familia", es_tipo_familia.Text);
                alta.Parameters.AddWithValue("nivel_ingreso_mensual", es_nivel_ingresos.Text);

                miBD.conexion.Open();
                int datos_actualizados = alta.ExecuteNonQuery();

                if (datos_actualizados > 0)
                {
                    MessageBox.Show("Se han modificado los datos");
                    limpiar_datos_socioeconomicos();
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

        private void es_btn_buscar_Click(object sender, EventArgs e)
        {
            try
            {
                miBD.conexion.Close();
                miBD.conexion.Open();

                MySqlCommand command = new MySqlCommand("select * from ninos_socioeconomico where num_miembro = " + es_noMiembro.Text + ";", miBD.conexion);
                MySqlDataReader lectura;

                //Se ejecuta la lectura
                lectura = command.ExecuteReader();

                //Si existen registros que cumplen las condiciones
                if (lectura.Read())
                {
                    es_transporte.Text = lectura.GetString(1);
                    es_casa_habita.Text = lectura.GetString(2);

                    es_cocina.Text = lectura.GetInt32(3).ToString();
                    es_comedor.Text = lectura.GetInt32(4).ToString();
                    es_sala.Text = lectura.GetInt32(5).ToString();
                    es_baño.Text = lectura.GetInt32(6).ToString();
                    es_dormitorio.Text = lectura.GetInt32(7).ToString();
                    es_lavado.Text = lectura.GetInt32(8).ToString();
                    es_jardin.Text = lectura.GetInt32(9).ToString();
                    es_patio.Text = lectura.GetInt32(10).ToString();

                    es_terraza.Text = lectura.GetInt32(11).ToString();
                    es_alberca.Text = lectura.GetInt32(12).ToString();
                    es_estacionamiento.Text = lectura.GetInt32(13).ToString();

                    es_contruccion_de.Text = lectura.GetString(14);
                    es_techo_de.Text = lectura.GetString(15);
                    es_piso_de.Text = lectura.GetString(16);

                    if (lectura.GetString(17).Equals("1"))
                        es_luz.Checked = true;
                    if (lectura.GetString(18).Equals("1"))
                        es_agua.Checked = true;
                    if (lectura.GetString(19).Equals("1"))
                        es_drenaje.Checked = true;
                    if (lectura.GetString(20).Equals("1"))
                        es_gas.Checked = true;
                    if (lectura.GetString(21).Equals("1"))
                        es_rec_basura.Checked = true;
                    if (lectura.GetString(22).Equals("1"))
                        es_alumbrado.Checked = true;
                    if (lectura.GetString(23).Equals("1"))
                        es_telefono.Checked = true;
                    if (lectura.GetString(24).Equals("1"))
                        es_tv.Checked = true;
                    if (lectura.GetString(25).Equals("1"))
                        es_area_recreativa.Checked = true;

                    es_gasto_vivienda.Text = lectura.GetFloat(26).ToString();
                    es_gasto_luz.Text = lectura.GetFloat(27).ToString();
                    es_gasto_agua.Text = lectura.GetFloat(28).ToString();
                    es_gasto_basura.Text = lectura.GetFloat(29).ToString();
                    es_gasto_telefono.Text = lectura.GetFloat(30).ToString();
                    es_gasto_tv.Text = lectura.GetFloat(31).ToString();
                    es_gasto_transporte.Text = lectura.GetFloat(32).ToString();
                    es_gasto_despensa.Text = lectura.GetFloat(33).ToString();
                    es_gasto_deudas.Text = lectura.GetFloat(34).ToString();
                    es_gasto_entretenimiento.Text = lectura.GetFloat(35).ToString();
                    es_gasto_total.Text = lectura.GetFloat(36).ToString();

                    es_tipo_familia.Text = lectura.GetString(37);
                    es_nivel_ingresos.Text = lectura.GetString(38);
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

        private void calcular_gastos_mensuales(object sender, EventArgs e)
        {
            try
            {
                float vivienda = Single.Parse(es_gasto_vivienda.Text);
                float luz = Single.Parse(es_gasto_luz.Text);
                float agua = Single.Parse(es_gasto_agua.Text);
                float basura = Single.Parse(es_gasto_basura.Text);
                float telefono = Single.Parse(es_gasto_telefono.Text);
                float tv = Single.Parse(es_gasto_tv.Text);
                float transporte = Single.Parse(es_gasto_transporte.Text);
                float despensa = Single.Parse(es_gasto_despensa.Text);
                float deudas = Single.Parse(es_gasto_deudas.Text);
                float entrenamiento = Single.Parse(es_gasto_entretenimiento.Text);

                float gasto_vivienda = vivienda + luz + agua + basura + telefono + tv + transporte + despensa + deudas + entrenamiento;
                es_gasto_total.Text = gasto_vivienda.ToString();
            }
            catch (FormatException fe) { MessageBox.Show("Rellena todos los campos de gastos"); }
        }



        //-------------------- INICIO Métodos utilizados en datos NÚCLEO FAMILIAR--------------------

        public string obtener_valores_nucleo_familiar(int valor)
        {

            switch (valor)
            {

                case 1: //padres


                    if (nf_rb1.Checked)
                    {
                        return "Viven juntos";
                    }
                    else if (nf_rb2.Checked)
                    {
                        return "Separados";
                    }
                    else if (nf_rb3.Checked)
                    {
                        return "Viudo(a)";
                    }
                    else if (nf_rb4.Checked)
                    {
                        return "madre o padre soltero(a)";
                    }

                    break;
                case 2: //disciplina
                    if (nf_rb5.Checked)
                    {

                        return "Mamá";

                    }
                    else if (nf_rb6.Checked)
                    {

                        return "Papá";
                    }
                    else if (nf_rb7.Checked)
                    {
                        return "Ambos";
                    }


                    break;

                case 3:

                    if (nf_rb8.Checked)
                    {

                        return "Mamá";

                    }
                    else if (nf_rb9.Checked)
                    {

                        return "Papá";
                    }
                    else if (nf_rb10.Checked)
                    {
                        return "Ambos";
                    }


                    break;
                case 4:
                    if (nf_rb11.Checked)
                    {

                        return "Mamá";

                    }
                    else if (nf_rb12.Checked)
                    {

                        return "Papá";
                    }
                    else if (nf_rb13.Checked)
                    {
                        return "Ambos";
                    }

                    break;
                case 5:
                    if (nf_rb14.Checked)
                    {

                        return "Mamá";

                    }
                    else if (nf_rb15.Checked)
                    {

                        return "Papá";
                    }
                    else if (nf_rb16.Checked)
                    {
                        return "Ambos";
                    }

                    break;
                case 6:
                    if (nf_rb17.Checked)
                    {

                        return "Mamá";

                    }
                    else if (nf_rb18.Checked)
                    {

                        return "Papá";
                    }
                    else if (nf_rb19.Checked)
                    {
                        return "Ambos";
                    }

                    break;
                case 7:
                    if (nf_rb20.Checked)
                    {

                        return "Mamá";

                    }
                    else if (nf_rb21.Checked)
                    {

                        return "Papá";
                    }
                    else if (nf_rb22.Checked)
                    {
                        return "Ambos";
                    }

                    break;

                default:

                    return "";

                    break;


            }

            return "";
        }

        public void establecer_valores_nucleo_familiar(int valor , String cadena)
        {

            switch (valor)
            {

                case 1: //padres


                    if (cadena  == "Viven juntos")
                    {
                        nf_rb1.Checked = true;

                    }
                    else if (cadena == "Separados")
                    {
                        nf_rb2.Checked = true;
                    }
                    else if (cadena == "Viudo(a)")
                    {
                        nf_rb3.Checked = true;
                    }
                    else if (cadena == "madre o padre soltero(a)")
                    {
                        nf_rb4.Checked = true;
                    }

                    break;
                case 2: //disciplina
                    if (cadena == "Mamá")
                    {
                        nf_rb5.Checked = true;

                    }
                    else if (cadena == "Papá")
                    {
                        nf_rb6.Checked = true;

                    }
                    else if (cadena == "Ambos")
                    {
                        nf_rb7.Checked = true;

                    }


                    break;

                case 3:

                    if (cadena == "Mamá")
                    {
                        nf_rb8.Checked = true;

                    }
                    else if (cadena == "Papá")
                    {
                        nf_rb9.Checked = true;

                    }
                    else if (cadena == "Ambos")
                    {
                        nf_rb10.Checked = true;

                    }


                    break;
                case 4:
                    if (cadena == "Mamá")
                    {
                        nf_rb11.Checked = true;

                    }
                    else if (cadena == "Papá")
                    {
                        nf_rb12.Checked = true;

                    }
                    else if (cadena == "Ambos")
                    {
                        nf_rb13.Checked = true;

                    }


                    break;
                case 5:
                    if (cadena == "Mamá")
                    {
                        nf_rb14.Checked = true;

                    }
                    else if (cadena == "Papá")
                    {
                        nf_rb15.Checked = true;

                    }
                    else if (cadena == "Ambos")
                    {
                        nf_rb16.Checked = true;

                    }


                    break;
                case 6:
                    if (cadena == "Mamá")
                    {
                        nf_rb17.Checked = true;

                    }
                    else if (cadena == "Papá")
                    {
                        nf_rb18.Checked = true;

                    }
                    else if (cadena == "Ambos")
                    {
                        nf_rb19.Checked = true;

                    }

                    break;
                case 7:
                    if (cadena == "Mamá")
                    {
                        nf_rb20.Checked = true;

                    }
                    else if (cadena == "Papá")
                    {
                        nf_rb21.Checked = true;

                    }
                    else if (cadena == "Ambos")
                    {
                        nf_rb22.Checked = true;

                    }

                    break;




            }


        }


        private void nf_bt1_Click(object sender, EventArgs e)
        {
            metroTabControl1.SelectedIndex = 3;
     
        }

        private void nf_bt2_Click(object sender, EventArgs e)
        {


            if (MessageBox.Show("¿Seguro que desea continuar?", "Continuar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (nf_nuevo.Checked)
                {
                    nf_guardar_datos_nucleoFamiliar();
                }
                else if (nf_modificar.Checked)
                {
                    nf_actualizar_datos_nucleoFamiliar();
                }


            }

        }


        public void nf_guardar_datos_nucleoFamiliar() {

            try
            {
                miBD.conexion.Close();

                string campos = "@no_miembro, @tutores_situacion, @nombre_padre, @apellido_padre, @fecha_nacim_padre,@lugar_nacim_padre," +
                    "@nacionalidad_padre, @Escolaridad_padre, @Ocupacion_padre, @lugar_trabajo_padre, @tel_particular_padre, @tel_trabajo_padre, @celular_padre, @email_padre," +
                    "@nombre_madre, @apellido_madre,@fecha_nacim_madre,@lugar_nacim_madre,@nacionalidad_madre,@Escolaridad_madre,@Ocupacion_madre," +
                    "@lugar_trabajo_madre, @tel_particular_madre,@tel_trabajo_madre,@celular_madre,@email_madre,@restriccion_legal,@tutor_autorizado,@desintegracion_familiar,@fallecimientos," +
                    "@nacimientos,@situacion_economica,@cambios_rutina,@disciplina,@juegos,@al_acostarse,@hora_alimentos,@al_levantarse,@hora_bano";

                MySqlCommand alta = new MySqlCommand("insert into nino_familia values(" + campos + ");", miBD.conexion);
                //Núcleo familiar
                alta.Parameters.AddWithValue("no_miembro", Convert.ToInt32(nf_noMiembro.Text));
                alta.Parameters.AddWithValue("tutores_situacion", obtener_valores_nucleo_familiar(1));
                alta.Parameters.AddWithValue("nombre_padre", nf_txtb1.Text);
                alta.Parameters.AddWithValue("apellido_padre", nf_txtb2.Text);
                alta.Parameters.AddWithValue("fecha_nacim_padre", nf_dt1.Text);
                alta.Parameters.AddWithValue("lugar_nacim_padre", nf_txtb3.Text);
                alta.Parameters.AddWithValue("nacionalidad_padre", nf_cb1.Text);
                alta.Parameters.AddWithValue("Escolaridad_padre", nf_cb2.Text);
                alta.Parameters.AddWithValue("Ocupacion_padre", nf_txtb5.Text);
                alta.Parameters.AddWithValue("lugar_trabajo_padre", nf_txtb6.Text);
                alta.Parameters.AddWithValue("tel_particular_padre", nf_txtb7.Text);
                alta.Parameters.AddWithValue("tel_trabajo_padre", nf_txtb8.Text);
                alta.Parameters.AddWithValue("celular_padre", nf_txtb9.Text);
                alta.Parameters.AddWithValue("email_padre", nf_txtb10.Text);
                alta.Parameters.AddWithValue("nombre_madre", nf_txtb11.Text);
                alta.Parameters.AddWithValue("apellido_madre", nf_txtb12.Text);
                alta.Parameters.AddWithValue("fecha_nacim_madre", nf_dt2.Text);
                alta.Parameters.AddWithValue("lugar_nacim_madre", nf_txtb13.Text);
                alta.Parameters.AddWithValue("nacionalidad_madre", nf_cb3.Text);
                alta.Parameters.AddWithValue("Escolaridad_madre", nf_cb4.Text);
                alta.Parameters.AddWithValue("Ocupacion_madre", nf_txtb15.Text);
                alta.Parameters.AddWithValue("lugar_trabajo_madre", nf_txtb16.Text);
                alta.Parameters.AddWithValue("tel_particular_madre", nf_txtb17.Text);
                alta.Parameters.AddWithValue("tel_trabajo_madre", nf_txtb18.Text);
                alta.Parameters.AddWithValue("celular_madre", nf_txtb19.Text);
                alta.Parameters.AddWithValue("email_madre", nf_txtb20.Text);


                //Núcleo familiar 2

                alta.Parameters.AddWithValue("restriccion_legal", bool.Parse(nf_chb1.Checked.ToString()));
                alta.Parameters.AddWithValue("tutor_autorizado", nf_txtb21);
                alta.Parameters.AddWithValue("desintegracion_familiar", bool.Parse(nf_chb2.Checked.ToString()));
                alta.Parameters.AddWithValue("fallecimientos", bool.Parse(nf_chb3.Checked.ToString()));
                alta.Parameters.AddWithValue("nacimientos", bool.Parse(nf_chb4.Checked.ToString()));
                alta.Parameters.AddWithValue("situacion_economica", bool.Parse(nf_chb5.Checked.ToString()));
                alta.Parameters.AddWithValue("cambios_rutina", bool.Parse(nf_chb6.Checked.ToString()));
                alta.Parameters.AddWithValue("disciplina", obtener_valores_nucleo_familiar(2));
                alta.Parameters.AddWithValue("juegos", obtener_valores_nucleo_familiar(3));
                alta.Parameters.AddWithValue("al_acostarse", obtener_valores_nucleo_familiar(4));
                alta.Parameters.AddWithValue("hora_alimentos", obtener_valores_nucleo_familiar(5));
                alta.Parameters.AddWithValue("al_levantarse", obtener_valores_nucleo_familiar(6));
                alta.Parameters.AddWithValue("hora_bano", obtener_valores_nucleo_familiar(7));
                miBD.conexion.Open();



                //Almacena si hubo filas guardadas
                int guardado = alta.ExecuteNonQuery();

                miBD.conexion.Close();

                if (guardado > 0)
                {
                    MessageBox.Show("Se ha guardado");
                    limpiar_datos_nucleoFamiliar();
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

        public void nf_actualizar_datos_nucleoFamiliar() {


            try { 

            miBD.conexion.Close();
            string campos = "tutores_situacion = @tutores_situacion, nombre_padre = @nombre_padre,apellido_padre = @apellido_padre,fecha_nacim_padre = @fecha_nacim_padre,lugar_nacim_padre = @lugar_nacim_padre, nacionalidad_padre = @nacionalidad_padre, " +
                            "Escolaridad_padre = @Escolaridad_padre,Ocupacion_padre = @Ocupacion_padre,lugar_trabajo_padre = @lugar_trabajo_padre,tel_particular_padre = @tel_particular_padre,tel_trabajo_padre = @tel_trabajo_padre,celular_padre = @celular_padre, " +
                            "email_padre = @email_padre,nombre_madre = @nombre_madre,apellido_madre = @apellido_madre,fecha_nacim_madre = @fecha_nacim_madre,lugar_nacim_madre = @lugar_nacim_madre,nacionalidad_madre = @nacionalidad_madre,Escolaridad_madre = @Escolaridad_madre, " +
                            "Ocupacion_madre = @Ocupacion_madre,lugar_trabajo_madre = @lugar_trabajo_madre,tel_particular_madre = @tel_particular_madre,tel_trabajo_madre = @tel_trabajo_madre,celular_madre = @celular_madre,email_madre = @email_madre,restriccion_legal = @restriccion_legal, " +
                            "tutor_autorizado = @tutor_autorizado,desintegracion_familiar = @desintegracion_familiar,fallecimientos = @fallecimientos,nacimientos = @nacimientos,situacion_economica =@situacion_economica,  cambios_rutina = @cambios_rutina,disciplica = @disciplica, " +
                            "juegos = @juegos, al_acostarse = @al_acostarse, hora_alimentos = @hora_alimentos,al_levantarse = @al_levantarse, hora_bano = @hora_bano";

            MySqlCommand modificar = new MySqlCommand("update nino_familia set " + campos + " where no_miembro = @no_miembro;", miBD.conexion);

                //Núcleo familiar
                modificar.Parameters.AddWithValue("no_miembro", Convert.ToInt32(nf_noMiembro.Text));
                modificar.Parameters.AddWithValue("tutores_situacion", obtener_valores_nucleo_familiar(1));
                modificar.Parameters.AddWithValue("nombre_padre", nf_txtb1.Text);
                modificar.Parameters.AddWithValue("apellido_padre", nf_txtb2.Text);
                modificar.Parameters.AddWithValue("fecha_nacim_padre", nf_dt1.Text);
                modificar.Parameters.AddWithValue("lugar_nacim_padre", nf_txtb3.Text);
                modificar.Parameters.AddWithValue("nacionalidad_padre", nf_cb1.Text);
                modificar.Parameters.AddWithValue("Escolaridad_padre", nf_cb2.Text);
                modificar.Parameters.AddWithValue("Ocupacion_padre", nf_txtb5.Text);
                modificar.Parameters.AddWithValue("lugar_trabajo_padre", nf_txtb6.Text);
                modificar.Parameters.AddWithValue("tel_particular_padre", nf_txtb7.Text);
                modificar.Parameters.AddWithValue("tel_trabajo_padre", nf_txtb8.Text);
                modificar.Parameters.AddWithValue("celular_padre", nf_txtb9.Text);
                modificar.Parameters.AddWithValue("email_padre", nf_txtb10.Text);
                modificar.Parameters.AddWithValue("nombre_madre", nf_txtb11.Text);
                modificar.Parameters.AddWithValue("apellido_madre", nf_txtb12.Text);
                modificar.Parameters.AddWithValue("fecha_nacim_madre", nf_dt2.Text);
                modificar.Parameters.AddWithValue("lugar_nacim_madre", nf_txtb13.Text);
                modificar.Parameters.AddWithValue("nacionalidad_madre", nf_cb3.Text);
                modificar.Parameters.AddWithValue("Escolaridad_madre", nf_cb4.Text);
                modificar.Parameters.AddWithValue("Ocupacion_madre", nf_txtb15.Text);
                modificar.Parameters.AddWithValue("lugar_trabajo_madre", nf_txtb16.Text);
                modificar.Parameters.AddWithValue("tel_particular_madre", nf_txtb17.Text);
                modificar.Parameters.AddWithValue("tel_trabajo_madre", nf_txtb18.Text);
                modificar.Parameters.AddWithValue("celular_madre", nf_txtb19.Text);
                modificar.Parameters.AddWithValue("email_madre", nf_txtb20.Text);


                //Núcleo familiar 2

                modificar.Parameters.AddWithValue("restriccion_legal", bool.Parse(nf_chb1.Checked.ToString()));
                modificar.Parameters.AddWithValue("tutor_autorizado", nf_txtb21);
                modificar.Parameters.AddWithValue("desintegracion_familiar", bool.Parse(nf_chb2.Checked.ToString()));
                modificar.Parameters.AddWithValue("fallecimientos", bool.Parse(nf_chb3.Checked.ToString()));
                modificar.Parameters.AddWithValue("nacimientos", bool.Parse(nf_chb4.Checked.ToString()));
                modificar.Parameters.AddWithValue("situacion_economica", bool.Parse(nf_chb5.Checked.ToString()));
                modificar.Parameters.AddWithValue("cambios_rutina", bool.Parse(nf_chb6.Checked.ToString()));
                modificar.Parameters.AddWithValue("disciplina", obtener_valores_nucleo_familiar(2));
                modificar.Parameters.AddWithValue("juegos", obtener_valores_nucleo_familiar(3));
                modificar.Parameters.AddWithValue("al_acostarse", obtener_valores_nucleo_familiar(4));
                modificar.Parameters.AddWithValue("hora_alimentos", obtener_valores_nucleo_familiar(5));
                modificar.Parameters.AddWithValue("al_levantarse", obtener_valores_nucleo_familiar(6));
                modificar.Parameters.AddWithValue("hora_bano", obtener_valores_nucleo_familiar(7));

                miBD.conexion.Open();

            //Almacena si hubo filas guardadas
            int guardado = modificar.ExecuteNonQuery();

            miBD.conexion.Close();

            if (guardado > 0)
            {
                MessageBox.Show("Se han guardado los cambios.");
                limpiar_datos_socioeconomicos();
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
            catch (FormatException fe)
            {
                MessageBox.Show("Error: " + fe.Message);
            }
            finally
            {
                miBD.conexion.Close();
            }
        }

        //-------------------- INICIO Métodos utilizados en DATOS MÉDICOS--------------------
        private void dm_bt1_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("¿Seguro que desea continuar?", "Continuar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    miBD.conexion.Close();

                    string campos = "@no_miembro,@alergias, @medicamentos, @cuidado_especial,@rebeola, @varicela, @escarlatina, @hepatitis, " +
                                    "@influenza, @tifoidea, @paperas, @tosferina, @otra_enfermedad, @ataques_epilepticos, @enfermedad_cronica, " +
                                    "@accidentes_graves, @ha_sido_operado, @tipo_operacion, @cantidad_operaciones, @fecha_operacion, " +
                                    "@piojos_liendres, @frec_piojos_liendres, @problema_habla, @problema_vista, @problema_oido, @problema_tono_muscular, " +
                                    "@otro_problema, @aparato_dental, @aparato_anteojos, @aparato_auditivo, @aparato_ortopedico, @otro_aparato ";

                    MySqlCommand alta = new MySqlCommand("insert into nino_medicos values(" + campos + ");", miBD.conexion);

                    alta.Parameters.AddWithValue("no_miembro", Convert.ToInt32(dm_noMiembro.Text));
                    alta.Parameters.AddWithValue("alergias", dm_txtb1.Text);
                    alta.Parameters.AddWithValue("medicamentos", dm_txtb2.Text);
                    alta.Parameters.AddWithValue("cuidado_especial", dm_txtb2.Text);
                    alta.Parameters.AddWithValue("rebeola", bool.Parse(dm_chb3.Checked.ToString()));
                    alta.Parameters.AddWithValue("varicela", bool.Parse(dm_chb4.Checked.ToString()));
                    alta.Parameters.AddWithValue("escarlatina", bool.Parse(dm_chb5.Checked.ToString()));
                    alta.Parameters.AddWithValue("hepatitis", bool.Parse(dm_chb6.Checked.ToString()));
                    alta.Parameters.AddWithValue("influenza", bool.Parse(dm_chb7.Checked.ToString()));
                    alta.Parameters.AddWithValue("tifoidea", bool.Parse(dm_chb8.Checked.ToString()));
                    alta.Parameters.AddWithValue("paperas", bool.Parse(dm_chb9.Checked.ToString()));
                    alta.Parameters.AddWithValue("tosferina", bool.Parse(dm_chb10.Checked.ToString()));
                    alta.Parameters.AddWithValue("otra_enfermedad", dm_txtb4.Text);
                    alta.Parameters.AddWithValue("ataques_epilepticos", dm_txtb5.Text);
                    alta.Parameters.AddWithValue("enfermedad_cronica", dm_txtb6.Text);
                    alta.Parameters.AddWithValue("accidentes_graves", dm_txtb7.Text);
                    alta.Parameters.AddWithValue("ha_sido_operado", bool.Parse(dm_chb14.Checked.ToString()));
                    alta.Parameters.AddWithValue("tipo_operacion", dm_txtb8.Text);
                    alta.Parameters.AddWithValue("cantidad_operaciones", Convert.ToInt32(dm_txtb9.Text));
                    alta.Parameters.AddWithValue("fecha_operacion", dm_dt1.Text);
                    alta.Parameters.AddWithValue("piojos_liendres", bool.Parse(dm_chb15.Checked.ToString()));
                    alta.Parameters.AddWithValue("frec_piojos_liendres", dm_txtb10.Text);
                    alta.Parameters.AddWithValue("problema_habla", bool.Parse(dm_chb16.Checked.ToString()));
                    alta.Parameters.AddWithValue("problema_vista", bool.Parse(dm_chb17.Checked.ToString()));
                    alta.Parameters.AddWithValue("problema_oido", bool.Parse(dm_chb18.Checked.ToString()));
                    alta.Parameters.AddWithValue("problema_tono_muscular", bool.Parse(dm_chb19.Checked.ToString()));
                    alta.Parameters.AddWithValue("otro_problema", dm_txtb11.Text);
                    alta.Parameters.AddWithValue("aparato_dental", bool.Parse(dm_chb20.Checked.ToString()));
                    alta.Parameters.AddWithValue("aparato_anteojos", bool.Parse(dm_chb21.Checked.ToString()));
                    alta.Parameters.AddWithValue("aparato_auditivo", bool.Parse(dm_chb22.Checked.ToString()));
                    alta.Parameters.AddWithValue("aparato_ortopedico", bool.Parse(dm_chb23.Checked.ToString()));
                    alta.Parameters.AddWithValue("otro_aparato", dm_txtb12.Text);


                    miBD.conexion.Open();

                    //Almacena si hubo filas guardadas
                    int guardado = alta.ExecuteNonQuery();

                    miBD.conexion.Close();

                    if (guardado > 0)
                    {
                        MessageBox.Show("Se ha guardado");
                        limpiar_datos_datosMedicos();
                    }
                    else
                    {
                        MessageBox.Show("No se guardo el usuario");
                    }
                }
                catch (MySqlException sqle)
                {
                    MessageBox.Show("Error: No se tienen los datos generales de el número de miembro actúal. ");
                    MessageBox.Show("Error: " + sqle.Message);
                    metroTabControl1.SelectedIndex = 0;
                }
                finally
                {
                    miBD.conexion.Close();
                }
            }
        }

        private void es_accion_modificar_CheckedChanged(object sender, EventArgs e)
        {
            if (es_accion_modificar.Checked)
            {
                es_noMiembro.Text = "";
                es_noMiembro.ReadOnly = false;
                es_btn_buscar.Enabled = true;

            }
            else if (es_accion_nuevo.Checked)
            {

                es_noMiembro.ReadOnly = true;
                es_btn_buscar.Enabled = false;
                obtener_ultimo_miembro("ninos_socioeconomico", "num_Miembro", es_noMiembro);
                limpiar_datos_socioeconomicos();

            }
        }

        private void es_noMiembro_Click(object sender, EventArgs e)
        {

        }

        private void Niños_Load(object sender, EventArgs e)
        {

        }

        private void nf_modificar_CheckedChanged(object sender, EventArgs e)
        {
            if (nf_modificar.Checked) {

                nf_noMiembro.ReadOnly = false;
                nf_noMiembro.Text = "";
                nf_buscar.Enabled = true;
                nf_noMiembro.Select();
                nf_noMiembro.Enabled = true;


            } else if (nf_nuevo.Checked) {
                limpiar_datos_nucleoFamiliar();
                nf_noMiembro.ReadOnly = true;
                obtener_ultimo_miembro("miembros", "no_miembro", nf_noMiembro);
                nf_buscar.Enabled = false;
             //   nf_noMiembro.Enabled = false;


            }
        }


        private void dm_modificar_CheckedChanged(object sender, EventArgs e)
        {
            if (dm_modificar.Checked)
            {

                dm_noMiembro.ReadOnly = false;
                dm_noMiembro.Enabled = true;
                dm_noMiembro.Text = "";
                dm_buscar.Enabled = true;
                dm_noMiembro.Select();


            }
            else if (dm_nuevo.Checked)
            {
                limpiar_datos_datosMedicos();
            //    dm_noMiembro.Enabled = false;
                dm_noMiembro.ReadOnly = true;
                obtener_ultimo_miembro("miembros", "no_miembro", dm_noMiembro);
                dm_buscar.Enabled = false;


            }
        }

        private void nf_dt1_ValueChanged(object sender, EventArgs e)
        {
            
            try
            {
                DateTime fecha_ingresada = DateTime.Parse(nf_dt1.Text);

                DateTime zeroTime = new DateTime(1, 1, 1);

                DateTime fecha_actual = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                DateTime fecha_nac = new DateTime(int.Parse(fecha_ingresada.ToString("yyyy")), int.Parse(fecha_ingresada.ToString("MM")), int.Parse(fecha_ingresada.ToString("dd")));

                TimeSpan span = fecha_actual - fecha_nac;
                int edad = (zeroTime + span).Year - 1;
                nf_txtb4.Text = edad.ToString();
            }
            catch (ArgumentOutOfRangeException) { }
        }

        private void nf_dt2_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime fecha_ingresada = DateTime.Parse(nf_dt2.Text);

                DateTime zeroTime = new DateTime(1, 1, 1);

                DateTime fecha_actual = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                DateTime fecha_nac = new DateTime(int.Parse(fecha_ingresada.ToString("yyyy")), int.Parse(fecha_ingresada.ToString("MM")), int.Parse(fecha_ingresada.ToString("dd")));

                TimeSpan span = fecha_actual - fecha_nac;
                int edad = (zeroTime + span).Year - 1;
                nf_txtb14.Text = edad.ToString();
            }
            catch (ArgumentOutOfRangeException) { }
        }

        private void dm_cambio_en_los_checkBox(object sender, EventArgs e)
        {
            MetroFramework.Controls.MetroCheckBox checkBox = sender as MetroFramework.Controls.MetroCheckBox;

            if (checkBox.Checked)
            {

                switch (checkBox.Name)
                {

                    case "dm_chb1":
                        dm_txtb2.Enabled = true;
                        break;
                    case "dm_chb2":
                        dm_txtb3.Enabled = true;
                        break;
                    case "dm_chb11":
                        dm_txtb5.Enabled = true;
                        break;
                    case "dm_chb12":
                        dm_txtb6.Enabled = true;
                        break;
                    case "dm_chb13":
                        dm_txtb7.Enabled = true;
                        break;
                    case "dm_chb14":
                        dm_txtb8.Enabled = true;
                        dm_txtb9.Enabled = true;
                        dm_dt1.Enabled = true;

                        break;
                    case "dm_chb15":
                        dm_txtb10.Enabled = true;

                        break;
                }



            }
            else {
                switch (checkBox.Name)
                {

                    case "dm_chb1":
                        dm_txtb2.Text = "";
                        dm_txtb2.Enabled = false;
                        break;
                    case "dm_chb2":
                        dm_txtb3.Text = "";
                        dm_txtb3.Enabled = false;
                        break;
                    case "dm_chb11":
                        dm_txtb5.Text = "";
                        dm_txtb5.Enabled = false;
                        break;
                    case "dm_chb12":
                        dm_txtb6.Text = "";
                        dm_txtb6.Enabled = false;
                        break;
                    case "dm_chb13":
                        dm_txtb7.Text = "";
                        dm_txtb7.Enabled = false;
                        break;
                    case "dm_chb14":
                        dm_txtb8.Text = "";
                        dm_txtb8.Enabled = false;
                        dm_txtb9.Text = "";
                        dm_txtb9.Enabled = false;
                        dm_dt1.Text = "";
                        dm_dt1.Enabled = false;

                        break;
                    case "dm_chb15":
                        dm_txtb10.Text = "";
                        dm_txtb10.Enabled = false;

                        break;
                }


            }

        }

        private void nf_buscar_Click(object sender, EventArgs e)
        {

            try { 
            miBD.conexion.Close();
            miBD.conexion.Open();

            MySqlCommand command = new MySqlCommand("select * from nino_familia where no_miembro = " + nf_noMiembro.Text + ";", miBD.conexion);
            MySqlDataReader lectura;

            //Se ejecuta la lectura
            lectura = command.ExecuteReader();

            //Si existen registros que cumplen las condiciones
            if (lectura.Read())
            {

                    establecer_valores_nucleo_familiar(1, lectura.GetString(1));
                    nf_txtb1.Text = lectura.GetString(2);
                    nf_txtb2.Text = lectura.GetString(3);
                    nf_dt1.Text = lectura.GetString(4);
                    nf_txtb3.Text = lectura.GetString(5);
                    nf_cb1.Text = lectura.GetString(6);
                    nf_cb2.Text = lectura.GetString(7);
                    nf_txtb5.Text = lectura.GetString(8);
                    nf_txtb6.Text = lectura.GetString(9);
                    nf_txtb7.Text = lectura.GetString(10);
                    nf_txtb8.Text = lectura.GetString(11);
                    nf_txtb9.Text = lectura.GetString(12);
                    nf_txtb10.Text = lectura.GetString(13);
                    nf_txtb11.Text = lectura.GetString(14);
                    nf_txtb12.Text = lectura.GetString(15);
                    nf_dt2.Text = lectura.GetString(16);
                    nf_txtb13.Text = lectura.GetString(17);
                    nf_cb3.Text = lectura.GetString(18);
                    nf_cb4.Text = lectura.GetString(19);
                    nf_txtb15.Text = lectura.GetString(20);
                    nf_txtb16.Text = lectura.GetString(21);
                    nf_txtb17.Text = lectura.GetString(22);
                    nf_txtb18.Text = lectura.GetString(23);
                    nf_txtb19.Text = lectura.GetString(24);
                    nf_txtb20.Text = lectura.GetString(25);

                    if (lectura.GetString(26) == "1") 
                        nf_chb1.Checked = true;
                    nf_txtb21.Text = lectura.GetString(27);
                    if (lectura.GetString(28) == "1")
                        nf_chb2.Checked = true;
                    if (lectura.GetString(29) == "1")
                        nf_chb3.Checked = true;
                    if (lectura.GetString(30) == "1")
                        nf_chb4.Checked = true;
                    if (lectura.GetString(31) == "1")
                        nf_chb5.Checked = true;
                    if (lectura.GetString(32) == "1")
                        nf_chb6.Checked = true;

                    establecer_valores_nucleo_familiar(2, lectura.GetString(33));
                    establecer_valores_nucleo_familiar(3, lectura.GetString(34));
                    establecer_valores_nucleo_familiar(4, lectura.GetString(35));
                    establecer_valores_nucleo_familiar(5, lectura.GetString(36));
                    establecer_valores_nucleo_familiar(6, lectura.GetString(37));
                    establecer_valores_nucleo_familiar(7, lectura.GetString(38));

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

        //Metodos de Desarrollo Humano 1

        public void dh_guardar_datos()
        {
            try
            {
                //  guardar_miembro();
                miBD.conexion.Close();
                string campos = "@no_miembro, @alegre, @amigable, @callado, @cooperador, @curioso, @comparte, @berrinches, @independiente," +
                                "@imaginativo, @irritable, @miedo, @moja_cama, @tolerante, @compania_adulto, @responsable, @ordendo," +
                                "@chupa_dedo, @sociable, @persistente, @timido, @hace_tarea, @hace_quehacer, @va_solo_bano, @terapia_previa, @motivo_terapia," +
                                "@presenta_tics, @diversiones, @situaciones_incomodas, @juegos_preferidos, @tipo_castigo, @obediente, @juega_peligroso," +
                                "@reaccion_obscuridad, @fobias_miedos, @duerme_solo, @duerme_con_padres, @duerme_con_hermanos, @duerme_otros, @siseta_durante_dia," +
                                "@horas_siesta, @horas_sueno, @transtorno_sueno, @pesadilla, @insomnio, rechina_dientes, @suena_tranquilo, @habla_dormido, @duerme_poco," +
                                "@otro_transtorno_sueno, @horas_television, @minutos_television, @television_solo, @television_compania, @hora_aparato_electronicos," +
                                "@minutos_aparatos_electronicos, @ve_caricaturas, @ve_telenovelas, @ve_documentales, @ve_series_policiacas, @ve_concursos @ve_videos," +
                                "@ve_series_terror, @visitas_familiares, @cine, @parque_diversiones, @conciertos, @salida_usa, @salida_deportiva, @redes_sociales, @otra_actividad," +
                                "@come_solo, @bano_solo, @peina_solo, @lava_dientes, viste_solo, @lava_manos, @otro_programa";


                MySqlCommand alta = new MySqlCommand("insert into nino_desarrollo_humano  values(" + campos + ");", miBD.conexion);
                alta.Parameters.AddWithValue("no_miembro", dh_Nomiembro.Text); //Convert.ToInt32(dg_noMiembro.Text));
                alta.Parameters.AddWithValue("alegre", dh_cb1.Text);
                alta.Parameters.AddWithValue("amigable", dh_cb2.Text);
                alta.Parameters.AddWithValue("callado", dh_cb3.Text);
                alta.Parameters.AddWithValue("cooperador", dh_cb4.Text);
                alta.Parameters.AddWithValue("curioso", dh_cb5.Text);
                alta.Parameters.AddWithValue("comparte", dh_cb6.Text);
                alta.Parameters.AddWithValue("berrinches", dh_cb7.Text);
                alta.Parameters.AddWithValue("independiente", dh_cb8.Text);

                alta.Parameters.AddWithValue("imaginativo", dh_cb9.Text);
                alta.Parameters.AddWithValue("irritable", dh_cb10.Text);
                alta.Parameters.AddWithValue("miedo", dh_cb11.Text);
                alta.Parameters.AddWithValue("moja_cama", dh_cb12.Text);
                alta.Parameters.AddWithValue("tolerante", dh_cb13.Text);
                alta.Parameters.AddWithValue("compania_adulto", dh_cb14.Text);
                alta.Parameters.AddWithValue("responsable", dh_cb15.Text);
                alta.Parameters.AddWithValue("ordendo", dh_cb16.Text);

                alta.Parameters.AddWithValue("chupa_dedo", dh_cb17.Text);
                alta.Parameters.AddWithValue("sociable", dh_cb18.Text);
                alta.Parameters.AddWithValue("persistente", dh_cb19.Text);
                alta.Parameters.AddWithValue("timido", dh_cb20.Text);
                alta.Parameters.AddWithValue("hace_tarea", dh_cb21.Text);
                alta.Parameters.AddWithValue("hace_quehacer", dh_cb22.Text);
                alta.Parameters.AddWithValue("va_solo_bano", dh_cb23.Text);
                alta.Parameters.AddWithValue("motivo_terapia", dh_tb1.Text);

                alta.Parameters.AddWithValue("presenta_tics", dh_tb2.Text);
                alta.Parameters.AddWithValue("diversiones", dh_tb3.Text);
                alta.Parameters.AddWithValue("situaciones_incomodas", dh_tb4.Text);
                alta.Parameters.AddWithValue("juegos_preferidos", dh_tb5.Text);
                alta.Parameters.AddWithValue("tipo_castigo", dh_cb24.Text);

                alta.Parameters.AddWithValue("terapia_previa", bool.Parse(dh_chb3.Checked.ToString()));
                alta.Parameters.AddWithValue("obediente", bool.Parse(dh_chb1.Checked.ToString()));
                alta.Parameters.AddWithValue("juega_peligroso", bool.Parse(dh_chb2.Checked.ToString()));

                //Desarrollo humano 2            
                alta.Parameters.AddWithValue("reaccion_obscuridad", dh_tb7.Text);
                alta.Parameters.AddWithValue("fobias_miedos", dh_tb8.Text);
                alta.Parameters.AddWithValue("horas_siesta", dh_tb9.Text);
                alta.Parameters.AddWithValue("horas_sueno", dh_tb10.Text);
                alta.Parameters.AddWithValue("otro_transtorno_sueno", dh_tb11.Text);
                alta.Parameters.AddWithValue("horas_television", dh_tb12.Text);
                alta.Parameters.AddWithValue("minutos_television", dh_tb13.Text);
                alta.Parameters.AddWithValue("horas_aparatos_electronicos", dh_tb14.Text);

                alta.Parameters.AddWithValue("minutos_aparatos_electronicos", dh_tb15.Text);
                alta.Parameters.AddWithValue("otro_programa", dh_tb16.Text);
                alta.Parameters.AddWithValue("otra_actividad", dh_tb17.Text);

                alta.Parameters.AddWithValue("duerme_solo", bool.Parse(dh_chb4.Checked.ToString()));
                alta.Parameters.AddWithValue("duerme_con_padres", bool.Parse(dh_chb5.Checked.ToString()));
                alta.Parameters.AddWithValue("duerme_con_hermanos", bool.Parse(dh_chb6.Checked.ToString()));
                alta.Parameters.AddWithValue("duerme_otros", bool.Parse(dh_chb7.Checked.ToString()));
                alta.Parameters.AddWithValue("siseta_durante_dia", bool.Parse(dh_chb8.Checked.ToString()));
                alta.Parameters.AddWithValue("transtorno_sueno", bool.Parse(dh_chb9.Checked.ToString()));
                alta.Parameters.AddWithValue("pesadilla", bool.Parse(dh_chb10.Checked.ToString()));
                alta.Parameters.AddWithValue("insomnio", bool.Parse(dh_chb11.Checked.ToString()));
                alta.Parameters.AddWithValue("suena_tranquilo", bool.Parse(dh_chb38.Checked.ToString()));
                alta.Parameters.AddWithValue("rechina_dientes", bool.Parse(dh_chb12.Checked.ToString()));
                alta.Parameters.AddWithValue("habla_dormido", bool.Parse(dh_chb13.Checked.ToString()));
                alta.Parameters.AddWithValue("duerme_poco", bool.Parse(dh_chb14.Checked.ToString()));
                alta.Parameters.AddWithValue("television_solo", bool.Parse(dh_chb16.Checked.ToString()));
                alta.Parameters.AddWithValue("television_compania", bool.Parse(dh_chb17.Checked.ToString()));
                alta.Parameters.AddWithValue("ve_caricaturas", bool.Parse(dh_chb18.Checked.ToString()));
                alta.Parameters.AddWithValue("ve_telenovelas", bool.Parse(dh_chb19.Checked.ToString()));
                alta.Parameters.AddWithValue("ve_documentales", bool.Parse(dh_chb20.Checked.ToString()));
                alta.Parameters.AddWithValue("ve_series_policiacas", bool.Parse(dh_chb21.Checked.ToString()));
                alta.Parameters.AddWithValue("ve_concursos", bool.Parse(dh_chb22.Checked.ToString()));
                alta.Parameters.AddWithValue("ve_videos", bool.Parse(dh_chb23.Checked.ToString()));
                alta.Parameters.AddWithValue("ve_series_terror", bool.Parse(dh_chb24.Checked.ToString()));
                alta.Parameters.AddWithValue("visitas_familiares", bool.Parse(dh_chb25.Checked.ToString()));
                alta.Parameters.AddWithValue("cine", bool.Parse(dh_chb26.Checked.ToString()));
                alta.Parameters.AddWithValue("parque_diversiones", bool.Parse(dh_chb27.Checked.ToString()));
                alta.Parameters.AddWithValue("conciertos", bool.Parse(dh_chb28.Checked.ToString()));
                alta.Parameters.AddWithValue("salida_usa", bool.Parse(dh_chb29.Checked.ToString()));
                alta.Parameters.AddWithValue("salida_deportiva", bool.Parse(dh_chb30.Checked.ToString()));
                alta.Parameters.AddWithValue("redes_sosciales", bool.Parse(dh_chb31.Checked.ToString()));
                alta.Parameters.AddWithValue("come_solo", bool.Parse(dh_chb32.Checked.ToString()));
                alta.Parameters.AddWithValue("bano_solo", bool.Parse(dh_chb33.Checked.ToString()));
                alta.Parameters.AddWithValue("peina_solo", bool.Parse(dh_chb34.Checked.ToString()));
                alta.Parameters.AddWithValue("lava_dientes", bool.Parse(dh_chb35.Checked.ToString()));
                alta.Parameters.AddWithValue("viste_solo", bool.Parse(dh_chb36.Checked.ToString()));
                alta.Parameters.AddWithValue("lava_manos", bool.Parse(dh_chb37.Checked.ToString()));

                miBD.conexion.Open();

                //Almacena si hubo filas guardadas
                int guardado = alta.ExecuteNonQuery();
                miBD.conexion.Close();

                if (guardado > 0)
                {
                    MessageBox.Show("Se ha guardado");
                    limpiar_desarrollo_humano1();
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
        public void dh_actualizar_datos()
        {
            try
            {
                miBD.conexion.Close();
                string campos = "no_miembro=@no_miembro, alegre=@alegre, amigable=@amigable, callado=@callado, cooperador=@cooperador, curioso=@curioso, comparte=@comparte, berrinches=@berrinches, independiente=@independiente," +
                                "imaginativo=@imaginativo, irritable=@irritable, miedo=@miedo, moja_cama=@moja_cama, tolerante=@tolerante, compania_adulto=@compania_adulto, responsable=@responsable, ordendo=@ordendo," +
                                "chupa_dedo=@chupa_dedo, sociable=@sociable, persistente=@persistente, timido=@timido, hace_tarea=@hace_tarea, hace_quehacer=@hace_quehacer, va_solo_bano=@va_solo_bano, terapia_previa=@terapia_previa, motivo_terapia=@motivo_terapia," +
                                "presenta_tics=@presenta_tics, diversiones=@diversiones, situaciones_incomodas=@situaciones_incomodas, juegos_preferidos=@juegos_preferidos, tipo_castigo=@tipo_castigo, obediente=@obediente, juega_peligroso=@juega_peligroso," +
                                "reaccion_obscuridad=@reaccion_obscuridad, fobias_miedos=@fobias_miedos, duerme_solo=@duerme_solo, duerme_con_padres=@duerme_con_padres, duerme_con_hermanos=@duerme_con_hermanos, duerme_otros=@duerme_otros, siseta_durante_dia=@siseta_durante_dia," +
                                "horas_siesta=@horas_siesta, horas_sueno=@horas_sueno, transtorno_sueno=@transtorno_sueno, pesadilla=@pesadilla, insomnio=@insomnio, rechina_dientes=rechina_dientes, suena_tranquilo=@suena_tranquilo, habla_dormido=@habla_dormido, duerme_poco=@duerme_poco," +
                                "otro_transtorno_sueno=@otro_transtorno_sueno, horas_television=@horas_television, minutos_television=@minutos_television, television_solo=@television_solo, television_compania=@television_compania, hora_aparato_electronicos=@hora_aparato_electronicos," +
                                "minutos_aparatos_electronicos=@minutos_aparatos_electronicos, ve_caricaturas=@ve_caricaturas, ve_telenovelas=@ve_telenovelas, ve_documentales=@ve_documentales, ve_series_policiacas=@ve_series_policiacas, ve_concursos=@ve_concursos, ve_videos=@ve_videos," +
                                "ve_series_terror=@ve_series_terror, visitas_familiares=@visitas_familiares, cine=@cine, parque_diversiones=@parque_diversiones, conciertos=@conciertos, salida_usa=@salida_usa, salida_deportiva=@salida_deportiva, redes_sociales=@redes_sociales, otra_actividad=@otra_actividad," +
                                "come_solo=@come_solo, bano_solo=@bano_solo, peina_solo=@peina_solo, lava_dientes=@lava_dientes, viste_solo=viste_solo, lava_manos=@lava_manos, otro_programa=@otro_programa";


                MySqlCommand alta = new MySqlCommand("update nino_desarrollo_humano set " + campos + " where no_miembro = @no_miembro;", miBD.conexion);

                //  MySqlCommand alta = new MySqlCommand("insert into nino_desarrollo_humano  values(" + campos + ");", miBD.conexion);
                //  alta.Parameters.AddWithValue("no_miembro", dh_Nomiembro.Text); //Convert.ToInt32(dg_noMiembro.Text));
                alta.Parameters.AddWithValue("alegre", dh_cb1.Text);
                alta.Parameters.AddWithValue("amigable", dh_cb2.Text);
                alta.Parameters.AddWithValue("callado", dh_cb3.Text);
                alta.Parameters.AddWithValue("cooperador", dh_cb4.Text);
                alta.Parameters.AddWithValue("curioso", dh_cb5.Text);
                alta.Parameters.AddWithValue("comparte", dh_cb6.Text);
                alta.Parameters.AddWithValue("berrinches", dh_cb7.Text);
                alta.Parameters.AddWithValue("independiente", dh_cb8.Text);

                alta.Parameters.AddWithValue("imaginativo", dh_cb9.Text);
                alta.Parameters.AddWithValue("irritable", dh_cb10.Text);
                alta.Parameters.AddWithValue("miedo", dh_cb11.Text);
                alta.Parameters.AddWithValue("moja_cama", dh_cb12.Text);
                alta.Parameters.AddWithValue("tolerante", dh_cb13.Text);
                alta.Parameters.AddWithValue("compania_adulto", dh_cb14.Text);
                alta.Parameters.AddWithValue("responsable", dh_cb15.Text);
                alta.Parameters.AddWithValue("ordendo", dh_cb16.Text);

                alta.Parameters.AddWithValue("chupa_dedo", dh_cb17.Text);
                alta.Parameters.AddWithValue("sociable", dh_cb18.Text);
                alta.Parameters.AddWithValue("persistente", dh_cb19.Text);
                alta.Parameters.AddWithValue("timido", dh_cb20.Text);
                alta.Parameters.AddWithValue("hace_tarea", dh_cb21.Text);
                alta.Parameters.AddWithValue("hace_quehacer", dh_cb22.Text);
                alta.Parameters.AddWithValue("va_solo_bano", dh_cb23.Text);
                alta.Parameters.AddWithValue("motivo_terapia", dh_tb1.Text);

                alta.Parameters.AddWithValue("presenta_tics", dh_tb2.Text);
                alta.Parameters.AddWithValue("diversiones", dh_tb3.Text);
                alta.Parameters.AddWithValue("situaciones_incomodas", dh_tb4.Text);
                alta.Parameters.AddWithValue("juegos_preferidos", dh_tb5.Text);
                alta.Parameters.AddWithValue("tipo_castigo", dh_cb24.Text);

                alta.Parameters.AddWithValue("terapia_previa", bool.Parse(dh_chb3.Checked.ToString()));
                alta.Parameters.AddWithValue("obediente", bool.Parse(dh_chb1.Checked.ToString()));
                alta.Parameters.AddWithValue("juega_peligroso", bool.Parse(dh_chb2.Checked.ToString()));

                //Desarrollo humano 2            
                alta.Parameters.AddWithValue("reaccion_obscuridad", dh_tb7.Text);
                alta.Parameters.AddWithValue("fobias_miedos", dh_tb8.Text);
                alta.Parameters.AddWithValue("horas_siesta", dh_tb9.Text);
                alta.Parameters.AddWithValue("horas_sueno", dh_tb10.Text);
                alta.Parameters.AddWithValue("otro_transtorno_sueno", dh_tb11.Text);
                alta.Parameters.AddWithValue("horas_television", dh_tb12.Text);
                alta.Parameters.AddWithValue("minutos_television", dh_tb13.Text);
                alta.Parameters.AddWithValue("horas_aparatos_electronicos", dh_tb14.Text);

                alta.Parameters.AddWithValue("minutos_aparatos_electronicos", dh_tb15.Text);
                alta.Parameters.AddWithValue("otro_programa", dh_tb16.Text);
                alta.Parameters.AddWithValue("otra_actividad", dh_tb17.Text);



                alta.Parameters.AddWithValue("duerme_solo", bool.Parse(dh_chb4.Checked.ToString()));
                alta.Parameters.AddWithValue("duerme_con_padres", bool.Parse(dh_chb5.Checked.ToString()));
                alta.Parameters.AddWithValue("duerme_con_hermanos", bool.Parse(dh_chb6.Checked.ToString()));
                alta.Parameters.AddWithValue("duerme_otros", bool.Parse(dh_chb7.Checked.ToString()));
                alta.Parameters.AddWithValue("siseta_durante_dia", bool.Parse(dh_chb8.Checked.ToString()));
                alta.Parameters.AddWithValue("transtorno_sueno", bool.Parse(dh_chb9.Checked.ToString()));
                alta.Parameters.AddWithValue("pesadilla", bool.Parse(dh_chb10.Checked.ToString()));
                alta.Parameters.AddWithValue("insomnio", bool.Parse(dh_chb11.Checked.ToString()));
                alta.Parameters.AddWithValue("rechina_dientes", bool.Parse(dh_chb12.Checked.ToString()));
                alta.Parameters.AddWithValue("suena_tranquilo", bool.Parse(dh_chb38.Checked.ToString()));
                alta.Parameters.AddWithValue("habla_dormido", bool.Parse(dh_chb13.Checked.ToString()));
                alta.Parameters.AddWithValue("duerme_poco", bool.Parse(dh_chb14.Checked.ToString()));
                alta.Parameters.AddWithValue("television_solo", bool.Parse(dh_chb16.Checked.ToString()));
                alta.Parameters.AddWithValue("television_compania", bool.Parse(dh_chb17.Checked.ToString()));
                alta.Parameters.AddWithValue("ve_caricaturas", bool.Parse(dh_chb18.Checked.ToString()));
                alta.Parameters.AddWithValue("ve_telenovelas", bool.Parse(dh_chb19.Checked.ToString()));
                alta.Parameters.AddWithValue("ve_documentales", bool.Parse(dh_chb20.Checked.ToString()));
                alta.Parameters.AddWithValue("ve_series_policiacas", bool.Parse(dh_chb21.Checked.ToString()));
                alta.Parameters.AddWithValue("ve_concursos", bool.Parse(dh_chb22.Checked.ToString()));
                alta.Parameters.AddWithValue("ve_videos", bool.Parse(dh_chb23.Checked.ToString()));
                alta.Parameters.AddWithValue("ve_series_terror", bool.Parse(dh_chb24.Checked.ToString()));
                alta.Parameters.AddWithValue("visitas_familiares", bool.Parse(dh_chb25.Checked.ToString()));
                alta.Parameters.AddWithValue("cine", bool.Parse(dh_chb26.Checked.ToString()));
                alta.Parameters.AddWithValue("parque_diversiones", bool.Parse(dh_chb27.Checked.ToString()));
                alta.Parameters.AddWithValue("conciertos", bool.Parse(dh_chb28.Checked.ToString()));
                alta.Parameters.AddWithValue("salida_usa", bool.Parse(dh_chb29.Checked.ToString()));
                alta.Parameters.AddWithValue("salida_deportiva", bool.Parse(dh_chb30.Checked.ToString()));
                alta.Parameters.AddWithValue("redes_sosciales", bool.Parse(dh_chb31.Checked.ToString()));
                alta.Parameters.AddWithValue("come_solo", bool.Parse(dh_chb32.Checked.ToString()));
                alta.Parameters.AddWithValue("bano_solo", bool.Parse(dh_chb33.Checked.ToString()));
                alta.Parameters.AddWithValue("peina_solo", bool.Parse(dh_chb34.Checked.ToString()));
                alta.Parameters.AddWithValue("lava_dientes", bool.Parse(dh_chb35.Checked.ToString()));
                alta.Parameters.AddWithValue("viste_solo", bool.Parse(dh_chb36.Checked.ToString()));
                alta.Parameters.AddWithValue("lava_manos", bool.Parse(dh_chb37.Checked.ToString()));

                miBD.conexion.Open();

                //Almacena si hubo filas guardadas
                int guardado = alta.ExecuteNonQuery();

                miBD.conexion.Close();

                if (guardado > 0)
                {
                    MessageBox.Show("Se ha guardado");
                    limpiar_desarrollo_humano1();
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

        private void dh_buscar1btn_Click(object sender, EventArgs e)
        {
                try
                {
                    miBD.conexion.Close();
                    miBD.conexion.Open();

                    MySqlCommand command = new MySqlCommand("select * from nino_desarollo_humano where no_miembro = " + dh_Nomiembro.Text + ";", miBD.conexion);
                    MySqlDataReader lectura;

                    //Se ejecuta la lectura
                    lectura = command.ExecuteReader();

                    //Si existen registros que cumplen las condiciones
                    if (lectura.Read())
                    {
                        dh_cb1.Text = lectura.GetString(1);
                        dh_cb2.Text = lectura.GetString(2);
                        dh_cb3.Text = lectura.GetString(3);
                        dh_cb4.Text = lectura.GetString(4);
                        dh_cb5.Text = lectura.GetString(5);
                        dh_cb6.Text = lectura.GetString(6);
                        dh_cb7.Text = lectura.GetString(7);
                        dh_cb8.Text = lectura.GetString(8);
                        dh_cb9.Text = lectura.GetString(9);
                        dh_cb10.Text = lectura.GetString(10);
                        dh_cb11.Text = lectura.GetString(11);
                        dh_cb12.Text = lectura.GetString(12);
                        dh_cb13.Text = lectura.GetString(13);
                        dh_cb14.Text = lectura.GetString(14);
                        dh_cb15.Text = lectura.GetString(15);
                        dh_cb16.Text = lectura.GetString(16);
                        dh_cb17.Text = lectura.GetString(17);
                        dh_cb18.Text = lectura.GetString(18);
                        dh_cb19.Text = lectura.GetString(19);
                        dh_cb20.Text = lectura.GetString(20);
                        dh_cb21.Text = lectura.GetString(21);
                        dh_cb22.Text = lectura.GetString(22);

                        if (lectura.GetString(24).Equals("1"))
                            dh_chb3.Checked = true;

                        dh_cb23.Text = lectura.GetString(23);
                        dh_tb1.Text = lectura.GetString(25);
                        dh_tb2.Text = lectura.GetString(26);
                        dh_tb3.Text = lectura.GetString(27);
                        dh_tb4.Text = lectura.GetString(28);
                        dh_tb5.Text = lectura.GetString(29);
                        dh_cb4.Text = lectura.GetString(30);


                        if (lectura.GetString(31).Equals("1"))
                            dh_chb1.Checked = true;
                        if (lectura.GetString(32).Equals("1"))
                            dh_chb2.Checked = true;


                        dh_tb7.Text = lectura.GetString(33);
                        dh_tb8.Text = lectura.GetString(34);

                        if (lectura.GetString(35).Equals("1"))
                            dh_chb4.Checked = true;
                        if (lectura.GetString(36).Equals("1"))
                            dh_chb5.Checked = true;
                        if (lectura.GetString(37).Equals("1"))
                            dh_chb6.Checked = true;
                        if (lectura.GetString(38).Equals("1"))
                            dh_chb7.Checked = true;
                        if (lectura.GetString(39).Equals("1"))
                            dh_chb8.Checked = true;

                        dh_tb9.Text = lectura.GetString(40);
                        dh_tb10.Text = lectura.GetString(41);

                        if (lectura.GetString(42).Equals("1"))
                            dh_chb9.Checked = true;
                        if (lectura.GetString(43).Equals("1"))
                            dh_chb10.Checked = true;
                        if (lectura.GetString(44).Equals("1"))
                            dh_chb11.Checked = true;
                        if (lectura.GetString(45).Equals("1"))
                            dh_chb12.Checked = true;
                        if (lectura.GetString(46).Equals("1"))
                            dh_chb38.Checked = true;
                        if (lectura.GetString(47).Equals("1"))
                            dh_chb13.Checked = true;
                        if (lectura.GetString(48).Equals("1"))
                            dh_chb14.Checked = true;
                        if (lectura.GetString(49).Equals("1"))
                            dh_chb16.Checked = true;

                        dh_tb11.Text = lectura.GetString(50);
                        dh_tb12.Text = lectura.GetString(51);
                        dh_tb13.Text = lectura.GetString(52);

                        if (lectura.GetString(53).Equals("1"))
                            dh_chb17.Checked = true;
                        if (lectura.GetString(54).Equals("1"))
                            dh_chb18.Checked = true;

                        dh_tb14.Text = lectura.GetString(55);
                        dh_tb15.Text = lectura.GetString(56);

                        if (lectura.GetString(57).Equals("1"))
                            dh_chb18.Checked = true;
                        if (lectura.GetString(58).Equals("1"))
                            dh_chb19.Checked = true;
                        if (lectura.GetString(59).Equals("1"))
                            dh_chb20.Checked = true;
                        if (lectura.GetString(60).Equals("1"))
                            dh_chb21.Checked = true;
                        if (lectura.GetString(61).Equals("1"))
                            dh_chb22.Checked = true;
                        if (lectura.GetString(62).Equals("1"))
                            dh_chb23.Checked = true;
                        if (lectura.GetString(63).Equals("1"))
                            dh_chb24.Checked = true;
                        if (lectura.GetString(64).Equals("1"))
                            dh_chb25.Checked = true;
                        if (lectura.GetString(65).Equals("1"))
                            dh_chb26.Checked = true;
                        if (lectura.GetString(66).Equals("1"))
                            dh_chb27.Checked = true;
                        if (lectura.GetString(67).Equals("1"))
                            dh_chb28.Checked = true;
                        if (lectura.GetString(68).Equals("1"))
                            dh_chb29.Checked = true;
                        if (lectura.GetString(69).Equals("1"))
                            dh_chb30.Checked = true;
                        if (lectura.GetString(70).Equals("1"))
                            dh_chb31.Checked = true;


                        dh_tb16.Text = lectura.GetString(71);

                        if (lectura.GetString(72).Equals("1"))
                            dh_chb32.Checked = true;
                        if (lectura.GetString(73).Equals("1"))
                            dh_chb33.Checked = true;
                        if (lectura.GetString(74).Equals("1"))
                            dh_chb34.Checked = true;
                        if (lectura.GetString(75).Equals("1"))
                            dh_chb35.Checked = true;
                        if (lectura.GetString(76).Equals("1"))
                            dh_chb36.Checked = true;
                        if (lectura.GetString(77).Equals("1"))
                            dh_chb37.Checked = true;

                        dh_tb17.Text = lectura.GetString(78);
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

        private void dh_accion_cambiada(object sender, EventArgs e)
        {
            MetroFramework.Controls.MetroRadioButton radio = sender as MetroFramework.Controls.MetroRadioButton;
            if (radio.Name.Equals("dh1_nuevo"))
            {
                //Sdh_Nomiembro.ReadOnly = true;
                dh_registrarbtn1.Enabled = true;
                dh_buscar1btn.Enabled = false;
                limpiar_desarrollo_humano1();
            }
            else if (radio.Name.Equals("dh1_modificar"))
            {
                dh_Nomiembro.ReadOnly = false;
                dh_registrarbtn1.Enabled = true;
                dh_buscar1btn.Enabled = true;
                dh_Nomiembro.Select();

            }
        }

        private void dh_registrarbtn2_Click(object sender, EventArgs e)
        {
            if (dh1_nuevo.Checked)
            {
                dh_guardar_datos();
            }
            else if (dh1_modificar.Checked)
            {
                dh_actualizar_datos();
            }
        }
    }
}
