namespace Enterprise2._0.Models
{
    public class ContatosEmergencia
    {
        public int IdContatosEmergencia { get; set; }
        public string? NomeContato { get; set; }
        public string? Parentesco { get; set; }
        public string? Cpf { get; set; }
        public DateTime DtNascimento { get; set; }
        public string? Genero { get; set; }
        public string? Endereco { get; set; }
        public string? Telefone { get; set; }
        public string? Email { get; set; }

        // Relacionamento com UsuarioPaciente
        public int UsuarioPacienteId { get; set; }
        public UsuarioPaciente? UsuarioPaciente { get; set; }
    }
}
