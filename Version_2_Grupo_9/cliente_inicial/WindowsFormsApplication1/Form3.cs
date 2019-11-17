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
    public partial class Form3 : Form
    {
        int BinEscuchado = 9051;
        Socket server;
        public Form3()
        {
            InitializeComponent();
        }

        private void Register_Click(object sender, EventArgs e)
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
            string mensaje = "-1/"  + Username_Box.Text + "/" + Password_Box.Text + "/"+ Nickname_Box.Text;
         
            // Enviamos al servidor el nombre tecleado
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            //Recibimos la respuesta del servidor
            byte[] msg2 = new byte[80];
            server.Receive(msg2);
            mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];

            if (mensaje == "1")
                MessageBox.Show("Register Correct " );
            else if (mensaje== "0")
                MessageBox.Show("Register inCorrect " );
            this.Close();
            
        }
    }
}
