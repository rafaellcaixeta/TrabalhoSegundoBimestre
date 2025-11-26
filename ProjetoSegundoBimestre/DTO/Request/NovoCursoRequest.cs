namespace ProjetoSegundoBimestre.DTO.Request
{
    public class NovoCursoRequest
    {
        public string nome { get; set; }
        public string nomeCoordenador { get; set; }
        public int idCurso { get; set; }
        public bool ativo { get; set; }
    }
}
