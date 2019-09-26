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
    public partial class EditarUsuario : Form
    {
        public EditarUsuario()
        {
            InitializeComponent();
        }

        private void EditarUsuario_Load(object sender, EventArgs e)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:64336/IUsuario.svc/Usuario/"+VariableGlobal.dniuser.Dni    .ToString());
            request.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string temp = reader.ReadToEnd();
            Usuario tmp = js.Deserialize<Usuario>(temp);
            VariableGlobal.dniuser.esInquilino = tmp.esInquilino;

            txtNombre.Text = tmp.Nombre;
            txtApelldo.Text = tmp.Apellido;
            txtSexo.Text = tmp.Apellido;
            txtCelular.Text = tmp.celular;
            
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            Usuario obj = new Usuario();
            obj.Dni = VariableGlobal.dniuser.Dni;
            obj.Nombre = txtNombre.Text;
            obj.Apellido = txtApelldo.Text;
            obj.Sexo = txtSexo.Text;
            obj.password = txtPass.Text;
            obj.celular = txtCelular.Text;
            obj.esInquilino = VariableGlobal.dniuser.esInquilino;



            string postdata = js.Serialize(obj);
            Byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:64336/IUsuario.svc/ModificarUsuario");
            request.Method = "PUT";
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
                MessageBox.Show("Usuario modificado", "Service ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Error en la modificación", "Service ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
