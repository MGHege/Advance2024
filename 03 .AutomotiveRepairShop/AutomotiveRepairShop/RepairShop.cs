using System.Text;

namespace AutomotiveRepairShop
{
    public class RepairShop
    {
        public RepairShop(int capacity)
        {
            Capacity = capacity;
            Vehicles = new List<Vehicle>();
        }

        public int Capacity { get; set; }
        public List<Vehicle> Vehicles { get; set; }
        public void AddVehicle(Vehicle vehicle)
        {
            if (Vehicles.Count< Capacity)
            {
                Vehicles.Add(vehicle);
            }
        }
        public bool RemoveVehicle(string vin) => this.Vehicles.Remove(this.Vehicles.FirstOrDefault(v=>v.VIN==vin));
        
        public int GetCount()
        { return this.Vehicles.Count; }
        public Vehicle GetLowestMileage()
        {return this.Vehicles.OrderBy(x => x.Mileage).FirstOrDefault(); }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Vehicles in the preparatory:");

            foreach (Vehicle v in this.Vehicles)
            {
                sb.AppendLine(v.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
