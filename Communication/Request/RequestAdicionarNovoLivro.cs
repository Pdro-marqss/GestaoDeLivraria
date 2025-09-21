using GestaoDeLivraria.Enums;

namespace GestaoDeLivraria.Communication.Request;

public class RequestAdicionarNovoLivro
{
    public string Titulo { get; set; } = string.Empty;
    public string Autor { get; set; } = string.Empty;
    public Genero Genero { get; set; }
    public int Preco { get; set; }
    public int QuantidadeEmEstoque { get; set; }
}