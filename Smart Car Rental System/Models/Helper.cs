namespace Smart_Car_Rental_System.Models
{
    internal static class Helper
    {
        private static int n = 1000;
        public static string GenerateID(string prefix)
        {
            n++;
            return $"{prefix}-{n}";
        }



        public static void ValidateEmail(string? email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                email = "N/A";
                return;
            }
            if (!email.Contains('@') || !email.Contains('.'))
                throw new ArgumentException("Invalid email format.");
        }
        public static int ReadInt(string message)
        {
            while (true)
            {
                Console.Write(message);
                if (int.TryParse(Console.ReadLine(), out int value))
                    return value;

                Console.WriteLine("Please enter a valid number.");
            }
        }

        public static void ValidatePhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone) || !phone.All(char.IsDigit))
                throw new ArgumentException("Invalid phone number ");
        }
    }
}
