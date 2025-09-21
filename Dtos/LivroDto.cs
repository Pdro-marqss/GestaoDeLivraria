using GestaoDeLivraria.Enums;

namespace GestaoDeLivraria.Dtos;

/// <summary>
/// Campos que representam um livro da livraria.
/// </summary>
public class LivroDto
{
    public string Id { get; set; } = string.Empty;
    public string Titulo { get; set; } = string.Empty;
    public string Autor { get; set; } = string.Empty;
    public Genero Genero { get; set; }
    public int Preco { get; set; }
    public int QuantidadeEmEstoque { get; set; }
}