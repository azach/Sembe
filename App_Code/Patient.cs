using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Class1
/// </summary>
public class Patient
{
    public string First_Name { get; set; }
    public string Last_Name { get; set; }
    public string MRN { get; set; }
    public string DOB { get; set; }
    public string Sex { get; set; }

	public Patient()
	{        
		//
		// TODO: Add constructor logic here
		//
	}
    /// <summary>
    /// Validates the patient's sex
    /// </summary>
    /// <param name="sex">String input representing patient's sex</param>
    /// <returns>True if it is a valid input, false otherwise</returns>
    public static bool IsValidSex(string sex)
    {
        if ((sex.ToUpper() == "M")|(sex.ToUpper() == "F")) { return true; }
        return false;
    }
    public static bool IsValidDOB(string dob)
    {
        if (String.IsNullOrWhiteSpace(dob)) { return true; } //Allow no DOB
        string validate = String.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(dob));
        if (String.IsNullOrWhiteSpace(validate)) { return false; }
        return true;
    }
}