﻿using System;
using System.ComponentModel.DataAnnotations;

namespace CategoriaApi.Data.Dto.DtoSubCategoria
{
    public class CreateSubCategoriaDto
    {
        [Required(ErrorMessage = "O campo nome é obrigatório")]
        [StringLength( 50, ErrorMessage = "A subCategoria deve conter no minimo três caracteres")]
        [RegularExpression(@"[a-zA-Zá-úÁ-Ú' '\s]{1,30}", ErrorMessage = "O campo nome deve conter apenas letras")]
        public string Nome { get; set; }
     
        [Required(ErrorMessage = "É necessario informar o Id da categoria que deseja cadastar a subcategoria")]
        public int CategoriaId { get; set; }
    }
}
