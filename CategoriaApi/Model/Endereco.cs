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

        [Required(ErrorMessage = "O campo Cepo CEP é Obrigatório")]
        public string CEP { get; set; }
        public string UF { get; set; }
        public string Localidade { get; set; }
        public string Bairro { get; set; }
        public string Logradouro { get; set; }
        [Required(ErrorMessage = "É necessario informar o numero da casa")]
        public int Numero { get; set; }
        public string Complemento { get; set; }
        [JsonIgnore]
        public virtual List<Cliente> Cliente { get; set; }
    }
}
