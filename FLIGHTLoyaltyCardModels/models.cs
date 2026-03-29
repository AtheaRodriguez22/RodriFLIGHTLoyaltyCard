using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FLIGHTLoyaltyCardModels
{
    public class LoyaltyAccount
    {

        public Guid AccountID { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = "";
        public string Email { get; set; } = "";
        public string Contact { get; set; } = "";
        public string FlightNumber { get; set; } = ""; // new added 

        public List<string> PointsHistory { get; set; } = new List<string>();
        public List<string> UsedVouchers { get; set; } = new List<string>();
        public int Points { get; set; }

        public string GetTier()// new add
        {
            if (Points >= 2000) return "Platinum";
            if (Points >= 1200) return "Gold";
            if (Points >= 800) return "Silver";
            if (Points >= 500) return "Bronze";
            return "Unranked";
        }

        public string GetTierProgress()
        {
            if (Points >= 2000) return "Woah! You have reached the highest tier: Platinum!";
            if (Points >= 1200) return $"Platinum: {2000 - Points} pts to go (need 2000)";
            if (Points >= 800) return $"Gold:     {1200 - Points} pts to go (need 1200)";
            if (Points >= 500) return $"Silver:   {800 - Points} pts to go (need 800)";
            return $"Bronze:   {500 - Points} pts to go (need 500)";
        }
    }
    public class RewardOption
    {
        public int RewardId { get; set; }
        public string Name { get; set; } = "";
        public int Cost { get; set; }

        public static RewardOption[] DefaultRewards = {
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

        public static VoucherCode[] DefaultVouchers = new VoucherCode[] {
        new VoucherCode { Code = "FLY50",      Points = 50  },
        new VoucherCode { Code = "BONUS100",   Points = 100 },
        new VoucherCode { Code = "WELCOME200", Points = 200 },
    };
}}