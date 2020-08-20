using System;
using System.Collections.Generic;
using System.Text;

namespace EasyHome.Shared
{
    public class BaseEntity
    {
        [NotToUpdate]
        public int ID { get; set; }
        [NotToUpdate]
        public DateTime InsertDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
