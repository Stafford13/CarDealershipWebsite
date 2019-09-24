using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace GuildCars.Models
{
    public class ContactViewModel : IValidatableObject
    {
        public Customer Customer { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrEmpty(Customer.FirstName))
            {
                errors.Add(new ValidationResult("First Name is required"));
            }

            if (string.IsNullOrEmpty(Customer.LastName))
            {
                errors.Add(new ValidationResult("Last Name is required"));
            }

            if (string.IsNullOrEmpty(Customer.Email))
            {
                errors.Add(new ValidationResult("Email Address is required"));
            }

            if (string.IsNullOrEmpty(Customer.Phone))
            {
                errors.Add(new ValidationResult("Phone is required"));
            }

            if (!Regex.Match(Customer.Phone, @"^[01]?[- .]?(\([2-9]\d{2}\)|[2-9]\d{2})[- .]?\d{3}[- .]?\d{4}$").Success)
            {
                errors.Add(new ValidationResult("A correct phone number is required"));
            }

            if (string.IsNullOrEmpty(Customer.Message))
            {
                errors.Add(new ValidationResult("Message is required"));
            }

            return errors;
        }

        private bool IsValidEmail(string email)
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