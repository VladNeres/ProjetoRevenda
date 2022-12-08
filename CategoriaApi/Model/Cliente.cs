using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CategoriaApi.Model
{

    public class Cliente
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "É necessario informar o nome do cliente")]
        [RegularExpression(@"[a-zA-Zá-úÁ-Ú' '/s]{1,20}", ErrorMessage = "O campo nome deve conter apenas letras")]
        public string Nome {get; set;}
        [JsonIgnore]
        public virtual Endereco Endereco { get; set; }
        public int EnderecoId { get; set; }
    }
}
