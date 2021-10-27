using Direct4Me_Test.Entities;
using System.ComponentModel.DataAnnotations;

namespace Direct4Me_Test.Models.Articles
{
    public class SaveArticleModel
    {
        public virtual string Title { get; set; }
      
        public virtual string Summary { get; set; }
        [Required]
        public virtual string ExternalId { get; set; }

        public virtual string Author { get; set; }
    }
}