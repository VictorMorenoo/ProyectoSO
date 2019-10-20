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

namespace clienteForm
{
    public partial class Consultas : Form
    {
        Socket server;
        public Consultas()
        {

            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }


        private void enviar_Click(object sender, EventArgs e)
        {

            //Creamos un IPEndPoint con el ip del servidor y puerto del servidor 
            //al que deseamos conectarnos
            IPAddress direc = IPAddress.Parse("192.168.56.101");
            IPEndPoint ipep = new IPEndPoint(direc, 9050);


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
                string mensaje = "3/" + "Prueba";
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
                string mensaje = "2/" + "Prueba";
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
                string mensaje = "1/" + "Prueba";
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

                //Recibimos la respuesta del servidor
                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];

                MessageBox.Show("Jugador que ha ganado la partida con duracion 40 minutos: " + mensaje);


            }

            else if (consulta4.Checked) {

                // Quiere saber si el nombre es bonito
                string mensaje = "4/" + Convert.ToString(nombre.Text);
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

                //Recibimos la respuesta del servidor
                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];

                MessageBox.Show("El Jugador con ID: " + Convert.ToString(nombre.Text)+ " es: " + mensaje);


            
            
            }


            //}
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
            IPAddress direc = IPAddress.Parse("192.168.56.101");
            IPEndPoint ipep = new IPEndPoint(direc, 9050);


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

            // Quiere saber la longitud
            string mensaje = "5/" + "Desconectar";
            // Enviamos al servidor el nombre tecleado
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            //Recibimos la respuesta del servidor
            //byte[] msg2 = new byte[80];
            //server.Receive(msg2);
            //mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
            //MessageBox.Show("La longitud de tu nombre es: " + mensaje);

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




    }
}
