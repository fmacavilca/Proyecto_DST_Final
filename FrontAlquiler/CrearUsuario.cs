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
    public partial class CrearUsuario : Form
    {
        public CrearUsuario()
        {
            InitializeComponent();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();

            try { 
                Usuario obj = new Usuario();
                obj.Dni = int.Parse(txtDNI.Text);
                obj.Nombre = txtNombre.Text;
                obj.Apellido  = txtApelldo.Text;
                obj.Sexo = txtSexo.Text;
                obj.password = txtPass.Text;
                obj.celular = txtCelular.Text;
                obj.esInquilino = 1;

                

                 string postdata = js.Serialize(obj);
                Byte[] data = Encoding.UTF8.GetBytes(postdata);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:64336/IUsuario.svc/CrearUsuario");
                request.Method = "POST";
            request.ContentLength = data.Length;
            request.ContentType = "application/json";
            var requestStream = request.GetRequestStream();
            requestStream.Write(data, 0, data.Length);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string temp = reader.ReadToEnd();

            Usuario rpta = js.Deserialize<Usuario>(temp);
                if (rpta != null)
                {
                    MessageBox.Show("Usuario Creado", "Service ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error en la Creación", "Service ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            } 
            catch(WebException ex)
            {
                HttpStatusCode Codigo = ((HttpWebResponse)ex.Response).StatusCode;
                StreamReader reader2 = new StreamReader(ex.Response.GetResponseStream());
                string tmp2 = reader2.ReadToEnd();
                Excepciones rpta = js.Deserialize<Excepciones>(tmp2);
                MessageBox.Show(rpta.Descripcion, "Service error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }






        }

        private void CrearUsuario_Load(object sender, EventArgs e)
        {

        }
    }
}
