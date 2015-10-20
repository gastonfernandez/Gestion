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
           /* el pass de prueba que use es AAAA para el usuario PEPE*/
          
            try
            {
                #region ValidarParametros y Usuario
                if (!validoParametros(textoUsuario, textoPass))
                {
                    MessageBox.Show("Ingrese todos los valores");
                    
                }
                else
                {

                    #region ObtenerUsuario
                    Usuario usu = new Usuario();

                    usu = usu.getUser(textoUsuario.Text, textoPass.Text);
                    #endregion  
                   
                    if (usu==null)
                        MessageBox.Show("La contraseña ingresada es incorrecta");
                    else
                        MessageBox.Show("Se ha logueado correctamente"); /* aca hay que hacer lo que siga*/

                    }

                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.Message); //throw new Exception("Se ha producido un error en el momento de realizar el logueo consulte al administrador" + ex.Message);
            }
                
            
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
