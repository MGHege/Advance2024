namespace CarManufacturer
{
    class Car
    {
        private string model;
        private string meke;
        private int year;

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
    }
}