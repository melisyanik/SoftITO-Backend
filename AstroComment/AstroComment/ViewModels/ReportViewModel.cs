using System;
using System.Collections.Generic;
using AstroComment.Models;

namespace AstroComment.ViewModels
{
    public class MostCommentedZodiacVM
    {
        public string Name { get; set; }
        public int TotalComments { get; set; }
    }

    public class TodayHoroscopeStatsVM
    {
        public string Name { get; set; }
        public int TodayComments { get; set; }
    }

    public class AdminReplyRateVM
    {
        public int TotalComments { get; set; }
        public int TotalReplies { get; set; }
        public decimal ReplyRate { get; set; }
    }

    public class DailyActivityVM
    {
        public DateTime Date { get; set; }
        public int TotalComments { get; set; }
    }

    public class MostActiveUsersVM
    {
        public string Username { get; set; }
        public int TotalComments { get; set; }
    }

    public class ReportViewModel
    {
        public List<MostCommentedZodiacVM> MostCommentedZodiacs { get; set; }
        public List<TodayHoroscopeStatsVM> TodayHoroscopeStats { get; set; }
        public AdminReplyRateVM AdminReplyRate { get; set; }
        public List<DailyActivityVM> DailyActivity { get; set; }
        public List<MostActiveUsersVM> MostActiveUsers { get; set; }

        public string SearchField { get; set; }
        public string SearchValue { get; set; }
        public List<UserModel> SearchResults { get; set; }
    }
}
