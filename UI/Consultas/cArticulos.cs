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
    public partial class cArticulos : Form
    {
        public cArticulos()
        {
            InitializeComponent();
        }
        Expression<Func<Articulos, bool>> filtro = x => true;
        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            var listado = new List<Articulos>();
            RepositorioBase<Articulos> db = new RepositorioBase<Articulos>();

            if (CriteriotextBox.Text.Trim().Length > 0)
            {
                switch (FiltrocomboBox.SelectedIndex)
                {
                    case 0: //todo
                        listado = db.GetList(u => true);
                        break;
                    case 1: // ID
                        int id = Convert.ToInt32(CriteriotextBox.Text);
                        listado = db.GetList(u => u.ArticuloId == id);
                        break;
                    case 2: //Descripcion
                        listado = db.GetList(u => u.Descripcion.Contains(CriteriotextBox.Text));
                        break;
                    case 3: // Costo
                        listado = db.GetList(u => u.Costo.ToString().Contains(CriteriotextBox.Text));
                        break;
                    case 4: //precio
                        listado = db.GetList(u => u.Precio.ToString().Contains(CriteriotextBox.Text));
                        break;
                    case 5: //Existencia
                        listado = db.GetList(u => u.Existencia.ToString().Contains(CriteriotextBox.Text));
                        break;
                    case 6: //Medida
                        listado = db.GetList(u => u.Medida.Contains(CriteriotextBox.Text));
                        break;
                }
                //  listado = listado.Where(c => c.FechaIngreso.Date >= DesdedateTimePicker.Value.Date && c.FechaIngreso <= HastadateTimePicker.Value.Date).ToList();
            }
            listado = db.GetList(filtro);
            if (FechaCheckBox.Checked == true)
                listado = db.GetList(filtro).Where(x => x.FechanEntrada.Date >= DesdedateTimePicker.Value.Date && x.FechanEntrada.Date <= HastadateTimePicker.Value.Date).ToList();
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
            if(FiltrocomboBox.SelectedIndex == 3)
            {
                soloNumeros(e);
            }
            if (FiltrocomboBox.SelectedIndex == 4)
            {
                soloNumeros(e);
            }
            if (FiltrocomboBox.SelectedIndex == 5)
            {
                soloNumeros(e);
            }
        }
    }
}
