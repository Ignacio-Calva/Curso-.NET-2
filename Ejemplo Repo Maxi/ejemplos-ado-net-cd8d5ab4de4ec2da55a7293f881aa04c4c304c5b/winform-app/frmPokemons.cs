using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winform_app
{
    public partial class frmPokemons : Form
    {
        public frmPokemons()
        {
            InitializeComponent();
        }

        private void frmPokemons_Load(object sender, EventArgs e)
        {
            PokemonNegocio negocio = new PokemonNegocio();
            dgvPokemons.DataSource = negocio.listar();
            cbSeleccion.DataSource = negocio.listarNombre();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            PokemonNegocio negocio = new PokemonNegocio();
            negocio.sacarPokemon(cbSeleccion.SelectedItem.ToString());
            string pokemonRemovido = "Se há removido el pokemon " + cbSeleccion.SelectedItem.ToString();
            MessageBox.Show(pokemonRemovido);
            dgvPokemons.DataSource = negocio.listar();
            cbSeleccion.DataSource = negocio.listarNombre();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAgregarPokemon formulario2 = new frmAgregarPokemon(this);
            formulario2.FormClosed += frmAgregarPokemon_FormClosed;
            this.Hide();
            formulario2.ShowDialog();
        }
        private void frmAgregarPokemon_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Esto es lo que querés que se ejecute al cerrar el segundo formulario
            PokemonNegocio negocio = new PokemonNegocio();
            dgvPokemons.DataSource = negocio.listar();
            cbSeleccion.DataSource = negocio.listarNombre();
        }

    }
}
