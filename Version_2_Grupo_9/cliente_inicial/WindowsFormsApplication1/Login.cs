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
    public partial class Login : Form
    {
        Socket server;
        int BinEscuchado = 9050;
        public Login()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }


  

        private void label1_Click(object sender, EventArgs e)
        {

        }

    
        private void entrar_Click(object sender, EventArgs e)
        {
            
            //Creamos un IPEndPoint con el ip del servidor y puerto del servidor 
            //al que deseamos conectarnos
            IPAddress direc = IPAddress.Parse("192.168.56.101");
            IPEndPoint ipep = new IPEndPoint(direc, BinEscuchado);


            //Creamos el socket 
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);


            try
            {
                server.Connect(ipep);//Intentamos conectar el socket
                //this.BackColor = Color.Green;
                
            }
            catch (SocketException)
            {
                //Si hay excepcion imprimimos error y salimos del programa con return 
                MessageBox.Show("No he podido conectar con el servidor");
                return;
            }


            // Quiere saber la longitud
            string mensaje = "0/"  + usernm.Text + "/" + psswd.Text + "/" + "relleno";
            // Enviamos al servidor el nombre tecleado
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            


            //Recibimos la respuesta del servidor
            byte[] msg2 = new byte[80];
            server.Receive(msg2);
            mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
            if (mensaje == "1")
            {
                MessageBox.Show("Inicializacion correcta");
                Consultas form = new Consultas();
                form.ShowDialog();
                
                
                
            }
            else if (mensaje == "0")
                MessageBox.Show("Error");

            
            
        }

        private void Regist_Click(object sender, EventArgs e)
        {




            //Creamos un IPEndPoint con el ip del servidor y puerto del servidor 
            //al que deseamos conectarnos
            IPAddress direc = IPAddress.Parse("192.168.56.101");
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
            string mensaje = "-1/" + usernm.Text + "/" + psswd.Text + "/" + Nicknm.Text;

            // Enviamos al servidor el nombre tecleado
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            //Recibimos la respuesta del servidor
            byte[] msg2 = new byte[80];
            server.Receive(msg2);
            mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];

            if (mensaje == "1")
                MessageBox.Show("Register Correct ");
            else if (mensaje == "0")
                MessageBox.Show("Register inCorrect ");
            
            



            //Form3 abrir = new Form3();
            //abrir.ShowDialog();
            
            Consultas form = new Consultas();
            form.ShowDialog();
        }

        

    }
}


