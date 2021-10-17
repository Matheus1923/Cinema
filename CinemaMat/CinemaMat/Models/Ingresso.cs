using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaMat.Models
{
    [Table("Ingresso")]
    public class Ingresso
    {
        [Key]
        [Column("idingresso")]
        [Required (ErrorMessage = "O campo é obrigatório")]

        public Int32 IdIngresso { get; set; }

        [Column("preco")]
        [Required(ErrorMessage = "O campo é obrigatório")]
        public Decimal Preco { get; set; }

     
        [Column("meiaentrada")]
        [Required(ErrorMessage = "O campo é obrigatório")]
        public Boolean MeiaEntrada  { get; set; }
    }
}
