using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace AerolineaFrba
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();  
        }

        private void button1_Click(object sender, EventArgs e)
        {


            if (!validoParametros(textoUsuario, textoPass))
            {
                MessageBox.Show("Ingrese todos los valores");
            }
            else
            {
                MessageBox.Show("VALIDO"); /* Validar logueo, de ser ok enviar al formulario principal. De ser error incrementar el valor del intentos y loguearlo*/
            }
            SqlConnection con = new SqlConnection();
            string datosConexion = "Data Source=GASTON\\SQLSERVER2012;" + "Initial Catalog=GD2C2015;" + "Integrated Security=true;"
                + "UID=gd" + "PWD=gd2015";

            con.ConnectionString = datosConexion;
            

            try
            {
                con.Open();
                /* ejemplo para tomar variable
                 */
                //string textoCmd = "SELECT @cantidad = COUNT(*) FROM TABLET "+ "WHERE PRECIO >@precio";

                //SqlCommand cmd = new SqlCommand(textoCmd,con);

               // SqlParameter p1 = new SqlParameter("@precio", Convert.ToInt32(textBox_precio.Text));
                //p1.Direction = ParameterDirection.Input;

                //SqlParameter p2 = new SqlParameter("@cantidad", null);
                //p2.Direction = ParameterDirection.Output;
                //p2.SqlDbType = SqlDbType.Int;

                //cmd.Parameters.Add(p1);
               // cmd.Parameters.Add(p2);
               // cmd.Parameters["@cantidad"].Value;
               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {
            


        }
        private string SHA256Encripta(string input)
        {
            SHA256CryptoServiceProvider provider = new SHA256CryptoServiceProvider();

            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashedBytes = provider.ComputeHash(inputBytes);

            StringBuilder output = new StringBuilder();

            for (int i = 0; i < hashedBytes.Length; i++)
                output.Append(hashedBytes[i].ToString("x2").ToLower());

            return output.ToString();
        }
        private Boolean validoParametros(TextBox usuario, TextBox pass)
        {
            if (usuario.Text == string.Empty || pass.Text == string.Empty)
                return false;
            else
                return true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textoUsuario_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
