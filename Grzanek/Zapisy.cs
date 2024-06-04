using System.ComponentModel.DataAnnotations;

namespace API
{
    public class Zapisy
    {
        [Required]
        public string Tytul { get; set; }
        [Required]
        public string Imie { get; set; }
        [Required]
        public string Nazwisko { get; set; }

    }
}
