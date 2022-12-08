using System.ComponentModel.DataAnnotations;

namespace RevendaApi.Data.Dto.ClienteDto
{
    public class CreateClienteDto
    {
        [Required(ErrorMessage ="Por favor insira o nome do cliente")]
        [RegularExpression(@"[a-zA-Zá-úÁ-Ú' '/s]{1,20}", ErrorMessage = "O campo nome deve conter apenas letras")]
        public string Nome { get; set; }
        
        public int EnderecoId { get; set; }
    }
}
