namespace AlquitaTuCarro.UI.Forms
{
    partial class LoginForm
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
            this.UserBox = new System.Windows.Forms.TextBox();
            this.LoginBtn = new System.Windows.Forms.Button();
            this.PasswordBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // UserBox
            // 
            this.UserBox.Location = new System.Drawing.Point(268, 83);
            this.UserBox.Name = "UserBox";
            this.UserBox.Size = new System.Drawing.Size(200, 39);
            this.UserBox.TabIndex = 0;
            // 
            // LoginBtn
            // 
            this.LoginBtn.Location = new System.Drawing.Point(289, 203);
            this.LoginBtn.Name = "LoginBtn";
            this.LoginBtn.Size = new System.Drawing.Size(150, 46);
            this.LoginBtn.TabIndex = 1;
            this.LoginBtn.Text = "Entrar";
            this.LoginBtn.UseVisualStyleBackColor = true;
            this.LoginBtn.Click += new System.EventHandler(this.LoginBtn_Click);
            // 
            // PasswordBox
            // 
            this.PasswordBox.Location = new System.Drawing.Point(268, 149);
            this.PasswordBox.Name = "PasswordBox";
            this.PasswordBox.PasswordChar = '*';
            this.PasswordBox.Size = new System.Drawing.Size(200, 39);
            this.PasswordBox.TabIndex = 3;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PasswordBox);
            this.Controls.Add(this.LoginBtn);
            this.Controls.Add(this.UserBox);
            this.Name = "LoginForm";
            this.Text = "LoginForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox UserBox;
        private Button LoginBtn;
        private TextBox PasswordBox;
    }
}