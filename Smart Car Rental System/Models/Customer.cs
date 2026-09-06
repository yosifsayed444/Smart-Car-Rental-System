namespace Smart_Car_Rental_System.Models
{
    internal class Customer : Person
    {
        public string CustomerId { get; private set; }
        public DateTime JoinedDate { get; private set; }
        public int ActiveRentals => Rentals.Count;

        private readonly List<RentalTransactions> Rentals;

        public Customer(string name, string email, string phone) : base(name, email, phone)
        {
            CustomerId = Helper.GenerateID("Cust");
            JoinedDate = DateTime.Now;
            Rentals = new List<RentalTransactions>();
        }

        public void AddTransaction(RentalTransactions transaction)
        {
            if (transaction == null)
                throw new ArgumentNullException(nameof(transaction));

            Rentals.Add(transaction);
        }

        public List<RentalTransactions> GetRentalHistory()
        {
            return Rentals;
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine(
                $"Customer ID: {CustomerId} |" +
                $"Joined Date: {JoinedDate} |" +
                $"Active Rentals: {ActiveRentals}"
                );
        }
    }
}
