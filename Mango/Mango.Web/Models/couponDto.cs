﻿
namespace Mango.Web.Models
{
    public class couponDto
    {
        public int CouponId { get; set; }
        public string CouponCode { get; set; }
        public double DiscountAmount { get; set; }
        public int MinAmount { get; set; }

        public static implicit operator string(couponDto v)
        {
            throw new NotImplementedException();
        }
    }
}
