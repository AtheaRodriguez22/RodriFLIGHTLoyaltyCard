using LoyaltyDataService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FLIGHTLoyaltyCardDataService
{
    public class LoyaltyDataService
    {
        private List<LoyaltyAccount> _accounts = new List<LoyaltyAccount>();
        private List<RewardOption> _rewards = new List<RewardOption>
        {
            new RewardOption { RewardID = 1, Name = "KFC",             Cost = 100 },
            new RewardOption { RewardID = 2, Name = "Jollibee",        Cost = 120 },
            new RewardOption { RewardID = 3, Name = "Wendy's",         Cost = 150 },
            new RewardOption { RewardID = 4, Name = "McDonald's",      Cost = 130 },
            new RewardOption { RewardID = 5, Name = "Flight Discount", Cost = 300 },
        };

        private List<Voucher> _vouchers = new List<Voucher>
        {
            new Voucher { Code = "FLY50",      Points = 50  },
            new Voucher { Code = "BONUS100",   Points = 100 },
            new Voucher { Code = "WELCOME200", Points = 200 },
        };

        public void Add(LoyaltyAccount account)
        {
            _accounts.Add(account);
        }

        public LoyaltyAccount? GetById(Guid accountId)
        {
            return _accounts.FirstOrDefault(a => a.AccountID == accountId);
        }

        public List<LoyaltyAccount> GetAll()
        {
            return _accounts;
        }

        public void Update(LoyaltyAccount account)
        {
            var existing = GetById(account.AccountID);
            if (existing == null) return;

            existing.Name = account.Name;
            existing.Email = account.Email;
            existing.Contact = account.Contact;
            existing.Points = account.Points;
            existing.PointsHistory = account.PointsHistory;
            existing.UsedVouchers = account.UsedVouchers;
        }

        public void Delete(Guid accountId)
        {
            var account = GetById(accountId);
            if (account != null)
                _accounts.Remove(account);
        }

        public List<RewardOption> GetRewards()
        {
            return _rewards;
        }

        public RewardOption? GetRewardById(int rewardId)
        {
            return _rewards.FirstOrDefault(r => r.RewardID == rewardId);
        }

        public Voucher? GetVoucherByCode(string code)
        {
            return _vouchers.FirstOrDefault(v => v.Code == code.ToUpper().Trim());
        }
    }
}