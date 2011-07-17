using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.SessionState;
using System.Web.Security;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Check for authentication
        FormsIdentity id = (FormsIdentity) HttpContext.Current.User.Identity;
        FormsAuthenticationTicket ticket = id.Ticket;
        if (id.Ticket.Expired && !id.Ticket.IsPersistent)
        {
            Dictionary<string, string> Redirect = (Dictionary<string, string>)Application["Redirect"];
            Server.Transfer(Redirect["Default"]);
        }
    }
}
