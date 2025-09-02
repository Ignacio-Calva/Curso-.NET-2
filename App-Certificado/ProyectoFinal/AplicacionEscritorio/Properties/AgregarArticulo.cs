using Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;

namespace AplicacionEscritorio.Properties
{
    public partial class AgregarArticulo : Form
    {
        public AgregarArticulo()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Articulos objeto = new Articulos();
            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
                objeto.Codigo = tbxCodigo.Text;
                objeto.Nombre = tbxNombre.Text;
                objeto.Descripcion = tbxDescripcion.Text;
                negocio.agregarArticulo(objeto);
                MessageBox.Show("Se agregó el articulo con exito!");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
