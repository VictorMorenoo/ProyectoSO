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
using System.Threading;

namespace clienteForm
{
    public partial class Consultas : Form
    {
        Socket server;
        Thread atender;
        
        string ID1 = "169.254.0.4";  //Vic
       
        
       // string ID1 = "192.168.56.101"; //Uli
        //string ID1 = "147.83.117.22";  //IP para shiva
        int BinEscuchado = 9050;
        //int BinEscuchado = 50075; //Puerto shiva
        int Speed;
        int Score = 0;
        String[] trozos = new String[100];
        PictureBox[] Road = new PictureBox[100];
        int NumRoads = 9;
        Random rnd = new Random();
      

        string Logeado = "NO";
        string Password;
        string Username;
        string Nickname;
        

        public Consultas()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        public void Inicializar(string nom, string user, string pass)
        {
            this.Nickname = nom;
            this.Password = pass;
            this.Username = user;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
       
            //Creamos server


            //Creamos un IPEndPoint con el ip del servidor y puerto del servidor 
            //al que deseamos conectarnos
            IPAddress direc = IPAddress.Parse(ID1);
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


            
            //



            
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


            ThreadStart ts = delegate { AtenderServidor(); };
            atender = new Thread(ts);
            atender.Start();

            Tabla_Conectados.Visible = true;


        }


        private void AtenderServidor() // funcion para atender al servidor
        {
            while (true)
            {
                //Recibimos mensaje del servidor
                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                string respuesta = Encoding.ASCII.GetString(msg2).Split('\0')[0];//netejar de basura

                string[] trozos = respuesta.Split('/');// Codigo/codigo error o numero filas/mensaje
                //MessageBox.Show(respuesta);

                int codigo = Convert.ToInt32(trozos[0]);//Sacamos el codigo correspondiente a que respuesta es
                string mensaje;

                

                switch (codigo)
                {
                   
            
                    case 0:
                        mensaje = trozos[1].Split('\0')[0];
                       
                        string mensaje1 = (trozos[1]);

                        try
                        {
                            if (mensaje1 == "1")
                            {
                                MessageBox.Show("Inicializacion correcta");
                                Logeado = "SI";
                                
                             



                            }
                            else if (mensaje1 == "-1")
                                MessageBox.Show("Wrong Password");
                            else if (mensaje == "-2")
                                MessageBox.Show("Usser Already on loby");

                        }
                        catch (SocketException)
                        {
                            MessageBox.Show("ERROR");
                        }
            




                        break;
                    case 1:  //Petición 1 

                        mensaje = trozos[1].Split('\0')[0];
                        MessageBox.Show("Jugador que ha ganado la partida con duracion 40 minutos: " + mensaje);
                        break;
                    case 2:      //Petición2
                        mensaje = trozos[1].Split('\0')[0];
                        MessageBox.Show("El jugador que mas partidas ha perdido es: " + mensaje);

                        break;
                    case 3:       //Petición3
                        mensaje = trozos[1].Split('\0')[0];
                        MessageBox.Show("El jugador que ha ganado la partida mas larga es: " + mensaje);

                        break;


                    case 4:       //Petición4
                        mensaje = trozos[1].Split('\0')[0];
                        MessageBox.Show("El Jugador con ID: " + Convert.ToString(nombre.Text) + " es: " + mensaje);
                        break;

                    case 5 :
                        MessageBox.Show("inside code 5");
                        mensaje = trozos[1].Split('\0')[0];
                        string [] mensaje2 = mensaje.Split(' ');
                        LLenaUsuarios(mensaje2);
                        
                        server.Shutdown(SocketShutdown.Both);
                        server.Close();
                       
                        MessageBox.Show("after atender abort");
                        this.Close();
                        atender.Abort(); // preguntar amiguel donde poner esto
                        break;
                    case 6:
                       
                        mensaje = trozos[1].Split('\0')[0];
                        string [] mensaje3 = mensaje.Split(' ');
                        

                        LLenaUsuarios(mensaje3);

                        break;
                }
            }
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

            this.Username = usernm.Text;
            this.Password = psswd.Text;
            this.Nickname = Nicknm.Text;

            ////Creamos un IPEndPoint con el ip del servidor y puerto del servidor 
            ////al que deseamos conectarnos
            //IPAddress direc = IPAddress.Parse(ID1);
            //IPEndPoint ipep = new IPEndPoint(direc, BinEscuchado);


            ////Creamos el socket 
            //server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);


            //try
            //{
            //    server.Connect(ipep);//Intentamos conectar el socket


               



            //}
            //catch (SocketException)
            //{
            //    //Si hay excepcion imprimimos error y salimos del programa con return 
            //    MessageBox.Show("No he podido conectar con el servidor");
            //    return;
            //}




            if (Logeado == "NO")
            {
                // Quiere saber la longitud
                string mensaje = "0/" + this.Username + "/" + this.Password + "/" + this.Nickname;
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }
         

            else if (Logeado == "SI")
            {



                if (consulta3.Checked)
                {
                    // Quiere saber la longitud
                    string mensaje = "3/" + "Prueba/" + "relleno/" + "relleno";
                    // Enviamos al servidor el nombre tecleado
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);

                    //Recibimos la respuesta del servidor
                    //byte[] msg2 = new byte[80];
                    //server.Receive(msg2);
                    //mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                    //MessageBox.Show("El jugador que ha ganado la partida mas larga es: " + mensaje);
                }
                else if (consulta2.Checked)
                {
                    // Quiere saber si el nombre es bonito
                    string mensaje = "2/" + "Prueba/" + "relleno/" + "relleno";
                    // Enviamos al servidor el nombre tecleado
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);

                    //Recibimos la respuesta del servidor
                    //byte[] msg2 = new byte[80];
                    //server.Receive(msg2);
                    //mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];

                    //MessageBox.Show("El jugador que mas partidas ha perdido es: " + mensaje);


                }
                else if (consulta1.Checked)
                {
                    try
                    {
                        // Quiere saber si el nombre es bonito
                        string mensaje = "1/" + "Prueba/" + "relleno/" + "relleno";
                        // Enviamos al servidor el nombre tecleado
                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                        server.Send(msg);

                        //Recibimos la respuesta del servidor
                        //byte[] msg2 = new byte[80];
                        //server.Receive(msg2);
                        //mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];


                    }
                    catch (SocketException)
                    {
                        MessageBox.Show("Error 202 : Server Closed");
                    }


                }

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

    

