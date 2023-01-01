using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI;
using ParkingManager.Models;
using ParkingManager.Services;

namespace ParkingManager
{
    public partial class _Default : Page
    {
        LotsService lotsService = new LotsService();
        UserService userService = new UserService();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (CheckInput())
            {
                String name = Name.Text.Trim();
                Int32 id = Int32.Parse(Id.Text);
                Int32 phone = Int32.Parse(Phone.Text);
                String ticket = Ticket.Text.Trim();
                String type = Type.Text.Trim();
                float height = float.Parse(this.Height.Text);
                float width = float.Parse(this.Width.Text);
                float length = float.Parse(this.Length.Text);

                User user = new User(id, name, phone, ticket, type, height, width, length);
                userService.InsertUser(user);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Message", "alert('Successfully Added')", true);
                ClearAll();
            }
        }


        private Boolean CheckInput()
        {
            if (Name.Text != "" && Id.Text != "" && Phone.Text != "" && Ticket.Text != "" && Type.Text != "" && Height.Text != "" && Width.Text != "" && Length.Text != "")
            {
                if ((!IsInt(Name.Text)) && (!IsFloat(Name.Text)))
                {
                    if (IsInt(Id.Text) && IsInt(Phone.Text) && IsFloat(Height.Text) && IsFloat(Width.Text) && IsFloat(Length.Text))
                    {
                        if (!lotsService.IsIdregistered(Id.Text))
                            return true;

                        else
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Message", "alert(' ID is already registered')", true);
                            return false;
                        }
                    }

                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Message", "alert(' Invalid input in one or more fields')", true);
                        return false;
                    }
                }

                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Message", "alert('Invalid Name')", true);
                    return false;
                }
            }

            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Message", "alert('Fill All Fields')", true);
            }

            return false;

        }

        private void ClearAll()
        {
            Name.Text = "";
            Id.Text = "";
            Phone.Text = "";
            Ticket.SelectedIndex = -1;
            Type.SelectedIndex = -1;
            Height.Text = "";
            Width.Text = "";
            Length.Text = "";
        }

        public bool IsFloat(string value)
        {            
            return float.TryParse(value, out float floatValue);
        }

        public bool IsInt(string value)
        {            
            return Int32.TryParse(value, out int intValue);
        }
    }
}