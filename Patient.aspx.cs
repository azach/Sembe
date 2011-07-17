using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.SessionState;

public partial class Patient : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string patientId = Request.Form["patientId"];
        Sembe.Patient currentPatient = null;

        //TODO: Support multiple patient workspaces

        //No patient information
        if (Session.Count == 0 && patientId == null) {
            Dictionary<string, string> Redirect = (Dictionary<string, string>) Application["Redirect"];
            Server.Transfer(Redirect["Default"]); 
        }

        if (patientId != null) {
            Session["patientId"] = patientId;
            currentPatient = new Sembe.Patient(Convert.ToInt32(patientId));
            currentPatient.Initialize();
            Session["patientObject"] = currentPatient;
        }
        else
        {
            patientId = (string) Session["patientId"];
            currentPatient = (Sembe.Patient) Session["patientObject"];
        }

        FullName.Text = currentPatient.FormatName();
        BasicDemographics.Text =
            "<b>ID:</b> " + currentPatient.ID.ToString() + " " +
            "<b>Sex:</b> " + currentPatient.Sex.ToString() + " " +
            "<b>Date of Birth:</b> ";
            if (!String.IsNullOrWhiteSpace(currentPatient.DOB.ToString())) {
               BasicDemographics.Text += String.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(currentPatient.DOB));
            }
    }
}