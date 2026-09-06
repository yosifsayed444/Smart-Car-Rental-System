using Smart_Car_Rental_System.Services;

namespace Smart_Car_Rental_System.Models
{
    internal static class App
    {
        public static void Run()
        {
            RentalSystem system = new RentalSystem();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("======================================");
                Console.WriteLine("       SMART CAR RENTAL SYSTEM");
                Console.WriteLine("======================================");
                Console.WriteLine("1. Show Branch Information");
                Console.WriteLine("2. Show All Users");
                Console.WriteLine("3. Show Available Cars");
                Console.WriteLine("4. Show All Fleet");
                Console.WriteLine("5. Rent Car");
                Console.WriteLine("6. Return Car");
                Console.WriteLine("7. Show Rental History");
                Console.WriteLine("8. Register Customer");
                Console.WriteLine("0. Exit");
                Console.WriteLine("======================================");

                Console.Write("Choose an option: ");
                string? choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            system.ShowBranchInfo();
                            break;
                        case "2":
                            system.ShowAllUsers();
                            break;
                        case "3":
                            system.ShowAvailableCars();
                            break;
                        case "4":
                            system.ShowAllFleet();
                            break;
                        case "5":
                            system.RentCar();
                            break;
                        case "6":
                            system.ReturnCar();
                            break;
                        case "7":
                            system.ShowRentalHistory();
                            break;
                        case "8":
                            system.RegisterCustomer();
                            break;
                        case "0":
                            Console.WriteLine("Goodbye!");
                            return;
                        default:
                            Console.WriteLine("Invalid choice!");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }

                Console.WriteLine();
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
            }
        }
    }
}
