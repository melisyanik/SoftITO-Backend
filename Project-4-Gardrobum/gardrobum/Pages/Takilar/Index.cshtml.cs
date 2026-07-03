using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace gardrobum.Pages.Takilar
{
    public class IndexModel : PageModel
    {
        public List<Takilar> liste = new();

        public void OnGet()
        {
            string conn =
                "Server=(localdb)\\MSSQLLocalDB;Database=Dolabim;Trusted_Connection=True;TrustServerCertificate=True;";

            string alan = Convert.ToString(Request.Query["alan"]);
            string q = Convert.ToString(Request.Query["q"]);

            using (SqlConnection con = new SqlConnection(conn))
            {
                con.Open();

                string sql = "SELECT * FROM Takilar WHERE 1=1";

                if (!string.IsNullOrWhiteSpace(q) &&
                    !string.IsNullOrWhiteSpace(alan))
                {
                    sql += $" AND {alan} LIKE @q";
                }

                SqlCommand cmd = new SqlCommand(sql, con);

                if (!string.IsNullOrWhiteSpace(q))
                {
                    cmd.Parameters.AddWithValue("@q", "%" + q + "%");
                }

                SqlDataReader r = cmd.ExecuteReader();

                while (r.Read())
                {
                    liste.Add(new Takilar
                    {
                        ID = Convert.ToInt32(r["ID"]),
                        TakýAdi = r["TakýAdi"].ToString(),
                        Tur = r["Tur"].ToString(),
                        Renk = r["Renk"].ToString(),
                        Marka = r["Marka"].ToString(),
                        Fiyat = r["Fiyat"].ToString(),
                        EklenmeTarihi = r["EklenmeTarihi"].ToString()
                    });
                }
            }
        }
    }
}