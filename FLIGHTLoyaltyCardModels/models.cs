using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLIGHTLoyaltyCardModels
{
    public class LoyaltyAccount
    {
        public string Name { get; set; } = "";
        public string Email { get; set; } = "";
        public string Contact { get; set; } = "";
        public int Points { get; set; } = 0;
        public string[] PointsHistory { get; set; } = new string[100];
        public int HistoryCount { get; set; } = 0;

        public string[] UsedVouchers { get; set; } = new string[10];
        public int UsedCount { get; set; } = 0;
    }
    public class RewardOption
    {
        public int RewardID { get; set; }
        public string Name { get; set; } = "";
        public int Cost { get; set; }
    }
    public class VoucherCode
    {
        public string Code { get; set; } = "";
        public int Points { get; set; }
    }}