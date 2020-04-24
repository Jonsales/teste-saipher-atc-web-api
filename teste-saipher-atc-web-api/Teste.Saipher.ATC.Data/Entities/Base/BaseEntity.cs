using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Teste.Saipher.ATC.Data.Entities.Base
{
    public class BaseEntity
    {
        [Column("Id")]
        [Key]
        public int Id { get; set; }

        [Column("Data_Cadastro")]
        public DateTime? DataCadastro { get; set; } = DateTime.Now;

        [Column("Data_Alteracao")]
        public DateTime? DataAlteracao { get; set; }

        internal static DateTime ConvertDate(DateTime? date)
        {
            return (date != null && date.HasValue) ? date.Value : DateTime.Now;
        }
    }
}
