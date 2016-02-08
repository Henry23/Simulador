using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace Simulador.Views.Simulador
{
    public partial class Simular : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            try
            {
               
                SqlDataSource1.SelectCommand = "SELECT * FROM [Datos] WHERE [Id] = " + DropDownList1.SelectedValue;
                this.SqlDataSource1.DataSourceMode = SqlDataSourceMode.DataReader;
                SqlDataReader datos = (SqlDataReader)this.SqlDataSource1.Select(DataSourceSelectArguments.Empty);
                if (datos.Read())
                {                    
                    TextBox1.Text = datos["cap_max_tanque"].ToString();
                    TextBox2.Text = datos["temp_inicial_tanque"].ToString();
                    TextBox3.Text = datos["material_tanque"].ToString();
                    TextBox4.Text = datos["resistencia_watts"].ToString();
                    TextBox5.Text = datos["cant_ml_s"].ToString();
                    TextBox6.Text = datos["cant_ml_incial"].ToString();
                }
                else
                {
                    TextBox1.Text = "Somthing wroth happend";
                }
            }
            catch (SqlException ex)
            {
                String mjs = ex.Message;
            }
                  
        }

    }
}