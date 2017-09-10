using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mothernaturesfarm.web.Models
{
    public class Coupon
    {
        public Coupon()
        {
            CouponId = 0;
            Name = string.Empty;
            Description = string.Empty;
            IsEnabled = false;
            DateCreated = DateTime.Now;
        }
        public int CouponId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsEnabled { get; set; }
        public DateTime DateCreated { get; set; }
    }
}