using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace Sembe
{
    public class Patient
    {
        public int ID { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DOB { get; set; }
        public string Sex { get; set; }

        public Patient(int patientId)
        {
            this.ID = patientId;
        }

        /// <summary>
        /// Populates the patient's demographic information from the database
        /// </summary>
        public void Initialize()
        {
            if (this.ID == null) { throw new MissingMemberException("Patient object missing ID"); }

            //Set up DB access
            string connString = System.Configuration.ConfigurationManager.ConnectionStrings["MySQL"].ConnectionString;
            MySqlConnection connection = new MySqlConnection(connString);
            MySqlCommand command = connection.CreateCommand();
            MySqlDataReader reader;

            //Configure search query
            command.CommandText = "SELECT first_name,last_name,birth_date,sex FROM patient WHERE id=@patientId";
            command.Parameters.Add("patientId", MySqlDbType.Int32).Value = this.ID;

            //Get results
            connection.Open();
            reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();
                this.FirstName = reader.GetValue(0).ToString();
                this.LastName = reader.GetValue(1).ToString();
                this.DOB = reader.GetValue(2).ToString();
                this.Sex = reader.GetValue(3).ToString();
            }

            connection.Close();
        }

        /// <summary>
        /// Format the patient's name in a string
        /// </summary>
        /// <returns>Returns the patient's full formatted name</returns>
        public string FormatName()
        {
            return this.LastName + ", " + this.FirstName;
        }

        /// <summary>
        /// Validates the patient's sex
        /// </summary>
        /// <param name="sex">String input representing patient's sex</param>
        /// <returns>True if it is a valid input, false otherwise</returns>
        public static bool IsValidSex(string sex)
        {
            if ((sex.ToUpper() == "M") | (sex.ToUpper() == "F")) { return true; }
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
}