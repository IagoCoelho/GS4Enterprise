namespace Enterprise2._0.Models
{
    public class PlanoSaude
    {
        public int IdPlanoSaude { get; set; }
        public string? NomePlano { get; set; }
        public string? TipoPlano { get; set; }
        public string? Cobertura { get; set; }
        public string? Carencia { get; set; }

        // Relacionamento com UsuarioPaciente
        public int UsuarioPacienteId { get; set; }
        public UsuarioPaciente? UsuarioPaciente { get; set; }
    }
}
