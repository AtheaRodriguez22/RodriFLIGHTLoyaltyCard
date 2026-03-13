using System;
using System.Collections.Generic;
namespace flightloyaltyCard { 

static class Program
{
    static string name = "";
    static string email = "";
    static string contact = "";
    static string rewardName = "";
    static int points = 0;
    
       static string[] pointsHistory = new string[100];
       static int historyCount = 0;

       static string[] voucherCodes = { "FLY50", "BONUS100", "WELCOME200" };
       static int[] voucherPoints = { 50, 100, 200 };

       static string[] usedVouchers = new string[10];
       static int usedCount = 0;
       
       static void Main(string[] args)
        {

            Console.WriteLine("===== WELCOME TO FLIGHT LOYALTY CARD SYSTEM =====");

        int choice;
    do
    {
           bool hasAccount = name != "";
           int n = hasAccount ? 0 : 1;

            Console.WriteLine();
                if (!hasAccount)
                {
            Console.WriteLine("1. Create An Account");
                }
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
                    continue; }
            int actualChoice = hasAccount ? choice + 1 : choice;

    switch (actualChoice) {
    case 1:
           Console.WriteLine("\n--- Create Your Account---");

           Console.Write("Enter Name: ");
           name = Console.ReadLine();
           Console.Write("Enter Email: ");
           email = Console.ReadLine();
           Console.Write("Enter Contact Number: ");
           contact = Console.ReadLine();
           Console.Write("Enter Starting Points: ");

           if (!int.TryParse(Console.ReadLine(), out points)) {
           Console.WriteLine("Invalid input. Starting points set to 0.");
           points = 0;
           }
           pointsHistory[historyCount++] = "[START] Account created with " + points + " points.";
           Console.WriteLine("\nWelcome, " + name + "! You have " + points + " points.");
    break;
    case 2:
           Console.WriteLine("\n----Edit Information----");
           Console.Write("New Name: ");
           name = Console.ReadLine();
           Console.Write("Email: ");
           email = Console.ReadLine();
           Console.Write("Contact: ");
           contact = Console.ReadLine();
           Console.WriteLine("\n----Your Information Is Updated!----");
    break;
    case 3:
           Console.WriteLine("\n----Account Summary----");
           Console.WriteLine("Name: " + name);
           Console.WriteLine("\n--- Account Details ---");
           Console.WriteLine("Name    : " + name);
           Console.WriteLine("Email   : " + email);
           Console.WriteLine("Contact : " + contact);
           Console.WriteLine("Points  : " + points);

           Console.WriteLine("\n--- Points History ---");
            if (historyCount == 0)
             {
           Console.WriteLine("No activity yet.");}
            else{
            for (int i = 0; i < historyCount; i++) 
          Console.WriteLine(pointsHistory[i]);
          }
          break;
    case 4:
          Console.WriteLine("\n--- Redeem Options ---");
          Console.WriteLine("1. KFC             - 100 pts");
          Console.WriteLine("2. Jollibee        - 120 pts");
          Console.WriteLine("3. Wendy's         - 150 pts");
          Console.WriteLine("4. McDonald's      - 130 pts");
          Console.WriteLine("5. Flight Discount - 300 pts");
          Console.Write("Choose reward: ");

          int reward;
              int rewardCost = 0;
                        if (!int.TryParse(Console.ReadLine(), out reward)){
          Console.WriteLine("Invalid choice.");
    break;
            }

            if (reward == 1) { rewardName = "KFC"; rewardCost = 100; }
            else if (reward == 2) { rewardName = "Jollibee"; rewardCost = 120; }
            else if (reward == 3) { rewardName = "Wendy's"; rewardCost = 150; }
            else if (reward == 4) { rewardName = "McDonald's"; rewardCost = 130; }
            else if (reward == 5) { rewardName = "Flight Discount"; rewardCost = 300; }
            else
            {
            Console.WriteLine("Invalid choice.");
    break;
            }
            if (points >= rewardCost){
            points -= rewardCost;
            pointsHistory[historyCount++] = "[REDEEM] " + rewardName + " redeemed for " + rewardCost + " pts. Remaining: " + points + " pts.";
            Console.WriteLine("Successfully redeemed " + rewardName + "! Remaining points: " + points);}
            else
            {
            Console.WriteLine("Not enough points! You need " + rewardCost + " pts but only have " + points + " pts.");}
    break;

    case 5:
            Console.Write("Enter Voucher Code: ");
            string code = Console.ReadLine().Trim().ToUpper();
            bool alreadyUsed = false;
               for (int i = 0; i < usedCount; i++)
              {
                if (usedVouchers[i] == code){
                 alreadyUsed = true;
    break;}
      }

          if (alreadyUsed) {
            Console.WriteLine("This voucher has already been used!");}
          else
          {
          bool found = false;
          for (int i = 0; i < voucherCodes.Length; i++)
            {
          if (voucherCodes[i] == code) {
                 int bonus = voucherPoints[i];
                 points += bonus;
            usedVouchers[usedCount++] = code;
              pointsHistory[historyCount++] = "[VOUCHER] Code '" + code + "' applied. +" + bonus + " pts. Total: " + points + " pts.";
            Console.WriteLine("Voucher '" + code + "' applied! You earned " + bonus + " points. Total: " + points + " pts.");
             found = true;
    break; }
             }
if (!found){
          Console.WriteLine("Invalid voucher code. Please try again.");
          Console.WriteLine("Hint: Try FLY50, BONUS100, or WELCOME200");
                                }}
          break;
    case 6:
    Console.Write("Are you sure you want to delete your account? (yes/no): "); //back simula
            string confirm = Console.ReadLine().Trim().ToLower();
      if (confirm == "yes")
        {
    Console.WriteLine("\nAccount for '" + name + "' has been deleted. Goodbye!");
    return;}
          else
    {
    Console.WriteLine("Account deletion cancelled.");
     }
    break;
    case 7:
    Console.WriteLine("\nThank you for using the Flight Loyalty Card System. Goodbye!");
    break;

    default:
    Console.WriteLine("Invalid choice. Please choose 1-" + (6 + n) + ".");
    break;
                        }

            } while (choice != 7);

        }
    }
} 