using System;
using Teste.Saipher.ATC.Application.Models.ViewModels.Base;

namespace Teste.Saipher.ATC.Application.Models.ViewModels
{
    public class PlanoVooViewModel : BaseViewModel
    {
        public string numeroVoo { get; set; }
        public string matriculaAeronave { get; set; }
        public DateTime dataHoraVoo { get; set; }
        public string tipoAeronave { get; set; }
        public string origem { get; set; }
        public string destino { get; set; }
    }
}
