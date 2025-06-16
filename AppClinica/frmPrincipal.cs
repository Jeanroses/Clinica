using AppClinica.Formularios;

namespace AppClinica
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen; 

        }

        private void registrarPacienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRegistrarPaciente ventana = new FrmRegistrarPaciente();
            ventana.ShowDialog();
        }

        private void atenderPacienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAtenderPaciente frmAtenderPaciente = new frmAtenderPaciente();
            frmAtenderPaciente.ShowDialog();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {

        }
    }
}
