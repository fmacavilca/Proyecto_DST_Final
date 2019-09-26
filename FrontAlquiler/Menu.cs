using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace FrontAlquiler
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Alquiler alq = new Alquiler();
            alq.ShowDialog();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            EditarUsuario form = new EditarUsuario();
            form.ShowDialog();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:64336/IUsuario.svc/Usuario/" + VariableGlobal.dniuser.Dni.ToString());
            request.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string temp = reader.ReadToEnd();
            Usuario tmp = js.Deserialize<Usuario>(temp);


            ConnectionFactory connectionFactory = new ConnectionFactory();
            connectionFactory.Uri = new Uri("amqp://gvxavqvf:mETkzN5KvUQAz6HW-ZqvQtHyBnmn9vMQ@wasp.rmq.cloudamqp.com/gvxavqvf");
            IConnection connection = connectionFactory.CreateConnection();
            IModel channel = connection.CreateModel();
            channel.QueueDeclare("inquilino"+tmp.Dni, false, false, false, null);
            var queueName = "inquilino" + tmp.Dni;
            var data = channel.BasicGet(queueName, false);
            var message = Encoding.UTF8.GetString(data.Body);
            channel.BasicAck(data.DeliveryTag, false);
            
            MessageBox.Show("El monto total es: "+message);
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:64336/IUsuario.svc/Usuario/" + VariableGlobal.dniuser.Dni.ToString());
            request.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string temp = reader.ReadToEnd();
            Usuario tmp = js.Deserialize<Usuario>(temp);

            if (tmp.esInquilino == 1)
            {
                button1.Visible = false;
                button3.Visible = false;
            }
            else
            {
                button4.Visible = false;

            }


        }

        private void Button3_Click(object sender, EventArgs e)
        {
            EnviarSMS form = new EnviarSMS();
            form.ShowDialog();
        }
    }
}
