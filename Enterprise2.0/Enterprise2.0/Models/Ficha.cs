namespace Enterprise2._0.Models
{
    public class Ficha
    {
        public int IdFicha { get; set; }
        public string? SintomasAtuais { get; set; }
        public string? MedicamentosUso { get; set; }
        public string? Alergias { get; set; }
        public int Peso { get; set; }
        public int Altura { get; set; }
        public string? Observacoes { get; set; }

        // Relacionamento com UsuarioPaciente
        public int UsuarioPacienteId { get; set; }
        public UsuarioPaciente? UsuarioPaciente { get; set; }
    }
}
