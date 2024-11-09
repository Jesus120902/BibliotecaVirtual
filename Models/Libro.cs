using System.ComponentModel.DataAnnotations;

public class Libro
{
    public int Id { get; set; }

    [Required]
    public string Titulo { get; set; }

    [Required]
    public string Autor { get; set; }

    [Required]
    public string Tema { get; set; }

    [Required]
    public string Editorial { get; set; }

    [Required]
    [Range(1900, 3000)]
    public int AnioPublicacion { get; set; }

    [Required]
    [Range(10, 1000)]
    public int Paginas { get; set; }

    [Required]
    public string Categoria { get; set; }
}
