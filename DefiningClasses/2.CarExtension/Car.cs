using System.Text;

namespace CarManufacturer
{
    internal class Car
    {
        private string meke;
        private string model;
        private int year;
        private double fuelQuantity;
        private double fuelConsumption;

        public string Make
        {
            get { return this.meke; }
            set { this.meke = value; }
        }
        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }
        public int Year
        {
            get { return this.year; }
            set { this.year = value; }
        }
        public double FuelQuantity
        {
            get { return this.fuelQuantity; }
            set { this.fuelQuantity = value; }
        }
        public double FuelConsumption
        {
            get { return this.fuelConsumption; }
            set { this.fuelConsumption = value; }
        }
        public void Drive(double distance)
        {
            if (this.FuelQuantity - (distance *this.FuelConsumption)>0)
            {
                this.FuelQuantity -= distance * this.FuelConsumption;
            }
            else
            {
                Console.WriteLine($"Not enough fuel to perform this trip!");        }
        }
        public string WhoAmI()
        {
            StringBuilder sb = new();
            sb.Append($"Make: { this.Make}");
            sb.Append($"Model: {this.Model}");
            sb.Append($"Year: {this.Year}");
            sb.Append($"Fuel: {this.FuelQuantity:F2}");
            return sb.ToString().TrimEnd();
        }
    }
}