using Smart_Car_Rental_System.Enums;

namespace Smart_Car_Rental_System.Models
{
    internal class RentalTransactions
    {
        private const decimal FeePerDay = 150m;

        public string TransactionId { get; private set; }
        public Car Car { get; private set; }
        public Customer Customer { get; private set; }
        public DateTime RentalDate { get; private set; }
        public DateTime ReturnDate { get; private set; }
        public TransactionStatus Status { get; private set; }
        public decimal Fees { get; private set; }

        public RentalTransactions(Car car, Customer customer, DateTime rentalDate)
        {
            TransactionId = Helper.GenerateID("Transaction");
            Car = car;
            Customer = customer;
            RentalDate = rentalDate;
            Status = TransactionStatus.Active;
            Fees = 0;
        }
      
        public decimal CalculateFees(DateTime returnDate)
        {
            if (Status == TransactionStatus.Returned)
                return Fees;

            ReturnDate = returnDate;

            int daysRented = (returnDate.Date - RentalDate.Date).Days;

            if (daysRented <= 14)
            {
                Fees = 0;
            }
            else
            {
                int extraDays = daysRented - 14;
                Fees = extraDays * FeePerDay;
            }

            Status = TransactionStatus.Returned;

            return Fees;
        }
        public void DisplayInfo()
        {
            Console.WriteLine($"Transaction ID: {TransactionId}");
            Console.WriteLine($"Car ID: {Car.CarId}");
            Console.WriteLine($"Customer ID: {Customer.CustomerId}");
            Console.WriteLine($"Rental Date: {RentalDate}");
            Console.WriteLine("Return Date: " + (Status == TransactionStatus.Returned ? ReturnDate.ToString() : "Not returned yet"));
            Console.WriteLine($"Status: {Status}");
            Console.WriteLine($"Fees: {Fees} EGP");
        }
    }
}
