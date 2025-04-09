using ProcesoCRUD.Datos;
using ProcesoCRUD.Entidades;
using ProcesoCRUD.Presentacion.Reportes;
using System;
using System.Web;
using System.Windows.Forms;

namespace ProcesoCRUD.Presentacion
{
    public partial class Frm_Productos: Form
    {
        public Frm_Productos()
        {
            InitializeComponent();
        }
        #region
        int nEstadoGuarda = 0;
        int vCodigo_pr = 0;

        #endregion


        #region "Mis Metodos"
        private void LimpiaTexto()
        {
            txtDescripcion_pr.Text = "";
            txtMarca_pr.Text = "";
            txtStockActual.Text = "0.00";
            cmbCategorias.Text = "";
            cmbMedidas.Text = "";
        }
        private void EstadoTexto(bool lEstado)
        {
            txtDescripcion_pr.Enabled = lEstado;
            txtMarca_pr.Enabled = lEstado;
            txtStockActual.Enabled = lEstado;
            cmbCategorias.Enabled = lEstado;
            cmbMedidas.Enabled = lEstado;
        }
        private void EstadoBotones(bool lEstado)
        {
            btnCancelar.Visible = !lEstado;
            btnGuardar.Visible = !lEstado;

            btnNuevo.Enabled = lEstado;
            btnActualizar.Enabled = lEstado;
            btnEliminar.Enabled = lEstado;
            btnReporte.Enabled = lEstado;
            btnSalir.Enabled = lEstado;
            
            btnBuscar.Enabled = lEstado;
            txtBuscar.Enabled = lEstado;
            dgvListado.Enabled = lEstado;
        }
        private void Cargar_Medidas()
        {
            D_Productos Datos = new D_Productos();
            cmbMedidas.DataSource = Datos.Listado_me();
            cmbMedidas.ValueMember = "codigo_me";
            cmbMedidas.DisplayMember = "descripcion_me";
        }
        private void Cargar_Categorias()
        {
            D_Productos Datos = new D_Productos();
            cmbCategorias.DataSource = Datos.Listado_ca();
            cmbCategorias.ValueMember = "codigo_ca";
            cmbCategorias.DisplayMember = "descripcion_ca";
        }

        private void Formato_pr()
        {
            dgvListado.Columns[0].Width= 50;
            dgvListado.Columns[0].HeaderText = "C.Prod";
            dgvListado.Columns[1].Width = 150;
            dgvListado.Columns[1].HeaderText = "Producto";
            dgvListado.Columns[2].Width = 100;
            dgvListado.Columns[2].HeaderText = "Marca";
            dgvListado.Columns[3].Width = 100;
            dgvListado.Columns[3].HeaderText = "Medida";
            dgvListado.Columns[4].Width = 100;
            dgvListado.Columns[4].HeaderText = "Categoria";
            dgvListado.Columns[5].Width = 80;
            dgvListado.Columns[5].HeaderText = "Stock A.";

            dgvListado.Columns[6].Visible = false;
            dgvListado.Columns[6].HeaderText = "C.Medida";
            dgvListado.Columns[7].Visible = false;
            dgvListado.Columns[7].HeaderText = "C.Categoria";
        }

        private void Listado_pr(string cTexto)
        {
            D_Productos Datos = new D_Productos();
            dgvListado.DataSource = Datos.Listado_pr(cTexto);
            this.Formato_pr();
        }

        private void Seleccion_Item_pr()
        {
            if(string.IsNullOrEmpty(dgvListado.CurrentRow.Cells["codigo_pr"].Value.ToString()))
            {
                MessageBox.Show("Lista vacia",
                                "Aviso del Sistema",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
                return;
            }
            if (dgvListado.Rows.Count > 0)
            {
                vCodigo_pr = Convert.ToInt32(dgvListado.CurrentRow.Cells[0].Value);
                txtDescripcion_pr.Text = dgvListado.CurrentRow.Cells[1].Value.ToString();
                txtMarca_pr.Text = dgvListado.CurrentRow.Cells[2].Value.ToString();
                cmbMedidas.SelectedValue = Convert.ToInt32(dgvListado.CurrentRow.Cells[6].Value);
                cmbCategorias.SelectedValue = Convert.ToInt32(dgvListado.CurrentRow.Cells[7].Value);
                txtStockActual.Text = dgvListado.CurrentRow.Cells[5].Value.ToString();
            }

        }

        #endregion

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.nEstadoGuarda = 1; // Nuevo Registro
            this.vCodigo_pr = 0;
            this.LimpiaTexto();
            this.EstadoTexto(true);
            this.EstadoBotones(false);
            txtDescripcion_pr.Focus();
        }


