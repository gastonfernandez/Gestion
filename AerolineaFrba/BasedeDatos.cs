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

        SqlConnection conexion = new SqlConnection("Data Source=GASTON\\SQLSERVER2012;" + "Initial Catalog=GD2C2015;" + "Integrated Security=true;"
                + "UID=gd" + "PWD=gd2015");


        public void openConnection()
        {
            conexion.Open();
        }

        public void closeConnection() { conexion.Close(); }

        public DataTable select_query(String query)
        {

            try
            {
                conexion.Open();
                SqlCommand queryCommand = new SqlCommand(query, conexion);
                SqlDataReader queryCommandReader = queryCommand.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(queryCommandReader);
                conexion.Close();
                return dataTable;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + " Query: " + query);

            }

            return new DataTable();
        }


    }
}
