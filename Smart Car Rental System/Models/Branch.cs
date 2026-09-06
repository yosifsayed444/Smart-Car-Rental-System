namespace Smart_Car_Rental_System.Models
{
    internal class Branch
    {
        public string BranchId { get; private set; }
        public string BranchName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public string Hours { get; set; }
        public Manager Manager { get; set; }

        private readonly List<Car> Cars;
        private readonly List<Customer> Customers;

        public Branch(string branchName, string address, string phone,string hours, Manager manager)
        {
            BranchId = Helper.GenerateID("Branch");
            BranchName = branchName;
            Address = address;
            Phone = phone;
            Hours = hours;
            Manager = manager;
            Cars = new List<Car>();
            Customers = new List<Customer>();
        }

        public void AddCar(Car car)
        {
            if (car != null && !Cars.Contains(car))
                Cars.Add(car);
        }

        public void AddCustomer(Customer customer)
        {
            if (customer != null && !Customers.Contains(customer))
                Customers.Add(customer);
        }

        public int GetTotalVehicles() => Cars.Count;
        public int GetTotalCustomers() => Customers.Count;
        public string CountCars() => $"Number of Cars: {Cars.Count}";
        public string CountCustomers() => $"Number of Customers: {Customers.Count}";
    }
}
