using System.ComponentModel.DataAnnotations;

namespace TodoDemo.Models
{
    public class TodoType
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Blabla")]
        [Display(Name ="ute eller inne")]
        public string UteInne { get; set; }

        public ICollection<Todo> Todos { get; set; }
    }
}
