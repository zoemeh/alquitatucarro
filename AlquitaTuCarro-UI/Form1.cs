using AlquitaTuCarro.Models;
using Newtonsoft.Json;
using System.Text.Json.Nodes;

namespace AlquitaTuCarro_UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            MakeDataSet();

        }

        private void MakeDataSet()
        {
            var client = new HttpClient();
            var response = client.GetAsync("https://localhost:7163/api/VehicleTypes");
            var s = response.Result.Content.ReadAsStringAsync().Result;
            List<VehicleType> arr = JsonConvert.DeserializeObject<List<VehicleType>>(s);

            dataGridView1.DataSource = arr;

        }
    }
}