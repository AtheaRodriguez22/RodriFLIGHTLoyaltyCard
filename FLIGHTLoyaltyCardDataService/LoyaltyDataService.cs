using FLIGHTLoyaltyCardModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FLIGHTLoyaltyCardDataService
{
    public class LoyaltyDataService
    {
        private List<LoyaltyAccount> accounts = new List<LoyaltyAccount>();
        private List<RewardOption> rewards = new List<RewardOption>();
        private List<VoucherCode> vouchers = new List<VoucherCode>();

        public LoyaltyDataService()
        {
            accounts.Add(new LoyaltyAccount
            {
                Name = "Athea",
                Email = "abctest@email.com",
                Contact = "09999999999",
                Points = 500
            });
            rewards.Add(new RewardOption { RewardID = 1, Name = "KFC", Cost = 100 });
            rewards.Add(new RewardOption { RewardID = 2, Name = "Jollibee", Cost = 120 });
            rewards.Add(new RewardOption { RewardID = 3, Name = "Wendy's", Cost = 150 });
            rewards.Add(new RewardOption { RewardID = 4, Name = "McDonald's", Cost = 130 });
            rewards.Add(new RewardOption { RewardID = 5, Name = "Flight Discount", Cost = 300 });

            vouchers.Add(new VoucherCode { Code = "FLY50", Points = 50 });
            vouchers.Add(new VoucherCode { Code = "BONUS100", Points = 100 });
            vouchers.Add(new VoucherCode { Code = "WELCOME200", Points = 200 });
        }
        public void Add(LoyaltyAccount account)
        {
            accounts.Add(account);
        }
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
            return rewards;
        }

        public RewardOption? GetRewardById(int rewardId)
        {
            return rewards.FirstOrDefault(r => r.RewardID == rewardId);
        }

        public VoucherCode? GetVoucher(string code)
        {
            return vouchers.FirstOrDefault(v => v.Code == code.ToUpper().Trim());
        }
    }
}