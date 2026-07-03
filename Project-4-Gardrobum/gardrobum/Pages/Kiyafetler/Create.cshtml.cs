using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace gardrobum.Pages.Kiyafetler
{
    public class CreateModel : PageModel
    {
        public void OnGet() { }

        public void OnPost()
        {
            string conn =
                "Server=(localdb)\\MSSQLLocalDB;Database=Dolabim;Trusted_Connection=True;";

          
            string urunAdi = Request.Form["UrunAdi"].ToString();
            string tur = Request.Form["Tur"].ToString();
            string renk = Request.Form["Renk"].ToString();
            string beden = Request.Form["Beden"].ToString();
            string marka = Request.Form["Marka"].ToString();
            string tarih = Request.Form["EklenmeTarihi"].ToString();

            using (SqlConnection con = new SqlConnection(conn))
            {
                con.Open();

                string sql = @"INSERT INTO Kiyafetler
                (UrunAdi,Tur,Renk,Beden,Marka,EklenmeTarihi)
                VALUES
                (@UrunAdi,@Tur,@Renk,@Beden,@Marka,@EklenmeTarihi)";

                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@UrunAdi", urunAdi);
                    cmd.Parameters.AddWithValue("@Tur", tur);
                    cmd.Parameters.AddWithValue("@Renk", renk);
                    cmd.Parameters.AddWithValue("@Beden", beden);
                    cmd.Parameters.AddWithValue("@Marka", marka);
                    cmd.Parameters.AddWithValue("@EklenmeTarihi", tarih);

                    cmd.ExecuteNonQuery();
                }
            }

            Response.Redirect("/Kiyafetler/Index");
        }
    }
}