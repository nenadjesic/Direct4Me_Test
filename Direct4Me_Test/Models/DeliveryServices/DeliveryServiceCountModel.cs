using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Direct4Me_Test.Entities;

namespace Direct4Me_Test.Models.DeliveryServiceModel
{

    public class DeliveryServiceCountModel
    {
        public virtual string Title { get; set; }

        public virtual int Count { get; set; }

    }
}