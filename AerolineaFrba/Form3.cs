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

namespace AerolineaFrba
{
    public partial class Form3 : Form
    {

        //Variables

        SqlConnection conexion = new SqlConnection("Server=192.168.0.100,1433\\SQLSERVER2012; Database=GD2C2015; User Id=sa; Password=GestionDeDatos2015");

        //Abro la conexión de red//


        public Form3()
        {
            InitializeComponent();
        }


        private void Form3_Load(object sender, EventArgs e)
        {
            try
            {
                conexion.Open();
                MessageBox.Show("La conexión fue exitosa");
                conexion.Close();
            }

            catch (SqlException)
            {
                MessageBox.Show("No se pudo realizar la conexión");
            }
        }
    }
}
