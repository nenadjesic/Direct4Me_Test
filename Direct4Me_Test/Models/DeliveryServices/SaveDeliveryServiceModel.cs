using Direct4Me_Test.Entities;
using System.ComponentModel.DataAnnotations;

namespace Direct4Me_Test.Models.DeliveryServices
{
    public class SaveDeliveryServiceModel
    {
        [Required]
        public virtual string Title { get; set; }
        [Required]
        public virtual string Code { get; set; }

    }
}