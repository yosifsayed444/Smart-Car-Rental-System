namespace Smart_Car_Rental_System.Models
{
    internal abstract class Person
    {
        public string Name { get; set; }
        public string Email{ get ; set;}
        public string Phone { get; set; }

        protected Person(string name, string email, string phone)
        {
            Helper.ValidateEmail(email);
            Helper.ValidatePhone(phone);
            Name = name;
            Email = string.IsNullOrEmpty(email) ? "N/A" : email;
            Phone = string.IsNullOrEmpty(phone) ? "N/A" : phone;
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine(
                   $"Name: {Name} | " +
                   $"Email: {Email} | " +
                   $"Phone: {Phone}"
               );

        }
    }
}
