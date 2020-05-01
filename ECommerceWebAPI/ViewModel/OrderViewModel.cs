using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceWebAPI.ViewModel
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }

        [StringLength(10)]
        public string Status { get; set; }

        public DateTime? Date { get; set; }

        [Required]
        public double? Total { get; set; }

        public int UserId { get; set; }

    }
}
