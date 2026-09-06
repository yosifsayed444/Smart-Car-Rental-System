using Smart_Car_Rental_System.Enums;

namespace Smart_Car_Rental_System.Models
{
    internal class Car
    {
        public string CarId { get; private set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public CarStatus CarStatus { get; private set; }
        public CondtionStatus ConditionStatus { get; private set; }
        public RentalTransactions? ActiveTransaction { get; private set; }

        public Car(string model, int year,
            CarStatus carStatus = CarStatus.Available,
            CondtionStatus conditionStatus = CondtionStatus.Good)
        {
            CarId = Helper.GenerateID("Car");
            Model = model;
            Year = year;
            CarStatus = carStatus;
            ConditionStatus = conditionStatus;
        }

        public bool IsAvailable()
        {
            return CarStatus == CarStatus.Available &&
                   ConditionStatus == CondtionStatus.Good;
        }

        public void Rent(RentalTransactions transaction)
        {
            if (!IsAvailable())
                throw new InvalidOperationException("Car is not available.");

            CarStatus = CarStatus.Rented;
            ActiveTransaction = transaction;
        }

        public void Return()
        {
            CarStatus = ConditionStatus == CondtionStatus.Good ? CarStatus.Available: CarStatus.Maintenance;
            ActiveTransaction = null;
        }

        public void SetCondition(CondtionStatus condition)
        {
            ConditionStatus = condition;

            if (condition == CondtionStatus.Bad)
                CarStatus = CarStatus.Maintenance;
            else if (CarStatus == CarStatus.Maintenance)
                CarStatus = CarStatus.Available;
        }
    }
}
