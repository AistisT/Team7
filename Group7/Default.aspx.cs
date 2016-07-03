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
    public partial class _Default : Page
    {
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                searchSelection();
                jobSearch.Focus();
            }
        }


        protected void searchExecuted(object sender, EventArgs e)
        {
            // created separate method so I dont need to pass  object sender, EventArgs e when calling from inside the code
            searchSelection();
        }

        protected void searchSelection()
        {
            bool job = jobSearchEmpty(), location = locationEmpty();//check if textboxes are emtpy
            searchListView.DataSource = null;

            if ((job == true) && (location == true))//if search and location textboxes are both empty
            {
                fullSearch();//carry out full search
            }
            else if (job == true)//if search textbox is empty
            {
                RetrieveAdvertbyLocation(locationSearch.Value);//retrieve advert by location
            }
            else if (location == true)//if location textbox is empty
            {
                search(jobSearch.Value);//search by value entered into search textbox and not location
            }
            else
            {
                searchLocation(jobSearch.Value, locationSearch.Value);//search by search value and location value
            }
        }

        protected bool locationEmpty()
        {
            if (string.IsNullOrEmpty(locationSearch.Value))//if location textbox is empty
            {
                return true;//return true
            }
            else//if location textbox is not empty
            {
                return false;//return false
            }
        }

        protected bool jobSearchEmpty()
        {
            if (string.IsNullOrEmpty(jobSearch.Value))//if search textbox is empty
            {
                return true;//return true
            }
            else//if search textbox is not empty
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
                string sqlQuery = "RetrieveAllAdverts";
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
                string sqlQuery = "RetrieveAdvertbyLocation";
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
            retrieveAdverts(searchParameter);//retrieve adverts by search parameter input by user
            if (ds.Tables[0].Rows.Count == 0)//if zero results returned
            {
                retrieveAdvertbyJobDescription(searchParameter);//retrieve advert based on job description
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
                string sqlQuery = "RetrieveAdverts";
                SqlCommand comm = new SqlCommand(sqlQuery, conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("@searchParameter", searchParameter);
                SqlDataAdapter adapter = new SqlDataAdapter(comm);
                adapter.Fill(ds);

                searchListView.DataSource = ds;
                searchListView.DataBind();
                comm.ExecuteNonQuery();
                conn.Close();// Close connection once we're finished with it

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
                string sqlQuery = "RetrieveAdverts_Description";
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
            retrieveAdvertsbySearchParameterandLocation(searchParameter, location);//search for advert based on search parameter and location
            if (ds.Tables[0].Rows.Count == 0)//if results are zero
            {
                retrieveAdvertbyJobDescription(searchParameter, location);//retrieve advert by job description and location
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
                string sqlQuery = "RetrieveAdverts_Location";
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
                string sqlQuery = "RetrieveAdverts_Description_Location";
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


        protected void searchListPropertiesChanged(object sender, EventArgs e)
        {
            searchSelection();
        }
    }
}