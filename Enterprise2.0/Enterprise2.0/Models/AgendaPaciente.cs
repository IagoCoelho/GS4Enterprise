namespace Enterprise2._0.Models
{
    public class AgendaPaciente
    {
        public int IdAgenda { get; set; }
        public string? Remedio { get; set; }
        public string? Descricao { get; set; }
        public DateTime DtInicio { get; set; }
        public DateTime? DtFim { get; set; }

        public int UsuarioPacienteId { get; set; }
        public UsuarioPaciente UsuarioPaciente { get; set; }
    }
}
