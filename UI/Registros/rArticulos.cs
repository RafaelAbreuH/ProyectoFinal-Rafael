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
    public partial class rArticulos : Form
    {
        public rArticulos()
        {
            InitializeComponent();
        }

        private void Limpiar()
        {
            IdnumericUpDown.Value = 0;
            DescripciontextBox.Text = string.Empty;
            CostotextBox.Text = string.Empty;
            PreciotextBox.Text = string.Empty;
            ExistenciatextBox.Text = string.Empty;
            DescripciontextBox.Text = string.Empty;
            FechadateTimePicker.Value = DateTime.Now;

        }

        private bool ExisteEnLaBaseDeDatos()
        {
            RepositorioBase<Articulos> db = new RepositorioBase<Articulos>();
            Articulos usuarios = db.Buscar((int)IdnumericUpDown.Value);
            return (usuarios != null);
        }

        //Llena campos
        private Articulos LlenaClase()
        {
            Articulos articulo = new Articulos();
            articulo.ArticuloId = Convert.ToInt32(IdnumericUpDown.Value);
            articulo.FechanEntrada = FechadateTimePicker.Value;
            articulo.Descripcion = DescripciontextBox.Text;
            articulo.Costo = Convert.ToDecimal(CostotextBox.Text);
            articulo.Precio = Convert.ToDecimal(PreciotextBox.Text);
            articulo.Existencia = 0;
            articulo.Medida = MedidacomboBox.Text;
            return articulo;
        }

        private void LlenaCampo(Articulos articulo)
        {
            IdnumericUpDown.Value = articulo.ArticuloId;
            DescripciontextBox.Text = articulo.Descripcion;
            CostotextBox.Text = articulo.Costo.ToString();
            PreciotextBox.Text = articulo.Precio.ToString();
            ExistenciatextBox.Text = articulo.Existencia.ToString();
            FechadateTimePicker.Value = articulo.FechanEntrada;
            MedidacomboBox.Text = articulo.Medida;
        }

        private bool Validar()
        {
            bool paso = true;
            errorProvider1.Clear();

            if (DescripciontextBox.Text == String.Empty)
            {
                errorProvider1.SetError(DescripciontextBox, "El campo Nombre no puede estar vacio");
                DescripciontextBox.Focus();
                paso = false;
            }
            if (CostotextBox.Text == String.Empty)
            {
                errorProvider1.SetError(CostotextBox, "El campo Costo no puede estar vacio");
                CostotextBox.Focus();
                paso = false;
            }
            if (PreciotextBox.Text == String.Empty)
            {
                errorProvider1.SetError(PreciotextBox, "El campo Precio no puede estar vacio");
                PreciotextBox.Focus();
                paso = false;
            }
            if (FechadateTimePicker.Value > DateTime.Now)
            {
                errorProvider1.SetError(FechadateTimePicker, "La fecha no puede ser Mayor que la de hoy");
                paso = false;
            }
            return paso;
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Articulos> db = new RepositorioBase<Articulos>();
            Articulos articulo = new Articulos();
            try
            {
                if (IdnumericUpDown.Value > 0)
                {
                    if ((articulo = db.Buscar((int)IdnumericUpDown.Value)) != null)
                    {
                        Limpiar();
                        LlenaCampo(articulo);
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
            RepositorioBase<Articulos> db = new RepositorioBase<Articulos>();
            Articulos articulo = LlenaClase();
            bool paso = false;

            if (!Validar())
                return;

            if (IdnumericUpDown.Value == 0)
                paso = db.Guardar(articulo);
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede modificar una Asignatura que no existe", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                paso = db.Modificar(articulo);
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
            RepositorioBase<Articulos> db = new RepositorioBase<Articulos>();
            errorProvider1.Clear();
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

        private void CostotextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloNumeros(e);
            if (e.KeyChar == '.')
            {
                // No deja poner un punto primero
                if (CostotextBox.TextLength < 1)
                    e.Handled = true;

                //Para que no deje poner mas de 1 Punto
                if (e.KeyChar == '.' && CostotextBox.Text.IndexOf('.') > -1)
                    e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void ItbistextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloNumeros(e);
            if (e.KeyChar == '.')
            {
                // No deja poner un punto primero
                if (CostotextBox.TextLength < 1)
                    e.Handled = true;

                //Para que no deje poner mas de 1 Punto
                if (e.KeyChar == '.' && CostotextBox.Text.IndexOf('.') > -1)
                    e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void PreciotextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloNumeros(e);
            if (e.KeyChar == '.')
            {
                // No deja poner un punto primero
                if (CostotextBox.TextLength < 1)
                    e.Handled = true;

                //Para que no deje poner mas de 1 Punto
                if (e.KeyChar == '.' && CostotextBox.Text.IndexOf('.') > -1)
                    e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void ExistenciatextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloNumeros(e);
            if (e.KeyChar == '.')
            {
                // No deja poner un punto primero
                if (CostotextBox.TextLength < 1)
                    e.Handled = true;

                //Para que no deje poner mas de 1 Punto
                if (e.KeyChar == '.' && CostotextBox.Text.IndexOf('.') > -1)
                    e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }
    }
}
