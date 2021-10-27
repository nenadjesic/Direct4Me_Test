using Microsoft.EntityFrameworkCore;

namespace Direct4Me_Test.Entities
{
    public class Article
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Summary { get; set; }

        public string ExternalId { get; set; }

        public string Author { get; set; }

        public int DeliveryServiceId { get; set; }

        public DeliveryService DeliveryService { get; set; }


    }
}