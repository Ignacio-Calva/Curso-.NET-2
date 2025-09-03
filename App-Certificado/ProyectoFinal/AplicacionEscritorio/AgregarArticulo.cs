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
                objeto.IdCategoria = (int)comboCategoria.SelectedValue;
                objeto.IdMarca = (int)comboMarca.SelectedValue;
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

        private void AgregarArticulo_Load(object sender, EventArgs e)
        {
            //Creo los negocio de Categoria y Marca
            CategoriaNegocio negocioCate = new CategoriaNegocio();
            MarcaNegocio negocioMarca = new MarcaNegocio();
            try
            {
                //Cargo los ComboBox
                comboCategoria.DataSource = negocioCate.listarCategorias();
                comboCategoria.ValueMember = "IdCategoria"; //Tengo que usar LA PROPIEDAD DE LA CLASE
                comboCategoria.DisplayMember = "Descripcion";


                /////MARCA (PENDIENTE)
                comboMarca.DataSource = negocioMarca.listarMarcas();
                comboMarca.ValueMember = "IdMarca";
                comboMarca.DisplayMember = "Descripcion";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
