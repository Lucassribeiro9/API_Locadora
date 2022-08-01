using System.ComponentModel.DataAnnotations;

namespace API_Locadora.Models

{
    public class Filme
    {
        // verificação de erros
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo nome é obrigatório!")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O campo deve ter no mínimo três caracteres!")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo gênero é obrigatório!")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "O campo deve ter no mínimo três caracteres!")]
        public string Genero { get; set; }

        public Filme()
        {
        }
    }
}
