using Teste.Saipher.ATC.Data.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System;

namespace Teste.Saipher.ATC.Data.Entities
{
    [Table("PLANO_VOO")]
    public class PlanoVoo : BaseEntity
    {
        [Column("Numero_voo")]
        [MaxLength(7)]
        public string NumeroVoo { get; set; }

        [Column("Matricula_Aeronave")]
        [MaxLength(7)]
        public string MatriculaAeronave { get; set; }
        [Column("Data_Hora_Voo")]
        public DateTime DataHoraVoo { get; set; }
        [Column("Tipo_Aeronave")]
        [MaxLength(4)]
        public string TipoAeronave { get; set; }

        [Column("Origem")]
        [MaxLength(4)]
        public string Origem { get; set; }

        [Column("Destino")]
        [MaxLength(4)]
        public string Destino { get; set; }
    }
}
