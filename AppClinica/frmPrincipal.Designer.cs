namespace AppClinica
{
    partial class frmPrincipal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            menuStrip1 = new MenuStrip();
            mantenimientoToolStripMenuItem = new ToolStripMenuItem();
            registrarPacienteToolStripMenuItem = new ToolStripMenuItem();
            atenciónToolStripMenuItem = new ToolStripMenuItem();
            atenderPacienteToolStripMenuItem = new ToolStripMenuItem();
            pictureBox1 = new PictureBox();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { mantenimientoToolStripMenuItem, atenciónToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(932, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // mantenimientoToolStripMenuItem
            // 
            mantenimientoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { registrarPacienteToolStripMenuItem });
            mantenimientoToolStripMenuItem.Name = "mantenimientoToolStripMenuItem";
            mantenimientoToolStripMenuItem.Size = new Size(124, 24);
            mantenimientoToolStripMenuItem.Text = "Mantenimiento";
            // 
            // registrarPacienteToolStripMenuItem
            // 
            registrarPacienteToolStripMenuItem.Name = "registrarPacienteToolStripMenuItem";
            registrarPacienteToolStripMenuItem.Size = new Size(210, 26);
            registrarPacienteToolStripMenuItem.Text = "Registrar Paciente";
            registrarPacienteToolStripMenuItem.Click += registrarPacienteToolStripMenuItem_Click;
            // 
            // atenciónToolStripMenuItem
            // 
            atenciónToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { atenderPacienteToolStripMenuItem });
            atenciónToolStripMenuItem.Name = "atenciónToolStripMenuItem";
            atenciónToolStripMenuItem.Size = new Size(82, 24);
            atenciónToolStripMenuItem.Text = "Atención";
            // 
            // atenderPacienteToolStripMenuItem
            // 
            atenderPacienteToolStripMenuItem.Name = "atenderPacienteToolStripMenuItem";
            atenderPacienteToolStripMenuItem.Size = new Size(204, 26);
            atenderPacienteToolStripMenuItem.Text = "Atender Paciente";
            atenderPacienteToolStripMenuItem.Click += atenderPacienteToolStripMenuItem_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 31);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(932, 455);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // frmPrincipal
            // 
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(932, 483);
            Controls.Add(pictureBox1);
            Controls.Add(menuStrip1);
            Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(5);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmPrincipal";
            Load += frmPrincipal_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem mantenimientoToolStripMenuItem;
        private ToolStripMenuItem registrarPacienteToolStripMenuItem;
        private ToolStripMenuItem atenciónToolStripMenuItem;
        private ToolStripMenuItem atenderPacienteToolStripMenuItem;
        private PictureBox pictureBox1;
    }
}
