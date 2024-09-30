using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pinnacle.PIS.Server.Domain
{
    [Table("AvailableProductQuantity", Schema = "dbo")]

    public class AvailableProductQuantity
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("ProductInfoId")]
        public int? ProductInfoId { get; set; }

        [Column("Quantity")]
        [Required]
        [DefaultValue(0)] // Note: DefaultValue is not directly supported by DataAnnotations, use Fluent API for default values
        public int Quantity { get; set; }

        [Column("CreatedDate")]
        [Required]
        public DateTime CreatedDate { get; set; }

        [Column("CreatedBy")]
        [Required]
        public int CreatedBy { get; set; }

        [Column("UpdatedDate")]
        public DateTime? UpdatedDate { get; set; }

        [Column("UpdatedBy")]
        public int? UpdatedBy { get; set; }

        // Navigation property
        [ForeignKey("ProductInfoId")]
        public ProductInfo ProductInfo { get; set; }
    }
}
