using System.ComponentModel.DataAnnotations;
using System;

namespace ApiRevenda.Data.Dto.Anotacoes
{
    public class CreateAnotacaoDto
    {

        [Required]
        public int Valor { get; set; }
        public string Notacao { get; set; }
        public DateTime Data { get; set; }

        [Required]
        public int ClienteId { get; set; }
    }
}
