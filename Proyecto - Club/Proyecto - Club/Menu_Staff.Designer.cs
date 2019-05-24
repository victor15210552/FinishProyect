namespace Proyecto___Club
{
    partial class Menu_Staff
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu_Staff));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.bajas_staff_btn = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(253, 38);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(52, 52);
            this.pictureBox1.TabIndex = 64;
            this.pictureBox1.TabStop = false;
            // 
            // metroButton1
            // 
            this.metroButton1.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.metroButton1.FontWeight = MetroFramework.MetroButtonWeight.Light;
            this.metroButton1.Location = new System.Drawing.Point(23, 129);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(282, 54);
            this.metroButton1.TabIndex = 65;
            this.metroButton1.Text = "Altas y Modificaciones";
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // bajas_staff_btn
            // 
            this.bajas_staff_btn.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.bajas_staff_btn.FontWeight = MetroFramework.MetroButtonWeight.Light;
            this.bajas_staff_btn.Location = new System.Drawing.Point(23, 213);
            this.bajas_staff_btn.Name = "bajas_staff_btn";
            this.bajas_staff_btn.Size = new System.Drawing.Size(282, 54);
            this.bajas_staff_btn.TabIndex = 66;
            this.bajas_staff_btn.Text = "Bajas";
            this.bajas_staff_btn.UseSelectable = true;
            this.bajas_staff_btn.Click += new System.EventHandler(this.bajas_staff_btn_Click);
            // 
            // Menu_Staff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 373);
            this.Controls.Add(this.bajas_staff_btn);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Menu_Staff";
            this.Text = "Staff ";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Menu_Staff_FormClosed_1);
            this.Load += new System.EventHandler(this.Menu_Staff_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroButton bajas_staff_btn;
    }
}