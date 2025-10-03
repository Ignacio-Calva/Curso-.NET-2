using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AplicacionEscritorio.Properties;
using Dominio;
using Negocio;

namespace AplicacionEscritorio
{
    public partial class formPrincipal : Form
    {
        List<Articulos> listaArt = new List<Articulos>();
        public formPrincipal()
        {
            InitializeComponent();
            cargarDgv();
            cargarComboBox();

        }
        public void cargarDgv()
        {
            //La lista esta declarada como un atributo
            ArticuloNegocio negocioArt = new Negocio.ArticuloNegocio();
            listaArt = negocioArt.listarArticulos();
            dgvProductos.DataSource = listaArt;
            dataGridView.formatoDgv(dgvProductos);
            ocultarColumnas();
            cargarImagen(listaArt[0].UrlImagen);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarArticulo ventana = new AgregarArticulo();
            ventana.ShowDialog();
            cargarDgv(); //Recargo la DGV para tenerla actualizada al haber agregado un articulo
        }


        private void dgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            Articulos aux = new Articulos();
            if (dgvProductos.CurrentRow != null)
            {
                aux = (Articulos)dgvProductos.CurrentRow.DataBoundItem;
                cargarImagen(aux.UrlImagen);
            }
            else
            {
                cargarImagen("https://imgs.search.brave.com/GoFaUzcpoaWIfsGMqByaylLvtEKMbDzzW-hC7myjZ_o/rs:fit:860:0:0:0/g:ce/aHR0cHM6Ly93d3cu/c2h1dHRlcnN0b2Nr/LmNvbS9pbWFnZS12/ZWN0b3IvZGVmYXVs/dC11aS1pbWFnZS1w/bGFjZWhvbGRlci13/aXJlZnJhbWVzLTI2/MG53LTEwMzc3MTkx/OTIuanBn");
            }
        }

        private void cargarImagen(string urlImagen)
        {
            try
            {
                pbxArticulo.Load(urlImagen);
            }
            catch
            {
                pbxArticulo.Load("https://imgs.search.brave.com/GoFaUzcpoaWIfsGMqByaylLvtEKMbDzzW-hC7myjZ_o/rs:fit:860:0:0:0/g:ce/aHR0cHM6Ly93d3cu/c2h1dHRlcnN0b2Nr/LmNvbS9pbWFnZS12/ZWN0b3IvZGVmYXVs/dC11aS1pbWFnZS1w/bGFjZWhvbGRlci13/aXJlZnJhbWVzLTI2/MG53LTEwMzc3MTkx/OTIuanBn");
            }
        }


