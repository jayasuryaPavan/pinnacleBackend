using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Pinnacle.PIS.Server.Domain
{

    [Table("ProductInfo", Schema = "dbo")]
    public class ProductInfo
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; } 

        [Column("Item_id")]
        [Required]
        public string ItemId { get; set; }

        [Column("Description")]
        [Required]
        [StringLength(500)]
        public string Description { get; set; }
        [Column("sell_price")]
        [Required]
        public string SellPrice { get; set; } 

        [Column("ext_sell_price")]
        [Required]
        public string ExtSellPrice { get; set; } 

        [Column("salvage_percentage")]
        [Required]
        public string SalvagePercentage { get; set; }

        [Column("salvage_amount")]
        [Required]
        public string SalvageAmount { get; set; } 

        [Column("IsDeleted")]
        [Required]
        public bool IsDeleted { get; set; } 

        [Column("CreatedDate")]
        [Required]
        public DateTime CreatedDate { get; set; } 

        [Column("CreatedBy")]
        [Required]
        public int CreatedBy { get; set; } 

        [Column("ModifiedDate")]
        public DateTime? ModifiedDate { get; set; } 

        [Column("ModifiedBy")]
        public int? ModifiedBy { get; set; }
        [Column("BarcodeValue")]
        public int BarcodeValue { get; set; }
        [NotMapped]
        public int ItemQuantity { get; set; }
        public ICollection<AvailableProductQuantity> AvailableProductQuantities { get; set; }
        public ICollection<ScanInventory> ScanInventories { get; set; }


    }
}
