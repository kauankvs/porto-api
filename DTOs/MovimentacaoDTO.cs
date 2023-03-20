namespace PortoAPI.DTOs
{
    public class MovimentacaoDTO
    {
        public string NumeroDeContainer { get; set; } = null!;

        public string Tipo { get; set; } = null!;

        public DateTime Inicio { get; set; }

        public DateTime Fim { get; set; }
    }
}
