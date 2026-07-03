using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace gardrobum.Pages.Kiyafetler
{
    public class DeleteModel : PageModel
    {
        public void OnGet()
        {
            string conn =
                "Server=(localdb)\\MSSQLLocalDB;Database=Dolabim;Trusted_Connection=True;";

            string id = Request.Query["ID"];

            using (SqlConnection con = new SqlConnection(conn))
            {
                con.Open();

                string sql = "DELETE FROM Kiyafetler WHERE ID=@ID";

                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.ExecuteNonQuery();
                }
            }

            Response.Redirect("/Kiyafetler/Index");
        }
    }
}