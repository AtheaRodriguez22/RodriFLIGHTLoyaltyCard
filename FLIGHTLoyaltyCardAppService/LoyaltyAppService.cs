using FLIGHTLoyaltyCardModels;
using FLIGHTLoyaltyCardDataService;
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

        public void Delete(Guid accountId)
        {
            _dataService.DeleteAccount(accountId);
            
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

