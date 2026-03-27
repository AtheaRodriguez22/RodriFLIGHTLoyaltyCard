using System;
using FLIGHTLoyaltyCardModels;
using FLIGHTLoyaltyCardDataService;
using FLIGHTLoyaltyCardAppService;

namespace flightloyaltyCard
{
    class Program
    {
        private static FLIGHTLoyaltyCardAppService.LoyaltyDataService dataService = new FLIGHTLoyaltyCardAppService.LoyaltyDataService();
        static LoyaltyAppService appService = new LoyaltyAppService(dataService);
        static LoyaltyAccount? currentAccount = null;

        static void Main(string[] args)
        {
            Console.WriteLine("===== WELCOME TO FLIGHT LOYALTY CARD SYSTEM =====");

            int choice;
            do
            {
                bool hasAccount = currentAccount != null;
                int n = hasAccount ? 0 : 1;

                Console.WriteLine();
                if (!hasAccount)
                    Console.WriteLine("1. Create An Account");

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

                int actualChoice = hasAccount ? choice + 1 : choice;

                switch (actualChoice)
                {
                    case 1:
                        LoyaltyAccount account = new LoyaltyAccount();
                        account.Name = Console.ReadLine() ?? "";
                        account.Email = Console.ReadLine() ?? "";
                        account.Contact = Console.ReadLine() ?? "";

                        Console.Write("Enter Starting Points: ");
                        if (!int.TryParse(Console.ReadLine(), out int startPoints))
                        {
                            Console.WriteLine("Invalid input. Starting points set to 0.");
                            startPoints = 0;
                        }

                        account.Points = startPoints;
                        account.PointsHistory.Add("[START] Account created with " + startPoints + " points.");

                        appService.Add(account);
                        currentAccount = account;

                        Console.WriteLine($"\nWelcome, {account.Name}! You have {account.Points} points.");
                        break;

                    case 2:
                        if (currentAccount == null) { Console.WriteLine("No account found."); break; }
                        currentAccount.Name = Console.ReadLine() ?? "";
                        currentAccount.Email = Console.ReadLine() ?? "";
                        currentAccount.Contact = Console.ReadLine() ?? "";

                        appService.Update(currentAccount);
                        Console.WriteLine("\n----Your Information Is Updated!----");
                        break;


                    //if (currentAccount == null) { Console.WriteLine("No account found."); break; }
                    //Console.Write("New Name: ");
                    //currentAccount.Name = Console.ReadLine();
                    //Console.Write("Email: ");
                    //currentAccount.Email = Console.ReadLine();
                    //Console.Write("Contact: ");
                    //currentAccount.Contact = Console.ReadLine();

                    case 3:
                        if (currentAccount == null) { Console.WriteLine("No account found."); break; }
                        Console.WriteLine("\n----Account Summary----");
                        Console.WriteLine("Name : " + currentAccount.Name);
                        Console.WriteLine("Email : " + currentAccount.Email);
                        Console.WriteLine("Contact : " + currentAccount.Contact);
                        Console.WriteLine("Points : " + currentAccount.Points);

                        Console.WriteLine("\n--- Points History ---");
                        if (currentAccount.PointsHistory.Count == 0)
                            Console.WriteLine("No activity yet.");
                        else
                            foreach (var history in currentAccount.PointsHistory)
                                Console.WriteLine(history);
                        break;

                    case 4:
                        if (currentAccount == null) { Console.WriteLine("No account found."); break; }
                        var rewardsList = appService.GetRewards();
                        Console.WriteLine("\n--- Redeem Options ---");
                        foreach (var r in rewardsList)
                            Console.WriteLine($"{r.RewardId}. {r.Name} - {r.Cost} pts");

                        Console.Write("Choose reward ID: ");
                        if (!int.TryParse(Console.ReadLine(), out int rewardId))
                        {
                            Console.WriteLine("Invalid choice.");
                            break;
                        }

                        var selectedReward = appService.GetRewardById(rewardId);
                        if (selectedReward == null)
                        {
                            Console.WriteLine("Invalid Reward.");
                            break;
                        }

                        if (currentAccount.Points >= selectedReward.Cost)
                        {
                            currentAccount.Points -= selectedReward.Cost;
                            currentAccount.PointsHistory.Add("[REDEEM] " + selectedReward.Name + " redeemed for " + selectedReward.Cost + " pts.");
                            appService.Update(currentAccount);
                            Console.WriteLine("Successfully redeemed " + selectedReward.Name + "! Remaining points: " + currentAccount.Points);
                        }
                        else
                        {
                            Console.WriteLine("Not enough points!");
                        }
                        break;

                    case 5:
                        if (currentAccount == null) { Console.WriteLine("No account found."); break; }
                        Console.Write("Enter Voucher Code: ");
                        string code = (Console.ReadLine() ?? "").Trim().ToUpper();

                        if (currentAccount.UsedVouchers.Contains(code))
                        {
                            Console.WriteLine("This voucher has already been used!");
                            break;
                        }

                        var voucher = appService.GetVoucherByCode(code);
                        if (voucher == null)
                        {
                            Console.WriteLine("Invalid voucher code. Hint: Try FLY50, BONUS100, or WELCOME200");
                            break;
                        }

                        currentAccount.Points += voucher.Points;
                        currentAccount.UsedVouchers.Add(code);
                        currentAccount.PointsHistory.Add("[VOUCHER] Code '" + code + "' applied +" + voucher.Points + " pts.");
                        appService.Update(currentAccount);

                        Console.WriteLine("Voucher '" + code + "' applied! Total: " + currentAccount.Points + " pts.");
                        break;

                    case 6:
                        if (currentAccount == null)
                        {
                            Console.WriteLine("No account found.");
                            break;
                        }

                        Console.Write("Are you sure you want to delete your account? (yes/no): ");
                        string confirm = (Console.ReadLine() ?? "").Trim().ToLower();

                        if (confirm == "yes")
                        {
                            appService.Delete(currentAccount.AccountID);
                            currentAccount = null;
                            Console.WriteLine("\nAccount has been deleted. Goodbye!");
                            return;
                        }
                        else
                        {
                            Console.WriteLine("Account deletion cancelled.");
                        }
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
    }}