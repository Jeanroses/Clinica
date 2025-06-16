namespace AppClinica.Formularios
{
    partial class frmAtenderPaciente
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
            txtBaja = new TextBox();
            txtMedia = new TextBox();
            txtUrgente = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            dgvDatos = new DataGridView();
            label2 = new Label();
            txtPaciente = new TextBox();
            label6 = new Label();
            btnAtender = new Button();
            btnCancelar = new Button();
            btnCerrar = new Button();
            txtEdad = new TextBox();
            groupBox2 = new GroupBox();
            txtSintomas = new TextBox();
            label7 = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDatos).BeginInit();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(315, 31);
            label1.Name = "label1";
            label1.Size = new Size(286, 31);
            label1.TabIndex = 0;
            label1.Text = "ATENCIÓN DE PACIENTES";
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.FromArgb(192, 255, 192);
            groupBox1.Controls.Add(txtBaja);
            groupBox1.Controls.Add(txtMedia);
            groupBox1.Controls.Add(txtUrgente);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(dgvDatos);
            groupBox1.Location = new Point(23, 78);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(451, 471);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Pacientes en cola";
            // 
            // txtBaja
            // 
            txtBaja.Location = new Point(148, 404);
            txtBaja.Name = "txtBaja";
            txtBaja.ReadOnly = true;
            txtBaja.Size = new Size(166, 38);
            txtBaja.TabIndex = 6;
            // 
            // txtMedia
            // 
            txtMedia.Location = new Point(150, 358);
            txtMedia.Name = "txtMedia";
            txtMedia.ReadOnly = true;
            txtMedia.Size = new Size(174, 38);
            txtMedia.TabIndex = 5;
            // 
            // txtUrgente
            // 
            txtUrgente.Location = new Point(150, 314);
            txtUrgente.Name = "txtUrgente";
            txtUrgente.ReadOnly = true;
            txtUrgente.Size = new Size(174, 38);
            txtUrgente.TabIndex = 4;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(76, 404);
            label5.Name = "label5";
            label5.Size = new Size(66, 31);
            label5.TabIndex = 3;
            label5.Text = "Baja:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(55, 361);
            label4.Name = "label4";
            label4.Size = new Size(87, 31);
            label4.TabIndex = 2;
            label4.Text = "Media:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(25, 312);
            label3.Name = "label3";
            label3.Size = new Size(117, 31);
            label3.TabIndex = 1;
            label3.Text = "Urgentes:";
            // 
            // dgvDatos
            // 
            dgvDatos.AllowUserToAddRows = false;
            dgvDatos.AllowUserToDeleteRows = false;
            dgvDatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDatos.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvDatos.Location = new Point(25, 37);
            dgvDatos.Name = "dgvDatos";
            dgvDatos.ReadOnly = true;
            dgvDatos.RowHeadersWidth = 51;
            dgvDatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDatos.Size = new Size(406, 257);
            dgvDatos.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(22, 63);
            label2.Name = "label2";
            label2.Size = new Size(110, 31);
            label2.TabIndex = 2;
            label2.Text = "Paciente:";
            // 
            // txtPaciente
            // 
            txtPaciente.Location = new Point(138, 60);
            txtPaciente.Name = "txtPaciente";
            txtPaciente.ReadOnly = true;
            txtPaciente.Size = new Size(326, 38);
            txtPaciente.TabIndex = 3;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(60, 120);
            label6.Name = "label6";
            label6.Size = new Size(72, 31);
            label6.TabIndex = 4;
            label6.Text = "Edad:";
            // 
            // btnAtender
            // 
            btnAtender.Location = new Point(22, 269);
            btnAtender.Name = "btnAtender";
            btnAtender.Size = new Size(118, 47);
            btnAtender.TabIndex = 5;
            btnAtender.Text = "Atender";
            btnAtender.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(179, 269);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(118, 47);
            btnCancelar.TabIndex = 6;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnCerrar
            // 
            btnCerrar.Location = new Point(346, 269);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(118, 47);
            btnCerrar.TabIndex = 7;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = true;
            // 
            // txtEdad
            // 
            txtEdad.Location = new Point(138, 117);
            txtEdad.Name = "txtEdad";
            txtEdad.ReadOnly = true;
            txtEdad.Size = new Size(63, 38);
            txtEdad.TabIndex = 8;
            // 
            // groupBox2
            // 
            groupBox2.BackColor = SystemColors.ActiveCaption;
            groupBox2.Controls.Add(txtSintomas);
            groupBox2.Controls.Add(btnCerrar);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(btnCancelar);
            groupBox2.Controls.Add(txtPaciente);
            groupBox2.Controls.Add(btnAtender);
            groupBox2.Controls.Add(txtEdad);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(label6);
            groupBox2.Location = new Point(502, 78);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(490, 375);
            groupBox2.TabIndex = 9;
            groupBox2.TabStop = false;
            groupBox2.Text = "Datos cita";
            // 
            // txtSintomas
            // 
            txtSintomas.Location = new Point(138, 168);
            txtSintomas.Name = "txtSintomas";
            txtSintomas.ReadOnly = true;
            txtSintomas.Size = new Size(326, 38);
            txtSintomas.TabIndex = 10;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 171);
            label7.Name = "label7";
            label7.Size = new Size(120, 31);
            label7.TabIndex = 9;
            label7.Text = "Sintomas:";
            // 
            // frmAtenderPaciente
            // 
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1020, 561);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Margin = new Padding(5);
            Name = "frmAtenderPaciente";
            Text = "frmAtenderPaciente";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDatos).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private GroupBox groupBox1;
        private Label label4;
        private Label label3;
        private DataGridView dgvDatos;
        private Label label2;
        private TextBox txtPaciente;
        private Label label5;
        private Label label6;
        private Button btnAtender;
        private Button btnCancelar;
        private Button btnCerrar;
        private TextBox txtEdad;
        private GroupBox groupBox2;
        private TextBox txtSintomas;
        private Label label7;
        private TextBox txtBaja;
        private TextBox txtMedia;
        private TextBox txtUrgente;
    }
}