using System;
using Teste.Saipher.ATC.Domain.Class.Models.Base;

namespace Teste.Saipher.ATC.Domain.Class.Models
{
    public class PlanoVooModel : BaseModel
    {
        public string NumeroVoo { get; set; }
        public string MatriculaAeronave { get; set; }
        public DateTime DataHoraVoo { get; set; }
        public string TipoAeronave { get; set; }
        public string Origem { get; set; }
        public string Destino { get; set; }

    }
}
