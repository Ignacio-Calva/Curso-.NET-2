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

namespace AplicacionEscritorio
{
    public partial class VerDetalle : Form
    {
        Articulos articuloCargado;
        public VerDetalle(Articulos articuloSeleccionado)
        {
            InitializeComponent();
            articuloCargado = articuloSeleccionado;
            CargarImagen(articuloCargado.UrlImagen);
            CargarDatos(articuloCargado);
        }
        private void CargarImagen(string urlImagen)
        {
            try
            {
                pbxArt.Load(urlImagen);
            }
            catch
            {
                pbxArt.Load("https://imgs.search.brave.com/GoFaUzcpoaWIfsGMqByaylLvtEKMbDzzW-hC7myjZ_o/rs:fit:860:0:0:0/g:ce/aHR0cHM6Ly93d3cu/c2h1dHRlcnN0b2Nr/LmNvbS9pbWFnZS12/ZWN0b3IvZGVmYXVs/dC11aS1pbWFnZS1w/bGFjZWhvbGRlci13/aXJlZnJhbWVzLTI2/MG53LTEwMzc3MTkx/OTIuanBn");
            }
        }
        private void CargarDatos(Articulos artCargado)
        {
            try
            {
                if (artCargado != null)
                {
                    if (!(string.IsNullOrEmpty(artCargado.IdArticulo.ToString()))) lblMostrarId.Text = artCargado.IdArticulo.ToString();
                    if (!(string.IsNullOrEmpty(artCargado.Codigo.ToString()))) lblMostrarCodigo.Text = artCargado.Codigo.ToString();
                    if (!(string.IsNullOrEmpty(artCargado.Nombre.ToString()))) lblMostrarNombre.Text = artCargado.Nombre.ToString();
                    if (!(string.IsNullOrEmpty(artCargado.Descripcion.ToString()))) lblMostrarDescripcion.Text = artCargado.Descripcion.ToString();
                    if (!(string.IsNullOrEmpty(artCargado.Marca.Descripcion.ToString()))) lblMostrarMarca.Text = artCargado.Marca.Descripcion.ToString();
                    if (!(string.IsNullOrEmpty(artCargado.Categoria.Descripcion.ToString()))) lblMostrarCategoria.Text = artCargado.Categoria.Descripcion.ToString();
                    if (!(string.IsNullOrEmpty(artCargado.Precio.ToString()))) lblMostrarPrecio.Text = artCargado.Precio.ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}
