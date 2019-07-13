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
    public partial class rUsuarios : Form
    {
        public rUsuarios()
        {
            InitializeComponent();
        }
        private void Limpiar()
        {
            IdnumericUpDown.Value = 0;
            NombretextBox.Text = string.Empty;
            EmailtextBox.Text = string.Empty;
            UsuariotextBox.Text = string.Empty;
            ClavemaskedTextBox.Text = string.Empty;
            ConfirmarmaskedTextBox.Text = string.Empty;
            FechadateTimePicker.Value = DateTime.Now;

        }

        private bool ExisteEnLaBaseDeDatos()
        {
            RepositorioBase<Usuarios> db = new RepositorioBase<Usuarios>();
            Usuarios usuarios = db.Buscar((int)IdnumericUpDown.Value);
            return (usuarios != null);
        }

        //Llena campos
        private Usuarios LlenaClase()
        {
            Usuarios usuario = new Usuarios();
            usuario.UsuarioId = Convert.ToInt32(IdnumericUpDown.Value);
            usuario.Usuario = UsuariotextBox.Text;
            usuario.Nombre = NombretextBox.Text;
            usuario.Email = EmailtextBox.Text;
            usuario.Clave = ClavemaskedTextBox.Text;
            usuario.FechaIngreso = FechadateTimePicker.Value;

            return usuario;
        }

        private void LlenaCampo(Usuarios usuario)
        {
            IdnumericUpDown.Value = usuario.UsuarioId;
            NombretextBox.Text = usuario.Nombre;
            UsuariotextBox.Text = usuario.Usuario;
            EmailtextBox.Text = usuario.Email;
            ClavemaskedTextBox.Text = usuario.Clave;
            FechadateTimePicker.Value = usuario.FechaIngreso;
        }

        private bool Validar()
        {
            bool paso = true;
            MyerrorProvider.Clear();

            if (NombretextBox.Text == String.Empty)
            {
                MyerrorProvider.SetError(NombretextBox, "El campo Nombre no puede estar vacio");
                NombretextBox.Focus();
                paso = false;
            }

            if (EmailtextBox.Text == String.Empty)
            {
                MyerrorProvider.SetError(EmailtextBox, "El campo Email no puede estar vacio");
                EmailtextBox.Focus();
                paso = false;
            }
            if (UsuariotextBox.Text == String.Empty)
            {
                MyerrorProvider.SetError(UsuariotextBox, "El campo usuario no puede estar vacio");
                UsuariotextBox.Focus();
                paso = false;
            }

            if (ClavemaskedTextBox.Text == String.Empty)
            {
                MyerrorProvider.SetError(ClavemaskedTextBox, "El campo Clave no puede estar vacio");
                ClavemaskedTextBox.Focus();
                paso = false;
            }

            if (ConfirmarmaskedTextBox.Text != ClavemaskedTextBox.Text)
            {
                MyerrorProvider.SetError(ConfirmarmaskedTextBox, "La clave no coincide");
                ConfirmarmaskedTextBox.Focus();
                paso = false;
            }

            return paso;
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Usuarios> db = new RepositorioBase<Usuarios>();
            Usuarios usuarios = new Usuarios();
            try
            {
                if (IdnumericUpDown.Value > 0)
                {
                    if ((usuarios = db.Buscar((int)IdnumericUpDown.Value)) != null)
                    {
                        Limpiar();
                        LlenaCampo(usuarios);
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
            RepositorioBase<Usuarios> db = new RepositorioBase<Usuarios>();
            Usuarios usuarios = LlenaClase();
            bool paso = false;

            if (!Validar())
                return;

            if (IdnumericUpDown.Value == 0)
                paso = db.Guardar(usuarios);
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede modificar un Estudiante que no existe", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                paso = db.Modificar(usuarios);
            }
            if (paso)
                MessageBox.Show("Guardado!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No fue posible guardar!!", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Limpiar();
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Usuarios> db = new RepositorioBase<Usuarios>();
            MyerrorProvider.Clear();
            try
            {
                if (IdnumericUpDown.Value > 0)
                {
                    if (db.Eliminar((int)IdnumericUpDown.Value))
                    {
                        Limpiar();
                        MessageBox.Show("Eliminado", "Atencion!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
