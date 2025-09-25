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
using System.Diagnostics.Contracts;
using System.Configuration;
using System.IO;

namespace AplicacionEscritorio.Properties
{
    public partial class AgregarArticulo : Form
    {
        Articulos objeto;
        OpenFileDialog archivo = null;
        public AgregarArticulo()
        {
            InitializeComponent();
        }
        public AgregarArticulo(Articulos articuloCargado) //Hago un constructor especifico para cuando se modifica
        {                                                //Que recibe el articulo desde la DGV
            InitializeComponent();
            objeto = articuloCargado;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            if (objeto == null)
                objeto = new Articulos();
            try
            {
                objeto.Codigo = tbxCodigo.Text;
                objeto.Nombre = tbxNombre.Text;
                objeto.Descripcion = tbxDescripcion.Text;
                objeto.Categoria = new Categorias(); //INSTANCIO LA CATEGORIA PRIMERO
                objeto.Categoria.IdCategoria = (int)comboCategoria.SelectedValue;
                objeto.Marca = new Marcas();
                objeto.Marca.IdMarca = (int)comboMarca.SelectedValue;
                objeto.Precio = decimal.Parse(tbxPrecio.Text);
                objeto.UrlImagen = tbxUrlImagen.Text;

                if (objeto.IdArticulo != 0) // ESTOY MODIFICANDO
                {
                    negocio.modificarArticulo(objeto);
                    MessageBox.Show("Se modificó el articulo con exito!");
                    Close();
                }
                else //ESTOY AGREGANDO
                {
                    negocio.agregarArticulo(objeto);
                    MessageBox.Show("Se agregó el articulo con exito!");
                    Close();
                }

                //Si levanto una imagen, la guardo aca.
                if (archivo != null && !(tbxUrlImagen.Text.ToLower().Contains("http"))) ;
                {
                    File.Copy(archivo.FileName, ConfigurationManager.AppSettings["images-folder"] + archivo.SafeFileName);
                }

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
            if (objeto != null)
            {
                lblAgregar.Text = "Modificar Articulo";
                btnAgregar.Text = "Modificar";
                Text = "Modificar Articulo";
            }
            try
            {
                //Cargo los ComboBox
                comboCategoria.DataSource = negocioCate.listarCategorias();
                comboCategoria.ValueMember = "IdCategoria"; //Tengo que usar LA PROPIEDAD DE LA CLASE
                comboCategoria.DisplayMember = "Descripcion";


                /////MARCA
                comboMarca.DataSource = negocioMarca.listarMarcas();
                comboMarca.ValueMember = "IdMarca";
                comboMarca.DisplayMember = "Descripcion";
                if (objeto != null) //Si NO ES Null es porque estoy modificando.
                {
                    tbxCodigo.Text = objeto.Codigo;
                    tbxNombre.Text = objeto.Nombre;
                    tbxDescripcion.Text = objeto.Descripcion;
                    tbxPrecio.Text = objeto.Precio.ToString();
                    tbxUrlImagen.Text = objeto.UrlImagen;
                    comboCategoria.SelectedValue = objeto.Categoria.IdCategoria;
                    comboMarca.SelectedValue = objeto.Marca.IdMarca;
                }
            }
            
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void tbxUrlImagen_TextChanged(object sender, EventArgs e)
        {
            cargarImagen(tbxUrlImagen.Text);
        }

        private void cargarImagen(string urlImagen)
        {
            try
            {
                pbxPreview.Load(urlImagen);
            }
            catch
            {
                pbxPreview.Load("https://imgs.search.brave.com/GoFaUzcpoaWIfsGMqByaylLvtEKMbDzzW-hC7myjZ_o/rs:fit:860:0:0:0/g:ce/aHR0cHM6Ly93d3cu/c2h1dHRlcnN0b2Nr/LmNvbS9pbWFnZS12/ZWN0b3IvZGVmYXVs/dC11aS1pbWFnZS1w/bGFjZWhvbGRlci13/aXJlZnJhbWVzLTI2/MG53LTEwMzc3MTkx/OTIuanBn");
            }
        }

        private void btnAgregarImagen_Click(object sender, EventArgs e)
        {
            archivo = new OpenFileDialog();
            archivo.Filter = "Imagen JPG | *.jpg| Imagen PNG | *.png";

            //PARA CREAR LA CARPETA SI NO EXISTE
            if (!Directory.Exists(ConfigurationManager.AppSettings["images-folder"]))
            {
                Directory.CreateDirectory(ConfigurationManager.AppSettings["images-folder"]);
            }


            if (archivo.ShowDialog() == DialogResult.OK)
            {
                tbxUrlImagen.Text = archivo.FileName;
                cargarImagen(archivo.FileName);

                //File.Copy(archivo.FileName, ConfigurationManager.AppSettings["images-folder"] + archivo.SafeFileName);
            }
        }
    }
    
}
