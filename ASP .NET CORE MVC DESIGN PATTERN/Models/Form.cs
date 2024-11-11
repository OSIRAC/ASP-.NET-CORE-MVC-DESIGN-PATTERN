using Microsoft.AspNetCore.Authorization;

namespace EFCORE_VERİALMA.Models
{
    public class Form
    {
        public string? Name { get; set; }

        public bool IsRead { get; set; }

        public string? Color { get; set; }

        public int Expire { get; set; }
    }
}
