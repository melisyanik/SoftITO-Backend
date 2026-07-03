using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace gardrobum.Pages.Ayakkabilar
{
    public class IndexModel : PageModel
    {
        public List<Ayakkabilar> liste = new();

        public void OnGet()
        {
            string conn =
                "Server=(localdb)\\MSSQLLocalDB;Database=Dolabim;Trusted_Connection=True;TrustServerCertificate=True;";

            string alan = Request.Query["alan"].ToString();
            string q = Request.Query["q"].ToString();

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
                               WHERE 1=1";

                if (!string.IsNullOrEmpty(q))
                {
                    string[] izinliAlanlar =
                    {
                        "AyakkabiAdi",
                        "Marka",
                        "Numara",
                        "Renk",
                        "Tur"
                    };

                    if (izinliAlanlar.Contains(alan))
                    {
                        sql += $" AND {alan} LIKE @q";
                    }
                }

                SqlCommand cmd = new SqlCommand(sql, con);

                if (!string.IsNullOrEmpty(q))
                {
                    cmd.Parameters.AddWithValue("@q", "%" + q + "%");
                }

                SqlDataReader r = cmd.ExecuteReader();

                while (r.Read())
                {
                    liste.Add(new Ayakkabilar
                    {
                        ID = Convert.ToInt32(r["ID"]),
                        AyakkabiAdi = r["AyakkabiAdi"].ToString() ?? "",
                        Marka = r["Marka"].ToString() ?? "",
                        Numara = r["Numara"].ToString() ?? "",
                        Renk = r["Renk"].ToString() ?? "",
                        Tur = r["Tur"].ToString() ?? "",
                        EklenmeTarihi = r["EklenmeTarihi"].ToString() ?? ""
                    });
                }
            }
        }
    }
}