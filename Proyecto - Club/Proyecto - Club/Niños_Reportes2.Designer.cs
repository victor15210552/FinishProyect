namespace Proyecto___Club
{
    partial class Niños_Reportes2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.PatronesDataSet = new System.Data.DataSet();
            ((System.ComponentModel.ISupportInitialize)(this.PatronesDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Proyecto___Club.Report2.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(11, 63);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(903, 443);
            this.reportViewer1.TabIndex = 71;
            // 
            // PatronesDataSet
            // 
            this.PatronesDataSet.DataSetName = "DataSet1";
            // 
            // Niños_Reportes2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(937, 529);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Niños_Reportes2";
            this.Text = "Reportes";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Niños_Reportes2_FormClosed);
            this.Load += new System.EventHandler(this.Niños_Reportes2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PatronesDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Data.DataSet PatronesDataSet;
    }
}