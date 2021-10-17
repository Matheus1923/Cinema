using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaMat.Models
{
    [Table("Filme")]
    public class Filme
    {
        [Key]
        [Column("idfilme")]
        [Required(ErrorMessage = "O campo é obrigatório")]

        public Int32 IdFilme { get; set; }

        [Column("nome")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo não pode ser nulo")]

        public String Nome { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "O campo deve ter entre 10 á 50 caracteres")]
        [Column("genero")]
        public String Genero { get; set; }

        [Column("idingresso")]
        [Required(ErrorMessage = "O campo é obrigatório")]
        public int IdIngresso { get; set; }
    }
}
