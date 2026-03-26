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

        public int Points { get; set; } = 0;
        public List<string> PointsHistory { get; set; } = new List<string>();
        public List<string> UsedVouchers { get; set; } = new List<string>();
        public int UsedCount { get; set; } = 0;
    }
    public class RewardOption
    {
        public int RewardID { get; set; }
        public string Name { get; set; } = "";
        public int Cost { get; set; }

        public static RewardOption[] DefaultRewards = new RewardOption[] { //function: need since mawawala reward option
        new RewardOption { RewardID = 1, Name = "KFC",             Cost = 100 },
        new RewardOption { RewardID = 2, Name = "Jollibee",        Cost = 120 },
        new RewardOption { RewardID = 3, Name = "Wendy's",         Cost = 150 },
        new RewardOption { RewardID = 4, Name = "McDonald's",      Cost = 130 },
        new RewardOption { RewardID = 5, Name = "Flight Discount", Cost = 300 },
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