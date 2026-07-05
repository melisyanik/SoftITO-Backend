using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduMaster.Models.ViewModels
{
    public class CategorySearchVM
    {
        public string? SearchText { get; set; }
        public string? SearchField { get; set; }

        public IEnumerable<Category> Categories { get; set; }
    }
}