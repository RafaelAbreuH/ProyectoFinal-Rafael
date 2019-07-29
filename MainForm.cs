using ProyectoFinal_Rafael.UI.Consultas;
using ProyectoFinal_Rafael.UI.Registros;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinal_Rafael
{
    public partial class Farmacia : Form
    {
        public Farmacia()
        {
            InitializeComponent();
        }

        private void EntradaAlmacenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rEntradaAlmacen ver = new rEntradaAlmacen ();
            ver.MdiParent = this;
            ver.Show();
        }

        private void ClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rClientes ver = new rClientes();
            ver.MdiParent = this;
            ver.Show();
        }

        private void CiudadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rCiudad ver = new rCiudad();
            ver.MdiParent = this;
            ver.Show();
        }

        private void UsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rUsuarios ver = new rUsuarios();
            ver.MdiParent = this;
            ver.Show();
        }

        private void ArticulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rArticulos ver = new rArticulos();
            ver.MdiParent = this;
            ver.Show();
        }

        private void FacturacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rFacturacion ver = new rFacturacion();
            ver.MdiParent = this;
            ver.Show();
        }

        private void ClientesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            cClientes ver = new cClientes();
            ver.MdiParent = this;
            ver.Show();
        }

        private void EntradaAlmacenToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            cEntradaAlmacen ver = new cEntradaAlmacen();
            ver.MdiParent = this;
            ver.Show();
        }

        private void FacturarionToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void UsuariosToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void ArticulosToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
    }
}
