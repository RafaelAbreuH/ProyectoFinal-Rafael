using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinal_Rafael.UI.Registros
{
    public partial class rClientes : Form
    {
        public rClientes()
        {
            InitializeComponent();
        }

        private void Limpiar()
        {

            IdnumericUpDown.Value = 0;
            NombretextBox.Text = String.Empty;
            C
            errorProvider.Clear();
        }

        private void LlenarCampos(Ciudades ciudad)
        {
            IdnumericUpDown.Value = ciudad.CiudadId;
            DescripciontextBox.Text = ciudad.Descripcion;
        }

        private Ciudades LlenarClase()
        {
            Ciudades ciudad = new Ciudades();

            ciudad.CiudadId = (int)IdnumericUpDown.Value;
            ciudad.Descripcion = DescripciontextBox.Text;
            return ciudad;
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            RepositorioBase<Ciudades> db = new RepositorioBase<Ciudades>();
            Ciudades ciudades = db.Buscar((int)IdnumericUpDown.Value);
            return (ciudades != null);
        }

        private bool Validar()
        {
            bool paso = true;
            errorProvider.Clear();

            if (DescripciontextBox.Text == String.Empty)
            {
                errorProvider.SetError(DescripciontextBox, "Digite una Descripcion");
                paso = false;
            }
            return paso;
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {

        }
    }
}
