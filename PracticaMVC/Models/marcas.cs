using System.ComponentModel.DataAnnotations;
namespace PracticaMVC.Models
{
    public class marcas
    {
        [Key]
        [Display(Name = "ID")]
        public int id_marcas { get; set; }
        [Display(Name = "Nombre de la marca")]
        public string? nombre_marca { get; set; }
        [Display(Name = "Estado")]
        public char estados { get; set; }

    }
}
