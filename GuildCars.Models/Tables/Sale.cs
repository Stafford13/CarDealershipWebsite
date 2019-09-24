using System;

namespace GuildCars.Models.Tables
{
    public class Sale
    {
        public int SaleId { get; set; }
        public string UserId { get; set; }
        public DateTime Date { get; set; }
        public int Price { get; set; }
        public int SpecialId{ get; set; }
        public int CarId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
    }
}
