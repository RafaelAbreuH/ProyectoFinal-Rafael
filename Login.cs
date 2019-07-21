using BLL;
using Entidades;
using ProyectoFinal_Rafael.UI.Consultas;
using ProyectoFinal_Rafael.UI.Registros;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinal_Rafael
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        private void CleanProvider()
        {
            errorProvider.Clear();
        }

        private void Entrarbutton_Click(object sender, EventArgs e)
        {
            bool paso = true;
            Expression<Func<Usuarios, bool>> filtrar = x => true;
            List<Usuarios> user = new List<Usuarios>();
            RepositorioBase<Usuarios> db = new RepositorioBase<Usuarios>();

            CleanProvider();
            if (UsuarioTextBox.Text == string.Empty)
            {
                paso = false;
                errorProvider.SetError(UsuarioTextBox, "Incorrecto");

            }
            if (ClavemaskedTextBox.Text == string.Empty)
            {
                paso = false;
                errorProvider.SetError(ClavemaskedTextBox, "Incorrecto");

            }
            if (paso == false)
            {
                MessageBox.Show("Campos Vacios!!");
                return;
            }
            if ((UsuarioTextBox.Text == "Admin") && (ClavemaskedTextBox.Text == "0000"))
            {
                this.Hide();
                MainForm ver = new MainForm();
                ver.Show();
            }
            else
            {
                filtrar = t => t.Usuario.Equals(UsuarioTextBox.Text);
                user = db.GetList(filtrar);

                if (user.Exists(x => x.Nombre == UsuarioTextBox.Text) && user.Exists(x => x.Clave == ClavemaskedTextBox.Text))
                {
                    this.Hide();
                    MainForm ver = new MainForm();
                    ver.Show();
                }
                else
                {
                    MessageBox.Show("Nombre de usuario o contraseña incorrecta!!");
                    errorProvider.SetError(ClavemaskedTextBox, "Incorrecto");
                    errorProvider.SetError(UsuarioTextBox, "Incorrecto");
                }
            }
        }

    }
}

