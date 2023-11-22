namespace Enterprise2._0.Models
{
    public class ContatosEmergencia
    {
        public int IdContatosEmergencia { get; set; }
        public String? NomeContato { get; set; }
        public String? Parentesco { get; set; }
        public string? Cpf { get; set; }
        public DateTime DtNascimento { get; set; }
        public Genero Genero { get; set; }
        public String? Endereco { get; set; }
        public String? Telefone { get; set; }
        public String? Email { get; set; }
    }
}
