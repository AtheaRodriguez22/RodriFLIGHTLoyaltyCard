using FLIGHTLoyaltyCardModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace FLIGHTLoyaltyCardDataService
{
    public class LoyaltyDataService_DB
    {
       
        string connectionString = @"Server=localhost\SQLEXPRESS;Database=RodriFLIGHTLoyaltyCard;Trusted_Connection=True;";
        private List<LoyaltyAccount> accounts = new List<LoyaltyAccount>();

       
        public void Add(LoyaltyAccount account)
        {
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open(); 
                string query = "INSERT INTO UserAccount (Name, Email, Contact, FlightNumber, Points, UsedVoucher, PointHistory) " +
                               "VALUES (@Name, @Email, @Contact, @FlightNumber, @Points, @UsedVoucher, @PointHistory)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", account.Name);
                cmd.Parameters.AddWithValue("@Email", account.Email);
                cmd.Parameters.AddWithValue("@Contact", account.Contact);
                cmd.Parameters.AddWithValue("@FlightNumber", account.FlightNumber);
                cmd.Parameters.AddWithValue("@Points", account.Points);

                string vouchersString = string.Join(",", account.UsedVouchers);
                string historyString = string.Join("|", account.PointsHistory);

                cmd.Parameters.AddWithValue("@UsedVoucher", vouchersString);
                cmd.Parameters.AddWithValue("@PointHistory", historyString);

                cmd.ExecuteNonQuery(); 
                accounts.Add(account);
            }
            finally
            {
                conn.Close();
            }
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
            List<LoyaltyAccount> accountsFromDb = new List<LoyaltyAccount>();
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();
                string query = "SELECT Name, Email, Contact, FlightNumber, Points, UsedVoucher, PointHistory FROM UserAccount";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    LoyaltyAccount acc = new LoyaltyAccount();

                    acc.Name = reader["Name"].ToString().Trim();
                    acc.Email = reader["Email"].ToString().Trim();
                    acc.Contact = reader["Contact"].ToString().Trim();
                    acc.FlightNumber = reader["FlightNumber"].ToString().Trim();
                    acc.Points = Convert.ToInt32(reader["Points"]);

                    string dbVouchers = reader["UsedVoucher"].ToString().Trim();
                    if (!string.IsNullOrEmpty(dbVouchers))
                    {
                        acc.UsedVouchers = dbVouchers.Split(',').ToList();
                    }

                    string dbHistory = reader["PointHistory"].ToString().Trim();
                    if (!string.IsNullOrEmpty(dbHistory))
                    {
                        acc.PointsHistory = dbHistory.Split('|').ToList();
                    }

                    accountsFromDb.Add(acc);
                }
            }
            finally
            {
                conn.Close(); 
            }

            return accountsFromDb;
        }

        public void Update(LoyaltyAccount account)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            //var existing = GetAccount(account.AccountID);

            //if (existing != null)
            //{
            //    existing.Name = account.Name;
            //    existing.Email = account.Email;
            //    existing.Contact = account.Contact;
            //    existing.FlightNumber = account.FlightNumber; //new add
            //    existing.Points = account.Points;
            //    existing.PointsHistory = account.PointsHistory;
            //    existing.UsedVouchers = account.UsedVouchers;
            //}
            try
            {
                conn.Open();

                // fUnctio by telling SQL to change an existing data. 
                string query = "UPDATE UserAccount SET Email = @Email, Contact = @Contact, FlightNumber = @FlightNumber, Points = @Points, UsedVoucher = @UsedVoucher, PointHistory = @PointHistory WHERE Name = @Name";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Name", account.Name);
                cmd.Parameters.AddWithValue("@Email", account.Email);
                cmd.Parameters.AddWithValue("@Contact", account.Contact);
                cmd.Parameters.AddWithValue("@FlightNumber", account.FlightNumber);
                cmd.Parameters.AddWithValue("@Points", account.Points);

                string vouchersString = string.Join(",", account.UsedVouchers);
                string historyString = string.Join("|", account.PointsHistory);

                cmd.Parameters.AddWithValue("@UsedVoucher", vouchersString);
                cmd.Parameters.AddWithValue("@PointHistory", historyString);

                cmd.ExecuteNonQuery(); 
                var existing = GetAccount(account.AccountID);
                if (existing != null)
                {
                    existing.Name = account.Name;
                    existing.Email = account.Email;
                    existing.Contact = account.Contact;
                    existing.FlightNumber = account.FlightNumber;
                    existing.Points = account.Points;
                    existing.UsedVouchers = account.UsedVouchers;
                    existing.PointsHistory = account.PointsHistory;
                }
            }
            finally
            {
                conn.Close();
            }
        }

        public void DeleteAccount(Guid id)
        {
            var accountToDelete = GetAccount(id);

            if (accountToDelete != null)
            {
                SqlConnection conn = new SqlConnection(connectionString);

                try
                {
                    conn.Open();

                    string query = "DELETE FROM UserAccount WHERE Name = @Name";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Name", accountToDelete.Name);

                    cmd.ExecuteNonQuery(); 
                }
                finally
                {
                    conn.Close();
                }

                accounts.Remove(accountToDelete);
            }
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