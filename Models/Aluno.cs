using System.ComponentModel.DataAnnotations;

namespace GinasioIsla.Models
{
    public class Aluno
    {
        public int ID { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Apelido { get; set;} = string.Empty;

        [DataType(DataType.Date)]
        [Display(Name ="Data de Inscrição")]
        public DateTime DataInscricao { get; set;}

        public ICollection<Inscricao> Inscricoes { get; set;}
    }
}
