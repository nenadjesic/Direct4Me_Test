using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Direct4Me_Test.Entities
{
    public class DeliveryService
    {
        public DeliveryService()
        {
           Articles = new HashSet<Article>();
        }
        public int Id { get; set; }

        public string Title { get; set; }

        public string Code { get; set; }

        public ICollection<Article> Articles { get; set; }
    }
}