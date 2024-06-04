using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace API
{
    public class Szkolenia
    {
        [Required]
        public DateOnly Data { get; set; }
        [Required]
        [MaxLength(100)]
        public string? Tytul { get; set; }
        [Required]
        [MaxLength(2000)]
        public string? Opis { get; set; }

    }
}
