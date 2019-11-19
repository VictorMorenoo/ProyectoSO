namespace clienteForm
{
    partial class Form3
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
            this.Nickname_Box = new System.Windows.Forms.TextBox();
            this.Username_Box = new System.Windows.Forms.TextBox();
            this.Password_Box = new System.Windows.Forms.TextBox();
            this.Register = new System.Windows.Forms.Button();
            this.Nickname = new System.Windows.Forms.Label();
            this.username = new System.Windows.Forms.Label();
            this.Password = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Nickname_Box
            // 
            this.Nickname_Box.Location = new System.Drawing.Point(88, 53);
            this.Nickname_Box.Name = "Nickname_Box";
            this.Nickname_Box.Size = new System.Drawing.Size(100, 20);
            this.Nickname_Box.TabIndex = 0;
            // 
            // Username_Box
            // 
            this.Username_Box.Location = new System.Drawing.Point(88, 97);
            this.Username_Box.Name = "Username_Box";
            this.Username_Box.Size = new System.Drawing.Size(100, 20);
            this.Username_Box.TabIndex = 1;
            // 
            // Password_Box
            // 
            this.Password_Box.Location = new System.Drawing.Point(88, 143);
            this.Password_Box.Name = "Password_Box";
            this.Password_Box.Size = new System.Drawing.Size(100, 20);
            this.Password_Box.TabIndex = 2;
            // 
            // Register
            // 
            this.Register.Location = new System.Drawing.Point(102, 185);
            this.Register.Name = "Register";
            this.Register.Size = new System.Drawing.Size(75, 23);
            this.Register.TabIndex = 3;
            this.Register.Text = "Register";
            this.Register.UseVisualStyleBackColor = true;
            this.Register.Click += new System.EventHandler(this.Register_Click);
            // 
            // Nickname
            // 
            this.Nickname.AutoSize = true;
            this.Nickname.Location = new System.Drawing.Point(31, 56);
            this.Nickname.Name = "Nickname";
            this.Nickname.Size = new System.Drawing.Size(55, 13);
            this.Nickname.TabIndex = 4;
            this.Nickname.Text = "Nickname";
            // 
            // username
            // 
            this.username.AutoSize = true;
            this.username.Location = new System.Drawing.Point(31, 100);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(55, 13);
            this.username.TabIndex = 5;
            this.username.Text = "Username";
            // 
            // Password
            // 
            this.Password.AutoSize = true;
            this.Password.Location = new System.Drawing.Point(31, 146);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(53, 13);
            this.Password.TabIndex = 6;
            this.Password.Text = "Password";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.username);
            this.Controls.Add(this.Nickname);
            this.Controls.Add(this.Register);
            this.Controls.Add(this.Password_Box);
            this.Controls.Add(this.Username_Box);
            this.Controls.Add(this.Nickname_Box);
            this.Name = "Form3";
            this.Text = "Form3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Nickname_Box;
        private System.Windows.Forms.TextBox Username_Box;
        private System.Windows.Forms.TextBox Password_Box;
        private System.Windows.Forms.Button Register;
        private System.Windows.Forms.Label Nickname;
        private System.Windows.Forms.Label username;
        private System.Windows.Forms.Label Password;
    }
}