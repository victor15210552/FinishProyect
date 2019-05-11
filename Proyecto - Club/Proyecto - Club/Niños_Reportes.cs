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
using System.Text.RegularExpressions;

namespace Proyecto___Club
{
    public partial class Niños_Reportes : MetroFramework.Forms.MetroForm
    {
        Niños_Menu menuNiños;
        cls_conexion miBD;
        DataTable dataTable = new DataTable();

        DateTime fecha = DateTime.Now;

        public Niños_Reportes(Niños_Menu menuNiños)
        {
            miBD = new cls_conexion();
            this.menuNiños = menuNiños;
            InitializeComponent();
            ocultar_paneles_busqueda();
        }
        private void cambio_filtro(object sender, EventArgs e)
        {
            ocultar_paneles_busqueda();
            MetroFramework.Controls.MetroComboBox combobox = sender as MetroFramework.Controls.MetroComboBox;

            if (combobox.Text.Equals("Miembro"))
            {
                panel_miembro.Visible = true;
                txt_no_miembro.Select();
            }
            else if (combobox.Text.Equals("Nombre"))
            {
                panel_nombre.Visible = true;
                txt_nombre.Select();
            }
            else if (combobox.Text.Equals("Apellido"))
            {
                panel_apellido.Visible = true;
                txt_apellido.Select();
            }
            else if (combobox.Text.Equals("Personalizado"))
            {
                panel_personalizado.Visible = true;
                cbox_color.Select();
            }
            limpiar_campos();
        }

        public void ocultar_paneles_busqueda()
        {
            panel_miembro.Visible = false;
            panel_nombre.Visible = false;
            panel_apellido.Visible = false;
            panel_personalizado.Visible = false;
        }

        public void limpiar_campos()
        {
            txt_no_miembro.Text = "";
            txt_nombre.Text = "";
            txt_edad_especifica.Text = "";
            txt_apellido.Text = "";

            cbox_color.Text = "";
            cbox_estado.Text = "";
            cbox_sexo.Text = "";
        }

        private void evento_edad(object sender, EventArgs e)
        {
            MetroFramework.Controls.MetroComboBox combobox = sender as MetroFramework.Controls.MetroComboBox;

            if (combobox.Text.Equals("Personalizado"))
            {
                txt_edad_especifica.Visible = true;
                txt_edad_especifica.Text = "";
                txt_edad_especifica.Select();
            }
            else
            {
                txt_edad_especifica.Visible = false;
                txt_edad_especifica.Text = "";
                cbox_sexo.Select();
            }
        }

        private void buscar_resultados(object sender, EventArgs e)
        {
            if (combo_filtro.Text.Equals("Miembro"))
            {
                busqueda_por_miembro();
            }
            else if (combo_filtro.Text.Equals("Nombre"))
            {
                busqueda_por_nombre();
            }
            else if (combo_filtro.Text.Equals("Apellido"))
            {
                busqueda_por_apellido();
            }
            else if (combo_filtro.Text.Equals("Personalizado"))
            {
                busqueda_por_personalizado();
            }
        }

