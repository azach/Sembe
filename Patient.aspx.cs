using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Patient : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        System.Text.StringBuilder displayValues =
            new System.Text.StringBuilder();
        System.Collections.Specialized.NameValueCollection
            postedValues = Request.Form;
        String nextKey;
        for (int i = 0; i < postedValues.AllKeys.Length; i++)
        {
            nextKey = postedValues.AllKeys[i];
            if (nextKey.Substring(0, 2) != "__")
            {
                //displayValues.Append(nextKey);
                displayValues.Append(postedValues[i]);
            }
        }
        PatientName.Text = displayValues.ToString();
    }
}