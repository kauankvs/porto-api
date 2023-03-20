namespace PortoAPI.Models
{
    //Não é uma entidade do Banco de Dados!!!
    public class Relatorio
    {
        public Dictionary<string, int> movimentacoesPorCliente { get; set; } = null!;
        public Dictionary<string, int> movimentacoesPorTipo { get; set; } = null!;
        public int TotalDeImportacoes { get; set; }
        public int TotalDeExportacoes { get; set; }
    }
}
