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
    public partial class rEntradaAlmacen : Form
    {
        public rEntradaAlmacen()
        {
            InitializeComponent();
            LlenarComboBox();

        }
        private void Limpiar()
        {

            IdnumericUpDown.Value = 0;
            ArticulocomboBox.Text = String.Empty;
            CantidadtextBox.Text = String.Empty;
            FechadateTimePicker.Value = DateTime.Now;
        }

        private void LlenarCampos(EntradaAlmacen entrada)
        {
            IdnumericUpDown.Value = entrada.EntradaId;
            ArticulocomboBox.Text = entrada.ArticuloId.ToString();
            CantidadtextBox.Text = entrada.Cantidad.ToString();
            FechadateTimePicker.Value = entrada.FechaEntrada;
        }

        private EntradaAlmacen LlenarClase()
        {
            EntradaAlmacen entrada = new EntradaAlmacen();

            entrada.EntradaId = (int)IdnumericUpDown.Value;
            entrada.ArticuloId = Convert.ToInt32(ArticulocomboBox.SelectedValue);
            entrada.Cantidad = Convert.ToDecimal(CantidadtextBox.Text);
            entrada.FechaEntrada = FechadateTimePicker.Value;
            return entrada;
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            RepositorioBase<EntradaAlmacen> db = new RepositorioBase<EntradaAlmacen>();
            EntradaAlmacen entrada = db.Buscar((int)IdnumericUpDown.Value);
            return (entrada != null);
        }

        private bool Validar()
        {
            bool paso = true;
            errorProvider.Clear();

            if (CantidadtextBox.Text == String.Empty)
            {
                errorProvider.SetError(CantidadtextBox, "Digite una Cantidad");
                paso = false;
            }
            if (FechadateTimePicker.Value > DateTime.Now)
            {
                errorProvider.SetError(FechadateTimePicker, "La fecha no puede ser Mayor que la de hoy");
                paso = false;
            }
            return paso;
        }

        private void LlenarComboBox()
        {

            RepositorioBase<Articulos> db = new RepositorioBase<Articulos>();
            var listado = new List<Articulos>();
            listado = db.GetList(l => true);
            ArticulocomboBox.DataSource = listado;
            ArticulocomboBox.DisplayMember = "Descripcion";
            ArticulocomboBox.ValueMember = "ArticuloId";



        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            RepositorioEntradaAlmacen db = new RepositorioEntradaAlmacen();
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

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            RepositorioBase<EntradaAlmacen> db = new RepositorioBase<EntradaAlmacen>();
            EntradaAlmacen entrada = new EntradaAlmacen();
            try
            {
                if (IdnumericUpDown.Value > 0)
                {
                    if ((entrada = db.Buscar((int)IdnumericUpDown.Value)) != null)
                    {
                        Limpiar();
                        LlenarCampos(entrada);
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
            RepositorioEntradaAlmacen db = new RepositorioEntradaAlmacen();
            EntradaAlmacen entrada = LlenarClase();
            bool paso = false;

            if (!Validar())
                return;

            if (IdnumericUpDown.Value == 0)
                paso = db.Guardar(entrada);
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede modificar una Asignatura que no existe", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                paso = db.Modificar(entrada);
            }
            if (paso)
            {
                MessageBox.Show("Guardado!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
            }
            else
                MessageBox.Show("No fue posible guardar!!", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        public void soloNumeros(KeyPressEventArgs e)
        {
            try
            {
                if (Char.IsNumber(e.KeyChar))
                {
                    e.Handled = false;
                }
                else if (Char.IsControl(e.KeyChar))
                {

                    e.Handled = false;
                }
                else if (Char.IsPunctuation(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
            catch (Exception)
            {

            }
        }
        private void CantidadtextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloNumeros(e);
        }
    }
}
