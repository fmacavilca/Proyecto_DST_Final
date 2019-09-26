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
using System.Windows.Forms;

namespace FrontAlquiler
{
    public partial class Login : Form
    {
        public int dnilogin=0;
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:64336/IUsuario.svc/Login/" + txtDNI.Text + "/" + txtPass.Text);
                request.Method = "GET";
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string temp = reader.ReadToEnd();
                if (temp.Contains("true"))
                {
                    dnilogin = int.Parse(txtDNI.Text);
                VariableGlobal.dniuser.Dni = dnilogin;
                
                Menu frmMenu = new Menu();
                    frmMenu.ShowDialog();
                Close();


            }
                else
                {
                    MessageBox.Show("Credenciales no válidas", "Service error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                
                

            
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            CrearUsuario form = new CrearUsuario();
            form.ShowDialog();
        }
    }
}
