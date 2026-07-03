using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace gardrobum.Pages
{
    public class IndexModel : PageModel
    {
        public List<ReportModel> kiyafetTur = new();
        public List<ReportModel> kiyafetRenk = new();
        public List<ReportModel> ayakkabiMarka = new();
        public List<ReportModel> ayakkabiNumara = new();
        public List<ReportModel> takiTur = new();
        public List<ReportModel> takiMarka = new();

        public void OnGet()
        {
            string conn =
                "Server=(localdb)\\MSSQLLocalDB;Database=Dolabim;Trusted_Connection=True;TrustServerCertificate=True;";

            using (SqlConnection con = new SqlConnection(conn))
            {
                con.Open();

                Load(con, "SELECT Tur, COUNT(*) FROM Kiyafetler GROUP BY Tur", kiyafetTur);
                Load(con, "SELECT Renk, COUNT(*) FROM Kiyafetler GROUP BY Renk", kiyafetRenk);

                Load(con, "SELECT Marka, COUNT(*) FROM Ayakkabilar GROUP BY Marka", ayakkabiMarka);
                Load(con, "SELECT Numara, COUNT(*) FROM Ayakkabilar GROUP BY Numara", ayakkabiNumara);

                Load(con, "SELECT Tur, COUNT(*) FROM Takilar GROUP BY Tur", takiTur);
                Load(con, "SELECT Marka, COUNT(*) FROM Takilar GROUP BY Marka", takiMarka);
            }
        }

        void Load(SqlConnection con, string sql, List<ReportModel> list)
        {
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader r = cmd.ExecuteReader();

            while (r.Read())
            {
                list.Add(new ReportModel
                {
                    Ad = r[0].ToString(),
                    Adet = (int)r[1]
                });
            }

            r.Close();
        }
    }

    public class ReportModel
    {
        public string Ad { get; set; } = "";
        public int Adet { get; set; }
    }
}