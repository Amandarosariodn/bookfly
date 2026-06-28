using System.ComponentModel.DataAnnotations;

namespace bookfly.Domain.Comunidades.Enums
{
    public enum GeneroComunidadeEnum
    {
        [Display(Name = "Romance")]
        Romance = 1,
        [Display(Name = "Fantasia")]
        Fantasia = 2,
        [Display(Name = "Ficção Científica")]
        FiccaoCientifica = 3,
        [Display(Name = "Terror")]
        Terror = 4,
        [Display(Name = "Mangás")]
        Mangas = 5,
        [Display(Name = "Clássicos")]
        Classicos = 6,
        [Display(Name = "Não Ficção")]
        NaoFiccao = 7,
        [Display(Name = "Geral")]
        Geral = 8
    }
}