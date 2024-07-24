using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GinasioIsla.Models
{
    public class Modalidade
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ModalidadeID { get; set; }

        [Display(Name = "Modalidade")]
        public string NomeModalidade { get; set; } = string.Empty;

        [Display(Name = "Horas Semanais")]
        public int HorasSemanais { get; set;}

        public ICollection<Inscricao> Inscricoes { get; set; }
    }
}
