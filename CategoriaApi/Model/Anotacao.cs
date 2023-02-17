using System;
using System.ComponentModel.DataAnnotations;

namespace ApiRevenda.Model
{
    public class Anotacao
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public int Valor { get; set; }
        public string Notacao { get; set; }
        public DateTime Data { get; set; }
    }
}
