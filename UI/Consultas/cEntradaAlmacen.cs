using BLL;
using Entidades;
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

namespace ProyectoFinal_Rafael.UI.Consultas
{
    public partial class cEntradaAlmacen : Form
    {
        public cEntradaAlmacen()
        {
            InitializeComponent();
        }
        Expression<Func<EntradaAlmacen, bool>> filtro = x => true;
        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            var listado = new List<EntradaAlmacen>();
            RepositorioBase<EntradaAlmacen> db = new RepositorioBase<EntradaAlmacen>();

            if (CriteriotextBox.Text.Trim().Length > 0)
            {
                switch (FiltrocomboBox.SelectedIndex)
                {
                    case 0: //todo
                        listado = db.GetList(u => true);
                        break;
                    case 1: // ID
                        int id = Convert.ToInt32(CriteriotextBox.Text);
                        listado = db.GetList(u => u.EntradaId == id);
                        break;
                    case 2: //Articulo ID
                        listado = db.GetList(u => u.ArticuloId.ToString().Contains(CriteriotextBox.Text));
                        break;
                    case 3: // Cantidad
                        listado = db.GetList(u => u.Cantidad.ToString().Contains(CriteriotextBox.Text));
                        break;

                }
            }
            listado = db.GetList(filtro);
            if (FechaCheckBox.Checked == true)
                listado = db.GetList(filtro).Where(x => x.FechaEntrada.Date >= DesdedateTimePicker.Value.Date && x.FechaEntrada.Date <= HastadateTimePicker.Value.Date).ToList();
            else
                listado = db.GetList(filtro);
            ConsultadataGridView.DataSource = null;
            ConsultadataGridView.DataSource = listado;
        }
        public void soloNumeros(KeyPressEventArgs e)
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
        private void CriteriotextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (FiltrocomboBox.SelectedIndex == 1)
            {
                soloNumeros(e);
            }
            if (FiltrocomboBox.SelectedIndex == 2)
            {
                soloNumeros(e);
            }
            if (FiltrocomboBox.SelectedIndex == 3)
            {
                soloNumeros(e);
            }
        }
    }
}
