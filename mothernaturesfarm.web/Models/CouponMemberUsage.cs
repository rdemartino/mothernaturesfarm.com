using System;

namespace mothernaturesfarm.web.Models
{
    public class CouponMemberUsage
    {
        public CouponMemberUsage()
        {
            CouponMemberUsageId = 0;
            CouponId = 0;
            MemberId = 0;
            DateUsed = DateTime.Now;
        }
        public int CouponMemberUsageId { get; set; }
        public int CouponId { get; set; }
        public int MemberId { get; set; }
        public DateTime DateUsed { get; set; }
    }
}