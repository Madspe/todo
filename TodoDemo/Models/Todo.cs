using System.ComponentModel.DataAnnotations;

namespace TodoDemo.Models
{
    public class Todo
    {
       
        public int Id { get; set; }

        [Required(ErrorMessage ="Navn på gjøremål må fylles ut")]
        [StringLength(100, ErrorMessage = "Navn på gjøremål kan ikke overstride 100 tegn")]
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime Deadline { get; set; }

        public bool Done { get; set; } = false;

        [Display(Name ="Ute eller inne")]
        public int TodoTypeId { get; set; }
        public TodoType TodoType { get; set; }
    }
}