        //-------------------Métodos de busqueda ---------------------------
        public void busqueda_por_miembro()
        {
            try
            {
                // Limpiando datos de la tabla
                grid_resultado.Rows.Clear();
                dataTable.Clear();

                //Llenar la tabla
                MySqlCommand command = new MySqlCommand("select no_miembro, nombres, ap_paterno, ap_materno, DATE_FORMAT(fecha_nac,'%Y-%M-%d'), DATE_FORMAT(fecha_inscripcion,'%Y-%M-%d'), estado from ninos_datos where no_miembro  LIKE '%" + txt_no_miembro.Text + "%';", miBD.conexion);
                metroTextBox1.Text = command.CommandText;
                MySqlDataAdapter sqlAdapter = new MySqlDataAdapter(command);

                sqlAdapter.Fill(dataTable);

                foreach (DataRow dr in dataTable.Rows)
                {
                    grid_resultado.Rows.Add(dr.ItemArray);
                }

                miBD.conexion.Close();
                sqlAdapter.Dispose();
            }
            catch (MySqlException) { }
            finally { miBD.conexion.Close(); }
        }
        public void busqueda_por_nombre()
        {
            try
            {
                // Limpiando datos de la tabla
                grid_resultado.Rows.Clear();
                dataTable.Clear();

                //Llenar la tabla
                MySqlCommand command = new MySqlCommand("select no_miembro, nombres, ap_paterno, ap_materno, DATE_FORMAT(fecha_nac,'%Y-%M-%d'), DATE_FORMAT(fecha_inscripcion,'%Y-%M-%d'), estado from ninos_datos where nombres  LIKE '%" + txt_nombre.Text + "%';", miBD.conexion);
                metroTextBox1.Text = command.CommandText;

                MySqlDataAdapter sqlAdapter = new MySqlDataAdapter(command);

                sqlAdapter.Fill(dataTable);

                foreach (DataRow dr in dataTable.Rows)
                {
                    grid_resultado.Rows.Add(dr.ItemArray);
                }

                miBD.conexion.Close();
                sqlAdapter.Dispose();
            }
            catch (MySqlException) { }
            finally { miBD.conexion.Close(); }
        }
        public void busqueda_por_apellido()
        {
            try
            {
                // Limpiando datos de la tabla
                grid_resultado.Rows.Clear();
                dataTable.Clear();

                //Llenar la tabla
                MySqlCommand command = new MySqlCommand("select no_miembro, nombres, ap_paterno, ap_materno, DATE_FORMAT(fecha_nac,'%Y-%M-%d'), DATE_FORMAT(fecha_inscripcion,'%Y-%M-%d'), estado from ninos_datos where ap_paterno  LIKE '%" + txt_apellido.Text + "%';", miBD.conexion);
                metroTextBox1.Text = command.CommandText;
                MySqlDataAdapter sqlAdapter = new MySqlDataAdapter(command);

                sqlAdapter.Fill(dataTable);

                foreach (DataRow dr in dataTable.Rows)
                {
                    grid_resultado.Rows.Add(dr.ItemArray);
                }

                miBD.conexion.Close();
                sqlAdapter.Dispose();
            }
            catch (MySqlException) { }
            finally { miBD.conexion.Close(); }
        }
        public void busqueda_por_personalizado()
        {
            if (eleccion_color() == "")
            {
                MessageBox.Show("Selecciona un color. Sí elegiste la opción personalizado agrega la información");
                return;
            }
            if (eleccion_sexo() == "")
            {
                MessageBox.Show("Selecciona un sexo");
                return;
            }
            if (eleccion_estado() == "")
            {
                MessageBox.Show("Selecciona un estado");
                return;
            }
            if (eleccion_nacionalidad() == "")
            {
                MessageBox.Show("Selecciona una nacionalidad");
                return;
            }

            try
            {
                // Limpiando datos de la tabla
                grid_resultado.Rows.Clear();
                dataTable.Clear();
                string query = "select no_miembro, nombres, ap_paterno, ap_materno, DATE_FORMAT(fecha_nac,'%Y-%M-%d'), DATE_FORMAT(fecha_inscripcion,'%Y-%M-%d'), estado from ninos_datos where " + eleccion_color() + eleccion_sexo() + eleccion_estado() + eleccion_nacionalidad() + ";";
                metroTextBox1.Text = query;
                //Llenar la tabla
                MySqlCommand command = new MySqlCommand(query, miBD.conexion);

                MySqlDataAdapter sqlAdapter = new MySqlDataAdapter(command);

                sqlAdapter.Fill(dataTable);

                foreach (DataRow dr in dataTable.Rows)
                {
                    grid_resultado.Rows.Add(dr.ItemArray);
                }

                miBD.conexion.Close();
                sqlAdapter.Dispose();
            }
            catch (MySqlException) { }
            finally { miBD.conexion.Close(); }
        }

        //busqueda por el keypress para cada caja
        private void cambio_texto_miembro(object sender, EventArgs e)
        {
            busqueda_por_miembro();
        }

        private void cambio_texto_nombre(object sender, EventArgs e)
        {
            busqueda_por_nombre();
        }

        private void cambio_texto_apellido(object sender, EventArgs e)
        {
            busqueda_por_apellido();
        }

