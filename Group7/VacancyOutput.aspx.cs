using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.Services;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Group7
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["ID"] != null)
            {
                try
                {
                    string urlID = Request["ID"];//retrieve advert ID from URL
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

                    //read in values returned from query
                    //assign values into relevant textboxes
                    if (dr.Read())
                    {
                        outputTitle.Text = dr["VacancyTitle"].ToString();
                        lblVacancyReferenceNumber.Text = dr["AdvertID"].ToString();

                        // hiding/not displaying fields that have no value
                        if (String.IsNullOrEmpty(dr["EmployeePosition"].ToString()))
                            positionGroup.Attributes.Add("hidden", "hidden");
                        lblEmployeePosition.Text = dr["EmployeePosition"].ToString();

                        if (String.IsNullOrEmpty(dr["Discipline"].ToString()))
                            disciplineGroup.Attributes.Add("hidden", "hidden");
                        lblJobField.Text = dr["Discipline"].ToString();

                        lblContractType.Text = dr["Contract"].ToString();

                        if (String.IsNullOrEmpty(dr["HoursPerWeek"].ToString()))
                            hoursGroup.Attributes.Add("hidden", "hidden");
                        lblHours.Text = dr["HoursPerWeek"].ToString();

                        lblSalary.Text = dr["Salary"].ToString();

                        if (String.IsNullOrEmpty(dr["StudentYear"].ToString()))
                            yearGroup.Attributes.Add("hidden", "hidden");
                        lblStudentLevel.Text = dr["StudentYear"].ToString();

                        string str = dr["CloseDate"].ToString();
                        DateTime dt = Convert.ToDateTime(str);
                        lblClosingDate.Text = dt.ToShortDateString();

                        lblCompanyName.Text = dr["CompanyName"].ToString();

                        if (String.IsNullOrEmpty(dr["Sector"].ToString()))
                            sectorGroup.Attributes.Add("hidden", "hidden");
                        lblCompanySector.Text = dr["Sector"].ToString();

                        if (String.IsNullOrEmpty(dr["Name"].ToString()))
                            contactNameGroup.Attributes.Add("hidden", "hidden");
                        lblName.Text = dr["Name"].ToString();

                        lblTelephone.Text = dr["TelNr"].ToString();
                        lblEmail.Text = dr["Email"].ToString();

                        if (String.IsNullOrEmpty(dr["HouseNr"].ToString()))
                            houseGroup.Attributes.Add("hidden", "hidden");
                        lblHouseNr.Text = dr["HouseNr"].ToString();

                        if (String.IsNullOrEmpty(dr["StreetName"].ToString()))
                            streetGroup.Attributes.Add("hidden", "hidden");
                        lblStreetName.Text = dr["StreetName"].ToString();

                        lblTown.Text = dr["Town"].ToString();

                        if (String.IsNullOrEmpty(dr["Postcode"].ToString()))
                            postcodeGroup.Attributes.Add("hidden", "hidden");
                        lblPostcode.Text = dr["Postcode"].ToString();

                        lblJobDescription.Text = dr["JobDescription"].ToString();
                    }
                    conn.Close();
                }
                catch
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Could not connect to the database.\\nClick \"OK\" to be returned to previous page.'); window.location.href = 'Default.aspx';", true);
                }

            }
            else
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Could not successfully redirect to output page.\\nClick \"OK\" to be returned to previous page.'); window.location.href = 'Default.aspx';", true);
            }
        }
    }
}