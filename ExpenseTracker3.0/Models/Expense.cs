using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseTracker3._0.Models
{
    public class Expense
    {
        public int Id { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [Range(0, double.MaxValue, ErrorMessage = "Please enter a value greater than 0.")]

        public decimal Value { get; set; }

        [Required(ErrorMessage = "Please enter a description.")]
        [StringLength(75, ErrorMessage = "Description is too long.")]
        required public string? Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please select an expense type.")]
        public string ExpenseType { get; set; }


        [Required(ErrorMessage = "Please enter a date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ExpenseDate { get; set; }
    }
}
