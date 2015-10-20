using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Data.SqlClient;
using System.Data;

namespace AerolineaFrba.Mappings
{
    class Usuario
    {
        public Int32 usuarioId=0;
        public String username = "";
        public String pass = "";
        public Int32 rolId = 0;
        public int usuarioIntentos;
        public int usuarioInhabilitado;
         


        public Usuario getUser(String login, String pass)
        {
            string valorEncriptado = SHA256Encripta(pass);

            #region ValidarUsuarioyPass Contra la base
            BasedeDatos db = new BasedeDatos();
            
                    DataTable dt = db.select_query("  select usuario_ID , USERNAME, PASS, USUARIO_INHAB,USUARIO_INTENTOS,ROL_ID from [#GDD].USUARIO where username= '"+login+"'");
                     
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
                            this.username= Convert.ToString(row["username"]);
                            this.usuarioId = Convert.ToInt32(row["usuario_ID"]);
                            this.pass = Convert.ToString(row["PASS"]);
                            this.rolId = Convert.ToInt32(row["ROL_ID"]);
                            this.usuarioIntentos = Convert.ToInt32(row["USUARIO_INTENTOS"]);
                            this.usuarioInhabilitado = Convert.ToInt32(row["USUARIO_INHAB"]);

                            
                        }
                        }
                    }

                    if (this.usuarioInhabilitado == 1)
                    {
                        throw new Exception("El usuario se encuentra bloqueado");
                    }
                    else
                    {
                        #region CompararValor Ingresado contra la base
                        String Msg = String.Empty;
                        if (this.pass == valorEncriptado)
                        {
                            Msg = "OK";
                            this.usuarioInhabilitado = 0;
                            this.usuarioIntentos = 0;
                        }
                        else
                        {
                            Msg = "ERR";
                            if (this.usuarioIntentos == 2)
                                this.usuarioInhabilitado = 1;
                            else
                                this.usuarioIntentos++;
                        }
                        #endregion

                        #region ModificarValor en base a lo procesado
                        string update = "update [#GDD].usuario " +
                                         " set USUARIO_INTENTOS= " + this.usuarioIntentos + "," +
                                         "USUARIO_INHAB= " + this.usuarioInhabilitado +
                                         " where usuario_ID= " + this.usuarioId;
                        db.query(update);
                        #endregion

                        if (Msg == "ERR")
                            return null;
                        else
                            return this;
                    }
            #endregion


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
      
    }
}
