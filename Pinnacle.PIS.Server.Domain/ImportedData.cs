using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Pinnacle.PIS.Server.Domain
{
    [Table("ImportedData", Schema = "dbo")] // Specifies the table name and schema
    public class ImportedData
    {
        [JsonIgnore]
        [Key] // Indicates that this is the primary key
        [Column("Id")] // Maps the property to the column "Id"
        public int Id { get; set; }

        [Column("ItemId")] // Maps the property to the column "ItemId"
        [MaxLength(12)] // Specifies the maximum length of the column
        public string ItemId { get; set; }

        [Column("Description")] // Maps the property to the column "Description"
        [Required] // Specifies that this column is required
        [MaxLength(500)] // Specifies the maximum length of the column
        public string Description { get; set; }

        [Column("ItemQuantity")] // Maps the property to the column "ItemQuantity"
        public int ItemQuantity { get; set; }

        [Column("SellPrice")] // Maps the property to the column "SellPrice"
        public string SellPrice { get; set; }

        [Column("ExtSellPrice")] // Maps the property to the column "ExtSellPrice"
        public string ExtSellPrice { get; set; }
        

        [Column("SalvagePercentage")] // Maps the property to the column "SalvagePercentage"
        public string SalvagePercentage { get; set; }
        

        [Column("SalvageAmount")] // Maps the property to the column "SalvageAmount"
        public string SalvageAmount { get; set; }
    }
}
