namespace clienteForm
{
    partial class Consultas
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.nombre = new System.Windows.Forms.TextBox();
            this.enviar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.consulta4 = new System.Windows.Forms.RadioButton();
            this.consulta3 = new System.Windows.Forms.RadioButton();
            this.button_Desconectar = new System.Windows.Forms.Button();
            this.consulta2 = new System.Windows.Forms.RadioButton();
            this.consulta1 = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre";
            // 
            // nombre
            // 
            this.nombre.Location = new System.Drawing.Point(116, 31);
            this.nombre.Name = "nombre";
            this.nombre.Size = new System.Drawing.Size(164, 20);
            this.nombre.TabIndex = 3;
            this.nombre.TextChanged += new System.EventHandler(this.nombre_TextChanged);
            // 
            // enviar
            // 
            this.enviar.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.enviar.Location = new System.Drawing.Point(47, 172);
            this.enviar.Name = "enviar";
            this.enviar.Size = new System.Drawing.Size(233, 56);
            this.enviar.TabIndex = 5;
            this.enviar.Text = "Enviar";
            this.enviar.UseVisualStyleBackColor = false;
            this.enviar.Click += new System.EventHandler(this.enviar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Thistle;
            this.groupBox1.Controls.Add(this.consulta4);
            this.groupBox1.Controls.Add(this.consulta3);
            this.groupBox1.Controls.Add(this.button_Desconectar);
            this.groupBox1.Controls.Add(this.consulta2);
            this.groupBox1.Controls.Add(this.consulta1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.enviar);
            this.groupBox1.Controls.Add(this.nombre);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(363, 282);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Peticion";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // consulta4
            // 
            this.consulta4.AutoSize = true;
            this.consulta4.Location = new System.Drawing.Point(72, 149);
            this.consulta4.Name = "consulta4";
            this.consulta4.Size = new System.Drawing.Size(217, 17);
            this.consulta4.TabIndex = 10;
            this.consulta4.TabStop = true;
            this.consulta4.Text = "Escribe ID del jugador que quiera buscar";
            this.consulta4.UseVisualStyleBackColor = true;
            this.consulta4.CheckedChanged += new System.EventHandler(this.radioButtonID_CheckedChanged);
            // 
            // consulta3
            // 
            this.consulta3.AutoSize = true;
            this.consulta3.Location = new System.Drawing.Point(72, 127);
            this.consulta3.Name = "consulta3";
            this.consulta3.Size = new System.Drawing.Size(247, 17);
            this.consulta3.TabIndex = 9;
            this.consulta3.TabStop = true;
            this.consulta3.Text = "El Jugador que ha ganado la partida mas larga ";
            this.consulta3.UseVisualStyleBackColor = true;
            // 
            // button_Desconectar
            // 
            this.button_Desconectar.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.button_Desconectar.Location = new System.Drawing.Point(72, 234);
            this.button_Desconectar.Name = "button_Desconectar";
            this.button_Desconectar.Size = new System.Drawing.Size(208, 42);
            this.button_Desconectar.TabIndex = 8;
            this.button_Desconectar.Text = "Desconectar";
            this.button_Desconectar.UseVisualStyleBackColor = false;
            this.button_Desconectar.Click += new System.EventHandler(this.button_Desconectar_Click);
            // 
            // consulta2
            // 
            this.consulta2.AutoSize = true;
            this.consulta2.Location = new System.Drawing.Point(72, 104);
            this.consulta2.Name = "consulta2";
            this.consulta2.Size = new System.Drawing.Size(208, 17);
            this.consulta2.TabIndex = 7;
            this.consulta2.TabStop = true;
            this.consulta2.Text = "El jugador que mas partidas ha perdido";
            this.consulta2.UseVisualStyleBackColor = true;
            // 
            // consulta1
            // 
            this.consulta1.AutoSize = true;
            this.consulta1.Location = new System.Drawing.Point(72, 81);
            this.consulta1.Name = "consulta1";
            this.consulta1.Size = new System.Drawing.Size(283, 17);
            this.consulta1.TabIndex = 8;
            this.consulta1.TabStop = true;
            this.consulta1.Text = "Jugador que ha ganado la partida con duracion 40 min";
            this.consulta1.UseVisualStyleBackColor = true;
            // 
            // Consultas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 308);
            this.Controls.Add(this.groupBox1);
            this.Name = "Consultas";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nombre;
        private System.Windows.Forms.Button enviar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton consulta2;
        private System.Windows.Forms.RadioButton consulta1;
        private System.Windows.Forms.Button button_Desconectar;
        private System.Windows.Forms.RadioButton consulta3;
        private System.Windows.Forms.RadioButton consulta4;
    }
}

