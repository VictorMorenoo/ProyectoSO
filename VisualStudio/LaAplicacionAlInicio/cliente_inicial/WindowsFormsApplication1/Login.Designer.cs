namespace clienteForm
{
    partial class Login
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
            this.label1 = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.Label();
            this.usernm = new System.Windows.Forms.TextBox();
            this.psswd = new System.Windows.Forms.TextBox();
            this.entrar = new System.Windows.Forms.Button();
            this.Regist = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // password
            // 
            this.password.AutoSize = true;
            this.password.Location = new System.Drawing.Point(16, 120);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(53, 13);
            this.password.TabIndex = 1;
            this.password.Text = "Password";
            // 
            // usernm
            // 
            this.usernm.Location = new System.Drawing.Point(80, 39);
            this.usernm.Name = "usernm";
            this.usernm.Size = new System.Drawing.Size(100, 20);
            this.usernm.TabIndex = 2;
            this.usernm.Text = "ToniTur";
            // 
            // psswd
            // 
            this.psswd.Location = new System.Drawing.Point(80, 113);
            this.psswd.Name = "psswd";
            this.psswd.Size = new System.Drawing.Size(100, 20);
            this.psswd.TabIndex = 3;
            this.psswd.Text = "123";
            // 
            // entrar
            // 
            this.entrar.Location = new System.Drawing.Point(92, 163);
            this.entrar.Name = "entrar";
            this.entrar.Size = new System.Drawing.Size(75, 23);
            this.entrar.TabIndex = 4;
            this.entrar.Text = "LogIn";
            this.entrar.UseVisualStyleBackColor = true;
            this.entrar.Click += new System.EventHandler(this.entrar_Click);
            // 
            // Regist
            // 
            this.Regist.Location = new System.Drawing.Point(92, 201);
            this.Regist.Name = "Regist";
            this.Regist.Size = new System.Drawing.Size(75, 23);
            this.Regist.TabIndex = 5;
            this.Regist.Text = "Register";
            this.Regist.UseVisualStyleBackColor = true;
            this.Regist.Click += new System.EventHandler(this.Regist_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.Regist);
            this.Controls.Add(this.entrar);
            this.Controls.Add(this.psswd);
            this.Controls.Add(this.usernm);
            this.Controls.Add(this.password);
            this.Controls.Add(this.label1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label password;
        private System.Windows.Forms.TextBox usernm;
        private System.Windows.Forms.TextBox psswd;
        private System.Windows.Forms.Button entrar;
        private System.Windows.Forms.Button Regist;
    }
}