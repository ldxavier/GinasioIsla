namespace GinasioIsla.Models
{
    public class Inscricao
    {
        public int InscricaoID { get; set; }
        public int AlunoID { get; set; }
        public int ModalidadeID { get; set; }

        public Aluno Aluno { get; set;}
        public Modalidade Modalidade { get; set; }
    }
}
