using Smart_Car_Rental_System.Enums;
using Smart_Car_Rental_System.Models;

namespace Smart_Car_Rental_System.Services
{
    internal class RentalSystem
    {
        private readonly Branch branch;
        private readonly List<Customer> customers;
        private readonly List<Car> cars;
        private Manager manager;
        private readonly List<RentalTransactions> transactions;

        public RentalSystem()
        {
            customers = new List<Customer>();
            cars = new List<Car>();
            transactions = new List<RentalTransactions>();
            manager = new Manager("yousif sayed", "yousif@gmail.com", "01000000000", 15000);
            branch = new Branch("Main Branch","Cairo, Egypt","01000000000","08:00 - 17:00",manager);

            AllCars();
        }

        private void AllCars()
        {
            AddCar(new Car("Toyota", 2024));
            AddCar(new Car("Hyundai", 2023));
            AddCar(new Car("Kia", 2024));
            AddCar(new Car("BMW", 2022));
            AddCar(new Car("Mercedes", 2022));
            AddCar(new Car("fiat", 2022));
            AddCar(new Car("BMW", 2019));
        }

        private void AddCar(Car car)
        {
            cars.Add(car);
            branch.AddCar(car);
        }

        public Customer? FindCustomer(string id)
        {
            foreach (var customer in customers)
            {
                if(id == customer.CustomerId)
                {
                    return customer;
                }
            }
            return null;
        }

        public Car? FindCar(string id)
        {
            foreach (var car in cars)
            {
                if (id == car.CarId)
                {
                    return car;
                }
            }
            return null;
        }

        public void RegisterCustomer()
        {
            Console.Write("Enter Customer Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Phone: ");
            string phone = Console.ReadLine();

            Console.Write("Enter Email: ");
            string email = Console.ReadLine();

            Customer customer = new Customer(name, email, phone);
            customers.Add(customer);
            branch.AddCustomer(customer);

            Console.WriteLine("Customer registered successfully.");
            Console.WriteLine($"Customer ID: {customer.CustomerId}");
        }

        public void RentCar()
        {
            if (customers.Count == 0)
            {
                Console.WriteLine("No customers registered. Register a customer first.");
                return;
            }

            Console.Write("Enter Customer ID: ");
            string customerId = Console.ReadLine() ?? string.Empty;

            Customer? customer = FindCustomer(customerId);
            if (customer == null)
            {
                Console.WriteLine("Customer not found.");
                return;
            }

            ShowAvailableCars();
            Console.Write("Enter Car ID: ");
            string carId = Console.ReadLine() ?? string.Empty;

            Car? car = FindCar(carId);
            if (car == null)
            {
                Console.WriteLine("Car not found.");
                return;
            }

            if (!car.IsAvailable())
            {
                Console.WriteLine("Car is not available.");
                return;
            }

            RentalTransactions transaction = new RentalTransactions(car, customer, DateTime.Now);

            car.Rent(transaction);
            customer.AddTransaction(transaction);
            transactions.Add(transaction);

            Console.WriteLine("Car rented successfully.");
            Console.WriteLine($"Transaction ID: {transaction.TransactionId}");
        }

        public void ReturnCar()
        {
            Console.Write("Enter Car ID: ");
            string carId = Console.ReadLine() ?? string.Empty;

            Car? car = FindCar(carId);

            if (car == null)
            {
                Console.WriteLine($"Car [{carId}] not found.");
                return;
            }

            if (car.CarStatus != CarStatus.Rented)
            {
                Console.WriteLine($"Car [{carId}] is not currently rented.");
                return;
            }

            RentalTransactions? transaction = car.ActiveTransaction;

            if (transaction == null || transaction.Status != TransactionStatus.Active)
            {
                Console.WriteLine("No active transaction for this car.");
                return;
            }
            
            decimal fees = transaction.CalculateFees(DateTime.Now);
            car.Return();

            Console.WriteLine($"Car [{car.CarId}]: {car.Model} {car.Year} returned.");

            if (fees == 0)
            {
                Console.WriteLine("Returned on time. No late fee.");
            }
            else
            {
                Console.WriteLine($"Late return fee: {fees:F2} EGP");
            }
        }

        public void ShowAvailableCars()
        {
            Console.WriteLine("Available Cars:");

            bool found = false;
            foreach (Car car in cars)
            {
                if (car.IsAvailable())
                {
                    found = true;
                    Console.WriteLine($"ID: {car.CarId} | Model: {car.Model} | Year: {car.Year}" + $"  | Condition: {car.ConditionStatus}| Status: {car.CarStatus}");
                }
            }

            if (!found)
                Console.WriteLine("No available cars.");
        }

        public void ShowAllFleet()
        {
            Console.WriteLine("All Vehicles:");

            foreach (Car car in cars)
            {
                Console.WriteLine($"ID: {car.CarId} | Model: {car.Model} | " +$"Year: {car.Year} | Status: {car.CarStatus} | " + $"Condition: {car.ConditionStatus}");
            }
        }

        public void ShowAllUsers()
        {
            Console.WriteLine("All Users:");

            if (customers.Count == 0)
            {
                Console.WriteLine("No customers registered.");
                return;
            }

            Console.WriteLine("Manager Profile:");
            manager.DisplayInfo();
            Console.WriteLine("Customers:");
            foreach (Customer customer in customers)
            {
                customer.DisplayInfo();
                Console.WriteLine("----------------------------");
            }
        }

        public void ShowRentalHistory()
        {
            if (customers.Count == 0)
            {
                Console.WriteLine("No customers registered.");
                return;
            }
            Console.Write("Enter Customer ID: ");
            string customerId = Console.ReadLine() ?? string.Empty;

            Customer? customer = FindCustomer(customerId);
            if (customer == null)
            {
                Console.WriteLine("Customer not found.");
                return;
            }
           List<RentalTransactions> history =  customer.GetRentalHistory();

            Console.WriteLine($"Rental History for {customer.Name}:");

            if (history.Count == 0)
            {
                Console.WriteLine("No rental transactions found.");
                return;
            }

            foreach (RentalTransactions transaction in history)
            {
                transaction.DisplayInfo();
                Console.WriteLine("----------------------------");
            }
        }

        public void ShowBranchInfo()
        {
            Console.WriteLine($"Branch ID: {branch.BranchId}");
            Console.WriteLine($"Name: {branch.BranchName}");
            Console.WriteLine($"Address: {branch.Address}");
            Console.WriteLine($"Phone: {branch.Phone}");
            Console.WriteLine($"Hours : {branch.Hours}");
            Console.WriteLine($"Manager: {branch.Manager.Name}");
            Console.WriteLine($"Total Customers: {branch.GetTotalCustomers()}");
            Console.WriteLine($"Total Vehicles: {branch.GetTotalVehicles()}");
            
        }
    }
}
