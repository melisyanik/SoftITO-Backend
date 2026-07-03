using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace gardrobum.Pages.Kiyafetler
{
    public class EditModel : PageModel
    {
        public Kiyafetler k = new Kiyafetler();

        public void OnGet()
        {
            string conn =
                "Server=(localdb)\\MSSQLLocalDB;Database=Dolabim;Trusted_Connection=True;";

        
            string id = Request.Query["ID"].ToString();

            using (SqlConnection con = new SqlConnection(conn))
            {
                con.Open();

                string sql = "SELECT * FROM Kiyafetler WHERE ID=@ID";

                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        if (r.Read())
                        {
                            k.ID = r.GetInt32(0);
                            k.UrunAdi = r.GetString(1);
                            k.Tur = r.GetString(2);
                            k.Renk = r.GetString(3);
                            k.Beden = r.GetString(4);
                            k.Marka = r.GetString(5);
                            k.EklenmeTarihi = r.GetString(6);
                        }
                    }
                }
            }
        }

        public void OnPost()
        {
            string conn =
                "Server=(localdb)\\MSSQLLocalDB;Database=Dolabim;Trusted_Connection=True;";

         
            string id = Request.Form["ID"].ToString();
            string urunAdi = Request.Form["UrunAdi"].ToString();
            string tur = Request.Form["Tur"].ToString();
            string renk = Request.Form["Renk"].ToString();
            string beden = Request.Form["Beden"].ToString();
            string marka = Request.Form["Marka"].ToString();
            string tarih = Request.Form["EklenmeTarihi"].ToString();

            using (SqlConnection con = new SqlConnection(conn))
            {
                con.Open();

                string sql = @"UPDATE Kiyafetler SET
                                UrunAdi=@UrunAdi,
                                Tur=@Tur,
                                Renk=@Renk,
                                Beden=@Beden,
                                Marka=@Marka,
                                EklenmeTarihi=@EklenmeTarihi
                               WHERE ID=@ID";

                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
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