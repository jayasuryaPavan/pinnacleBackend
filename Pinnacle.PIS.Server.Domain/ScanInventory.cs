using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pinnacle.PIS.Server.Domain
{
    [Table("ScanInventory", Schema = "dbo")]
    public class ScanInventory
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("ProductInfoId")]
        public int? ProductInfoId { get; set; }

        [Column("ScannedDate")]
        [Required]
        public DateTime ScannedDate { get; set; }

        [Column("ScannedBy")]
        [Required]
        public int ScannedBy { get; set; }

        // Navigation property
        [ForeignKey("ProductInfoId")]
        public ProductInfo ProductInfo { get; set; }
    }
}
