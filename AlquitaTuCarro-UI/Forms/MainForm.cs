using AlquitaTuCarro.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlquitaTuCarro_UI
{
    public partial class MainForm : Form
    {
        private BaseIndexForm<FuelType> FuelTypesForm;
        private BaseIndexForm<VehicleType> VehicleTypesForm;
        private BaseIndexForm<VehicleBrand> VehicleBrandsForm;
        private BaseIndexForm<Vehicle> VehiclesForm;
        private BaseIndexForm<Client> ClientsForm;

        private Form _currentform;
        private Form CurrentForm
        {
            get => _currentform;
            set
            {
                if (_currentform is not null)
                {
                    _currentform.Hide();
                }
                _currentform = value;
                _currentform.Show();
            }
        }

        public MainForm()
        {
            InitializeComponent();
            FuelTypesForm = new BaseIndexForm<FuelType>(apiUrl: "https://localhost:7163/api/FuelTypes", title: "Tipos de Combustible");
            VehicleTypesForm = new BaseIndexForm<VehicleType>(apiUrl: "https://localhost:7163/api/VehicleTypes", title: "Tipos de Vehiculos");
            VehicleBrandsForm = new BaseIndexForm<VehicleBrand>(apiUrl: "https://localhost:7163/api/VehicleBrands", title: "Marcas de Vehiculos");
            VehiclesForm = new BaseIndexForm<Vehicle>(apiUrl: "https://localhost:7163/api/Vehicles", title: "Vehiculos");
            ClientsForm = new BaseIndexForm<Client>(apiUrl: "https://localhost:7163/api/Clients", title: "Clientes");


            MakeInlineForm(FuelTypesForm);
            MakeInlineForm(VehicleTypesForm);
            MakeInlineForm(VehicleBrandsForm);
            MakeInlineForm(VehiclesForm);
            MakeInlineForm(ClientsForm);
        }

        private void MakeInlineForm(Form f)
        {
            f.TopLevel = false;
            Controls.Add(f);
            f.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            f.Dock = DockStyle.Fill;
        }

        private void tiposDeCombustibleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentForm = FuelTypesForm;
        }

        private void tiposDeAutoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentForm = VehicleTypesForm;
        }

        private void marcasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentForm = VehicleTypesForm;
        }

        private void vehiculosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentForm = VehiclesForm;
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentForm = ClientsForm;
        }
    }
}
