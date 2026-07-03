using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace gardrobum.Pages.Ayakkabilar
{
    public class EditModel : PageModel
    {
        public Ayakkabilar a = new();

        public void OnGet()
        {
            string conn =
                "Server=(localdb)\\MSSQLLocalDB;Database=Dolabim;Trusted_Connection=True;TrustServerCertificate=True;";

            string id = Request.Query["ID"].ToString();

            using (SqlConnection con = new SqlConnection(conn))
            {
                con.Open();

                string sql = @"SELECT
                               ID,
                               AyakkabiAdi,
                               Marka,
                               Numara,
                               Renk,
                               Tur,
                               EklenmeTarihi
                               FROM Ayakkabilar
                               WHERE ID=@ID";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@ID", id);

                SqlDataReader r = cmd.ExecuteReader();

                if (r.Read())
                {
                    a.ID = Convert.ToInt32(r["ID"]);
                    a.AyakkabiAdi = r["AyakkabiAdi"].ToString() ?? "";
                    a.Marka = r["Marka"].ToString() ?? "";
                    a.Numara = r["Numara"].ToString() ?? "";
                    a.Renk = r["Renk"].ToString() ?? "";
                    a.Tur = r["Tur"].ToString() ?? "";
                    a.EklenmeTarihi = r["EklenmeTarihi"].ToString() ?? "";
                }
            }
        }

        public void OnPost()
        {
            string conn =
                "Server=(localdb)\\MSSQLLocalDB;Database=Dolabim;Trusted_Connection=True;TrustServerCertificate=True;";

            using (SqlConnection con = new SqlConnection(conn))
            {
                con.Open();

                string sql = @"UPDATE Ayakkabilar SET
                               AyakkabiAdi=@AyakkabiAdi,
                               Marka=@Marka,
                               Numara=@Numara,
                               Renk=@Renk,
                               Tur=@Tur,
                               EklenmeTarihi=@EklenmeTarihi
                               WHERE ID=@ID";

                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@ID", Request.Form["ID"].ToString());
                cmd.Parameters.AddWithValue("@AyakkabiAdi", Request.Form["AyakkabiAdi"].ToString());
                cmd.Parameters.AddWithValue("@Marka", Request.Form["Marka"].ToString());
                cmd.Parameters.AddWithValue("@Numara", Request.Form["Numara"].ToString());
                cmd.Parameters.AddWithValue("@Renk", Request.Form["Renk"].ToString());
                cmd.Parameters.AddWithValue("@Tur", Request.Form["Tur"].ToString());
                cmd.Parameters.AddWithValue("@EklenmeTarihi", Request.Form["EklenmeTarihi"].ToString());

                cmd.ExecuteNonQuery();
            }

            Response.Redirect("/Ayakkabilar/Index");
        }
    }
}