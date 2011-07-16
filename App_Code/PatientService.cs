using System;
using System.Collections.Generic;
using System.Web.Services;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Runtime.Serialization.Json;
using Sembe;
using MySql.Data.MySqlClient;

/// <summary>
/// Summary description for PatientService
/// </summary>
[WebService(Namespace = "Sembe")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService] //Allow javascript to access web service
public class PatientService : System.Web.Services.WebService {

    /// <summary>
    /// Finds a set of patients based on given criteria via web service. All fields are optional,
    /// but at least one must be specified.
    /// </summary>
    /// <param name="firstName">Patient's first name</param>
    /// <param name="lastName">Patient's last name</param>
    /// <param name="dob">Patient's birth date</param>
    /// <param name="sex">Patient's sex</param>
    /// <param name="patientId">Patient's ID</param>
    /// <returns>JSON formatted array of patients matching input criteria</returns>
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string FindPatient(string firstName, string lastName, string dob, string sex, string patientId)
    {
        //Set up DB access
        string connString = System.Configuration.ConfigurationManager.ConnectionStrings["MySQL"].ConnectionString;
        MySqlConnection connection = new MySqlConnection(connString);
        MySqlCommand command = connection.CreateCommand();
        MySqlDataReader reader;

        //Configure search query
        command.CommandText = "SELECT id,first_name,last_name,birth_date,sex FROM patient WHERE ";
        string conditions = "";

        if (!String.IsNullOrWhiteSpace(patientId))
        {
            conditions += "id=@mrn";
            command.Parameters.Add("mrn", MySqlDbType.Int32).Value = patientId;
        }
        if (!String.IsNullOrWhiteSpace(firstName))
        {
            if (!String.IsNullOrWhiteSpace(conditions)) { conditions += " AND "; }
            conditions += "SOUNDEX(first_name)=SOUNDEX(@fname)";
            command.Parameters.Add("fname", MySqlDbType.String, 45).Value = firstName;
        }
        if (!String.IsNullOrWhiteSpace(lastName))
        {
            if (!String.IsNullOrWhiteSpace(conditions)) { conditions += " AND "; }
            conditions += "SOUNDEX(last_name)=SOUNDEX(@lname)";
            command.Parameters.Add("lname", MySqlDbType.String, 45).Value = lastName;
        }
        if (!String.IsNullOrWhiteSpace(dob))
        {
            if (!String.IsNullOrWhiteSpace(conditions)) { conditions += " AND "; }
            conditions += "birth_date=@dob";
            command.Parameters.Add("dob", MySqlDbType.Date).Value = String.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(dob));
        }
        if (!String.IsNullOrWhiteSpace(sex))
        {
            if (!String.IsNullOrWhiteSpace(conditions)) { conditions += " AND "; }
            conditions += "sex=@sex";
            command.Parameters.Add("sex", MySqlDbType.Enum).Value = sex;
        }
        if (String.IsNullOrWhiteSpace(conditions)) { throw new ArgumentException("Patient query not well-defined"); }
        else { 
            command.CommandText += conditions;
            command.CommandText += " LIMIT 100";
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
                foundPatients.Add(new Patient((int) reader.GetValue(0)) {
                    FirstName = reader.GetValue(1).ToString(),
                    LastName = reader.GetValue(2).ToString(),
                    DOB = reader.GetValue(3).ToString(),
                    Sex = reader.GetValue(4).ToString()
                });
            }
        }

        connection.Close();

        return ser.Serialize(foundPatients);
    }
    
    /// <summary>
    /// Creates a new patient via web service
    /// </summary>
    /// <param name="fname">Patient's first name</param>
    /// <param name="lname">Patient's last name</param>
    /// <param name="dob">Patient's date of birth</param>
    /// <param name="sex">Patient's sex</param>
    /// <returns>True if the patient is created</returns>    
    //TODO: Return ID and forward user to Patient.aspx    
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
            command.CommandText = "INSERT INTO patient (first_name, last_name, birth_date, sex) VALUES (@fname, @lname, @dob, @sex)";
            command.Parameters.Add("fname", MySqlDbType.String).Value = fname;
            command.Parameters.Add("lname", MySqlDbType.String).Value = lname;
            command.Parameters.Add("dob", MySqlDbType.Date).Value = String.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(dob));
            command.Parameters.Add("sex", MySqlDbType.Enum).Value = sex;

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
