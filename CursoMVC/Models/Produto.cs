using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CursoMVC.Models
{
    public class Produto
    {
        public int Id { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "O campo descrição é obrigatorio!")]
        public string Desccricao { get; set; }

        [Range(1, 10, ErrorMessage = "Quantidade não permitida!")]
        public int Quantidade { get; set; }
        
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
    }
}
