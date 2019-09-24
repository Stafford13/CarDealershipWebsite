using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.Models
{
    public class CarEditViewModel
    {
        public IEnumerable<SelectListItem> Makes { get; set; }
        public IEnumerable<SelectListItem> Models { get; set; }
        public Car Car { get; set; }
        public HttpPostedFileBase ImageUpload { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrEmpty(Car.Body))
            {
                errors.Add(new ValidationResult("Body is required"));
            }

            if (string.IsNullOrEmpty(Car.ExColor))
            {
                errors.Add(new ValidationResult("An exterior color is required"));
            }

            if (string.IsNullOrEmpty(Car.IntColor))
            {
                errors.Add(new ValidationResult("An interior color is required"));
            }

            if (string.IsNullOrEmpty(Car.Type))
            {
                errors.Add(new ValidationResult("Type is required"));
            }

            if (Car.MSRP < 0)
            {
                errors.Add(new ValidationResult("MSRP must be greater than or equal to 0"));
            }

            if (Car.Price < 0)
            {
                errors.Add(new ValidationResult("Price must be greater than or equal to 0"));
            }

            if (Car.Price >= (Car.MSRP * 100))
            {
                errors.Add(new ValidationResult("Price can not be more than 100% of the MSRP"));
            }

            if (string.IsNullOrEmpty(Car.Make.MakeName))
            {
                errors.Add(new ValidationResult("The make of the car is required"));
            }

            if (string.IsNullOrEmpty(Car.Model.ModelName))
            {
                errors.Add(new ValidationResult("The model of the car is required"));
            }

            if (ImageUpload != null && ImageUpload.ContentLength > 0)
            {
                var extensions = new string[] { ".jpg", ".png", ".gif", ".jpeg" };

                var extension = Path.GetExtension(ImageUpload.FileName);

                if (!extensions.Contains(extension))
                {
                    errors.Add(new ValidationResult("Image file must be a jpg, png, gif, or jpeg."));
                }
            }

            if (Car.Year <= 2000 || Car.Year >= 2021)
            {
                errors.Add(new ValidationResult("Year must be between 2000 and 2021"));
            }

            if (Car.Mileage < 0)
            {
                errors.Add(new ValidationResult("Milage must be greater than or equal to 0"));
            }

            if (Car.Mileage < 1000 && Car.Type != "New")
            {
                errors.Add(new ValidationResult("Type must be new if mileage is less than 1000"));
            }

            if (Car.Mileage >= 1000 && Car.Type != "Used")
            {
                errors.Add(new ValidationResult("Type must be new if mileage is less than 1000"));
            }
            return errors;
        }
    }
}