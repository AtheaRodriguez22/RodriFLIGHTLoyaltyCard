using System;
namespace flightloyaltyCard;

static void Main()
{
    string name = "";
    string email = "";
    string contact = "";
    int points = 0;
    int voucherUsed = 0;
    int choice;

    Console.WriteLine("-----LOYALTY CARD SYSTEM-----");
    Console.Write("Enter Name: ");
    name = Console.ReadLine();
    Console.Write("Enter Email: ");
    email = Console.ReadLine();
    Console.Write("Enter Contact Number: ");
    contact = Console.ReadLine();
    Console.Write("Enter Starting Points: ");
    do
    {
        Console.WriteLine("Invalid input. Please enter a number."); { //note: possible iadd ko pa validation here hihi
        Console.WriteLine("\n----- MENU -----");
        Console.WriteLine("1. Edit Information");
        Console.WriteLine("2. View Total Points");
        Console.WriteLine("3. Redeem Points");
        Console.WriteLine("4. Enter Voucher Code");
        Console.WriteLine("5. Delete Account");
        Console.WriteLine("6. Exit");
        Console.Write("Choose: ");
              
    switch (choice) {
        case 1;
           Console.WriteLine("\n----Edit Information----");
           Console.Write("New Name");
           name = Console.ReadLine();
           Console.Write("Email");
           email = Console.ReadLine();
           Console.Write("Email");
           email = Console.ReadLine();
           Console.Write("Contact");
           contact = Console.ReadLine();
           Console.WriteLine("\n----Your Information Is Updated----");
        break;
        case 2
           Console.WriteLine("\n----Account Summary----");
           Console.WriteLine("Name: " + name);
            }