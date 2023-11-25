using System.Collections.ObjectModel;

namespace Enterprise2._0.Models
{
    public class UsuarioPaciente
    {
        public int IdPaciente { get; set; }
        public string? NomePaciente { get; set; }
        public string? DoencasCronicas { get; set; }
        public string? NrCpf { get; set; }
        public DateTime DtNascimento { get; set; }
        public string? Sexo { get; set; }
        public string? Endereco { get; set; }
        public string? NrTelefone { get; set; }
        public string? NnEmail { get; set; }

        // Relacionamentos com outras entidades
        public ICollection<AgendaPaciente>? AgendasPacientes { get; set; }
        public ContatosEmergencia? ContatosEmergencia { get; set; }
        public Ficha? Ficha { get; set; }
        public PlanoSaude? PlanoSaude { get; set; }
    }

    public enum Genero 
    {
        Feminino, Masculino
    }
}
