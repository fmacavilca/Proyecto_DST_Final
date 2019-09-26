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
    public partial class EnviarSMS : Form
    {
        public EnviarSMS()
        {
            InitializeComponent();
        }

        private void EnviarSMS_Load(object sender, EventArgs e)
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

        private void BtnEnviar_Click(object sender, EventArgs e)
        {

            JavaScriptSerializer js = new JavaScriptSerializer();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:64336/IUsuario.svc/Usuario/" +cboInquilino.SelectedValue.ToString());
            request.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string temp = reader.ReadToEnd();
            Usuario tmp = js.Deserialize<Usuario>(temp);

            ServiceReference1.RegistrarGastosClient obj = new ServiceReference1.RegistrarGastosClient();
            
            ServiceReference1.Inmuebles rpta = new ServiceReference1.Inmuebles();
            ServiceReference1.Inmuebles tmp2 = new ServiceReference1.Inmuebles();
            tmp2.idInquilino = tmp.Dni;
            rpta = obj.ObtenerbyInquilino(tmp2);
            decimal total = rpta.gAlquiler + rpta.gAdicionales + rpta.gMantenimiento;
            string celular = "51" + tmp.celular;
            string sms = "Estimado inquilino " + tmp.Nombre + " por favor cancelar la deuda pendiente del departamento monto total: " + total.ToString();
            HttpWebRequest loHttp =
              (HttpWebRequest)WebRequest.Create("http://www.altiria.net/api/http");
            // Compone el mensaje a enviar
            // 33
            //Especificaciones de la Interfaz HTTP para env´ıo de SMS
            // XX, YY y ZZ se corresponden con los valores de identificaci´on del usuario en el sistema.
            string lcPostData = $"cmd=sendsms&domainId=test&login=frank.diego14@gmail.com&passwd=59cxmaq9&dest={celular}&msg={sms}";
            //es posible utilizar el remitente en Am´erica pero s´ı en Espa~na y Europa
            //Descomentar la l´ınea solo si se cuenta con un remitente autorizado por Altiria
            //cmd=cmd + "&senderId=remitente";
            // Se codifica en utf-8
            byte[] lbPostBuffer = System.Text.Encoding.GetEncoding("utf-8").GetBytes(lcPostData);
            loHttp.Method = "POST";
            loHttp.ContentType = "application/x-www-form-urlencoded";
            loHttp.ContentLength = lbPostBuffer.Length;
            //Fijamos tiempo de espera de respuesta = 60 seg
            loHttp.Timeout = 60000;
            String error = "";
            String response2 = "";
            // Env´ıa la peticion
            try
            {
                Stream loPostData = loHttp.GetRequestStream();
                loPostData.Write(lbPostBuffer, 0, lbPostBuffer.Length);
                loPostData.Close();
                // Prepara el objeto para obtener la respuesta
                HttpWebResponse loWebResponse = (HttpWebResponse)loHttp.GetResponse();
                // La respuesta vendr´ıa codificada en utf-8
                Encoding enc = System.Text.Encoding.GetEncoding("utf-8");
                StreamReader loResponseStream =
                new StreamReader(loWebResponse.GetResponseStream(), enc);
                // Conseguimos la respuesta en una cadena de texto
                response2 = loResponseStream.ReadToEnd();
                loWebResponse.Close();
                loResponseStream.Close();
            }
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ConnectFailure)
                    error = "Error en la conexion";
                else if (ex.Status == WebExceptionStatus.Timeout)
                    error = "Error TimeOut";
                else
                    error = ex.Message;
            }
            MessageBox.Show("Mensaje Enviado Correctamente", "Registro creado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
