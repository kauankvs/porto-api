namespace PortoAPI.DTOs
{
    public class ContainerDTO
    {
        public string Cliente { get; set; } = null!;

        public int Tipo { get; set; }

        public string Status { get; set; } = null!;

        public string Categoria { get; set; } = null!;
    }
}
