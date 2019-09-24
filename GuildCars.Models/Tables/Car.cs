namespace GuildCars.Models.Tables
{
    public class Car
    {
        //public static object Make { get; set; }
        public int CarId { get; set; }
        public string Body { get; set; }
        public int Year { get; set; }
        public int Mileage { get; set; }
        public string ExColor { get; set; }
        public string IntColor { get; set; }
        public string Transmission { get; set; }
        public string Type { get; set; }
        public int MSRP { get; set; }
        public int Price { get; set; }
        public string ImageFileName { get; set; }
        public int MakeId { get; set; }
        public int ModelId { get; set; }
        public bool isFeatured { get; set; }
        public bool isSold { get; set; }
        public virtual Model Model { get; set; }
        public virtual Make Make { get; set; }
        public string VIN { get; set; }
        public string Description { get; set; }
        public int SalePrice { get; set; }
        public int SoldYear { get; set; }
    }
}
