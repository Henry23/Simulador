using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Threading;

namespace Simulador.Views.Simulador
{
    public partial class Simular : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
         
        }

        public double currentTemp = 0.0;
        public double tankVolume = 0.0;
        public double timeInSeconds = 0.0;
        public double timeInSecondsChange = 0.0;
        public double energyInWatts = 0.0;
        public double timeElapsed = 0.0;
        public double tempFinalStatic = 0.0;

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

        protected void Button1_Click(object sender, EventArgs e)
        {
            // B8 -> Gallons
            // C8 -> Watts
            // D8 -> Start Temp
            // E8 -> Final Temp
            // =((B8*8.33*453.59237)*(((5/9)*(E8-32))-((5/9)*(D8-32)))/(C8*0.238845896628*F8))/60
            double minutos = 0.0;
            try
            {
                SqlDataSource1.SelectCommand = "SELECT * FROM [Datos] WHERE [Id] = " + DropDownList1.SelectedValue;
                this.SqlDataSource1.DataSourceMode = SqlDataSourceMode.DataReader;
                SqlDataReader datos = (SqlDataReader)this.SqlDataSource1.Select(DataSourceSelectArguments.Empty);
                var TempInicial = "";
                var Potencia = "";
                var VolumenInicial= "";
                var VolumenTotal= "";
                var costo = "";


                if (datos.Read())
                {
                    VolumenTotal = datos["cap_max_tanque"].ToString();
                    TempInicial = datos["temp_inicial_tanque"].ToString();
                    costo = datos["material_tanque"].ToString();
                    Potencia = datos["resistencia_watts"].ToString();
               //   TextBox5.Text = datos["cant_ml_s"].ToString();
                    VolumenInicial = datos["cant_ml_incial"].ToString();
                }
                try
                {
                    if (TempFinal.Text != "" )
                    {
                        var volumeInGallons = Int32.Parse(VolumenInicial) * 0.264;
                        var startTempInF = Int32.Parse(TempInicial);
                        var endTempInF = Int32.Parse(TempFinal.Text);
                        energyInWatts = Int32.Parse(Potencia);
                        if (startTempInF < endTempInF)
                        {
                             minutos = Math.Round(100 * ((volumeInGallons * 8.33 * 453.59237) * (endTempInF - startTempInF) /
                            (energyInWatts * 0.238845896628 * 95)) / 60);

                            //var Horas = (Math.Floor(Math.Abs(minutos) / 60));
                            minutos = (Math.Abs(minutos) % 60);
                            currentTemp = startTempInF;
                            tempFinalStatic = endTempInF;
                            tankVolume = Double.Parse(VolumenInicial);
                            TextBox8.Text = minutos + " Minutos";
                            timeInSeconds = minutos * 60;

                        }
                    }
                }catch(Exception ex) { }
               
            }
            catch (SqlException ex)
            {
                String mjs = ex.Message;
            }

        /*    ThreadStart childthreat = new ThreadStart(childthreadcall);
          // Response.Write("Child Thread Started <br/>");
           Thread child = new Thread(childthreat);

           child.Start();

           //Response.Write("Main sleeping  for 2 seconds.......<br/>");
           Thread.Sleep(10);
           //Response.Write("<br/>Main aborting child thread<br/>");
           child.Abort();*/
        }

        

       


 
        
      /*  public void childthreadcall()
        {
            try
            {
                Label3.Text = "<br />Child thread started <br/>";
                Label3.Text += "Child Thread: Coiunting to 10";

                for (int i = 0; i < 10; i++)
                {
                    Thread.Sleep(10);
                    Label1.Text += "<br/>" + i;
                }
              //  Label1.Text += "<br/> child thread finished";
            }
            catch (ThreadAbortException es)
            {
                Label1.Text += "<br /> child thread - exception";
            }
            finally
            {
                Label1.Text += "<br /> child thread - unable to catch the  exception";
            }
        }*/

        protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var listItems = CheckBoxList1.Items.Cast<ListItem>();
            listItems.Select(x => x.Enabled);
           
            var isNoneSelected = listItems.Any(x => x.Value == "None" && x.Selected == true);
            if (isNoneSelected)
            {
                listItems.Where(x => x.Value != "None").ToList().ForEach(x => x.Selected = false);
            }
        }
    }
}