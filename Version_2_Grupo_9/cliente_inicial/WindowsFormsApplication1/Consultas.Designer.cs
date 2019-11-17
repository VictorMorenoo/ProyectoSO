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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Consultas));
            this.label2 = new System.Windows.Forms.Label();
            this.nombre = new System.Windows.Forms.TextBox();
            this.enviar = new System.Windows.Forms.Button();
            this.Panel_Consultas = new System.Windows.Forms.GroupBox();
            this.Consulta_Tabla_Conectados = new System.Windows.Forms.RadioButton();
            this.Tabla_Conectados = new System.Windows.Forms.DataGridView();
            this.consulta4 = new System.Windows.Forms.RadioButton();
            this.consulta3 = new System.Windows.Forms.RadioButton();
            this.button_Desconectar = new System.Windows.Forms.Button();
            this.consulta2 = new System.Windows.Forms.RadioButton();
            this.consulta1 = new System.Windows.Forms.RadioButton();
            this.Play_Button = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.RoadMover = new System.Windows.Forms.Timer(this.components);
            this.Car = new System.Windows.Forms.PictureBox();
            this.Left_mover = new System.Windows.Forms.Timer(this.components);
            this.Right_mover = new System.Windows.Forms.Timer(this.components);
            this.EnemyCar1 = new System.Windows.Forms.PictureBox();
            this.EnemyCar2 = new System.Windows.Forms.PictureBox();
            this.Enemy1_mover = new System.Windows.Forms.Timer(this.components);
            this.Enemy2_mover = new System.Windows.Forms.Timer(this.components);
            this.End_Label = new System.Windows.Forms.Label();
            this.Score_Label = new System.Windows.Forms.Label();
            this.Replay_Button = new System.Windows.Forms.Button();
            this.Panel_Consultas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Tabla_Conectados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Car)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnemyCar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnemyCar2)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // nombre
            // 
            resources.ApplyResources(this.nombre, "nombre");
            this.nombre.Name = "nombre";
            this.nombre.TextChanged += new System.EventHandler(this.nombre_TextChanged);
            // 
            // enviar
            // 
            this.enviar.BackColor = System.Drawing.SystemColors.ScrollBar;
            resources.ApplyResources(this.enviar, "enviar");
            this.enviar.Name = "enviar";
            this.enviar.UseVisualStyleBackColor = false;
            this.enviar.Click += new System.EventHandler(this.enviar_Click);
            // 
            // Panel_Consultas
            // 
            this.Panel_Consultas.BackColor = System.Drawing.Color.Thistle;
            this.Panel_Consultas.Controls.Add(this.Consulta_Tabla_Conectados);
            this.Panel_Consultas.Controls.Add(this.Tabla_Conectados);
            this.Panel_Consultas.Controls.Add(this.consulta4);
            this.Panel_Consultas.Controls.Add(this.consulta3);
            this.Panel_Consultas.Controls.Add(this.button_Desconectar);
            this.Panel_Consultas.Controls.Add(this.consulta2);
            this.Panel_Consultas.Controls.Add(this.consulta1);
            this.Panel_Consultas.Controls.Add(this.label2);
            this.Panel_Consultas.Controls.Add(this.enviar);
            this.Panel_Consultas.Controls.Add(this.nombre);
            resources.ApplyResources(this.Panel_Consultas, "Panel_Consultas");
            this.Panel_Consultas.Name = "Panel_Consultas";
            this.Panel_Consultas.TabStop = false;
            this.Panel_Consultas.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // Consulta_Tabla_Conectados
            // 
            resources.ApplyResources(this.Consulta_Tabla_Conectados, "Consulta_Tabla_Conectados");
            this.Consulta_Tabla_Conectados.Name = "Consulta_Tabla_Conectados";
            this.Consulta_Tabla_Conectados.TabStop = true;
            this.Consulta_Tabla_Conectados.UseVisualStyleBackColor = true;
            this.Consulta_Tabla_Conectados.CheckedChanged += new System.EventHandler(this.Consulta_Tabla_Conectados_CheckedChanged);
            // 
            // Tabla_Conectados
            // 
            this.Tabla_Conectados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.Tabla_Conectados, "Tabla_Conectados");
            this.Tabla_Conectados.Name = "Tabla_Conectados";
            this.Tabla_Conectados.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Tabla_Conectados_CellContentClick);
            // 
            // consulta4
            // 
            resources.ApplyResources(this.consulta4, "consulta4");
            this.consulta4.Name = "consulta4";
            this.consulta4.TabStop = true;
            this.consulta4.UseVisualStyleBackColor = true;
            this.consulta4.CheckedChanged += new System.EventHandler(this.radioButtonID_CheckedChanged);
            // 
            // consulta3
            // 
            resources.ApplyResources(this.consulta3, "consulta3");
            this.consulta3.Name = "consulta3";
            this.consulta3.TabStop = true;
            this.consulta3.UseVisualStyleBackColor = true;
            // 
            // button_Desconectar
            // 
            this.button_Desconectar.BackColor = System.Drawing.SystemColors.ScrollBar;
            resources.ApplyResources(this.button_Desconectar, "button_Desconectar");
            this.button_Desconectar.Name = "button_Desconectar";
            this.button_Desconectar.UseVisualStyleBackColor = false;
            this.button_Desconectar.Click += new System.EventHandler(this.button_Desconectar_Click);
            // 
            // consulta2
            // 
            resources.ApplyResources(this.consulta2, "consulta2");
            this.consulta2.Name = "consulta2";
            this.consulta2.TabStop = true;
            this.consulta2.UseVisualStyleBackColor = true;
            this.consulta2.CheckedChanged += new System.EventHandler(this.consulta2_CheckedChanged);
            // 
            // consulta1
            // 
            resources.ApplyResources(this.consulta1, "consulta1");
            this.consulta1.Name = "consulta1";
            this.consulta1.TabStop = true;
            this.consulta1.UseVisualStyleBackColor = true;
            this.consulta1.CheckedChanged += new System.EventHandler(this.consulta1_CheckedChanged);
            // 
            // Play_Button
            // 
            resources.ApplyResources(this.Play_Button, "Play_Button");
            this.Play_Button.Name = "Play_Button";
            this.Play_Button.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.pictureBox2, "pictureBox2");
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.pictureBox3, "pictureBox3");
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.pictureBox4, "pictureBox4");
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.pictureBox5, "pictureBox5");
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.pictureBox6, "pictureBox6");
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.pictureBox7, "pictureBox7");
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.TabStop = false;
            // 
            // pictureBox8
            // 
            this.pictureBox8.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.pictureBox8, "pictureBox8");
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.TabStop = false;
            // 
            // pictureBox9
            // 
            this.pictureBox9.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.pictureBox9, "pictureBox9");
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.TabStop = false;
            // 
            // RoadMover
            // 
            this.RoadMover.Enabled = true;
            this.RoadMover.Interval = 10;
            this.RoadMover.Tick += new System.EventHandler(this.RoadMover_Tick);
            // 
            // Car
            // 
            resources.ApplyResources(this.Car, "Car");
            this.Car.Name = "Car";
            this.Car.TabStop = false;
            this.Car.Click += new System.EventHandler(this.Car_Click);
            // 
            // Left_mover
            // 
            this.Left_mover.Interval = 10;
            this.Left_mover.Tick += new System.EventHandler(this.Left_mover_Tick);
            // 
            // Right_mover
            // 
            this.Right_mover.Interval = 10;
            this.Right_mover.Tick += new System.EventHandler(this.Right_mover_Tick);
            // 
            // EnemyCar1
            // 
            resources.ApplyResources(this.EnemyCar1, "EnemyCar1");
            this.EnemyCar1.Name = "EnemyCar1";
            this.EnemyCar1.TabStop = false;
            // 
            // EnemyCar2
            // 
            resources.ApplyResources(this.EnemyCar2, "EnemyCar2");
            this.EnemyCar2.Name = "EnemyCar2";
            this.EnemyCar2.TabStop = false;
            // 
            // Enemy1_mover
            // 
            this.Enemy1_mover.Enabled = true;
            this.Enemy1_mover.Interval = 10;
            this.Enemy1_mover.Tick += new System.EventHandler(this.Enemy1_mover_Tick);
            // 
            // Enemy2_mover
            // 
            this.Enemy2_mover.Enabled = true;
            this.Enemy2_mover.Interval = 10;
            this.Enemy2_mover.Tick += new System.EventHandler(this.Enemy2_mover_Tick);
            // 
            // End_Label
            // 
            resources.ApplyResources(this.End_Label, "End_Label");
            this.End_Label.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.End_Label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.End_Label.Name = "End_Label";
            // 
            // Score_Label
            // 
            resources.ApplyResources(this.Score_Label, "Score_Label");
            this.Score_Label.Name = "Score_Label";
            // 
            // Replay_Button
            // 
            this.Replay_Button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.Replay_Button.ForeColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.Replay_Button, "Replay_Button");
            this.Replay_Button.Name = "Replay_Button";
            this.Replay_Button.UseVisualStyleBackColor = false;
            this.Replay_Button.Click += new System.EventHandler(this.Replay_Button_Click);
            // 
            // Consultas
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Play_Button);
            this.Controls.Add(this.Replay_Button);
            this.Controls.Add(this.Score_Label);
            this.Controls.Add(this.End_Label);
            this.Controls.Add(this.EnemyCar2);
            this.Controls.Add(this.EnemyCar1);
            this.Controls.Add(this.Car);
            this.Controls.Add(this.pictureBox9);
            this.Controls.Add(this.pictureBox8);
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Panel_Consultas);
            this.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Name = "Consultas";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Consultas_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Consultas_KeyUp);
            this.Panel_Consultas.ResumeLayout(false);
            this.Panel_Consultas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Tabla_Conectados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Car)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnemyCar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnemyCar2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nombre;
        private System.Windows.Forms.Button enviar;
        private System.Windows.Forms.GroupBox Panel_Consultas;
        private System.Windows.Forms.RadioButton consulta2;
        private System.Windows.Forms.RadioButton consulta1;
        private System.Windows.Forms.Button button_Desconectar;
        private System.Windows.Forms.RadioButton consulta3;
        private System.Windows.Forms.RadioButton consulta4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.Timer RoadMover;
        private System.Windows.Forms.PictureBox Car;
        private System.Windows.Forms.Timer Left_mover;
        private System.Windows.Forms.Timer Right_mover;
        private System.Windows.Forms.PictureBox EnemyCar1;
        private System.Windows.Forms.PictureBox EnemyCar2;
        private System.Windows.Forms.Timer Enemy1_mover;
        private System.Windows.Forms.Timer Enemy2_mover;
        public System.Windows.Forms.Label End_Label;
        private System.Windows.Forms.Label Score_Label;
        private System.Windows.Forms.Button Replay_Button;
        private System.Windows.Forms.DataGridView Tabla_Conectados;
        private System.Windows.Forms.RadioButton Consulta_Tabla_Conectados;
        private System.Windows.Forms.Button Play_Button;
    }
}

