namespace AppClinica.Formularios
{
    partial class frmInforme
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
            dgvInforme = new DataGridView();
            btnCerrar = new Button();
            label2 = new Label();
            cboCitas = new ComboBox();
            btnMostrar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvInforme).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(335, 35);
            label1.Name = "label1";
            label1.Size = new Size(317, 31);
            label1.TabIndex = 0;
            label1.Text = "INFORMES SALA DE ESPERA";
            // 
            // dgvInforme
            // 
            dgvInforme.AllowUserToAddRows = false;
            dgvInforme.AllowUserToDeleteRows = false;
            dgvInforme.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvInforme.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInforme.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvInforme.Location = new Point(54, 144);
            dgvInforme.MultiSelect = false;
            dgvInforme.Name = "dgvInforme";
            dgvInforme.ReadOnly = true;
            dgvInforme.RowHeadersWidth = 51;
            dgvInforme.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvInforme.Size = new Size(822, 343);
            dgvInforme.TabIndex = 1;
            // 
            // btnCerrar
            // 
            btnCerrar.Location = new Point(908, 530);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(114, 43);
            btnCerrar.TabIndex = 2;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(64, 97);
            label2.Name = "label2";
            label2.Size = new Size(66, 31);
            label2.TabIndex = 3;
            label2.Text = "Citas";
            // 
            // cboCitas
            // 
            cboCitas.FormattingEnabled = true;
            cboCitas.Location = new Point(174, 96);
            cboCitas.Name = "cboCitas";
            cboCitas.Size = new Size(232, 39);
            cboCitas.TabIndex = 4;
            // 
            // btnMostrar
            // 
            btnMostrar.Location = new Point(444, 96);
            btnMostrar.Name = "btnMostrar";
            btnMostrar.Size = new Size(149, 39);
            btnMostrar.TabIndex = 5;
            btnMostrar.Text = "Mostrar";
            btnMostrar.UseVisualStyleBackColor = true;
            btnMostrar.Click += btnMostrar_Click;
            // 
            // frmInforme
            // 
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1058, 585);
            Controls.Add(btnMostrar);
            Controls.Add(cboCitas);
            Controls.Add(label2);
            Controls.Add(btnCerrar);
            Controls.Add(dgvInforme);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Margin = new Padding(5);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmInforme";
            Text = "frmInforme";
            Load += frmInforme_Load;
            ((System.ComponentModel.ISupportInitialize)dgvInforme).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView dgvInforme;
        private Button btnCerrar;
        private Label label2;
        private ComboBox cboCitas;
        private Button btnMostrar;
    }
}