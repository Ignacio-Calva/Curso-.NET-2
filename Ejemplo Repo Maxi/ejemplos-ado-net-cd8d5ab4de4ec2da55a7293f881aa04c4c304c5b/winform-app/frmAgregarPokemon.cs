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
    public partial class frmAgregarPokemon : Form
    {
        frmPokemons formulario1;
        public frmAgregarPokemon(frmPokemons formulario)
        {
            formulario1 = formulario;
            InitializeComponent();
        }

        private void btnAgregarForm_Click(object sender, EventArgs e)
        {
            Pokemon pokemonAgregado = new Pokemon();
            pokemonAgregado.Numero = int.Parse(tbNumero.Text); 
            pokemonAgregado.Nombre = tbNombre.Text.Trim(); 
            pokemonAgregado.Descripcion = tbDesc.Text.Trim(); 
            PokemonNegocio negocio = new PokemonNegocio();
            negocio.agregarPokemon(pokemonAgregado);
            MessageBox.Show("Se ha agregado el pokemon.");
        }

        private void frmAgregarPokemon_FormClosed(object sender, FormClosedEventArgs e)
        {
            formulario1.Show();
        }
    }
}
