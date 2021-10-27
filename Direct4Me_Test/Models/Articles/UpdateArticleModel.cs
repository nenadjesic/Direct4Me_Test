using Direct4Me_Test.Entities;
using System.ComponentModel.DataAnnotations;

namespace Direct4Me_Test.Models.Articles
{
  public class UpdateArticleModel
    {
        [Required]
        public virtual string Title { get; set; }
        [Required]
        public virtual string Summary { get; set; }
        [Required]
        public virtual string ExternalId { get; set; }
        [Required]
        public virtual string Author { get; set; }
        [Required]
        public virtual DeliveryService DeliveryService { get; set; }
    }
}