using BLL;
using Entidades;
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
    public partial class rCiudad : Form
    {
        public rCiudad()
        {
            InitializeComponent();
        }

        private void Limpiar()
        {

            IdnumericUpDown.Value = 0;
            DescripciontextBox.Text = string.Empty;
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
            RepositorioBase<Ciudades> db = new RepositorioBase<Ciudades>();
            Ciudades ciudades = new Ciudades();
            try
            {
                if (IdnumericUpDown.Value > 0)
                {
                    if ((ciudades = db.Buscar((int)IdnumericUpDown.Value)) != null)
                    {
                        Limpiar();
                        LlenarCampos(ciudades);
                    }
                    else
                        MessageBox.Show("No se encontro!", "Atencion!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo buscar", "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Ciudades> db = new RepositorioBase<Ciudades>();
            Ciudades ciudades = LlenarClase();
            bool paso = false;

            if (!Validar())
                return;

            if (IdnumericUpDown.Value == 0)
                paso = db.Guardar(ciudades);
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede modificar una Asignatura que no existe", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                paso = db.Modificar(ciudades);
            }
            if (paso)
            {
                MessageBox.Show("Guardado!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
            }
            else
                MessageBox.Show("No fue posible guardar!!", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Ciudades> db = new RepositorioBase<Ciudades>();
            errorProvider.Clear();
            try
            {
                if (IdnumericUpDown.Value > 0)
                {
                    if (db.Eliminar((int)IdnumericUpDown.Value))
                    {
                        MessageBox.Show("Eliminado", "Atencion!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Limpiar();
                    }
                    else
                        MessageBox.Show("No se puede eliminar", "Atencion!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo eliminar", "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
