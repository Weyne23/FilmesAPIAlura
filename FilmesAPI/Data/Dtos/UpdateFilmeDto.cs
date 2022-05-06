using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos
{
    public class UpdateFilmeDto
    {
        [Required(ErrorMessage = "O campo titulo é obrigratorio")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "O campo diretor é obrigratorio")]
        public string Diretor { get; set; }
        [StringLength(30, ErrorMessage = "O campo genero não pode passar de 30 caracteres")]
        public string Genero { get; set; }
        [Range(1, 400, ErrorMessage = "A duração minima é 1 e maxima 600")]
        public int Duracao { get; set; }
    }
}
