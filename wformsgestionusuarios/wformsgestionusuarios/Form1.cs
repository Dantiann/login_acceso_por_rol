using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wformsgestionusuarios
{
    public partial class frmAcceso : Form
    {
        public frmAcceso()
        {
            InitializeComponent();
        }
        SqlConnection conexion = new SqlConnection("server=DESKTOP-NE3TVQ9\\SQLEXPRESS;database=gestionnotasd;integrated security=true");
        public void logear(string Usuario, string Password)
        {
            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SELECT usuario, password, rol FROM usuarios WHERE usuario=@Usuario AND password=@Password", conexion);
                cmd.Parameters.AddWithValue("Usuario", Usuario);
                cmd.Parameters.AddWithValue("Password", Password);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count == 1)
                {
                    this.Hide();
                    if (dt.Rows [0][2].ToString()=="1")
                    {
                        frmMenu frm = new frmMenu();
                        frm.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("El usuario y/o contraseña son incorrectos");
                }
            } 
            
            catch (Exception ex) { 
            }
            finally {
                conexion.Close();
            }
        }
                private void btnAceptar_Click(object sender, EventArgs e)
        {
            logear(this.txtUsuario.Text, txtPassword.Text);

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmAcceso_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void lblUsuario_Click(object sender, EventArgs e)
        {

        }

        private void lblAcceso_Click(object sender, EventArgs e)
        {

        }
    }
}
