using System;
using FLIGHTLoyaltyCardModels;
using FLIGHTLoyaltyCardDataService;
using FLIGHTLoyaltyCardAppService;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Xml.Linq;

namespace FLIGHTLoyaltyCard
{
        class Program
        {
            static void Main(string[] args)
            {
                LoyaltyDataService dataService = new LoyaltyDataService();
                LoyaltyAppService appService = new LoyaltyAppService(dataService);

                LoyaltyAccount currentAccount = null;

                Console.WriteLine("===== WELCOME TO FLIGHT LOYALTY CARD SYSTEM =====");

                int choice;
                do
                {
                    bool has = currentAccount != null;
                    int n = has ? 0 : 1;

                    Console.WriteLine();
                    if (!has) Console.WriteLine("1. Create An Account");
                    Console.WriteLine((1 + n) + ". Edit Information");
                    Console.WriteLine((2 + n) + ". View Account & Points Summary");
                    Console.WriteLine((3 + n) + ". Redeem Points");
                    Console.WriteLine((4 + n) + ". Enter Voucher Code");
                    Console.WriteLine((5 + n) + ". Delete Account");
                    Console.WriteLine((6 + n) + ". Exit");

                    Console.Write("Choose: ");
                    if (!int.TryParse(Console.ReadLine(), out choice))
                    {
                        Console.WriteLine("Invalid input. Please enter a number.");
                        continue;
                    }

                    int choose = has ? choice + 1 : choice;

                    switch (choose)
                    {
                        case 1: // CREATE
                            LoyaltyAccount account = new LoyaltyAccount();
                            Console.Write("Enter Name: ");
                            account.Name = Console.ReadLine() ?? "";
                            Console.Write("Enter Email: ");
                            account.Email = Console.ReadLine() ?? "";
                            Console.Write("Enter Contact: ");
                            account.Contact = Console.ReadLine() ?? "";
                            Console.Write("Enter Flight Number: ");
                            account.FlightNumber = Console.ReadLine() ?? "";
                            Console.Write("Enter Starting Points: ");
                            account.Points = int.TryParse(Console.ReadLine(), out int sp) ? sp : 0;

                            account.PointsHistory.Add($"[START] Account created with {account.Points} points.");
                            appService.Add(account);
                            currentAccount = account;
                            Console.WriteLine($"\nWelcome, {account.Name}! You have {account.Points} points.");
                            break;


                    case 2: //EDIT
                        if (currentAccount == null) { Console.WriteLine("No account found."); break; }
                        Console.Write("New Name: ");
                        currentAccount.Name = Console.ReadLine() ?? "";
                        Console.Write("New Email: ");
                        currentAccount.Email = Console.ReadLine() ?? "";
                        Console.Write("New Contact: ");
                        currentAccount.Contact = Console.ReadLine() ?? "";
                        Console.Write("New Flight Number: ");
                        currentAccount.FlightNumber = Console.ReadLine() ?? "";
                        appService.Update(currentAccount);
                        Console.WriteLine("\n----Your Information Is Updated!----");
                        break;

                    case 3: // SUMMARY
                            if (currentAccount == null) { Console.WriteLine("No account found."); break; }
                            Console.WriteLine("\n----Account Summary----");
                            Console.WriteLine("Name          : " + currentAccount.Name);
                            Console.WriteLine("Email         : " + currentAccount.Email);
                            Console.WriteLine("Contact       : " + currentAccount.Contact);
                            Console.WriteLine("Flight Number : " + currentAccount.FlightNumber);
                            Console.WriteLine("\nPoints        : " + currentAccount.Points);
                            Console.WriteLine("Current Tier  : " + currentAccount.GetTier());
                            Console.WriteLine("\nUnranked --> Bronze (500) --> Silver (800) --> Gold (1200) --> Platinum (2000)");
                            Console.WriteLine("\n--- Points History ---");
                            if (currentAccount.PointsHistory.Count == 0)
                                Console.WriteLine("No activity yet.");
                            else
                                foreach (var h in currentAccount.PointsHistory) Console.WriteLine(h);
                            break;

                        case 4: // REDEEM
                            if (currentAccount == null) { Console.WriteLine("No account found."); break; }
                            Console.WriteLine("\n--- Redeem Options ---");
                            foreach (var r in appService.GetRewards())
                                Console.WriteLine($"{r.RewardId}. {r.Name} - {r.Cost} pts");
                            Console.Write("Choose reward ID: ");
                            if (!int.TryParse(Console.ReadLine(), out int rewardId)) { Console.WriteLine("Invalid choice."); break; }
                            var reward = appService.GetRewardById(rewardId);
                            if (reward == null) { Console.WriteLine("Invalid Reward."); break; }
                            if (currentAccount.Points >= reward.Cost)
                            {
                                currentAccount.Points -= reward.Cost;
                                currentAccount.PointsHistory.Add($"[REDEEM] {reward.Name} redeemed for {reward.Cost} pts.");
                                appService.Update(currentAccount);
                                Console.WriteLine($"Successfully redeemed {reward.Name}! Remaining points: {currentAccount.Points}");
                            }
                            else Console.WriteLine("Not enough points!");
                            break;

                        case 5: // VOUCHER
                            if (currentAccount == null) { Console.WriteLine("No account found."); break; }
                            Console.Write("Enter Voucher Code: ");
                            string code = (Console.ReadLine() ?? "").Trim().ToUpper();
                            if (currentAccount.UsedVouchers.Contains(code)) { Console.WriteLine("This voucher has already been used!"); break; }
                            var voucher = appService.GetVoucherByCode(code);
                            if (voucher == null) { Console.WriteLine("Invalid voucher code. Hint: Try FLY50, BONUS100, or WELCOME200"); break; }
                            currentAccount.Points += voucher.Points;
                            currentAccount.UsedVouchers.Add(code);
                            currentAccount.PointsHistory.Add($"[VOUCHER] Code '{code}' applied +{voucher.Points} pts.");
                            appService.Update(currentAccount);
                            Console.WriteLine($"Voucher '{code}' applied! Total: {currentAccount.Points} pts.");
                            break;

                        case 6: // DELETE ACC
                            if (currentAccount == null) { Console.WriteLine("No account found."); break; }
                            Console.Write("Are you sure you want to delete your account? (yes/no): ");
                            if ((Console.ReadLine() ?? "").Trim().ToLower() == "yes")
                            {
                                appService.Delete(currentAccount.AccountID);
                                currentAccount = null;
                                Console.WriteLine("\nAccount has been deleted. Goodbye!");
                                return;
                            }
                            Console.WriteLine("Account deletion cancelled.");
                            break;

                        case 7:
                            Console.WriteLine("\nThank you for using the Flight Loyalty Card System. Goodbye!");
                            break;

                        default:
                            Console.WriteLine("Invalid choice.");
                            break;
                    }
                } while (choice != 7);
            }
        }
    }