        private void Frm_Productos_Load(object sender, EventArgs e)
        {
            this.Cargar_Medidas();
            this.Cargar_Categorias();
            this.Listado_pr("%");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {

            this.LimpiaTexto();
            // Este boton es para salir del programa
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.Listado_pr(txtBuscar.Text);
            txtBuscar.Text = "";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.LimpiaTexto();
            this.EstadoTexto(false);
            this.EstadoBotones(true);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(txtDescripcion_pr.Text == string.Empty)
            {
                MessageBox.Show("Ingrese la descripcion del producto",
                                "Aviso del Sistema", 
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
                txtDescripcion_pr.Focus();
                return;
            }
            if (txtMarca_pr.Text == string.Empty)
            {
                MessageBox.Show("Ingrese la marca del producto",
                                "Aviso del Sistema",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
                txtMarca_pr.Focus();
                return;
            }
            if (cmbMedidas.Text == string.Empty)
            {
                MessageBox.Show("Seleccione la medida del producto",
                                "Aviso del Sistema",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
                cmbMedidas.Focus();
                return;
            }
            if (cmbCategorias.Text == string.Empty)
            {
                MessageBox.Show("Seleccione la categoria del producto",
                                "Aviso del Sistema",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
                cmbCategorias.Focus();
                return;
            }
            if (txtStockActual.Text == string.Empty)
            {
                MessageBox.Show("Ingrese el stock actual del producto",
                                "Aviso del Sistema",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
                txtStockActual.Focus();
                return;
            }
            E_Productos oPro = new E_Productos();
            string Respuesta = "";
            oPro.Codigo_pr = this.vCodigo_pr;
            oPro.Descripcion_pr = txtDescripcion_pr.Text;
            oPro.Marca_pr = txtMarca_pr.Text;
            oPro.Codigo_me = Convert.ToInt32(cmbMedidas.SelectedValue);
            oPro.Codigo_ca = Convert.ToInt32(cmbCategorias.SelectedValue);
            oPro.Stock_actual = Convert.ToDecimal(txtStockActual.Text);

            D_Productos Datos = new D_Productos();
            Respuesta = Datos.Guardar_pr(this.nEstadoGuarda, oPro);
            if(Respuesta == "OK")
            {
                MessageBox.Show("Registro guardado con exito",
                                "Aviso del Sistema",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                this.Listado_pr("%");
                this.vCodigo_pr = 0;
                this.LimpiaTexto();
                this.EstadoTexto(false);
                this.EstadoBotones(true);
            }
            else
            {
                MessageBox.Show(Respuesta,
                                "Aviso del Sistema",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void dgvListado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Seleccion_Item_pr();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.nEstadoGuarda = 2; // Actualizar Registro
            this.EstadoTexto(true);
            this.EstadoBotones(false);
            txtDescripcion_pr.Focus();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if(dgvListado.Rows.Count <= 0
                || string.IsNullOrEmpty(Convert.ToString(dgvListado.CurrentRow.Cells["codigo_pr"].Value)))
            {
                MessageBox.Show("Lista vacia",
                                "Aviso del Sistema",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
                return;
            }
            if (vCodigo_pr == 0)
            {
                MessageBox.Show("Seleccione un producto",
                                "Aviso del Sistema",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
                return;
            }
            string Respuesta = "";
            D_Productos Datos = new D_Productos();
            Respuesta = Datos.Activo_pr(Convert.ToInt32(vCodigo_pr), false);
            if (Respuesta == "OK")
            {
                MessageBox.Show("Registro eliminado con exito",
                                "Aviso del Sistema",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                this.Listado_pr("%");
                this.vCodigo_pr = 0;
                this.LimpiaTexto();
            }
            else
            {
                MessageBox.Show(Respuesta,
                                "Aviso del Sistema",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            Frm_Rpt_Listado_pr oFrm_rpt = new Frm_Rpt_Listado_pr();
            oFrm_rpt.txt01.Text = txtBuscar.Text;
            oFrm_rpt.ShowDialog();
        }
    }
}
