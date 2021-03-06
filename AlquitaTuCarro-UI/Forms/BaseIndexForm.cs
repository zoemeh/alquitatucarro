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
        private Form CreateRecordForm;
        public BaseIndexForm(string apiUrl, string title, Form createForm)
        {
            InitializeComponent();
            Text = title;
            ApiUrl = apiUrl;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            CreateRecordForm = createForm;
        }

        private void MakeDataSet()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + TokenStore.Token);
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
            CreateRecordForm.ShowDialog();
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

            var record = new Dictionary<string, string>();
            for(var i =0; i < dataGridView1.ColumnCount; i++)
            {
                String columnName = dataGridView1.Columns[i].Name;
                record[columnName] = editedRow.Cells[i].Value.ToString();

            }
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + TokenStore.Token);


            string json = JsonConvert.SerializeObject(record, Formatting.Indented);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = client.PutAsync(ApiUrl + "/" + id, content);
            var result = response.Result.Content.ReadAsStringAsync().Result;
            MessageBox.Show(result);
            MakeDataSet();
        }
    }
}
