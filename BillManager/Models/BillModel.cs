using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BillManager.Models
{
    public class BillModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BillId { get; set; }

        [Required]
        public string UserId { get; set; }

        public string BillName { get; set; }

        public string BillCompany { get; set; }

        public int BillPrice { get; set; }

        public DateTime BillDueDate { get; set; }

        public bool BillStatus { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
    }
}