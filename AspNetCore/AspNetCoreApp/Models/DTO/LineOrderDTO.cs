using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace AspNetCoreApp.Models.DTO
{
    public class LineOrderDTO
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string PurchasePrice { get; set; }
        public int CountOrder { get; set; }
        public int? CountShipment { get; set; }
        public int? CodTovara_FK_ { get; set; }
        public int NumberOrder_FK_ { get; set; }
        public DateTime? DataManuf { get; set; }

    }
}
