using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using ParkingManager.Services;
using ParkingManager.Models;
using static ParkingManager.Models.Ticket;

namespace ParkingManager
{
    public partial class About : Page
    {
        LotsService lotsService = new LotsService();
        UserService userService = new UserService();

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadRecord();
        }

        public bool IsInt(string value)
        {
            return Int32.TryParse(value, out int intValue);
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            if (IdTextBox.Text != "" && IsInt(IdTextBox.Text) && (lotsService.IsIdregistered(IdTextBox.Text)))
            {
                Int32 id = Int32.Parse(IdTextBox.Text);
                if (!lotsService.IsIdPark(id))
                {
                    var user = userService.GetUserById(id);
                    var ticket = new Ticket(user.TicketType);

                    if (ticket.ValidateTicket(user.Vehicle.Class) && ticket.ValidateDimension(user.Vehicle))
                    {
                        lotsService.SetParkingLot(id, ticket);
                    }

                    else
                    {
                        TicketType ticketOption = Ticket.GetMinimalTicketPrice(user.Vehicle);
                        int extra = ticket.ExtraMoney(ticketOption);
                        DialogResult dialogResult = MessageBox.Show($"Add {extra}$ and buy {ticketOption} ticket","Message",MessageBoxButtons.YesNo,MessageBoxIcon.Warning,MessageBoxDefaultButton.Button1,MessageBoxOptions.DefaultDesktopOnly);
                        if (dialogResult == DialogResult.Yes)
                        {
                            var newTicket = new Ticket(ticketOption);
                            lotsService.SetParkingLot(id, newTicket);
                            lotsService.UpdateTicket(ticketOption.ToString(), id);
                            LoadRecord();
                        }                     
                    }
                }
                else
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Message", "alert('The vehicle is already in the parking lot')", true);
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
    }
}