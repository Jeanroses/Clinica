namespace AppClinica.Formularios
{
    partial class FrmRegistrarPaciente
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
            label1 = new Label();
            groupBox1 = new GroupBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtNombres = new TextBox();
            txtEdad = new TextBox();
            txtSintoma = new TextBox();
            btnAgregar = new Button();
            btnNuevo = new Button();
            btnCerrar = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(227, 30);
            label1.Name = "label1";
            label1.Size = new Size(268, 31);
            label1.TabIndex = 0;
            label1.Text = "REGISTRO DE PACIENTE";
            // 
            // groupBox1
            // 
            groupBox1.BackColor = SystemColors.ActiveCaption;
            groupBox1.Controls.Add(btnCerrar);
            groupBox1.Controls.Add(btnNuevo);
            groupBox1.Controls.Add(btnAgregar);
            groupBox1.Controls.Add(txtSintoma);
            groupBox1.Controls.Add(txtEdad);
            groupBox1.Controls.Add(txtNombres);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(38, 74);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(614, 302);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Datos paciente";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(50, 60);
            label2.Name = "label2";
            label2.Size = new Size(118, 31);
            label2.TabIndex = 0;
            label2.Text = "Nombres:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(96, 118);
            label3.Name = "label3";
            label3.Size = new Size(72, 31);
            label3.TabIndex = 1;
            label3.Text = "Edad:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(48, 176);
            label4.Name = "label4";
            label4.Size = new Size(120, 31);
            label4.TabIndex = 2;
            label4.Text = "Sintomas:";
            // 
            // txtNombres
            // 
            txtNombres.Location = new Point(174, 60);
            txtNombres.Name = "txtNombres";
            txtNombres.Size = new Size(366, 38);
            txtNombres.TabIndex = 3;
            // 
            // txtEdad
            // 
            txtEdad.Location = new Point(174, 118);
            txtEdad.Name = "txtEdad";
            txtEdad.Size = new Size(84, 38);
            txtEdad.TabIndex = 4;
            // 
            // txtSintoma
            // 
            txtSintoma.Location = new Point(174, 176);
            txtSintoma.Name = "txtSintoma";
            txtSintoma.Size = new Size(366, 38);
            txtSintoma.TabIndex = 5;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(106, 238);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(115, 41);
            btnAgregar.TabIndex = 2;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(265, 238);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(115, 41);
            btnNuevo.TabIndex = 6;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            // 
            // btnCerrar
            // 
            btnCerrar.Location = new Point(425, 238);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(115, 41);
            btnCerrar.TabIndex = 7;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = true;
            // 
            // FrmRegistrarPaciente
            // 
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(727, 420);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Margin = new Padding(5);
            Name = "FrmRegistrarPaciente";
            Text = "FrmRegistrarPaciente";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private GroupBox groupBox1;
        private TextBox txtNombres;
        private Label label4;
        private Label label3;
        private Label label2;
        private TextBox txtSintoma;
        private TextBox txtEdad;
        private Button btnAgregar;
        private Button btnCerrar;
        private Button btnNuevo;
    }
}