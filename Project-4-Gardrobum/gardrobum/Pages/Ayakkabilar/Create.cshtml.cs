using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace gardrobum.Pages.Ayakkabilar
{
    public class CreateModel : PageModel
    {
        public void OnGet() { }

        public void OnPost()
        {
            string conn =
                "Server=(localdb)\\MSSQLLocalDB;Database=Dolabim;Trusted_Connection=True;TrustServerCertificate=True;";

            string adi = Request.Form["AyakkabiAdi"].ToString();
            string tur = Request.Form["Tur"].ToString();
            string renk = Request.Form["Renk"].ToString();
            string numara = Request.Form["Numara"].ToString();
            string marka = Request.Form["Marka"].ToString();
            string tarih = Request.Form["EklenmeTarihi"].ToString();

            using (SqlConnection con = new SqlConnection(conn))
            {
                con.Open();

                string sql = @"INSERT INTO Ayakkabilar
                (AyakkabiAdi,Marka,Numara,Renk,Tur,EklenmeTarihi)
                VALUES
                (@AyakkabiAdi,@Marka,@Numara,@Renk,@Tur,@EklenmeTarihi)";

                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@AyakkabiAdi", adi);
                    cmd.Parameters.AddWithValue("@Marka", marka);
                    cmd.Parameters.AddWithValue("@Numara", numara);
                    cmd.Parameters.AddWithValue("@Renk", renk);
                    cmd.Parameters.AddWithValue("@Tur", tur);
                    cmd.Parameters.AddWithValue("@EklenmeTarihi", tarih);

                    cmd.ExecuteNonQuery();
                }
            }

            Response.Redirect("/Ayakkabilar/Index");
        }
    }
}