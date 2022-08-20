using System.ComponentModel.DataAnnotations;

namespace Entra21.CSharp.ClinicaVeterinaria.Servico.ViewModels
{
    public class RacaViewModel
    {
        // obriga a ser preenchido
        // [Display(Name ="Nome")]
        [Display(Name = nameof(Nome))]
        [Required(ErrorMessage = "{0} deve ser preenchido")]
        [MinLength(4, ErrorMessage = "{0} deve conter no mínimo {1} caracters")]
        [MaxLength(50, ErrorMessage = "{0} deve conter no máximo {1} caracters")]
        public string Nome { get; set; }
        
        [Display(Name ="Espécie")]
        [Required(ErrorMessage = "{0} deve ser escolhida")]
        public string Especie { get; set; }
    }
}