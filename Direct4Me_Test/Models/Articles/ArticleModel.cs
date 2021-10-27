using Direct4Me_Test.Entities;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Direct4Me_Test.Models.Articles
{
    /// <summary>
    ///   Represents Article object.
    /// </summary>
  
    public class ArticleModel 
    {
        public virtual string Title { get; set; }

        public virtual string Summary { get; set; }

        public virtual string ExternalId { get; set; }

        public virtual string Author { get; set; }

        public virtual  DeliveryService DeliveryService { get; set; }

    }
}