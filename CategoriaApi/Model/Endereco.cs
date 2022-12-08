using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CategoriaApi.Model
{
    public class Endereco
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "É necessario informar o nome da rua")]
        public string Lougradouro { get; set; }
        [Required(ErrorMessage = "É necessario informar o numero da casa")]
        public int Numero { get; set; }
        public string Complemento { get; set; }
        [JsonIgnore]
        public virtual List<Cliente> Cliente { get; set; }
    }
}
