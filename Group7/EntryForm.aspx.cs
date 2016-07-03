using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace Group7
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //setting default focus
            inputTitle.Focus();
        }

        // on submit button click
        protected void submitExecuted(object sender, EventArgs e)
        {
            // getting values from all input fields
            string jobDescription = inputJobDescription.Text.Trim();
            string title = inputTitle.Text.Trim();
            string position = inputPosition.Text.Trim();
            string discipline = inputDiscipline.Text.Trim();
            string contract = inputContract.Text.Trim();
            string hours = inputHours.Text.Trim();
            string salary = inputSalary.Text.Trim();
            string year = inputYear.Text.Trim();
            string closingDate = inputClosingDate.Text.Trim();
            string companyName = inputCompanyName.Text.Trim();
            string sector = inputSector.Text.Trim();
            string contactName = inputContactName.Text.Trim();
            string contactEmail = inputContactEmail.Text.Trim();
            string contactNumber = inputContactNumber.Text.Trim();
            string house = inputHouse.Text.Trim();
            string street = inputStreet.Text.Trim();
            string postcode = inputPostcode.Text.Trim();
            string town = inputTown.Text.Trim();
            string postingTime = DateTime.Now.ToString().Trim();

            DateTime closeDate = Convert.ToDateTime(closingDate);

            try
            {
                // Open database connection
                string connString = ConfigurationManager.ConnectionStrings["ourDb"].ConnectionString;
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = connString;
                conn.Open();

                // Prepare and execute SQL command
                string sqlQuery = "InputAdvert";
                SqlCommand comm = new SqlCommand(sqlQuery, conn);
                comm.CommandType = CommandType.StoredProcedure;

                // Pass in the parameters
                comm.Parameters.AddWithValue("@vacancyTitle", title);
                comm.Parameters.AddWithValue("@employeePosition", position);
                comm.Parameters.AddWithValue("@contract", contract);
                comm.Parameters.AddWithValue("@hoursPerWeek", hours);
                comm.Parameters.AddWithValue("@salary", salary);
                comm.Parameters.AddWithValue("@jobDescription", jobDescription);
                comm.Parameters.AddWithValue("@studentYear", year);
                comm.Parameters.AddWithValue("@discipline", discipline);
                comm.Parameters.AddWithValue("@companyName", companyName);
                comm.Parameters.AddWithValue("@name", contactName);
                comm.Parameters.AddWithValue("@email", contactEmail);
                comm.Parameters.AddWithValue("@telNr", contactNumber);
                comm.Parameters.AddWithValue("@streetName", street);
                comm.Parameters.AddWithValue("@houseNr", house);
                comm.Parameters.AddWithValue("@postcode", postcode);
                comm.Parameters.AddWithValue("@town", town);
                comm.Parameters.AddWithValue("@sector", sector);
                comm.Parameters.AddWithValue("@postingDate", postingTime);
                comm.Parameters.AddWithValue("@closeDate", closeDate);
                // Execute the command
                comm.ExecuteNonQuery();

                // Close connection once we're finished with it
                conn.Close();
                // clearing fields after submission
                ClearInputs(Page.Controls);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Vacancy: \"" + title + "\" has been posted successfully');", true);
                // System.Diagnostics.Debug.Write(title, contract);
            }
            catch
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Could not connect to database.\\nVacancy: \"" + title + "\" has not been posted');", true);
            }
        }

        //reset button
        protected void resetExecuted(object sender, EventArgs e)
        {
            ClearInputs(Page.Controls);
        }
        // method to clear all inputs
        protected void ClearInputs(ControlCollection ctrls)
        {
            foreach (Control ctrl in ctrls)
            {
                if (ctrl is TextBox)
                {
                    ((TextBox)ctrl).Text = string.Empty;
                }
                ClearInputs(ctrl.Controls);
            }
        }
    }
}
