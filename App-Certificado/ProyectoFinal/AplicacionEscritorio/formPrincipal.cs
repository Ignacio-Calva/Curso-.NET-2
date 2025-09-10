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
        }
        public void cargarDgv()
        {
            //La lista esta declarada como un atributo
            ArticuloNegocio negocioArt = new Negocio.ArticuloNegocio();
            listaArt = negocioArt.listarArticulos();
            dgvProductos.DataSource = listaArt;
            dgvProductos.Columns["UrlImagen"].Visible = false;
            dgvProductos.Columns["IdArticulo"].Visible = false; 
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
            aux = (Articulos)dgvProductos.CurrentRow.DataBoundItem;
            cargarImagen(aux.UrlImagen);
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
        }
    }
}
