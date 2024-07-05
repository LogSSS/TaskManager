using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Todo.Models
{
    [Table("cards")]
    public class Card
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public required string Name { get; set; }

        [Column(TypeName = "text")]
        public string? Description { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DueDate { get; set; }

        [StringLength(15)]
        public string Priority { get; set; }

        public int ListId { get; set; }
        [ForeignKey("ListId")]
        public virtual CardList? List { get; set; }

        [StringLength(50)]
        public string ListName { get; set; }
    }
}
