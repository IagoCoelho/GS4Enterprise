namespace Enterprise2._0.Models
{
    public class UsuarioMedico
    {
        public int IdMedico { get; set; }
        public string? NomeMedico { get; set; }
        public String? Especialidade { get; set; }
        public String? Crm { get; set; }
        public string? Cpf { get; set; }
        public DateTime DtNascimento { get; set; }
        public Genero Genero { get; set; }
        public String? Endereco { get; set; }
        public String? Telefone { get; set; }
        public String? Email { get; set; }
        public ICollection<UsuarioPaciente>? Pacientes { get; set; }
    }
}
