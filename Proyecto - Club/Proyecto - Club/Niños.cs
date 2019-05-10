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
        
        public Niños(Niños_Menu menuNiños)
        { 
         
        }

        private void Niños_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void solo_numeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        //-------------------- INICIO Métodos para limpiar campos--------------------
        public void limpiar_datos_generales()
        {
            
        }

        public void limpiar_datos_socioeconomicos()
        {
        }

        public void limpiar_datos_nucleoFamiliar()
        {

            
        }

        public void limpiar_datos_datosMedicos()
        {
            
        }

        public void limpiar_desarrollo_humano1()
        {
            
        }
        
        public void obtener_ultimo_miembro(string tabla, string identificador, MetroFramework.Controls.MetroTextBox TextBox)
        {
        }

        public void guardar_miembro()
        {
            
        }

        
        private void dg_accion_cambiada(object sender, EventArgs e)
        {
        }

        private void dg_btn_guardar_Click(object sender, EventArgs e)
        {
          
        }

        public void dg_guardar_datos_generales()
        {
           
        }

        public void dg_actualizar_datos_generales()
        {
           
        }

        private void dg_btnbuscar(object sender, EventArgs e)
        {
            
        }

        private void dg_btnFoto_Click(object sender, EventArgs e)
        {
           
        }

        private void fecha_nacimiento_seleccionaa(object sender, EventArgs e)
        {
            
        }

        

        private void es_accion_cambiada(object sender, EventArgs e)
        {
            
        }

        private void es_btn_guardar_datos_Click(object sender, EventArgs e)
        {
           
        }

        public void es_guardar_datos_socioeconomicos()
        {
           
        }

        public void es_actualizar_datos_socioeconomicos()
        {
           
        }

        private void es_btn_buscar_Click(object sender, EventArgs e)
        {
            
        }

        private void calcular_gastos_mensuales(object sender, EventArgs e)
        {
            
        }


        

      

        public void establecer_valores_nucleo_familiar(int valor , String cadena)
        {

            




            


        }


        private void nf_bt1_Click(object sender, EventArgs e)
        {
           
     
        }

        private void nf_bt2_Click(object sender, EventArgs e)
        {


            

        }


        public void nf_guardar_datos_nucleoFamiliar() {




        }

        public void nf_actualizar_datos_nucleoFamiliar() {


           

            
        }

        
        private void dm_bt1_Click(object sender, EventArgs e)
        {
        }

        private void es_noMiembro_Click(object sender, EventArgs e)
        {

        }

        private void Niños_Load(object sender, EventArgs e)
        {

        }

        private void nf_modificar_CheckedChanged(object sender, EventArgs e)
        {
            


           
        }


        private void dm_modificar_CheckedChanged(object sender, EventArgs e)
        {
          
        }

        private void nf_dt1_ValueChanged(object sender, EventArgs e)
        {
            
           
        }

        private void nf_dt2_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void dm_cambio_en_los_checkBox(object sender, EventArgs e)
        {



        

        }

        private void nf_buscar_Click(object sender, EventArgs e)
        {

            

                  
                   
           
        }

        

        public void dh_guardar_datos()
        {
            
        }
        public void dh_actualizar_datos()
        {
            

                

                

        }

        private void dh_buscar1btn_Click(object sender, EventArgs e)
        {
                
        }

        private void dh_accion_cambiada(object sender, EventArgs e)
        {
           

            
        }

        private void dh_registrarbtn2_Click(object sender, EventArgs e)
        {
           
        }
    }
}
