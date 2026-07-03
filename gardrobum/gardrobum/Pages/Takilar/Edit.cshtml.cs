using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace gardrobum.Pages.Takilar
{
    public class EditModel : PageModel
    {
        public Takilar t = new();

        public void OnGet()
        {
            string conn =
                "Server=(localdb)\\MSSQLLocalDB;Database=Dolabim;Trusted_Connection=True;TrustServerCertificate=True;";

            string id = Request.Query["ID"];

            using (SqlConnection con = new SqlConnection(conn))
            {
                con.Open();

                string sql = "SELECT * FROM Takilar WHERE ID=@ID";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@ID", id);

                SqlDataReader r = cmd.ExecuteReader();

                if (r.Read())
                {
                    t.ID = Convert.ToInt32(r["ID"]);
                    t.TakýAdi = r["TakýAdi"].ToString();
                    t.Tur = r["Tur"].ToString();
                    t.Renk = r["Renk"].ToString();
                    t.Marka = r["Marka"].ToString();
                    t.Fiyat = r["Fiyat"].ToString();
                    t.EklenmeTarihi = r["EklenmeTarihi"].ToString();
                }
            }
        }

        public void OnPost()
        {
            string conn =
                "Server=(localdb)\\MSSQLLocalDB;Database=Dolabim;Trusted_Connection=True;TrustServerCertificate=True;";

            string id = Convert.ToString(Request.Form["ID"]);
            string adi = Convert.ToString(Request.Form["TakýAdi"]);
            string tur = Convert.ToString(Request.Form["Tur"]);
            string renk = Convert.ToString(Request.Form["Renk"]);
            string marka = Convert.ToString(Request.Form["Marka"]);
            string fiyat = Convert.ToString(Request.Form["Fiyat"]);
            string tarih = Convert.ToString(Request.Form["EklenmeTarihi"]);

            using (SqlConnection con = new SqlConnection(conn))
            {
                con.Open();

                string sql = @"UPDATE Takilar SET
        TakýAdi=@TakýAdi,
        Tur=@Tur,
        Renk=@Renk,
        Marka=@Marka,
        Fiyat=@Fiyat,
        EklenmeTarihi=@EklenmeTarihi
        WHERE ID=@ID";

                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@TakýAdi", adi);
                cmd.Parameters.AddWithValue("@Tur", tur);
                cmd.Parameters.AddWithValue("@Renk", renk);
                cmd.Parameters.AddWithValue("@Marka", marka);
                cmd.Parameters.AddWithValue("@Fiyat", fiyat);
                cmd.Parameters.AddWithValue("@EklenmeTarihi", tarih);

                cmd.ExecuteNonQuery();
            }

            Response.Redirect("/Takilar/Index");
        }
    }
}