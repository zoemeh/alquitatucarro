using AlquitaTuCarro.Models;
using AlquitaTuCarro.UI;
using AlquitaTuCarro.UI.Forms;
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
        where ModelType : new()
    {

        private string ApiUrl;
        private List<ModelType>? dataList;
        public BaseIndexForm(string apiUrl, string title)
        {
            InitializeComponent();
            Text = title;
            ApiUrl = apiUrl;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
        }

        private void MakeDataSet()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization",  "Bearer " + TokenStore.Token);
            var response = client.GetAsync(ApiUrl);
            var s = response.Result.Content.ReadAsStringAsync().Result;
            dataList = JsonConvert.DeserializeObject<List<ModelType>>(s);
            dataGridView1.DataSource = dataList;
        }

        private void BaseIndexForm_Load(object sender, EventArgs e)
        {
           //MakeDataSet();
        }

        private void CrearBtn_Click(object sender, EventArgs e)
        {
            var f = new CreateFuelTypeForm();
            f.ShowDialog();
            MakeDataSet();
            
        }

        private void BaseIndexForm_Shown(object sender, EventArgs e)
        {
            MakeDataSet();
        }

        private void BorrarBtn_Click(object sender, EventArgs e)
        {
            Int32 selectedRowCount =
          dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();

                for (int i = 0; i < selectedRowCount; i++)
                {
                    sb.Append("Row: ");
                    sb.Append(dataGridView1.SelectedRows[i].Index.ToString());
                    sb.Append(Environment.NewLine);
                }

                sb.Append("Total: " + selectedRowCount.ToString());
                MessageBox.Show(sb.ToString(), "Selected Rows");
            }

        }
    }
}
