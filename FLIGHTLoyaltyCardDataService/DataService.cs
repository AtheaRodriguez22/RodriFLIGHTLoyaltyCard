using FLIGHTLoyaltyCardModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace FLIGHTLoyaltyCardDL
{
    public class LoyaltyDataService
    {
        public List<LoyaltyAccount> dummyAccounts = new List<LoyaltyAccount>();
        public List<RewardOption> dummyRewards = new List<RewardOption>();
        public List<VoucherCode> dummyVouchers = new List<VoucherCode>();

        public LoyaltyDataService()
        {
            LoyaltyAccount account1 = new LoyaltyAccount
            {
                Name = "",
                Email = "",
                Contact = "",
                Points = 200
            };

            LoyaltyAccount account2 = new LoyaltyAccount
            {
                Name = " ",
                Email = " ",
                Contact = " ",
                Points = 500
            };

            dummyAccounts.Add(account1);
            dummyAccounts.Add(account2);

            dummyRewards.Add(new RewardOption { RewardID = 1, Name = "KFC", Cost = 100 });
            dummyRewards.Add(new RewardOption { RewardID = 2, Name = "Jollibee", Cost = 120 });
            dummyRewards.Add(new RewardOption { RewardID = 3, Name = "Wendy's", Cost = 150 });
            dummyRewards.Add(new RewardOption { RewardID = 4, Name = "McDonald's", Cost = 130 });
            dummyRewards.Add(new RewardOption { RewardID = 5, Name = "Flight Discount", Cost = 300 });

            dummyVouchers.Add(new VoucherCode { Code = "FLY50", Points = 50 });
            dummyVouchers.Add(new VoucherCode { Code = "BONUS100", Points = 100 });
            dummyVouchers.Add(new VoucherCode { Code = "WELCOME200", Points = 200 });
        }

        public void Add(LoyaltyAccount account)
        {
            dummyAccounts.Add(account);
        }

        public LoyaltyAccount? GetById(Guid id)
        {
            return dummyAccounts.FirstOrDefault(a => a.AccountID == id);
        }

        public List<LoyaltyAccount> GetAccounts()
        {
            return dummyAccounts;
        }

        public void Update(LoyaltyAccount account)
        {
            var existing = GetById(account.AccountID);

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

        public void Delete(Guid id)
        {
            var account = GetById(id);

            if (account != null)
                dummyAccounts.Remove(account);
        }

        public List<RewardOption> GetRewards()
        {
            return dummyRewards;
        }

        public RewardOption? GetRewardById(int rewardId)
        {
            return dummyRewards.FirstOrDefault(r => r.RewardID == rewardId);
        }

        public VoucherCode? GetVoucherByCode(string code)
        {
            return dummyVouchers.FirstOrDefault(v => v.Code == code.ToUpper().Trim());
        }
    }
}