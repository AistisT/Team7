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
    public partial class EditForm : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    inputTitle.Focus();

                    string urlID = Request["ID"];//read in advert id from url
                    int advertID = Convert.ToInt32(urlID);//convert string to integer

                    // Open database connection
                    string connString = ConfigurationManager.ConnectionStrings["ourDb"].ConnectionString;
                    SqlConnection conn = new SqlConnection();
                    conn.ConnectionString = connString;
                    conn.Open();

                    // Prepare and execute SQL command
                    string sqlQuery = "RetrieveAdvert";
                    SqlCommand comm = new SqlCommand(sqlQuery, conn);
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.Parameters.AddWithValue("@AdvertID", advertID);

                    SqlDataReader dr = comm.ExecuteReader();

                    //input returned colums into textboxes
                    if (dr.Read())
                    {
                        inputTitle.Text = dr["VacancyTitle"].ToString();
                        inputPosition.Text = dr["EmployeePosition"].ToString();
                        inputDiscipline.Text = dr["Discipline"].ToString();
                        inputContract.Text = dr["Contract"].ToString();
                        inputHours.Text = dr["HoursPerWeek"].ToString();
                        inputSalary.Text = dr["Salary"].ToString();
                        inputYear.Text = dr["StudentYear"].ToString();
                        string str = dr["CloseDate"].ToString();
                        DateTime dt = Convert.ToDateTime(str);
                        inputClosingDate.Text = dt.ToShortDateString();
                        inputCompanyName.Text = dr["CompanyName"].ToString();
                        inputSector.Text = dr["Sector"].ToString();
                        inputContactName.Text = dr["Name"].ToString();
                        inputContactEmail.Text = dr["Email"].ToString();
                        inputContactNumber.Text = dr["TelNr"].ToString();
                        inputHouse.Text = dr["HouseNr"].ToString();
                        inputStreet.Text = dr["StreetName"].ToString();
                        inputPostcode.Text = dr["Postcode"].ToString();
                        inputTown.Text = dr["Town"].ToString();
                        inputJobDescription.Text = dr["JobDescription"].ToString();

                        if (!String.IsNullOrEmpty(dr["MatriculationNr"].ToString()))
                        {
                            checkBox.Checked = true;
                            StudentValidator.Attributes.Remove("hidden");
                            inputStudentMatr.Text = dr["MatriculationNr"].ToString();
                            inputStudentFirstName.Text = dr["FirstName"].ToString();
                            inputStudentLastName.Text = dr["LastName"].ToString();
                            inputStudentCourse.Text = dr["Course"].ToString();
                            InputStudentYear.Text = dr["Year"].ToString();
                        }
                    }
                    conn.Close();
                }
                catch
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Could not connect to the database.\\nClick \"OK\" to be returned to previous page.'); window.location.href = 'AdminSearch.aspx';", true);
                }
            }
        }


        // on submit button click
        protected void submitExecuted(object sender, EventArgs e)
        {
            string urlID = Request["ID"];
            int advertID = Convert.ToInt32(urlID);

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
            DateTime closeDate = Convert.ToDateTime(closingDate);
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

            try 
            {
            // Open database connection
            string connString = ConfigurationManager.ConnectionStrings["ourDb"].ConnectionString;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connString;
            conn.Open();

            // Prepare and execute update advert SQL command
            string sqlQueryUpdateAdvert = "UpdateAdvert";
            SqlCommand updtAdvert = new SqlCommand(sqlQueryUpdateAdvert, conn);
            updtAdvert.CommandType = CommandType.StoredProcedure;
            updtAdvert.Parameters.AddWithValue("@advertID", advertID);
            updtAdvert.Parameters.AddWithValue("@vacancyTitle", title);
            updtAdvert.Parameters.AddWithValue("@employeePosition", position);
            updtAdvert.Parameters.AddWithValue("@contract", contract);
            updtAdvert.Parameters.AddWithValue("@hoursPerWeek", hours);
            updtAdvert.Parameters.AddWithValue("@salary", salary);
            updtAdvert.Parameters.AddWithValue("@jobDescription", jobDescription);
            updtAdvert.Parameters.AddWithValue("@studentYear", year);
            updtAdvert.Parameters.AddWithValue("@discipline", discipline);
            updtAdvert.Parameters.AddWithValue("@closeDate", closeDate);
            updtAdvert.ExecuteNonQuery();

            // Prepare and execute update contact information SQL command
            string sqlQueryUpdateContactInfo = "UpdateContactInfo";
            SqlCommand updtContact = new SqlCommand(sqlQueryUpdateContactInfo, conn);
            updtContact.CommandType = CommandType.StoredProcedure;
            updtContact.Parameters.AddWithValue("@advertID", advertID);
            updtContact.Parameters.AddWithValue("@name", contactName);
            updtContact.Parameters.AddWithValue("@email", contactEmail);
            updtContact.Parameters.AddWithValue("@telNr", contactNumber);
            updtContact.ExecuteNonQuery();

            // Prepare and execute update location SQL command
            string sqlQueryUpdateLocation = "UpdateLocation";
            SqlCommand updtLocation = new SqlCommand(sqlQueryUpdateLocation, conn);
            updtLocation.CommandType = CommandType.StoredProcedure;
            updtLocation.Parameters.AddWithValue("@advertID", advertID);
            updtLocation.Parameters.AddWithValue("@streetName", street);
            updtLocation.Parameters.AddWithValue("@houseNr", house);
            updtLocation.Parameters.AddWithValue("@postcode", postcode);
            updtLocation.Parameters.AddWithValue("@town", town);
            updtLocation.ExecuteNonQuery();

            // Prepare and execute update employer SQL command
            string sqlQueryUpdateEmployer = "UpdateEmployer";
            SqlCommand updtEmployer = new SqlCommand(sqlQueryUpdateEmployer, conn);
            updtEmployer.CommandType = CommandType.StoredProcedure;
            updtEmployer.Parameters.AddWithValue("@advertID", advertID);
            updtEmployer.Parameters.AddWithValue("@companyName", companyName);
            updtEmployer.Parameters.AddWithValue("@sector", sector);
            updtEmployer.ExecuteNonQuery();

            if (checkBox.Checked)
            {
                //read user input
                string matriculationNr = inputStudentMatr.Text.Trim();
                string firstname = inputStudentFirstName.Text.Trim();
                string lastname = inputStudentLastName.Text.Trim();
                string course = inputStudentCourse.Text.Trim();
                string studentYear = InputStudentYear.Text.Trim();

                // Prepare and execute update student SQL command
                string sqlQueryAddStudent = "UpdateStudent";
                SqlCommand insertStudent = new SqlCommand(sqlQueryAddStudent, conn);
                insertStudent.CommandType = CommandType.StoredProcedure;
                insertStudent.Parameters.AddWithValue("@advertID", advertID);
                insertStudent.Parameters.AddWithValue("@matriculationNr", matriculationNr);
                insertStudent.Parameters.AddWithValue("@firstname", firstname);
                insertStudent.Parameters.AddWithValue("@lastname", lastname);
                insertStudent.Parameters.AddWithValue("@course", course);
                insertStudent.Parameters.AddWithValue("@year", studentYear);
                insertStudent.ExecuteNonQuery();
            }

                // Close connection once we're finished with it
                conn.Close();
                ClearInputs(Page.Controls);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Vacancy: \"" + title + "\" has been updated successfully'); window.location.href = 'AdminSearch.aspx';", true);
                // System.Diagnostics.Debug.Write(title, contract);
            }
            catch
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Could not connect to database.\\nVacancy: \"" + title + "\" has not been updated.');", true);
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

        protected void deleteExecuted(object sender, EventArgs e)
        {
            // used just for error warning
            string title = inputTitle.Text.Trim();
            try
            {
                string urlID = Request["ID"];//read in advert ID from url
                int advertID = Convert.ToInt32(urlID);//convert string to integer
                //read in user input
                string companyName = inputCompanyName.Text.Trim();
                string matriculationNumber = inputStudentMatr.Text.Trim();

                // Open database connection
                string connString = ConfigurationManager.ConnectionStrings["ourDb"].ConnectionString;
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = connString;
                conn.Open();

                // Prepare and execute SQL delete location command
                string sqlQueryDeleteLocation = "DeleteLocation";
                SqlCommand deleteLocation = new SqlCommand(sqlQueryDeleteLocation, conn);
                deleteLocation.CommandType = CommandType.StoredProcedure;
                deleteLocation.Parameters.AddWithValue("@advertID", advertID);
                deleteLocation.ExecuteNonQuery();

                // Prepare and execute SQL delete contact info command
                string sqlQueryDeleteContactInfo = "DeleteContactInfo";
                SqlCommand deleteContactInfo = new SqlCommand(sqlQueryDeleteContactInfo, conn);
                deleteContactInfo.CommandType = CommandType.StoredProcedure;
                deleteContactInfo.Parameters.AddWithValue("@advertID", advertID);
                deleteContactInfo.ExecuteNonQuery();

                // Prepare and execute SQL delete advert command
                string sqlQueryDeleteAdvert = "DeleteAdvert";
                SqlCommand deleteAdvert = new SqlCommand(sqlQueryDeleteAdvert, conn);
                deleteAdvert.CommandType = CommandType.StoredProcedure;
                deleteAdvert.Parameters.AddWithValue("@advertID", advertID);
                deleteAdvert.ExecuteNonQuery();

                conn.Close();//close connection

                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Vacancy: \"" + title + "\" has been successfully deleted');  window.location.href = 'AdminSearch.aspx';", true);
            }
            catch
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Could not connect to database.\\nVacancy: \"" + title + "\" has not been deleted.');", true);
            }
        }
        protected void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox.Checked)
            {
                StudentValidator.Attributes.Remove("hidden");
                inputStudentMatr.Focus();
            }
            if (!checkBox.Checked)
            {
                StudentValidator.Attributes.Add("hidden", "hidden");
            }
            // executing javascript on html page
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "checkBoxTicked();", true);
        }
    }
}