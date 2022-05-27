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

namespace AlquitaTuCarro_UI
{
    public partial class BaseIndexForm<ModelType> : Form
    {

        private string ApiUrl;
        public BaseIndexForm(string apiUrl, string title)
        {
            InitializeComponent();
            Text = title;
            ApiUrl = apiUrl;
        }

        private void MakeDataSet()
        {
            var client = new HttpClient();
            var response = client.GetAsync(ApiUrl);
            var s = response.Result.Content.ReadAsStringAsync().Result;
            List<ModelType>? arr = JsonConvert.DeserializeObject<List<ModelType>>(s);
            dataGridView1.DataSource = arr;
        }

        private void BaseIndexForm_Load(object sender, EventArgs e)
        {
            MakeDataSet();
        }
    }
}
