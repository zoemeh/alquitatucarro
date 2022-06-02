using AlquitaTuCarro.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlquitaTuCarro.UI.Forms
{
    public partial class CreateFuelTypeForm : Form
    {
        public CreateFuelTypeForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var fuelType = new FuelType();
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + TokenStore.Token);

            fuelType.Description = textBox1.Text;
            string json = JsonConvert.SerializeObject(fuelType, Formatting.Indented);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = client.PostAsync("https://localhost:7163/api/FuelTypes", content);
            var result = response.Result;
            MessageBox.Show(result.StatusCode.ToString());
            Close();    
        }
    }
}
