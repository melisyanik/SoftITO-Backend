using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace gardrobum.Pages.Kiyafetler
{
    public class IndexModel : PageModel
    {
        public List<Kiyafetler> liste = new();

        public void OnGet()
        {
            string conn =
                "Server=(localdb)\\MSSQLLocalDB;Database=Dolabim;Trusted_Connection=True;";

            string alan = Request.Query["alan"].ToString();
            string q = Request.Query["q"].ToString();

            using (SqlConnection con = new SqlConnection(conn))
            {
                con.Open();

                string sql = "SELECT * FROM Kiyafetler WHERE 1=1";

           
                if (!string.IsNullOrEmpty(q))
                {
                    sql += $" AND {alan} LIKE @q";
                }

                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    if (!string.IsNullOrEmpty(q))
                    {
                        cmd.Parameters.AddWithValue("@q", "%" + q + "%");
                    }

                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            liste.Add(new Kiyafetler
                            {
                                ID = r.GetInt32(0),
                                UrunAdi = r.GetString(1),
                                Tur = r.GetString(2),
                                Renk = r.GetString(3),
                                Beden = r.GetString(4),
                                Marka = r.GetString(5),
                                EklenmeTarihi = r.GetString(6)
                            });
                        }
                    }
                }
            }
        }
    }
}