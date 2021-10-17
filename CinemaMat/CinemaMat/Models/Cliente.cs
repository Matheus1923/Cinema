using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaMat.Models
{
    [Table("Cliente")]
    public class Cliente
    {
        [Key]
        [Column("idcliente")]
        [Required(ErrorMessage = "O campo é obrigatório")]

        public Int32 IdCliente { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo não pode ser nulo")]
        [Column("nome")]

        public string Nome { get; set; }

        [Required]
        [StringLength(7, ErrorMessage = "O valor de caracteres deve ser 7")]
        [Column("registrogeral")]

        public string RegistroGeral { get; set; }

        [Required]
        [StringLength(3, MinimumLength = 1, ErrorMessage = "O campo deve conter pelo menos de 1 á 3 caracteres")]
        [Column("idade")]

        public string Idade { get; set; }

        [Column("idingresso")]
        [Required(ErrorMessage = "O campo deve ser obrigatório")]

        public int IdIngresso { get; set; }
    }
}
