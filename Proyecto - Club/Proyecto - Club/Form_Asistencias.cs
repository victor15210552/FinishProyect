using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Proyecto___Club
{
    public partial class Form_Asistencias : MetroFramework.Forms.MetroForm
    {
        cls_conexion miBD = new cls_conexion();
        Form form;

        DataTable dataTable = new DataTable();

        ArrayList no_miembros = new ArrayList();
        ArrayList entrada_miembro = new ArrayList();

        public Form_Asistencias()
        {
            InitializeComponent();
        }

        public Form_Asistencias(Form form)
        {
            this.form = form;
            InitializeComponent();
            no_miembro_registro.Select();
            traer_asistencias_sin_chequeo_salida();
        }

        private void Form_Asistencias_Load(object sender, EventArgs e)
        {

        }

        private void btn_registro_Click(object sender, EventArgs e)
        {
            //Horas completadas
            //select TIMEDIFF(now(), entrada), salida from asistencias where no_miembro = 2 and date(entrada) = date(now());select TIMEDIFF(now(), entrada), salida from asistencias where no_miembro = 2 and date(entrada) = date(now());select TIMEDIFF(now(), entrada), salida from asistencias where no_miembro = 2 and date(entrada) = date(now());select TIMEDIFF(now(), entrada), salida from asistencias where no_miembro = 2 and date(entrada) = date(now());

            //horas completadas del usuario
            //select SEC_TO_TIME( SUM( TIME_TO_SEC(horas_completadas) ) ) AS horas_usuario from asistencias;
            try
            {
                if (staff_activo(int.Parse(no_miembro_registro.Text)) == true)
                {
                    usuario_ya_registro_entrada(int.Parse(no_miembro_registro.Text));
                }
                //usuario_ya_registro_entrada(int.Parse(no_miembro_registro.Text));
            }
            catch (FormatException) { MessageBox.Show("Formato de entrada incorrecto."); }
            finally { no_miembro_registro.Select(); no_miembro_registro.Text = ""; }
        }

        private void btn_consulta_Click(object sender, EventArgs e)
        {
            try
            {
                // Limpiando datos de la tabla
                grid_resultado.Rows.Clear();
                dataTable.Clear();

                //Llenar la tabla
                MySqlCommand command = new MySqlCommand("select entrada, salida, horas_completadas, quien_modifico from asistencias where no_miembro =" + no_miembro_historial.Text + ";", miBD.conexion);

                MySqlDataAdapter sqlAdapter = new MySqlDataAdapter(command);

                sqlAdapter.Fill(dataTable);

                foreach (DataRow dr in dataTable.Rows)
                {
                    grid_resultado.Rows.Add(dr.ItemArray);
                }

                miBD.conexion.Close();
                sqlAdapter.Dispose();
            }
            catch (MySqlException) { MessageBox.Show("Error"); }
            catch (FormatException) { MessageBox.Show("Entrada incorrecta."); }
            finally
            {
                miBD.conexion.Close();
                get_total_horas();
                no_miembro_historial.Select();
                no_miembro_historial.Text = "";
            }
        }


        public bool staff_activo(int no_miembro)
        {
            try
            {
                miBD.conexion.Close();
                miBD.conexion.Open();

                MySqlCommand command = new MySqlCommand("select nombre, ap_paterno, ap_materno, estado from staff where no_miembro = " + no_miembro + ";", miBD.conexion);
                MySqlDataReader lectura;

                //Se ejecuta la lectura
                lectura = command.ExecuteReader();

                if (lectura.Read())
                {
                    if (lectura.GetString(3).Equals("0"))
                    {
                        MessageBox.Show("No se permitío registrar tu asistencia, ya que te encuentras inactivo en el sistema.");
                        return false;
                    }
                    else
                    {
                        DialogResult dialogResult = MessageBox.Show(lectura.GetString(0) + " " + lectura.GetString(1) + " " + lectura.GetString(1) + "\nEs correcto? ", "Eres tu?", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("No se registró la asistencia");
                            return false;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No se encontrarón resultados");
                    return false;
                }

                lectura.Close();
                miBD.conexion.Close();
            }

            catch (MySqlException) { return false; }
            catch (SqlNullValueException) { return false; }
            finally
            {
                miBD.conexion.Close();
            }
        }

        public void usuario_ya_registro_entrada(int no_miembro)
        {
            try
            {
                miBD.conexion.Close();
                miBD.conexion.Open();

                MySqlCommand command = new MySqlCommand("select entrada, salida from asistencias where no_miembro = " + no_miembro + " and date(entrada) = date(now()) and salida is null;", miBD.conexion);
                MySqlDataReader lectura;

                //Se ejecuta la lectura
                lectura = command.ExecuteReader();
                if (lectura.Read())
                {
                    //usuario ya registró su entrada anteriormente, ahora registrará su salida
                    registrar_salida(no_miembro);
                }
                else
                {
                    //usuario apenas registrará su entrada
                    registrar_entrada(no_miembro);
                }

                lectura.Close();
                miBD.conexion.Close();
            }

            catch (MySqlException) { }
            catch (SqlNullValueException) { }
            finally
            {
                miBD.conexion.Close();
            }
        }

        public void registrar_entrada(int no_miembro)
        {
            try
            {
                miBD.conexion.Close();

                MySqlCommand alta = new MySqlCommand("insert into asistencias(no_miembro, entrada) values (@no_miembro, now());", miBD.conexion);
                alta.Parameters.AddWithValue("no_miembro", no_miembro);
                miBD.conexion.Open();

                //Almacena si hubo filas guardadas
                int guardado = alta.ExecuteNonQuery();

                miBD.conexion.Close();

                if (guardado > 0)
                {
                    MessageBox.Show("Se ha guardado tu entrada.");
                }
                else
                {
                    MessageBox.Show("No se guardo la entradas");
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

        public void registrar_salida(int no_miembro)
        {
            try
            {
                //update asistencias set salida =  now(), horas_completadas = TIMEDIFF(now(), entrada) where no_miembro = 2 and date(entrada) = date(now());
                miBD.conexion.Close();

                string campos = "salida = now(), horas_completadas = TIMEDIFF(now(), entrada)";

                MySqlCommand alta = new MySqlCommand("update asistencias set " + campos + " where no_miembro = @no_miembro  and date(entrada) = date(now()) and salida is null;; ", miBD.conexion);

                alta.Parameters.AddWithValue("no_miembro", no_miembro);

                miBD.conexion.Open();
                int datos_actualizados = alta.ExecuteNonQuery();

                if (datos_actualizados > 0)
                {
                    MessageBox.Show("Se ha registrado la salida");
                }
                else
                {
                    MessageBox.Show("ocurrio un error al registrar la salida");
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


        public void get_total_horas()
        {
            try
            {
                miBD.conexion.Close();
                miBD.conexion.Open();

                MySqlCommand command = new MySqlCommand("select SEC_TO_TIME( SUM( TIME_TO_SEC(horas_completadas) ) ) AS horas_usuario from asistencias where no_miembro = " + no_miembro_historial.Text + ";", miBD.conexion);
                MySqlDataReader lectura;

                //Se ejecuta la lectura
                lectura = command.ExecuteReader();

                //Si existen registros que cumplen las condiciones
                if (lectura.Read())
                {
                    total_horas.Text = "Total de horas: " + lectura.GetString(0);
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

        public void traer_asistencias_sin_chequeo_salida()
        {
            //1. Traer el no_miembro y la fecha
            try
            {
                miBD.conexion.Close();
                miBD.conexion.Open();

                MySqlCommand command = new MySqlCommand("select no_miembro, DATE_FORMAT(entrada, '%Y-%m-%d %H:%i:%s') as entrada from asistencias where horas_completadas is null and date(entrada) <  date(now());", miBD.conexion);
                MySqlDataReader lectura;

                //Se ejecuta la lectura
                lectura = command.ExecuteReader();

                //Si existen registros que cumplen las condiciones
                while (lectura.Read())
                {
                    no_miembros.Add(lectura.GetInt32(0));
                    entrada_miembro.Add(lectura.GetString(1).ToString());
                }
                lectura.Close();
                miBD.conexion.Close();
            }
            catch (MySqlException me) { MessageBox.Show(me.Message); }
            catch (SqlNullValueException se) { MessageBox.Show(se.Message); }
            finally { miBD.conexion.Close(); }

            //2. Una vez obtenido las asistencias que no fueron cerradas, esta  las cerrará automaticamente
            for (int i = 0; i < no_miembros.Count; i++)
                guardar_asistencias_sin_chequeo_salida(int.Parse(no_miembros[i].ToString()), entrada_miembro[i].ToString());
        }

        public void guardar_asistencias_sin_chequeo_salida(int no_miembro, string entrada)
        {
            try
            {
                //Ejemplo:
                //update asistencias set salida = (select addtime(time("2018-05-21 11:02:31"), "04:00:00")), horas_completadas="04:00:00" where no_miembro = 2 and entrada="2018-05-21 11:02:31";
                miBD.conexion.Close();

                string horas_agregar = "04:00:00";
                string campos = "salida = (select addtime(time(@entrada), @horas_agregar)), horas_completadas = @horas_agregar, quien_modifico = 'Cerrado automáticamente por el sistema.'";

                MySqlCommand alta = new MySqlCommand("update asistencias set " + campos + " where no_miembro = @no_miembro and entrada=@entrada", miBD.conexion);

                alta.Parameters.AddWithValue("no_miembro", no_miembro);
                alta.Parameters.AddWithValue("entrada", entrada);
                alta.Parameters.AddWithValue("horas_agregar", horas_agregar);

                miBD.conexion.Open();
                int datos_actualizados = alta.ExecuteNonQuery();
                miBD.conexion.Close();
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Error: " + e.Message);
            }
            finally
            {
                miBD.conexion.Close();
            }
        }

        private void Form_Asistencias_FormClosed(object sender, FormClosedEventArgs e)
        {
            {
                try
                {
                    form.Show();
                }
                catch
                {

                    MessageBox.Show("Error: Utilice el constructor sobrecargado de la clase.");
                }
            }
        }
    }
}
