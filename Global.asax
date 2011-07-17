<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        //Create global redirects
        Dictionary<string, string> Redirect = new Dictionary<string,string>();
        Redirect.Add("Default", "/Default.aspx");
        Application["Redirect"] = Redirect;
    }
    
    void Application_End(object sender, EventArgs e) 
    {        
    }
        
    void Application_Error(object sender, EventArgs e) 
    {
        Dictionary<string, string> Redirect = (Dictionary<string, string>) Application["Redirect"];
        Server.Transfer(Redirect["Default"]);
    }

    void Session_Start(object sender, EventArgs e) 
    {
    }

    void Session_End(object sender, EventArgs e) 
    {
        //TODO: Release any locks
    }
       
</script>