        private void button_Desconectar_Click(object sender, EventArgs e)
        {

            ////Creamos un IPEndPoint con el ip del servidor y puerto del servidor 
            ////al que deseamos conectarnos
            //IPAddress direc = IPAddress.Parse(ID1);
            //IPEndPoint ipep = new IPEndPoint(direc, BinEscuchado);


            ////Creamos el socket 
            //server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);


            //try
            //{
            //    server.Connect(ipep);//Intentamos conectar el socket
            //}
            //catch (SocketException)
            //{
            //    //Si hay excepcion imprimimos error y salimos del programa con return 
            //    MessageBox.Show("No he podido conectar con el servidor");
            //    return;
            //}

            //string UserDelete = Login.Username;

            // Quiere saber la longitud
            string mensaje = "5/" + this.Username + "/relleno/" + "relleno";
            // Enviamos al servidor el nombre tecleado
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);




            //atender.Abort();




            //Recibimos la respuesta del servidor
            //byte[] msg2 = new byte[80];
            //server.Receive(msg2);
            //mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];




            //server.Shutdown(SocketShutdown.Both);
            //server.Close();

            //this.Close();
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
            if (Car.Location.X > 180)//mirar las dimensiones de la road
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

        private void Replay_Button_Click1(object sender, EventArgs e)
        {
        
        }

      
        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void Consulta_Tabla_Conectados_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void consulta1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void consulta4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void nombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void Tabla_Conectados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Play_Button_Click(object sender, EventArgs e)
        {
           
            Play_Button.Enabled = false;




             if (Play_Button.Text == "PLAY")
            {
                Panel_Consultas.Enabled = false;
                Play_Button.Enabled = false;

                RoadMover.Start();
                Enemy1_mover.Start();
                Enemy2_mover.Start();
                Panel_Map.Visible = true;
                 Play_Button.Text = "STOP";
            }
            else
            {
                Panel_Map.Visible = false;
                Panel_Consultas.Enabled = true;


                RoadMover.Stop();
                Enemy1_mover.Stop();
                Enemy2_mover.Stop();
                  Play_Button.Text = "PLAY";
            }
        }

        private void Replay_Button_Click_1(object sender, EventArgs e)
        {
            Score = 0;
            Controls.Clear();
            InitializeComponent();
            //Consultas_Load(e, e);
            Form1_Load(e, e);

        }

          




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

