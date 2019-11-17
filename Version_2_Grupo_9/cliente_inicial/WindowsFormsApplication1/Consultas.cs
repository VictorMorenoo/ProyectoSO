using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using clienteForm;

namespace clienteForm
{
    public partial class Consultas : Form
    {
        Socket server;
        int BinEscuchado = 9051;
        int Speed;
        int Score = 0;
        String[] trozos = new String[100];
        PictureBox[] Road = new PictureBox[100];
        int NumRoads = 9;
        Random rnd = new Random();
        string UserDelete;
        

        public Consultas()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Speed = 3;
          

            Road[0] = pictureBox1;
            Road[1] = pictureBox2;
            Road[2] = pictureBox3;
            Road[3] = pictureBox4;
            Road[4] = pictureBox5;
            Road[5] = pictureBox6;
            Road[6] = pictureBox7;
            Road[7] = pictureBox8;
            Road[8] = pictureBox9;
        }

        private void LLenaUsuarios(string[] trozos)// llenamos la gridview de los usuarios conectados al servidor para despues poder crear una partida
        {
            
            int filas = Convert.ToInt32(trozos[0]);
             
            if (filas != 0)
            {
                Tabla_Conectados.RowCount = filas;
                Tabla_Conectados.ColumnCount = 1;

                Tabla_Conectados.Columns[0].HeaderText = "Usuarios conectados";

                for (int i = 1; i < trozos.Length; i++)
                {
                    Tabla_Conectados.Rows[i - 1].Cells[0].Value = trozos[i];
                }
            }
        }
        private void enviar_Click(object sender, EventArgs e)
        {

            //Creamos un IPEndPoint con el ip del servidor y puerto del servidor 
            //al que deseamos conectarnos
            IPAddress direc = IPAddress.Parse("169.254.0.4");
            IPEndPoint ipep = new IPEndPoint(direc, BinEscuchado);


            //Creamos el socket 
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);


            try
            {
                server.Connect(ipep);//Intentamos conectar el socket
            }
            catch (SocketException)
            {
                //Si hay excepcion imprimimos error y salimos del programa con return 
                MessageBox.Show("No he podido conectar con el servidor");
                return;
            }


            if (consulta3.Checked)
            {
                // Quiere saber la longitud
                string mensaje = "3/" + "Prueba/" + "relleno/" + "relleno";
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

                //Recibimos la respuesta del servidor
                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                MessageBox.Show("El jugador que ha ganado la partida mas larga es: " + mensaje);
            }
            else if (consulta2.Checked)

            {
                // Quiere saber si el nombre es bonito
                string mensaje = "2/" + "Prueba/" + "relleno/" + "relleno";
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

                //Recibimos la respuesta del servidor
                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];