        //busqueda en filtro personalizado
        public string eleccion_color()
        {
            int año_actual = int.Parse(fecha.ToString("yyyy"));
            if (cbox_color.Text.Equals("6-7(Rojos)"))
            {
                return "(year(fecha_nac) >= " + (año_actual - 7) + " AND year(fecha_nac) <=" + (año_actual - 6) + ") ";
            }
            else if (cbox_color.Text.Equals("8-10(Verdes)"))
            {
                return "(year(fecha_nac) >= " + (año_actual - 10) + " AND year(fecha_nac) <=" + (año_actual - 8) + ") ";
            }
            else if (cbox_color.Text.Equals("11-13(Azules)"))
            {
                return "(year(fecha_nac) >= " + (año_actual - 13) + " AND year(fecha_nac) <=" + (año_actual - 11) + ") ";
            }
            else if (cbox_color.Text.Equals("14-16(Naranjas)"))
            {
                return "(year(fecha_nac) >= " + (año_actual - 16) + " AND year(fecha_nac) <=" + (año_actual - 14) + ") ";
            }
            else if (cbox_color.Text.Equals("Personalizado"))
            {
                try
                {
                    string[] valores = Regex.Split(txt_edad_especifica.Text, @" ");

                    string consulta = "(";
                    int pos = 0;
                    foreach (var valor in valores)
                    {
                        if (pos == 0)
                        {
                            consulta += "year(fecha_nac) = " + (año_actual - int.Parse(valor));
                            pos = 1;
                        }
                        else
                        {
                            consulta += " OR year(fecha_nac) = " + (año_actual - int.Parse(valor));
                        }
                    }

                    consulta += ")";
                    return consulta;
                }
                catch (FormatException) { MessageBox.Show("Las edades especificadas no cumplen con el formato correcto\nej:8,10,12"); return ""; }
            }
            else if (cbox_color.Text.Equals("Todos"))
            {
                return "(fecha_nac = fecha_nac)";
            }
            else
            {
                return "";
            }

        }

        public string eleccion_sexo()
        {
            if (cbox_sexo.Text.Equals("Niños"))
            {
                return " AND (sexo = 'Masculino')";
            }
            if (cbox_sexo.Text.Equals("Niñas"))
            {
                return " AND (sexo = 'Femenino')";
            }
            if (cbox_sexo.Text.Equals("Todos"))
            {
                return " AND (sexo = sexo)";
            }
            else
            {
                return "";
            }
        }

        public string eleccion_estado()
        {
            if (cbox_estado.Text.Equals("Activo"))
            {
                return " AND (estado = '1')";
            }
            else if (cbox_estado.Text.Equals("Inactivo"))
            {
                return " AND (estado = '0')";
            }
            else if (cbox_estado.Text.Equals("Todos"))
            {
                return " AND (estado = estado)";
            }
            else
            {
                return "";
            }
        }

        public string eleccion_nacionalidad()
        {
            if (cbox_nacionalidad.Text.Equals("Mexicano(a)"))
            {
                return " AND (nacionalidad = 'Mexicano(a)')";
            }
            else if (cbox_nacionalidad.Text.Equals("Extranjero(a)"))
            {
                return " AND (nacionalidad = 'Extranjero(a)')";
            }
            else if (cbox_nacionalidad.Text.Equals("Todos"))
            {
                return " AND (nacionalidad = nacionalidad)";
            }
            else
            {
                return "";
            }
        }

        private void Niños_Reportes_Load(object sender, EventArgs e)
        {

        }



        private void Niños_Reportes_FormClosed(object sender, FormClosedEventArgs e)
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

        private void btn_reporte_Click(object sender, EventArgs e)
        {
            String noMiembro = "";
            // Niños_Reportes2 reportes;
            noMiembro = Convert.ToString(grid_resultado.SelectedRows[0].Cells[0].Value);

            Director director = new Director();

            Builder reporteBuilder = new ReporteBuilder();



            try
            {
                if (rb_completo.Checked)
                {
                    director.Construct(reporteBuilder, metroTextBox1.Text, "Completo");

                    //  reportes = new Niños_Reportes2(this, metroTextBox1.Text);
                }
                else
                {  //De lo contrario es individual

                    director.Construct(reporteBuilder, noMiembro, "Individual");
                    // reportes = new Niños_Reportes2(this, noMiembro);

                }

                Reporte r1 = reporteBuilder.GetResult();
                this.Hide();
                r1.crear(this);


                // reportes.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se a podido generar el reporte. " + ex.ToString());

            }



        }

    }
}
