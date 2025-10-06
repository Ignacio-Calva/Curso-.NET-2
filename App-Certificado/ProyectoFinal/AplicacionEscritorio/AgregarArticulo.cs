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
using System.Diagnostics.Eventing.Reader;

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
                if (caracter == '.')
                {
                    return false;
                }
            }
            return true;
        }

        private bool validarArticulo(Articulos articulo)
        {
            if (string.IsNullOrEmpty(tbxCodigo.Text))
            {
                MessageBox.Show("Por favor ingrese un codigo.", "Atencion", MessageBoxButtons.OK);
                return false;
            }
            else if (string.IsNullOrEmpty(tbxNombre.Text))
            {
                MessageBox.Show("Por favor ingrese un nombre.", "Atencion", MessageBoxButtons.OK);
                return false;
            }
            //VALIDACIONES DEL PRECIO (Que se haya ingresado, que no tenga letras, y que el decimal se separe por puntos.
            else if (string.IsNullOrEmpty(tbxPrecio.Text))
            {
                MessageBox.Show("Por favor ingrese un precio.", "Atencion", MessageBoxButtons.OK);
                return false;
            }
            else if (!(soloNumeros(tbxPrecio.Text.Trim())))
            {
                MessageBox.Show("El precio no debe contener letras.", "Atencion", MessageBoxButtons.OK);
                return false;
            }
            else if (!contieneComa(tbxPrecio.Text.Trim()))
            {
                MessageBox.Show("Por favor, separe los decimales con una coma (,).", "Atencion", MessageBoxButtons.OK);
                return false;
            }

            else if (comboMarca.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor seleccione una marca.", "Atencion", MessageBoxButtons.OK);
                return false;
            }
            else if (comboCategoria.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor seleccione una categoría.", "Atencion", MessageBoxButtons.OK);
                return false;
            }
            
            return true;
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            if (objeto == null)
                objeto = new Articulos();
            try
            {
                if (!(validarArticulo(objeto)))
                    return;
                objeto.Codigo = tbxCodigo.Text;
                objeto.Nombre = tbxNombre.Text;
                objeto.Descripcion = tbxDescripcion.Text;
                if (string.IsNullOrEmpty(tbxDescripcion.Text))
                {
                    objeto.Descripcion = "-- Sin Descripcion --"; //Para que el DGV quede mas prolijo
                }
                objeto.Categoria = new Categorias(); //INSTANCIO LA CATEGORIA PRIMERO
                objeto.Categoria.IdCategoria = (int)comboCategoria.SelectedValue;
                objeto.Marca = new Marcas();
                objeto.Marca.IdMarca = (int)comboMarca.SelectedValue;
                objeto.Precio = decimal.Parse(tbxPrecio.Text);
                objeto.UrlImagen = tbxUrlImagen.Text;

                //Si levanto una imagen, la guardo aca.
                if (archivo != null && !(tbxUrlImagen.Text.ToLower().Contains("http")))
                {
                    if (File.Exists(ConfigurationManager.AppSettings["images-folder"] + archivo.SafeFileName) && objeto.IdArticulo == 0)
                    //La condicion del if SOLO CONTEMPLA si estoy agregando.
                    {
                        MessageBox.Show("La foto seleccionada ya existe.", "Atencion", MessageBoxButtons.OK);
                        return;
                    } else if (objeto.IdArticulo != 0 )
                    { //ARCHIVO NUEVO, ARCHIVO ANTIGUO.
                        File.Copy(archivo.FileName, ConfigurationManager.AppSettings["images-folder"] + archivo.SafeFileName, true);
                    }
                    else 
                    {
                       File.Copy(archivo.FileName, ConfigurationManager.AppSettings["images-folder"] + archivo.SafeFileName);
                    }
                    
                }

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
            Text = "Agregar Articulo";
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
                comboCategoria.SelectedIndex = -1;
                comboCategoria.DataSource = negocioCate.listarCategorias();
                comboCategoria.ValueMember = "IdCategoria"; //Tengo que usar LA PROPIEDAD DE LA CLASE
                comboCategoria.DisplayMember = "Descripcion";


                /////MARCA
                comboMarca.SelectedIndex = -1;
                comboMarca.DataSource = negocioMarca.listarMarcas();
                comboMarca.ValueMember = "IdMarca";
                comboMarca.DisplayMember = "Descripcion";
                
                if (objeto != null) //Si NO ES Null es porque estoy modificando.
                {
                    string precioModificado;
                    tbxCodigo.Text = objeto.Codigo;
                    tbxNombre.Text = objeto.Nombre;
                    tbxDescripcion.Text = objeto.Descripcion;
                    precioModificado = objeto.Precio.ToString().Substring(0, objeto.Precio.ToString().Length - 5); ;
                    tbxPrecio.Text = precioModificado;
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
            archivo.Filter = "Imagen JPG| *.jpg|Imagen PNG| *.png";

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

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnMin_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        //PARA MOVER LA VENTANA DESDE EL PANEL
        private int clickX, clickY;

        private void pnlBotones_MouseMove_1(object sender, MouseEventArgs e)
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
    }
    
}
