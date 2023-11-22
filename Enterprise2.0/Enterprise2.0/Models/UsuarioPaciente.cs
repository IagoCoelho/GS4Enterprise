namespace Enterprise2._0.Models
{
    public class UsuarioPaciente
    {
        public int IdPaciente { get; set; }
        public string? NomePaciente { get; set; }
        public string? DoencaCronica { get; set; }
        public string? Cpf { get; set; }
        public DateTime DtNascimento { get; set; }
        public Genero Genero { get; set; }
        public String? Endereco { get; set; }
        public String? Telefone { get; set; }
        public String? Email { get; set; }
    }

    public enum Genero 
    {
        Feminino, Masculino
    }
}
