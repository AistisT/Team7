using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace Group7
{
    public partial class WebForm1 : Page
    {
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                jobSearch.Focus();

                // restoring search parameters from session/cookies
                if (Session["Search"] != null)
                {
                    jobSearch.Value = (string)Session["Search"];
                }
                if (Session["Location"] != null)
                {
                    jobSearch.Value = (string)Session["Location"];
                }

                searchSelection();
            }

        }


        protected void searchExecuted(object sender, EventArgs e)
        {
            // created seprate method so I dont need to pass  object sender, EventArgs e when calling from inside the code
            searchSelection();
            // storing search parameters in session/cookies
            Session["Search"] = jobSearch.Value;
            Session["Location"] = jobSearch.Value;

        }

        protected void searchSelection()
        {
            bool job = jobSearchEmpty(), location = locationEmpty();//check if job search and location search textboxes are empty or not
            searchListView.DataSource = null;

            if ((job == true) && (location == true))//if job search text box is empty, and location search box is empty...
            {
                fullSearch();//carry out a full search without any parameters
            }
            else if (job == true)//if job search text box is empty...
            {
                RetrieveAdvertbyLocation(locationSearch.Value);//carry out search based on location search text box details
            }
            else if (location == true)//if location search text box is empty...
            {
                search(jobSearch.Value);//carry out search based on job search text box details
            }
            else//if box text boxes have entries
            {
                searchLocation(jobSearch.Value, locationSearch.Value);//search based on job search and location search text box details
            }
        }

        protected bool locationEmpty()
        {
            if (string.IsNullOrEmpty(locationSearch.Value))//if textbox is null
            {
                return true;//return true
            }
            else//if textbox is not null
            {
                return false;//return false
            }
        }

        protected bool jobSearchEmpty()
        {
            if (string.IsNullOrEmpty(jobSearch.Value))//if textbox is null
            {
                return true;//return true
            }
            else//if textbox is not null
            {
                return false;//return false
            }
        }

        protected void fullSearch()
        {
            try
            {
                // Open database connection
                string connString = ConfigurationManager.ConnectionStrings["ourDb"].ConnectionString;
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = connString;
                conn.Open();

                // Prepare and execute SQL command
                string sqlQuery = "RetrieveAllAdverts_Admin";
                SqlCommand comm = new SqlCommand(sqlQuery, conn);
                comm.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(comm);
                adapter.Fill(ds);

                searchListView.DataSource = ds;
                searchListView.DataBind();
                comm.ExecuteNonQuery();
                conn.Close();

                //adding and removing to prevent multiple attributes added overtime without being removed, and when removing it wouldn't remove all of them
                connectWarning.Attributes.Remove("hidden");
                connectWarning.Attributes.Add("hidden", "hidden");
            }
            catch
            {
                connectWarning.Attributes.Remove("hidden");
            }
        }

        protected void RetrieveAdvertbyLocation(string location)
        {
            try
            {
                // Open database connection
                string connString = ConfigurationManager.ConnectionStrings["ourDb"].ConnectionString;
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = connString;
                conn.Open();

                // Prepare and execute SQL command
                string sqlQuery = "RetrieveAdvertbyLocation_Admin";
                SqlCommand comm = new SqlCommand(sqlQuery, conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("@location", location);
                SqlDataAdapter adapter = new SqlDataAdapter(comm);
                adapter.Fill(ds);

                searchListView.DataSource = ds;
                searchListView.DataBind();
                comm.ExecuteNonQuery();
                conn.Close();

                //adding and removing to prevent multiple attributes added overtime without being removed, and when removing it wouldn't remove all of them
                connectWarning.Attributes.Remove("hidden");
                connectWarning.Attributes.Add("hidden", "hidden");
            }
            catch
            {
                connectWarning.Attributes.Remove("hidden");
            }
        }

        protected void search(string searchParameter)
        {
            bool containDigits = searchParameter.All(char.IsDigit);//check if search parameter contains digits

            if (containDigits == true)//if search parameter contains digits
            {
                retrieveAdvertbyAdvertID(searchParameter);//execute query to search by advert ID
            }
            else//if search parameter doesn't contain digits
            {
                retrieveAdverts(searchParameter);//retrieve all adverts based on search parameter
                if (ds.Tables[0].Rows.Count == 0)//if zero results returned
                {
                    retrieveAdvertbyJobDescription(searchParameter);//retrieve advert based on job description
                }
            }
        }

        protected void retrieveAdvertbyAdvertID(string advertID)
        {
            try
            {
                int advID = Convert.ToInt32(advertID);//convert advert ID to integer

                // Open database connection
                string connString = ConfigurationManager.ConnectionStrings["ourDb"].ConnectionString;
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = connString;
                conn.Open();

                // Prepare and execute SQL command
                string sqlQuery = "RetrieveAdvertbyAdvertID_Admin";
                SqlCommand comm = new SqlCommand(sqlQuery, conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("@advertID", advID);
                SqlDataAdapter adapter = new SqlDataAdapter(comm);
                adapter.Fill(ds);

                searchListView.DataSource = ds;
                searchListView.DataBind();
                comm.ExecuteNonQuery();
                conn.Close();

                //adding and removing to prevent multiple attributes added overtime without being removed, and when removing it wouldn't remove all of them
                connectWarning.Attributes.Remove("hidden");
                connectWarning.Attributes.Add("hidden", "hidden");
            }
            catch
            {
                connectWarning.Attributes.Remove("hidden");
            }
        }

        protected void retrieveAdverts(string searchParameter)
        {
            try
            {
                // Open database connection
                string connString = ConfigurationManager.ConnectionStrings["ourDb"].ConnectionString;
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = connString;
                conn.Open();

                // Prepare and execute SQL command
                string sqlQuery = "RetrieveAdverts_Admin";
                SqlCommand comm = new SqlCommand(sqlQuery, conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("@searchParameter", searchParameter);
                SqlDataAdapter adapter = new SqlDataAdapter(comm);
                adapter.Fill(ds);

                searchListView.DataSource = ds;
                searchListView.DataBind();
                comm.ExecuteNonQuery();
                conn.Close();

                //adding and removing to prevent multiple attributes added overtime without being removed, and when removing it wouldn't remove all of them
                connectWarning.Attributes.Remove("hidden");
                connectWarning.Attributes.Add("hidden", "hidden");
            }
            catch
            {
                connectWarning.Attributes.Remove("hidden");
            }
        }

        protected void retrieveAdvertbyJobDescription(string searchParameter)
        {
            try
            {
                // Open database connection
                string connString = ConfigurationManager.ConnectionStrings["ourDb"].ConnectionString;
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = connString;
                conn.Open();

                // Prepare and execute SQL command
                string sqlQuery = "RetrieveAdverts_Description_Admin";
                SqlCommand comm = new SqlCommand(sqlQuery, conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("@searchParameter", searchParameter);
                SqlDataAdapter adapter = new SqlDataAdapter(comm);
                adapter.Fill(ds);

                searchListView.DataSource = ds;
                searchListView.DataBind();
                comm.ExecuteNonQuery();
                conn.Close();

                //adding and removing to prevent multiple attributes added overtime without being removed, and when removing it wouldn't remove all of them
                connectWarning.Attributes.Remove("hidden");
                connectWarning.Attributes.Add("hidden", "hidden");
            }
            catch
            {
                connectWarning.Attributes.Remove("hidden");
            }
        }

        protected void searchLocation(string searchParameter, string location)
        {
            retrieveAdvertsbySearchParameterandLocation(searchParameter, location);//retrieve adverts based on search parameter and location
            if (ds.Tables[0].Rows.Count == 0)//if zero results returned
            {
                retrieveAdvertbyJobDescription(searchParameter, location);//retrieve adverts based on job description and location
            }
        }

        protected void retrieveAdvertsbySearchParameterandLocation(string searchParameter, string location)
        {
            try
            {
                // Open database connection
                string connString = ConfigurationManager.ConnectionStrings["ourDb"].ConnectionString;
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = connString;
                conn.Open();

                // Prepare and execute SQL command
                string sqlQuery = "RetrieveAdverts_Location_Admin";
                SqlCommand comm = new SqlCommand(sqlQuery, conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("@searchParameter", searchParameter);
                comm.Parameters.AddWithValue("@location", location);
                SqlDataAdapter adapter = new SqlDataAdapter(comm);
                adapter.Fill(ds);

                searchListView.DataSource = ds;
                searchListView.DataBind();
                comm.ExecuteNonQuery();
                conn.Close();

                //adding and removing to prevent multiple attributes added overtime without being removed, and when removing it wouldn't remove all of them
                connectWarning.Attributes.Remove("hidden");
                connectWarning.Attributes.Add("hidden", "hidden");
            }
            catch
            {
                connectWarning.Attributes.Remove("hidden");
            }
        }

        protected void retrieveAdvertbyJobDescription(string searchParameter, string location)
        {
            try
            {
                // Open database connection
                string connString = ConfigurationManager.ConnectionStrings["ourDb"].ConnectionString;
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = connString;
                conn.Open();

                // Prepare and execute SQL command
                string sqlQuery = "RetrieveAdverts_Description_Location_Admin";
                SqlCommand comm = new SqlCommand(sqlQuery, conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("@searchParameter", searchParameter);
                comm.Parameters.AddWithValue("@location", location);
                SqlDataAdapter adapter = new SqlDataAdapter(comm);
                adapter.Fill(ds);

                searchListView.DataSource = ds;
                searchListView.DataBind();
                comm.ExecuteNonQuery();
                conn.Close();
                //adding and removing to prevent multiple attributes added overtime without being removed, and when removing it wouldn't remove all of them
                connectWarning.Attributes.Remove("hidden");
                connectWarning.Attributes.Add("hidden", "hidden");
            }
            catch
            {
                connectWarning.Attributes.Remove("hidden");
            }
        }

        // refreshing search, needed for pager to work
        protected void searchListPropertiesChanged(object sender, EventArgs e)
        {
            searchSelection();
        }
    }
}
