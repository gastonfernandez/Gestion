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
using AerolineaFrba.Mappings;




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
               
                    string valorEncriptado = SHA256Encripta(textoPass.Text);

                    BasedeDatos db = new BasedeDatos();



                    DataTable dt = db.select_query("  select usuario_ID , USERNAME, PASS, USUARIO_INHAB,USUARIO_INTENTOS,ROL_ID from dbo.USUARIO");
                      Usuario usu = new Usuario();
                    if (dt.Rows.Count > 1)
                    {
                        throw new Exception("Se produjo un problema al intentar iniciar sesion por favor concatese con el administrador");
                    
                    }
                    else
                    {
                        if(dt.Rows.Count==0)
                        {
                            throw new Exception ("El usuario ingresado es inexistente");
                        }
                        else
                        {
                      

                        foreach (DataRow row in dt.Rows)
                        {
                            usu.username= Convert.ToString(row["username"]);
                            usu.usuarioId = Convert.ToInt32(row["usuario_ID"]);
                            usu.pass = Convert.ToString(row["PASS"]);
                            usu.rolId = Convert.ToInt32(row["ROL_ID"]);
                            usu.usuarioIntentos = Convert.ToInt32(row["USUARIO_INTENTOS"]);
                            usu.usuarioInhabilitado = Convert.ToInt32(row["USUARIO_INHAB"]);

                            MessageBox.Show("");//logged_user.funcionalidades.Add(Convert.ToInt32(row["funcion_id"]));
                        }
                        }
                    }

                    if (usu.usuarioInhabilitado == 1)
                    {
                        throw new Exception("El usuario se encuentra bloqueado");
                    }
                    else
                    {
                        string msg;
                        if (usu.pass == valorEncriptado)
                        {
                            usu.usuarioInhabilitado = 0;
                            usu.usuarioIntentos = 0;
                            msg = "OK";


                        }
                        else
                        {
                            msg = "ERR";
                            if (usu.usuarioIntentos == 2)
                                usu.usuarioInhabilitado = 1;
                            else
                                usu.usuarioIntentos++;
                        }
                        string update = "update usuario " +
                                         " set USUARIO_INTENTOS= " + usu.usuarioIntentos + "," +
                                         "USUARIO_INHAB= " + usu.usuarioInhabilitado +
                                         "where usuario_ID= " + usu.usuarioId;
                        db.query(update);

                        /* loguear en tabla log */

                        //DataTable dt = new BasedeDatos().select_query("select	pass from	USUARIO where	USERNAME= '" + textoUsuario + "';");


                        /* Validar logueo, de ser ok enviar al formulario principal. De ser error incrementar el valor del intentos y loguearlo*/
                    }
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
