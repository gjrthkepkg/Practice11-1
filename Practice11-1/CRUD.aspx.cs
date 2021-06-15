using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Practice11_1
{
    public partial class CRUD : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string scon = "Data Source=(localdb)\\ProjectsV13;" +
                         "Initial Catalog=Test;" +
                         "Integrated Security=True;" +
                         "Connect Timeout=30;Encrypt=False;" +
                         "TrustServerCertificate=False;" +
                         "ApplicationIntent=ReadWrite;MultiSubnetFailover=False;" +
                         "User ID = sa; Password = 12345";
            DateTime today = DateTime.Now;
 
            try
            {

                SqlConnection dbcon = new SqlConnection(scon);
                //N為Unicode 因Name欄位為nvarchar
                SqlCommand com = new SqlCommand("UPDATE Users SET Birthday = @Today WHERE Name=N'狗狗旭'", dbcon);
                //Add a parameter with name and give it a value
                com.Parameters.AddWithValue("@Today", today);

                dbcon.Open();
                int reader = com.ExecuteNonQuery();
                if (reader == 1)
                    Response.Write("Update successfully!");
                else
                    Response.Write("Failed");
                dbcon.Close();
            }
            catch (Exception exc)
            {
                Response.Write(exc.ToString());
            }
        }
    }
}