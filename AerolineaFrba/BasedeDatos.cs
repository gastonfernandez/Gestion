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
    public partial class BasedeDatos : Form
    {
        public BasedeDatos()
        {
            InitializeComponent();
        }

        private void BasedeDatos_Load(object sender, EventArgs e)
        {

        }

        SqlConnection conexion = new SqlConnection("Data Source=LOCALHOST\\SQLSERVER2012;" + "Initial Catalog=GD2C2015;" + "Integrated Security=true;"
                + "UID=sa" + "PWD=GestionDeDatos2015");


        public void openConnection()
        {
            conexion.Open();
        }
    }
}
