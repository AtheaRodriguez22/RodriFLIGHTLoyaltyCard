using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLIGHTLoyaltyCardModels
{
    public class LoyaltyAccount
    {

        public Guid AccountID { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = "";
        public string Email { get; set; } = "";
        public string Contact { get; set; } = "";

        public List<string> PointsHistory { get; set; } = new List<string>();
        public List<string> UsedVouchers { get; set; } = new List<string>();
        public int Points { get; set; }
        //public int UsedCount { get; set; } = 0;
    }
    public class RewardOption
    {
        public int RewardId { get; set; }
        public string Name { get; set; } = "";
        public int Cost { get; set; }

        public static RewardOption[] DefaultRewards = new RewardOption[] { 
        new RewardOption { RewardId = 1, Name = "KFC",             Cost = 2000 },
        new RewardOption { RewardId = 2, Name = "Jollibee",        Cost = 3000 },
        new RewardOption { RewardId = 3, Name = "Wendy's",         Cost = 4000 },
        new RewardOption { RewardId = 4, Name = "McDonald's",      Cost = 4000 },
        new RewardOption { RewardId = 5, Name = "Flight Discount", Cost = 10000 },
        new RewardOption { RewardId = 6, Name = "Business Class", Cost = 10000 },

    };
    }
   public class VoucherCode
    {
       public string Code { get; set; } = "";
        public int Points { get; set; }

        public static VoucherCode[] DefaultVouchers = new VoucherCode[]{
        new VoucherCode { Code = "FLY50",      Points = 50  },
        new VoucherCode { Code = "BONUS100",   Points = 100 },
        new VoucherCode { Code = "WELCOME200", Points = 200 },
    };
}}