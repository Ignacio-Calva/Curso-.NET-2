using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Negocio;

namespace AplicacionEscritorio
{
    public partial class formPrincipal : Form
    {
        public formPrincipal()
        { 
            InitializeComponent();
            cargarDgv();
        }
        public void cargarDgv()
        {
            List<Articulos> listaArt = new List<Articulos>();
            ArticuloNegocio negocioArt = new Negocio.ArticuloNegocio();
            listaArt = negocioArt.listarArticulos();
            dgvProductos.DataSource = listaArt;
            dgvProductos.Columns["UrlImagen"].Visible = false;
        }
    }
}
