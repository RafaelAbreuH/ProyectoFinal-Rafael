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
    public partial class rClientes : Form
    {
        public rClientes()
        {
            InitializeComponent();
            LlenarComboBox();
        }
        private void LlenarComboBox()
        {

            RepositorioBase<Clientes> db = new RepositorioBase<Clientes>();
            var listado = new List<Clientes>();
            listado = db.GetList(l => true);
            CiudadcomboBox.DataSource = listado;
            CiudadcomboBox.DisplayMember = "Descripcion";
            CiudadcomboBox.ValueMember = "CiudadId";

        }
        private void Limpiar()
        {

            IdnumericUpDown.Value = 0;
            NombretextBox.Text = String.Empty;
            CedulamaskedTextBox1.Text = String.Empty;
            EmailtextBox.Text = string.Empty;
            TelefonomaskedTextBox.Text = string.Empty;
            CiudadcomboBox.Text = String.Empty;
            FechadateTimePicker.Value = DateTime.Now;
            BalancetextBox.Text = string.Empty;
        }

        private void LlenarCampos(Clientes cliente)
        {
            IdnumericUpDown.Value = cliente.ClienteId;
            NombretextBox.Text = cliente.Nombre;
            CedulamaskedTextBox1.Text = cliente.Cedula;
            EmailtextBox.Text = cliente.Email;
            TelefonomaskedTextBox.Text = cliente.Celular;
            CiudadcomboBox.Text = cliente.CiudadId.ToString();
            FechadateTimePicker.Value = cliente.FechaIngreso;
            BalancetextBox.Text = cliente.Balance.ToString();
        }

        private Clientes LlenarClase()
        {
            Clientes cliente = new Clientes();

            cliente.ClienteId = (int)IdnumericUpDown.Value;
            cliente.Nombre = NombretextBox.Text;
            cliente.Cedula = CedulamaskedTextBox1.Text;
            cliente.Email = EmailtextBox.Text;
            cliente.Celular = TelefonomaskedTextBox.Text;
            cliente.CiudadId = Convert.ToInt32(CiudadcomboBox.Text);
            cliente.FechaIngreso = FechadateTimePicker.Value;
            cliente.Balance = Convert.ToDecimal(BalancetextBox.Text);

            return cliente; 
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            RepositorioBase<Clientes> db = new RepositorioBase<Clientes>();
            Clientes clientes = db.Buscar((int)IdnumericUpDown.Value);
            return (clientes != null);
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

        private bool Validar()
        {
            bool paso = true;
            errorProvider1.Clear();

            if (NombretextBox.Text == String.Empty)
            {
                errorProvider1.SetError(NombretextBox, "Digite un Nombre");
                paso = false;
            }
            if (CedulamaskedTextBox1.Text == String.Empty)
            {
                errorProvider1.SetError(CedulamaskedTextBox1, "Digite la cedula");
                paso = false;
            }
            if (EmailtextBox.Text == String.Empty)
            {
                errorProvider1.SetError(EmailtextBox, "Digite un email");
                paso = false;
            }
            if (TelefonomaskedTextBox.Text == String.Empty)
            {
                errorProvider1.SetError(TelefonomaskedTextBox, "Digite un Telefono");
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
            RepositorioBase<Clientes> db = new RepositorioBase<Clientes>();
            Clientes cliente = new Clientes();
            try
            {
                if (IdnumericUpDown.Value > 0)
                {
                    if ((cliente = db.Buscar((int)IdnumericUpDown.Value)) != null)
                    {
                        Limpiar();
                        LlenarCampos(cliente);
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

        private void Agregarbutton_Click(object sender, EventArgs e)
        {
            rCiudad dialog = new rCiudad();
            dialog.ShowDialog(this);

            CiudadcomboBox.Refresh(); // HACER QUE COMBOBOX PRESENTE EL VALOR AGREGADo -----------------------------------------------
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Clientes> db = new RepositorioBase<Clientes>();
            Clientes cliente = LlenarClase();
            bool paso = false;

            if (!Validar())
                return;

            if (IdnumericUpDown.Value == 0)
                paso = db.Guardar(cliente);
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede modificar una Asignatura que no existe", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                paso = db.Modificar(cliente);
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
            RepositorioBase<Clientes> db = new RepositorioBase<Clientes>();
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


    }
}
