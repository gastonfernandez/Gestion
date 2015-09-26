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

        private void Ingresar_click(object sender, EventArgs e)
        {
           /* el pass de prueba que use es asd para el usuario PEPE*/
          
            try
            {
                #region ValidarParametros
                if (!validoParametros(textoUsuario, textoPass))
                {
                    MessageBox.Show("Ingrese todos los valores");
                    
                }
                else
                {
                    DataTable dt = new BasedeDatos().select_query(" select usuario_ID , USERNAME, PASS from dbo.USUARIO;");
                    //DataTable dt = new BasedeDatos().select_query("select	pass from	USUARIO where	USERNAME= '" + textoUsuario + "';");
               

                    MessageBox.Show("VALIDO"); /* Validar logueo, de ser ok enviar al formulario principal. De ser error incrementar el valor del intentos y loguearlo*/
                }
                #endregion
            }
            catch (Exception ex)
            {
                throw new Exception("Se ha producido un error en el momento de realizar el logueo consulte al administrador" + ex.Message);
            }
                
            
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
