using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.NetworkInformation;

namespace RecyclingApp.Models
{
    public class WeightRangeAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var weight = (decimal)value;
            var dbContext = new ApplicationDbContext(); // Ensure you have a way to access the DbContext

            // Fetch the RecyclableType based on the ID from the model instance
            var recyclableTypeId = dbContext.RecyclableItems
                .Where(item => item.Weight == weight)
                .Select(item => item.RecyclableTypeId)
                .FirstOrDefault();

            var recyclableType = dbContext.RecyclableTypes.Find(recyclableTypeId);

            if (recyclableType == null)
            {
                return false; // Invalid recyclable type ID
            }

            return weight >= recyclableType.MinKg && weight <= recyclableType.MaxKg;
        }

        public override string FormatErrorMessage(string name)
        {
            return $"The weight must be between between the listed weight.";
        }
    }
}
