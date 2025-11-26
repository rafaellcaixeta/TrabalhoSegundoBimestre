namespace ProjetoSegundoBimestre.DTO.Request
{
    public class AtualizarMatriculaRequest
    {
        public int IdAluno { get; set; }
        public int IdCurso { get; set; }
        public DateTime DataMatricula { get; set; }
        public bool Ativo { get; set; }
    }
}
