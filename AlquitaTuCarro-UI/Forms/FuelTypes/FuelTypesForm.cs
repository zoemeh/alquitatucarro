using AlquitaTuCarro.Data;
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
    public partial class FuelTypesForm : Form
    {
        private readonly string ApiUrl = "https://localhost:7163/api/FuelTypes";
        private List<FuelType>? dataList;

        public FuelTypesForm()
        {
            InitializeComponent();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
        }

        private void MakeDataSet()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + TokenStore.Token);
            var response = client.GetAsync(ApiUrl);
            var s = response.Result.Content.ReadAsStringAsync().Result;
            dataList = JsonConvert.DeserializeObject<List<FuelType>>(s);
            dataGridView1.DataSource = dataList;
            dataGridView1.Columns[0].ReadOnly = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var f = new CreateFuelTypeForm();
            f.ShowDialog();
            MakeDataSet();
        }

        private void BorrarBtn_Click(object sender, EventArgs e)
        {
            Int32 selectedRowCount =
         dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                for (int i = 0; i < selectedRowCount; i++)
                {
                    var id = dataGridView1.SelectedRows[i].Cells[0].Value.ToString();
                    var client = new HttpClient();
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + TokenStore.Token);
                    var response = client.DeleteAsync(ApiUrl + "/" + id);
                    // Not used for now
                    var result = response.Result.Content.ReadAsStringAsync().Result;
                }
                MakeDataSet();
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var editedRow = dataGridView1.Rows[e.RowIndex];
            var id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();

            var record = new FuelType();
            record.Id = int.Parse(editedRow.Cells[0].Value.ToString());
            record.Description = editedRow.Cells[1].Value.ToString();
            record.IsActive = Convert.ToBoolean(editedRow.Cells[2].Value.ToString());
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + TokenStore.Token);

            string json = JsonConvert.SerializeObject(record, Formatting.Indented);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = client.PutAsync(ApiUrl + "/" + id, content);
            var result = response.Result.Content.ReadAsStringAsync().Result;
            //MakeDataSet();
        }

        private void FuelTypesForm_Load(object sender, EventArgs e)
        {
            MakeDataSet();
        }
    }
}
