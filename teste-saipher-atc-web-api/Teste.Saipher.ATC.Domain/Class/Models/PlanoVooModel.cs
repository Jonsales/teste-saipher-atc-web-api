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

        public PlanoVooModel() { }
        public PlanoVooModel(string numeroVoo = null, string matriculaAeronave = null, DateTime dataHoraVoo = new DateTime(), string tripoAeronave = null, string origem = null, string destino = null)
        {
            this.NumeroVoo = numeroVoo;
            this.MatriculaAeronave = matriculaAeronave;
            this.DataHoraVoo = dataHoraVoo;
            this.TipoAeronave = tripoAeronave;
            this.Origem = origem;
            this.Destino = destino;
        }
    }
}
