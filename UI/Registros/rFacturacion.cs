using BLL;
using DAL;
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
    public partial class rFacturacion : Form
    {
        public rFacturacion()
        {
            InitializeComponent();
            LlenarComboBox();
        }

        private void LlenarComboBox()
        {
            RepositorioBase<Clientes> CRepositorio = new RepositorioBase<Clientes>();
            RepositorioBase<Articulos> ARepositorio = new RepositorioBase<Articulos>();

            ClientecomboBox.DataSource = CRepositorio.GetList(c => true);
            ClientecomboBox.ValueMember = "ClienteId";
            ClientecomboBox.DisplayMember = "Nombre";
            ArticulocomboBox.DataSource = ARepositorio.GetList(c => true);
            ArticulocomboBox.ValueMember = "ArticuloId";
            ArticulocomboBox.DisplayMember = "Descripcion";
        }

        private void LlenaCampos(Factura factura)
        {
            IdnumericUpDown.Value = factura.FacturaId;
            FechadateTimePicker.Value = factura.Fecha;
            TipoPagocomboBox.Text = factura.TipoPago;
            ClientecomboBox.SelectedValue = factura.ClienteId;
            SubTotaltextBox.Text = factura.SubTotal.ToString();
            ItbistextBox.Text = factura.Itbis.ToString();
            TotaltextBox.Text = factura.Total.ToString();

            DetalledataGridView.DataSource = factura.Detalle;

            DetalledataGridView.Columns["Id"].Visible = false;
            DetalledataGridView.Columns["FacturaId"].Visible = false;
            DetalledataGridView.Columns["Articulo"].Visible = false;
            DetalledataGridView.Columns["Factura"].Visible = false;
        }
        private int ToInt(object valor)
        {
            int retorno = 0;
            int.TryParse(valor.ToString(), out retorno);

            return retorno;
        }

        private decimal ToDecimal(object valor)
        {
            decimal retorno = 0;
            decimal.TryParse(valor.ToString(), out retorno);

            return retorno;
        }

        private Factura LlenaClase()
        {
            Factura factura = new Factura();

            factura.FacturaId = Convert.ToInt32(IdnumericUpDown.Value);
            factura.Fecha = FechadateTimePicker.Value;
            factura.TipoPago = TipoPagocomboBox.Text;
            factura.ClienteId = Convert.ToInt32(ClientecomboBox.SelectedValue);
            factura.SubTotal = Convert.ToDecimal(SubTotaltextBox.Text);
            factura.Itbis = Convert.ToDecimal(ItbistextBox.Text);
            factura.Total = Convert.ToDecimal(TotaltextBox.Text);

            foreach (DataGridViewRow item in DetalledataGridView.Rows)
            {
                factura.AgregarDetalle(
                    ToInt(item.Cells["Id"].Value),
                    ToInt(item.Cells["FacturaId"].Value),
                    ToInt(item.Cells["ArticuloId"].Value),
                    item.Cells["Descripcion"].ToString(),
                    ToDecimal(item.Cells["Cantidad"].Value),
                    ToDecimal(item.Cells["Precio"].Value),
                    ToDecimal(item.Cells["Importe"].Value)
                );
            }

            DetalledataGridView.Columns["Id"].Visible = false;
            DetalledataGridView.Columns["FacturaId"].Visible = false;

            return factura;
        }

        private void Limpiar()
        {
            IdnumericUpDown.Value = 0;
            FechadateTimePicker.Value = DateTime.Now;
            ClientecomboBox.SelectedIndex = 0;
            ArticulocomboBox.SelectedIndex = 0;
            CantidadtextBox.Clear();
            PreciotextBox.Clear();
            ImportetextBox.Clear();
            DetalledataGridView.DataSource = null;
            SubTotaltextBox.Clear();
            ItbistextBox.Clear();
            TotaltextBox.Clear();
            MyErrorProvider.Clear();
        }

        private void Anadir()
        {
            List<FacturaDetalle> detalle = new List<FacturaDetalle>();

            if (DetalledataGridView.DataSource != null)
            {
                detalle = (List<FacturaDetalle>)DetalledataGridView.DataSource;
            }            
            decimal Total = 0;
            decimal Itbis = 0;
            decimal SubTotal = 0;
            foreach (var item in detalle)
            {
                Total += item.Importe;
            }
            Itbis = Total * 0.18m;
            SubTotal = Total - Itbis;
            SubTotaltextBox.Text = SubTotal.ToString();
            ItbistextBox.Text = Itbis.ToString();
            TotaltextBox.Text = Total.ToString();
        }

        private void Rebajar()
        {
            List<FacturaDetalle> detalle = new List<FacturaDetalle>();

            if (DetalledataGridView.DataSource != null)
            {
                detalle = (List<FacturaDetalle>)DetalledataGridView.DataSource;
            }
            decimal Total = 0;
            decimal Itbis = 0;
            decimal SubTotal = 0;
            foreach (var item in detalle)
            {
                Total -= item.Importe;
            }
            Total *= (-1);
            Itbis = Total * 0.18m;
            SubTotal = Total - Itbis;
            SubTotaltextBox.Text = SubTotal.ToString();
            ItbistextBox.Text = Itbis.ToString();
            TotaltextBox.Text = Total.ToString();
        }

        private bool CantidadInventario()
        {
            List<FacturaDetalle> detalle = new List<FacturaDetalle>();

            if (DetalledataGridView.DataSource != null)
            {
                detalle = (List<FacturaDetalle>)DetalledataGridView.DataSource;
            }

            RepositorioBase<Articulos> repositorio = new RepositorioBase<Articulos>();
            int id = ToInt(ArticulocomboBox.SelectedValue);
            Articulos articulo = repositorio.Buscar(id);

            decimal CantidadCotizada = 0;

            decimal CantidadProducto = articulo.Existencia;
            CantidadCotizada = ToInt(CantidadtextBox.Text);
            bool paso = false;

            if (ToInt(CantidadtextBox.Text) > articulo.Existencia)
            {
                MyErrorProvider.SetError(CantidadtextBox, "Error");
                MessageBox.Show("Cantidad mayor a la existente en inventario!!", "Falló!!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                paso = true;
            }
            

            if (DetalledataGridView.Rows.Count != 0)
            {
                decimal CantProducto = ToInt(CantidadtextBox.Text);

                CantidadProducto -= CantidadCotizada;
                if (ToInt(CantidadtextBox.Text) > CantProducto)
                {
                    MyErrorProvider.SetError(CantidadtextBox, "Error");
                    MessageBox.Show("Cantidad mayor a la existente en inventario!!", "Falló!!",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    paso = true;
                }
            }
            if (CantidadProducto < CantidadCotizada)
            {
                MessageBox.Show($"Solo quedan {CantidadProducto} del articulo deseado!!", "Articulo Agotado!!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                paso = true;
            }

            return paso;
        }

        private bool HayErrores()
        {
            bool HayErrores = false;

            if (DetalledataGridView.RowCount == 0)
            {
                MyErrorProvider.SetError(DetalledataGridView,
                    "Debe Agregar los Productos ");
                HayErrores = true;
            }

            return HayErrores;
        }

        private void Agregarbutton_Click(object sender, EventArgs e)
        {
            List<FacturaDetalle> detalle = new List<FacturaDetalle>();

            if (DetalledataGridView.DataSource != null)
            {
                detalle = (List<FacturaDetalle>)DetalledataGridView.DataSource;
            }
            if (CantidadInventario())
            {
                return;
            }
            else if (String.IsNullOrWhiteSpace(CantidadtextBox.Text))
            {
                MessageBox.Show("Cantidad no puede ser cero!!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                detalle.Add(
                    new FacturaDetalle(
                       id: 0,
                       facturaId: (int)IdnumericUpDown.Value,
                       articuloId: (int)ArticulocomboBox.SelectedValue,
                       descripcion: ArticulocomboBox.Text,
                       cantidad: (decimal)Convert.ToDecimal(CantidadtextBox.Text),
                       precio: (decimal)Convert.ToDecimal(PreciotextBox.Text),
                       importe: (decimal)Convert.ToDecimal(ImportetextBox.Text)
               ));

                DetalledataGridView.DataSource = null;
                DetalledataGridView.DataSource = detalle;
                DetalledataGridView.Columns["Id"].Visible = false;
                DetalledataGridView.Columns["ArticuloId"].Visible = false;
                DetalledataGridView.Columns["FacturaId"].Visible = false;
                DetalledataGridView.Columns["Articulo"].Visible = false;
                DetalledataGridView.Columns["Factura"].Visible = false;
                Anadir();
            }
        }

        private void Removerbutton_Click(object sender, EventArgs e)
        {
            if (DetalledataGridView.Rows.Count > 0 && DetalledataGridView.CurrentRow != null)
            {
                List<FacturaDetalle> detalle = (List<FacturaDetalle>)DetalledataGridView.DataSource;

                detalle.RemoveAt(DetalledataGridView.CurrentRow.Index);

                DetalledataGridView.DataSource = null;
                DetalledataGridView.DataSource = detalle;

                Rebajar();
            }
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(IdnumericUpDown.Value);
            RepositorioBase<Factura> repositorio = new RepositorioBase<Factura>();
            Factura factura = repositorio.Buscar(id);

            if (factura != null)
            {
                LlenaCampos(factura);
            }
            else
                MessageBox.Show("No se encontró!!!", "Falló",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            Factura factura;
            bool Paso = false;
            RepositorioBase<Factura> repositorio = new RepositorioBase<Factura>();
            if (HayErrores())
            {
                MessageBox.Show("Favor revisar todos los campos!!", "Validación!!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            factura = LlenaClase();

            if (IdnumericUpDown.Value == 0)
            {
                Paso = repositorio.Guardar(factura);
                MessageBox.Show("Guardado!!", "Exito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                int id = Convert.ToInt32(IdnumericUpDown.Value);
                RepositorioBase<Factura> repositorioDos = new RepositorioBase<Factura>();
                Factura fac = repositorioDos.Buscar(id);

                if (fac != null)
                {
                    Paso = repositorio.Modificar(factura);
                    MessageBox.Show("Modificado!!", "Exito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Id no existe", "Falló",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (Paso)
            {
                Nuevobutton.PerformClick();
            }
            else
                MessageBox.Show("No se pudo guardar!!", "Fallo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(IdnumericUpDown.Value);
            RepositorioBase<Factura> repositorio = new RepositorioBase<Factura>();
            Factura factura = repositorio.Buscar(id);

            if (factura != null)
            {
                if (repositorio.Eliminar(id))
                {
                    MessageBox.Show("Eliminado!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                }
                else
                    MessageBox.Show("No se pudo eliminar!!", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("No existe!!", "Falló", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void LlenarPrecio()
        {
            RepositorioBase<Articulos> repositorio = new RepositorioBase<Articulos>();
            List<Articulos> lista = repositorio.GetList(c => c.Descripcion == ArticulocomboBox.Text);
            foreach (var item in lista)
            {
                PreciotextBox.Text = item.Precio.ToString();
            }
        }

        private void LlenarImporte()
        {
            RepositorioFactura repositorio = new RepositorioFactura();
            decimal cantidad = 0;
            decimal precio = 0;

            cantidad = ToDecimal(CantidadtextBox.Text);
            precio = ToDecimal(PreciotextBox.Text);
            ImportetextBox.Text = repositorio.Importe(cantidad, precio).ToString();
        }

        private void CantidadtextBox_TextChanged(object sender, EventArgs e)
        {
            LlenarPrecio();
            LlenarImporte();
        }

        private void ArticulocomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarPrecio();
            if (CantidadtextBox.Text != "0")
            {
                LlenarImporte();
            }
            LlenarPrecio();
        }
    }
}