        private void btnModificar_Click(object sender, EventArgs e)
        {
            Articulos articuloSeleccionado = new Articulos();
            articuloSeleccionado = (Articulos)dgvProductos.CurrentRow.DataBoundItem;
            AgregarArticulo modificar = new AgregarArticulo(articuloSeleccionado);
            modificar.ShowDialog();
            cargarDgv();
            ocultarColumnas();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            Articulos seleccionado;
            try
            {
                DialogResult eleccion;
                eleccion = MessageBox.Show("Estas seguro que deseas eliminar el articulo?", "ATENCION", MessageBoxButtons.YesNo);
                if (eleccion == DialogResult.Yes)
                {
                    seleccionado = (Articulos)dgvProductos.CurrentRow.DataBoundItem;
                    negocio.eliminarArticulos(seleccionado);
                    cargarDgv();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        //Para validar seleccion
        private bool soloNumeros(string texto)
        {
            foreach (char caracter in texto)
            {
                if ((!char.IsNumber(caracter)) && !(char.IsPunctuation(caracter)))
                {
                    return false;
                }
            }
            return true;
        }
        private bool contieneComa(string texto)
        {
            foreach (char caracter in texto)
            {
                if (caracter == ',')
                {
                    return false;
                }
            }
            return true;
        }
        private bool filtroSeleccionado()
        {
            if (cbxCampo.SelectedIndex < 0)
            {
                MessageBox.Show("Por favor seleccione un filtro.", "Atencion", MessageBoxButtons.OK);
                return false;
            }
            else if (string.IsNullOrEmpty(tbxValor.Text))
            {
                MessageBox.Show("Por favor escriba el filtro deseado.", "Atencion", MessageBoxButtons.OK);
                return false;
            }
            //Para precio especificamente
            if (cbxCampo.SelectedItem.ToString() == "Precio")
            {
                if (!(soloNumeros(tbxValor.Text.Trim()))) //Si no se cumple, contiene alguna letra
                {
                    MessageBox.Show("Solo puede ingresar numeros para este filtro.", "Atencion", MessageBoxButtons.OK);
                    return false;
                }
                else if (!contieneComa(tbxValor.Text.Trim()))
                {
                    MessageBox.Show("Por favor, separe los decimales con un punto (.).", "Atencion", MessageBoxButtons.OK);
                    return false;
                }
            }
            return true;
        }
        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            if (!filtroSeleccionado()) return; //Reviso que haya algun campo seleccionado
            ArticuloNegocio negocio = new ArticuloNegocio();
            string campo = cbxCampo.SelectedItem.ToString();
            string criterio = cbxCriterio.SelectedItem.ToString();
            string filtro = tbxValor.Text;
            listaArt = negocio.filtrarArticulos(campo, criterio, filtro);
            dgvProductos.DataSource = null;
            dgvProductos.DataSource = listaArt;
            ocultarColumnas();
        }
        private void ocultarColumnas()
        {
            dgvProductos.Columns["UrlImagen"].Visible = false;
            dgvProductos.Columns["IdArticulo"].Visible = false;
            dgvProductos.Columns["Codigo"].Visible = false;
            dgvProductos.Columns["Descripcion"].Visible = false;
        }

        private void tbxFiltro_TextChanged(object sender, EventArgs e)
        {
            List<Articulos> listaFiltrada;
            string filtro = tbxFiltro.Text;
            try
            {
                if (filtro.Length >= 3)
                {
                    listaFiltrada = listaArt.FindAll(Articulo => Articulo.Nombre.ToUpper().Contains(filtro.ToUpper()));
                }
                else
                {
                    listaFiltrada = listaArt;
                }
                dgvProductos.DataSource = null;
                dgvProductos.DataSource = listaFiltrada;
                ocultarColumnas();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void cargarComboBox()
        {
            ///CAMPO
            cbxCampo.Items.Add("Codigo");
            cbxCampo.Items.Add("Nombre");
            cbxCampo.Items.Add("Descripcion");
            cbxCampo.Items.Add("Marca");
            cbxCampo.Items.Add("Categoria");
            cbxCampo.Items.Add("Precio");
        }

        private void cbxCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbxCampo.SelectedIndex == -1) return; //Por si estoy usando el boton de limpiar filtros
                                                          //CARGAR CBX CRITERIO
                if (cbxCampo.SelectedItem.ToString() == "Precio")
                {
                    cbxCriterio.Items.Clear();
                    cbxCriterio.Items.Add("Mayor a");
                    cbxCriterio.Items.Add("Menor a");
                    cbxCriterio.Items.Add("Igual a");
                    cbxCriterio.SelectedItem = "Igual a";
                }
                else
                {
                    cbxCriterio.Items.Clear();
                    cbxCriterio.Items.Add("Comienza con");
                    cbxCriterio.Items.Add("Termina con");
                    cbxCriterio.Items.Add("Contiene");
                    cbxCriterio.SelectedItem = "Contiene";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void btnLimpiarFiltro_Click(object sender, EventArgs e)
        {
            cargarDgv();
            cbxCampo.SelectedIndex = -1;
            cbxCriterio.SelectedIndex = -1;
            tbxValor.Text = string.Empty;
        }

        private void dgvProductos_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
           e.Cancel = true;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMax_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal) {
                WindowState = FormWindowState.Maximized;
            }
            else if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        //PARA MOVER LA VENTANA DESDE EL PANEL
        private int clickX, clickY;

        private void pnlBotones_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                clickX = e.X;
                clickY = e.Y;
            }
            else
            {
                this.Left = this.Left + (e.X - clickX);
                this.Top = this.Top + (e.Y - clickY);
            }
        }
        private void btnDetalle_Click(object sender, EventArgs e)
        {
            Articulos articuloSeleccionado = new Articulos();
            articuloSeleccionado = (Articulos)dgvProductos.CurrentRow.DataBoundItem;
            VerDetalle ventanaDetalle = new VerDetalle(articuloSeleccionado);
            ventanaDetalle.ShowDialog();
            cargarDgv();
            ocultarColumnas();
        }
    }
}
