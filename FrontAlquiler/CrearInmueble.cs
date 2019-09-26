using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace FrontAlquiler
{
    public partial class Alquiler : Form
    {
        public Alquiler()
        {
            InitializeComponent();
        }

        private void Alquiler_Load(object sender, EventArgs e)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:64336/IUsuario.svc/UsuariosbyTipo/1");
            request.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string temp = reader.ReadToEnd();
            List<Usuario> tmp = js.Deserialize<List<Usuario>>(temp);
            cboInquilino.DataSource = tmp;
            cboInquilino.ValueMember = "Dni";
            cboInquilino.DisplayMember = "Nombre";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ServiceReference1.RegistrarGastosClient obj = new ServiceReference1.RegistrarGastosClient();
                ServiceReference1.Inmuebles obj2 = new ServiceReference1.Inmuebles();
                ServiceReference1.Inmuebles rpta = new ServiceReference1.Inmuebles();
                obj2.codigo = codigo.Text;
                obj2.direccion = direccion.Text;
                obj2.gAlquiler = Convert.ToDecimal(galquiler.Text);
                obj2.gMantenimiento = Convert.ToDecimal(gmant.Text);
                obj2.gAdicionales = Convert.ToDecimal(gadicionales.Text);
                obj2.idInquilino = int.Parse(cboInquilino.SelectedValue.ToString());
                rpta =obj.CrearInmueble(obj2);
                if (rpta != null)
                {
                    decimal total_ = Convert.ToDecimal(galquiler.Text) + Convert.ToDecimal(gmant.Text) + Convert.ToDecimal(gadicionales.Text);
                    MessageBox.Show("Correcto", "Registro creado",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                    codigo.Text = "";
                    direccion.Text = "";
                    galquiler.Text = "";
                    gmant.Text = "";
                    gadicionales.Text = "";

                    
                    ConnectionFactory connectionFactory = new ConnectionFactory();
                    connectionFactory.Uri = new Uri("amqp://gvxavqvf:mETkzN5KvUQAz6HW-ZqvQtHyBnmn9vMQ@wasp.rmq.cloudamqp.com/gvxavqvf");
                    IConnection connection = connectionFactory.CreateConnection();
                    var queueName = "inquilino"+obj2.idInquilino;
                    IModel model = connection.CreateModel();
                    model.QueueDeclare(queueName, false, false, false, null);
                    var exchangeName = "";
                    var routingKey = "inquilino" + obj2.idInquilino;
                    var data = Encoding.UTF8.GetBytes(total_.ToString());
                    model.BasicPublish(exchangeName, routingKey, true, null, data);

                }
                    
            }
            catch (FaultException<ServiceReference1.Excepciones> error)
            {
                MessageBox.Show(error.Detail.Descripcion, "Service error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }

        }

        private void gadicionales_TextChanged(object sender, EventArgs e)
        {
            if (gadicionales.Text != "")
            {
                decimal total_ = Convert.ToDecimal(galquiler.Text) + Convert.ToDecimal(gmant.Text) + Convert.ToDecimal(gadicionales.Text);
                total.Text = total_.ToString();
            }
            
        }

        
    }
}
