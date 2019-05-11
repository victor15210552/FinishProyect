using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using MySql.Data.MySqlClient;
using System.Data.SqlTypes;

namespace Proyecto___Club
{
    public partial class Niños_Reportes2 : MetroFramework.Forms.MetroForm
    {
        ReportDataSource dataSource;
        Niños_Reportes objNiñosReportes;
        String comando;
        String tipo;

        public Niños_Reportes2()
        {
            InitializeComponent();
        }

        public Niños_Reportes2(Niños_Reportes objNiñosReportes, string comando, string tipo)
        {
            this.objNiñosReportes = objNiñosReportes;
            this.comando = comando;
            this.tipo = tipo;
            InitializeComponent();
            if (tipo == "Completo")
            {
                this.comando = "select * " + comando.Substring(136);
            }
        }


        private void Niños_Reportes2_Load(object sender, EventArgs e)
        {
            if (tipo == "Individual")
            {

                reporteIndividual();

            }
            else if (tipo == "Completo")
            {

                reporteCompleto();
            }




        }

        private void Niños_Reportes2_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                objNiñosReportes.Show();
            }
            catch
            {

                MessageBox.Show("Error: Utilice el constructor sobrecargado de la clase.");
            }
        }

        public void reporteIndividual()
        {


            cls_conexion miBD = new cls_conexion();

            MySqlCommand consulta = new MySqlCommand("select * from ninos_datos where no_miembro = " + comando + " ;", miBD.conexion); //no_miembro, nombres, ap_paterno, ap_materno, fecha_nac, sexo
            miBD.conexion.Open();

            DataTable dt = new DataTable();
            // dt.Load(consulta.ExecuteReader());

            MySqlDataAdapter sqlAdapter = new MySqlDataAdapter(consulta);

            sqlAdapter.Fill(dt);

            MySqlDataReader lectura;

            //Se ejecuta la lectura
            lectura = consulta.ExecuteReader();
            if (lectura.Read())
            {
                ReportParameter no_miembro = new ReportParameter("no_miembro", lectura.GetString(0));
                ReportParameter nombres = new ReportParameter("nombres", lectura.GetString(1));
                ReportParameter paterno = new ReportParameter("ap_paterno", lectura.GetString(2));
                ReportParameter materno = new ReportParameter("ap_materno", lectura.GetString(3));
                ReportParameter nacimiento = new ReportParameter("fecha_nac", lectura.GetString(4));
                ReportParameter lugar_nac = new ReportParameter("lugar_nac", lectura.GetString(5));
                ReportParameter nacionalidad = new ReportParameter("nacionalidad", lectura.GetString(6));
                ReportParameter sexo = new ReportParameter("sexo", lectura.GetString(7));
                ReportParameter vive_con = new ReportParameter("vive_con", lectura.GetString(8));
                ReportParameter telefono = new ReportParameter("telefono", lectura.GetString(9));
                ReportParameter dom_calle = new ReportParameter("dom_calle", lectura.GetString(10));
                ReportParameter dom_numero = new ReportParameter("dom_numero", lectura.GetString(11));
                ReportParameter dom_colonia = new ReportParameter("dom_colonia", lectura.GetString(12));
                ReportParameter dom_codpost = new ReportParameter("dom_codpost", lectura.GetString(13));
                ReportParameter dom_delegacion = new ReportParameter("dom_delegacion", lectura.GetString(14));
                ReportParameter dom_municipio = new ReportParameter("dom_municipio", lectura.GetString(15));
                ReportParameter escuela = new ReportParameter("escuela", lectura.GetString(16));
                ReportParameter esc_turno = new ReportParameter("esc_turno", lectura.GetString(17));
                ReportParameter recoge1_nino = new ReportParameter("recoge1_nino", lectura.GetString(18));
                ReportParameter parent_recoge1 = new ReportParameter("parent_recoge1", lectura.GetString(19));
                ReportParameter recoge2_nino = new ReportParameter("recoge2_nino", lectura.GetString(20));
                ReportParameter parent_recoge2 = new ReportParameter("parent_recoge2", lectura.GetString(21));
                ReportParameter recoge3_nino = new ReportParameter("recoge3_nino", lectura.GetString(22));
                ReportParameter parent_recoge3 = new ReportParameter("parent_recoge3", lectura.GetString(23));
                ReportParameter aviso_emergencia1 = new ReportParameter("aviso_emergencia1", lectura.GetString(24));
                ReportParameter aviso_emergencia2 = new ReportParameter("aviso_emergencia2", lectura.GetString(25));
                ReportParameter aviso_emergencia3 = new ReportParameter("aviso_emergencia3", lectura.GetString(26));
                ReportParameter fecha_inscripcion = new ReportParameter("fecha_inscripcion", lectura.GetString(27));
                ReportParameter estado = new ReportParameter("estado", lectura.GetString(28));
                ReportParameter imss = new ReportParameter("imss", lectura.GetString(29));
                ReportParameter isste = new ReportParameter("isste", lectura.GetString(30));
                ReportParameter isstecali = new ReportParameter("isstecali", lectura.GetString(31));
                ReportParameter seguro_popular = new ReportParameter("seguro_popular", lectura.GetString(32));
                ReportParameter particular = new ReportParameter("particular", lectura.GetString(33));

                this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { no_miembro, nombres, paterno, materno, nacimiento,lugar_nac, nacionalidad, sexo,vive_con, telefono, dom_calle, dom_numero, dom_colonia,
                    dom_codpost, dom_delegacion, dom_municipio, escuela, esc_turno,recoge1_nino, parent_recoge1, recoge2_nino, parent_recoge2, recoge3_nino, parent_recoge3,
                    aviso_emergencia1, aviso_emergencia2 , aviso_emergencia3, fecha_inscripcion, estado,imss, isste, isstecali, seguro_popular, particular   });
            }


            miBD.conexion.Close();
            ReportDataSource rprtDTSource = new ReportDataSource();

            rprtDTSource.Name = "DataSet1";

            rprtDTSource.Value = dt;

            this.reportViewer1.RefreshReport();



        }

        public void reporteCompleto()
        {
            reportViewer1.LocalReport.ReportPath = "Report1.rdlc";

            cls_conexion miBD = new cls_conexion();

            MySqlCommand consulta = new MySqlCommand(this.comando, miBD.conexion); //no_miembro, nombres, ap_paterno, ap_materno, fecha_nac, sexo
            miBD.conexion.Open();

            MySqlDataAdapter sqlAdapter = new MySqlDataAdapter(consulta);

            DataTable dt = new DataTable();

            sqlAdapter.Fill(dt);

            dt.TableName = "DataSet1";

            dataSource = new ReportDataSource(dt.TableName, dt);

            this.reportViewer1.LocalReport.DataSources.Add(dataSource);
            this.reportViewer1.RefreshReport();


            reportViewer1.LocalReport.Refresh();

        }

    }

}