                MessageBox.Show("El jugador que mas partidas ha perdido es: " + mensaje);


            }
            else if (consulta1.Checked)
            {
                // Quiere saber si el nombre es bonito
                string mensaje = "1/" + "Prueba/" + "relleno/" + "relleno";
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

                //Recibimos la respuesta del servidor
                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];

                MessageBox.Show("Jugador que ha ganado la partida con duracion 40 minutos: " + mensaje);


            }


            else if (Consulta_Tabla_Conectados.Checked)
            {
                Tabla_Conectados.Visible = true;
                // Quiere saber si el nombre es bonito
                string mensaje = "11/" + "Prueba/" + "relleno/" + "relleno";
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

                //Recibimos la respuesta del servidor
                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];//limpio el mensaje de suciedad y cosas finales
                string[] trozos = mensaje.Split('/');
                LLenaUsuarios(trozos);
               

            }
            else if (consulta4.Checked)
            {

                if (Convert.ToString(nombre.Text) != "")
                {
                    // Quiere saber si el nombre es bonito
                    string mensaje = "4/" + Convert.ToString(nombre.Text) + "/" + "rellenito/" + "relleno";
                    // Enviamos al servidor el nombre tecleado
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);

                    //Recibimos la respuesta del servidor
                    byte[] msg2 = new byte[80];
                    server.Receive(msg2);
                    mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];

                    MessageBox.Show("El Jugador con ID: " + Convert.ToString(nombre.Text) + " es: " + mensaje);

                }

                else
                {


                    //Si hay excepcion imprimimos error y salimos del programa con return 
                    MessageBox.Show("Please, fill all the gaps");
                    return;
                }


            }



            
            //catch (SocketException )
            //{
            //    //Si hay excepcion imprimimos error y salimos del programa con return 
            //    MessageBox.Show("No he podido conectar con el servidor");
            //    return;
            //} 






        }

        private void nombre_TextChanged(object sender, EventArgs e)
        {

        }


        private void button_Desconectar_Click(object sender, EventArgs e)
        {

            //Creamos un IPEndPoint con el ip del servidor y puerto del servidor 
            //al que deseamos conectarnos
            IPAddress direc = IPAddress.Parse("169.254.0.4");
            IPEndPoint ipep = new IPEndPoint(direc, BinEscuchado);


            //Creamos el socket 
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);


            try
            {
                server.Connect(ipep);//Intentamos conectar el socket
            }
            catch (SocketException)
            {
                //Si hay excepcion imprimimos error y salimos del programa con return 
                MessageBox.Show("No he podido conectar con el servidor");
                return;
            }

            string UserDelete = Login.Username;

            // Quiere saber la longitud
            string mensaje = "5/" + UserDelete + "/relleno/" + "relleno";
            // Enviamos al servidor el nombre tecleado
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            //Recibimos la respuesta del servidor
            byte[] msg2 = new byte[80];
            server.Receive(msg2);
            mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
            //if (mensaje == "1")
            //{ 
            //    MessageBox.Show("Correct Desconnection");
            
            //}
            //else if (mensaje == "-1")
            //{
            //    MessageBox.Show("impossible to Desconnect");
            //}
            // Se terminó el servicio. 
            // Nos desconectamos
            server.Shutdown(SocketShutdown.Both);
            server.Close();
           
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void radioButtonID_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void RoadMover_Tick(object sender, EventArgs e)
        {

            for (int i = 0; i < NumRoads; i++)
            {
                Road[i].Top += 2;

                if (Road[i].Top >= 500)//ajustar 500
                {
                    Road[i].Top = -20;//mirar de ajustar esto es del tutorial 2 pero deberiamos mirar como ajustarlo automaticalme

                }
            }
            if (Car.Bounds.IntersectsWith(EnemyCar1.Bounds))
            {
                GameOver();
            }
            if (Car.Bounds.IntersectsWith(EnemyCar2.Bounds))
            {
                GameOver();
            }
        }
        private void GameOver() 
        {
            End_Label.Visible = true;
            Replay_Button.Visible = true;
            RoadMover.Stop();
            Enemy1_mover.Stop();
            Enemy2_mover.Stop();
        
        
        }
        private void Consultas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                Right_mover.Start();
            }
            if (e.KeyCode == Keys.Left)//mirar que el boton el panel de consultas este enable o dissable
            {
                Left_mover.Start();
            }
        }

        private void Car_Click(object sender, EventArgs e)
        {

        }

        private void Right_mover_Tick(object sender, EventArgs e)
        {
            if (Car.Location.X < 900)//mirar las dimensiones de la road
            {
                Car.Left += 5;
            }
           
        }

        private void Left_mover_Tick(object sender, EventArgs e)
        {
            if (Car.Location.X > 380)//mirar las dimensiones de la road
            {
                Car.Left -= 5;
            }
        }

        private void Consultas_KeyUp(object sender, KeyEventArgs e)
        {
            Right_mover.Stop();
            Left_mover.Stop();
        }

        private void Enemy1_mover_Tick(object sender, EventArgs e)
        {
            EnemyCar1.Top += 1;
            if (EnemyCar1.Top >= 500)//mirar de ajustarlo automatico
            {
                Score += 1;
                Score_Label.Text = "Score:" + Score;
                int RoadWidth = rnd.Next(400, 650);
                int RoadHeigth = rnd.Next(0, 500);
                EnemyCar1.Top = -(RoadHeigth);
                EnemyCar1.Left = (RoadWidth);
            }
        }

        private void Enemy2_mover_Tick(object sender, EventArgs e)
        {
            EnemyCar2.Top += 2;
        
            if (EnemyCar2.Top >= 500)//mirar de ajustarlo automatico
            {
                Score += 1;
                Score_Label.Text = "Score:" + Score;
                int RoadWidth = rnd.Next(650,900);
                int RoadHeigth = rnd.Next(0,500);
                EnemyCar2.Top = -(RoadHeigth);
                EnemyCar2.Left = (RoadWidth);
            }
        }

        private void Replay_Button_Click(object sender, EventArgs e)
        {
            Score = 0;
            Controls.Clear();
            InitializeComponent();
            //Consultas_Load(e, e);
            Form1_Load(e, e);
        }

        private void consulta2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Tabla_Conectados.Visible = true;
        }

        private void consulta1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Consulta_Tabla_Conectados_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Tabla_Conectados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //private void Play_Button_Click(object sender, EventArgs e)
        //{

        //    if (Play_Button.Text == "PLAY")
        //    {
        //        Panel_Consultas.Enabled = false;
        //        Play_Button.Enabled = true;
        //        Play_Button.Text = "STOP";
        //        RoadMover.Start();
        //        Enemy1_mover.Start();
        //        Enemy2_mover.Start();
        //    }
        //    else
        //    {
        //        Panel_Consultas.Enabled = true;

        //        Play_Button.Text = "PLAY";
        //        RoadMover.Stop();
        //        Enemy1_mover.Stop();
        //        Enemy2_mover.Stop();
        //    }
        //}




    }
}
