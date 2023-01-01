using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ParkingManager
{
    public partial class Contact : Page
    {        
        LotsService lotsService = new LotsService();

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadRecord();
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            if (IdTextBox.Text != "" && IsInt(IdTextBox.Text) && (lotsService.IsIdregistered(IdTextBox.Text)))
            {
                Int32 id = Int32.Parse(IdTextBox.Text);
                if (lotsService.FreeLot(id))
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Message", "alert('The vehicle was successfully removed from the parking lot')", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Message", "alert('The vehicle is not in the parking lot')", true);
                }
            }

            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Message", "alert('Invalid Id')", true);
            }

            LoadRecord();
        }

        protected void LoadRecord()
        {
            DataTable ds = lotsService.GetTable();
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }


        public bool IsInt(string value)
        {
            return Int32.TryParse(value, out int intValue);
        }

      
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}