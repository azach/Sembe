using System;
using System.Collections.Generic;
using System.Web.Services;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Runtime.Serialization.Json;
using MySql.Data.MySqlClient;

/// <summary>
/// Summary description for PatientService
/// </summary>
[WebService(Namespace = "Sembe")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService] //Allow javascript to access web service
public class PatientService : System.Web.Services.WebService {

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string FindPatient(string fname, string lname, string dob, string sex, string mrn)
    {
        if ((String.IsNullOrWhiteSpace(fname)) & (String.IsNullOrWhiteSpace(lname)) & (String.IsNullOrWhiteSpace(mrn)))
        {
            throw new ArgumentException("Please enter a name or MRN");
        }

        //Set up DB access
        string connString = System.Configuration.ConfigurationManager.ConnectionStrings["MySQL"].ConnectionString;
        MySqlConnection connection = new MySqlConnection(connString);
        MySqlCommand command = connection.CreateCommand();
        MySqlDataReader reader;

        //Configure search query
        if (!String.IsNullOrWhiteSpace(mrn)) { command.CommandText = "SELECT id,first_name,last_name,birth_date,sex FROM patient WHERE id=" + mrn; }
        else { 
            command.CommandText = "SELECT * FROM patient WHERE first_name=\"" + fname + "\"";
        }

        //Configure JSON data to return
        JavaScriptSerializer ser = new JavaScriptSerializer();
        List<Patient> foundPatients = new List<Patient>();

        //Get results
        connection.Open();
        reader = command.ExecuteReader();

        if (reader.HasRows)
        {
            while (reader.Read())
            {
                foundPatients.Add(new Patient() { 
                    MRN = reader.GetValue(0).ToString(),
                    First_Name = reader.GetValue(1).ToString(),
                    Last_Name = reader.GetValue(2).ToString(),                        
                    DOB = reader.GetValue(3).ToString(),
                    Sex = reader.GetValue(4).ToString()
                });
            }
        }

        connection.Close();

        return ser.Serialize(foundPatients);
    }
    [WebMethod]
    public bool CreatePatient(string fname, string lname, string dob, string sex)
    {        
        if ((String.IsNullOrWhiteSpace(fname)) | (String.IsNullOrWhiteSpace(lname)) | (!Patient.IsValidDOB(dob)) | (!Patient.IsValidSex(sex)))
        {
            return false;
        }
        try
        {
            string connString = System.Configuration.ConfigurationManager.ConnectionStrings["MySQL"].ConnectionString;
            MySqlConnection connection = new MySqlConnection(connString);
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO patient (first_name, last_name, birth_date, sex) VALUES (";
            command.CommandText += "'" + fname + "', ";
            command.CommandText += "'" + lname + "', ";
            command.CommandText += "'" + String.Format("{0:yyyy-MM-dd}",Convert.ToDateTime(dob)) + "',";
            command.CommandText += "'" + sex + "')";
            connection.Open();
            command.ExecuteReader();
            connection.Close();
            return true;
        }
        catch
        {
            return false;
        }
    }
}
