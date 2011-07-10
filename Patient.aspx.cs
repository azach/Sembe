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
        
        if (Session.Count == 0 && patientId == null) { return; } //No patient information

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

        PatientName.Text = currentPatient.FormatName();
    }
}