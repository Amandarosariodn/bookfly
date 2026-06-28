using System.ComponentModel.DataAnnotations;

namespace bookfly.Domain.EstanteLivros.Enums
{
    public enum StatusLeituraEnum
    {
        [Display(Name = "Lendo")]
        Lendo = 1,
        [Display(Name = "Lido")]
        Lido = 2,
        [Display(Name = "Quero Ler")]
        QueroLer = 3,
        [Display(Name = "Avaliados")]
        Avaliados = 4
    }
}