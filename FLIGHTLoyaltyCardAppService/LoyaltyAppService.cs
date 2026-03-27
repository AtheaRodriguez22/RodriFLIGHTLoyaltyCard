using FLIGHTLoyaltyCardModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FLIGHTLoyaltyCardAppService
{
    public class LoyaltyAppService
    {
        private readonly LoyaltyDataService _dataService;

        public LoyaltyAppService(LoyaltyDataService dataService)
        {
            _dataService = dataService;
        }

        public void Add(LoyaltyAccount account)
        {
            _dataService.Add(account);
        }
        public LoyaltyAccount? GetById(Guid accountId)  // t get account by ID
        {
            return _dataService.GetAccount(accountId);
        }
        public List<LoyaltyAccount> GetAll()  // to get all the accounts
        {
            return _dataService.GetAccounts();
        }

        public void Update(LoyaltyAccount account)  // for acc update 
        {
            _dataService.Update(account);
        }
            //var existing = GetById(account.AccountID);
            //if (existing == null) return;

            //existing.Name = account.Name;
            //existing.Email = account.Email;
            //existing.Contact = account.Contact;
            //existing.Points = account.Points;
            //existing.PointsHistory = account.PointsHistory;
            //existing.UsedVouchers = account.UsedVouchers;

        public void Delete(Guid accountId)
        {
            _dataService.DeleteAccount(accountId);
            //var account = GetById(accountId);
            //if (account != null)
            //    _accounts.Remove(account);
        }
        public List<RewardOption> GetRewards()
        {
            return _dataService.GetRewards(); // for rewards
        }

        public RewardOption? GetRewardById(int rewardId)
        {
            return _dataService.GetRewardById(rewardId);
        }
        public VoucherCode? GetVoucherByCode(string code) // for vouchers
        {
            return _dataService.GetVoucher(code);
        }
    }
}
