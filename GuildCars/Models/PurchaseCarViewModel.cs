using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.Models
{
    public class PurchaseCarViewModel : IValidatableObject
    {
        public Car Car { get; set; }
        public Sale Sale { get; set; }
        public HttpPostedFileBase ImageUpload { get; set; }
        public Sale Customer { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrEmpty(Sale.Name))
            {
                errors.Add(new ValidationResult("Name is required"));
            }

            if (string.IsNullOrEmpty(Sale.Email))
            {
                errors.Add(new ValidationResult("Email is required"));
            }

            if (string.IsNullOrEmpty(Sale.Phone))
            {
                errors.Add(new ValidationResult("Phone number is required"));
            }

            if (!Regex.Match(Sale.Phone, @"^[01]?[- .]?(\([2-9]\d{2}\)|[2-9]\d{2})[- .]?\d{3}[- .]?\d{4}$").Success)
            {
                errors.Add(new ValidationResult("A correct phone number is required"));
            }

            if (string.IsNullOrEmpty(Sale.Address1))
            {
                errors.Add(new ValidationResult("Street address is required"));
            }

            if (Sale.Price <= (Car.Price * .95))
            {
                errors.Add(new ValidationResult("Sale price must be at least 95% of the vehicle's' price"));
            }

            if (!Regex.Match(Sale.ZipCode.ToString(), @"^\d{5}$").Success)
            {
                errors.Add(new ValidationResult("Zip Code must be a 5 digit number"));
            }

            return errors;
        }

        private bool IsValidEmail (string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}