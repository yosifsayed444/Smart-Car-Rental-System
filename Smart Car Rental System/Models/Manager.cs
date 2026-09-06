namespace Smart_Car_Rental_System.Models
{
    internal class Manager : Person
    {
        public string MgrId { get; private set; }
        public decimal Salary { get; set; }
        public DateTime HiredDate { get; set; }

        public Manager(string name, string email, string phone, decimal salary): base(name, email, phone)
        {
            MgrId = Helper.GenerateID("MGR");
            Salary = salary;
            HiredDate = DateTime.Now;
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine(
                   $"ID: {MgrId} | " +
                   $"Salary: {Salary} | " +
                   $"Hire Date: {HiredDate:d} | " 
               );

        }
    }
}
