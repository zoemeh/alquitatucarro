namespace AlquitaTuCarro_UI
{
    partial class BaseIndexForm<ModelType>
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.CrearBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 80);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(776, 358);
            this.dataGridView1.TabIndex = 0;
            // 
            // CrearBtn
            // 
            this.CrearBtn.Location = new System.Drawing.Point(713, 51);
            this.CrearBtn.Name = "CrearBtn";
            this.CrearBtn.Size = new System.Drawing.Size(75, 23);
            this.CrearBtn.TabIndex = 1;
            this.CrearBtn.Text = "Crear";
            this.CrearBtn.UseVisualStyleBackColor = true;
            // 
            // BaseIndexForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CrearBtn);
            this.Controls.Add(this.dataGridView1);
            this.Name = "BaseIndexForm";
            this.Text = "BaseIndexForm";
            this.Load += new System.EventHandler(this.BaseIndexForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dataGridView1;
        private Button CrearBtn;
    }
}