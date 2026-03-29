using FLIGHTLoyaltyCardModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FLIGHTLoyaltyCardDataService
{
    public class LoyaltyDataService
    {
        private List<LoyaltyAccount> accounts = new List<LoyaltyAccount>();

        public void Add(LoyaltyAccount account)
        {
            accounts.Add(account);
        }
        //    Name = "Athea",
        //    Email = "abctest@email.com",
        //    Contact = "09999999999",
        //    Points = 500
        //});
        //rewards.Add(new RewardOption { RewardId = 1, Name = "KFC", Cost =  });
        //rewards.Add(new RewardOption { RewardId = 2, Name = "Jollibee", Cost =  });
        //rewards.Add(new RewardOption { RewardId = 3, Name = "Wendy's", Cost =  });
        //rewards.Add(new RewardOption { RewardId = 4, Name = "McDonald's", Cost = });
        //new RewardOption { RewardID = 5, Name = "Flight Discount", Cost =  },
        //new RewardOption { RewardID = 5, Name = "Business Class", Cost =  }, 

        //vouchers.Add(new VoucherCode { Code = "FLY50", Points = 50 });
        //vouchers.Add(new VoucherCode { Code = "BONUS100", Points = 100 });
        //vouchers.Add(new VoucherCode { Code = "WELCOME200", Points = 200 });
        public LoyaltyAccount? GetAccount(Guid id)
        {
            return accounts.FirstOrDefault(a => a.AccountID == id);
        }

        public List<LoyaltyAccount> GetAccounts()
        {
            return accounts;
        }

        public void Update(LoyaltyAccount account)
        {
            var existing = GetAccount(account.AccountID);

            if (existing != null)
            {
                existing.Name = account.Name;
                existing.Email = account.Email;
                existing.Contact = account.Contact;
                existing.FlightNumber = account.FlightNumber; //new add
                existing.Points = account.Points;
                existing.PointsHistory = account.PointsHistory;
                existing.UsedVouchers = account.UsedVouchers;
            }
        }

        public void DeleteAccount(Guid id)
        {
            var account = GetAccount(id);
            if (account != null)
                accounts.Remove(account);
        }
        public List<RewardOption> GetRewards()
        {
            return RewardOption.DefaultRewards.ToList();
        }
        public RewardOption? GetRewardById(int rewardId)
        {
            return RewardOption.DefaultRewards.FirstOrDefault(r => r.RewardId == rewardId);
        }

        public VoucherCode? GetVoucher(string code)
        {
            return VoucherCode.DefaultVouchers
                .FirstOrDefault(v => v.Code.Equals(code, StringComparison.OrdinalIgnoreCase));
        }
    }
}