using System.ComponentModel.DataAnnotations;
public class Usuario
{   
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    public Usuario() { }

    public Usuario(Guid id)
    {
        Id = id;
    }

    [Required(ErrorMessage ="O nome é obrigatorio.")]
    public string Nome { get; set; } = "";
    [Required(ErrorMessage ="Lograduoro é obrigatorio.")]
    public string Logradouro {get; set;} = "";
    [Required(ErrorMessage ="O Email é obrigatorio.")]
    [EmailAddress(ErrorMessage ="O email informado não é valido")]
    public string Email { get; set; } = "";
    [Required(ErrorMessage ="Informe seu estado.")]
    public string Estado { get; set; } = "";
    [Required(ErrorMessage ="Informe sua cidade.")]
    public string Cidade { get; set; } = "";

}