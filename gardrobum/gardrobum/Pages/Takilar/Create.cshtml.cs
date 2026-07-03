using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace gardrobum.Pages.Takilar
{
    public class CreateModel : PageModel
    {
        public void OnGet() { }

        public void OnPost()
        {
            string conn =
                "Server=(localdb)\\MSSQLLocalDB;Database=Dolabim;Trusted_Connection=True;TrustServerCertificate=True;";

            using (SqlConnection con = new SqlConnection(conn))
            {
                con.Open();

                string sql = @"INSERT INTO Takilar
                (TakýAdi,Tur,Renk,Marka,Fiyat,EklenmeTarihi)
                VALUES
                (@TakýAdi,@Tur,@Renk,@Marka,@Fiyat,@EklenmeTarihi)";

                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@TakýAdi", Convert.ToString(Request.Form["TakýAdi"]));
                cmd.Parameters.AddWithValue("@Tur", Convert.ToString(Request.Form["Tur"]));
                cmd.Parameters.AddWithValue("@Renk", Convert.ToString(Request.Form["Renk"]));
                cmd.Parameters.AddWithValue("@Marka", Convert.ToString(Request.Form["Marka"]));
                cmd.Parameters.AddWithValue("@Fiyat", Convert.ToString(Request.Form["Fiyat"]));
                cmd.Parameters.AddWithValue("@EklenmeTarihi", Convert.ToString(Request.Form["EklenmeTarihi"]));

                cmd.ExecuteNonQuery();
            }

            Response.Redirect("/Takilar/Index");
        }
    }
}