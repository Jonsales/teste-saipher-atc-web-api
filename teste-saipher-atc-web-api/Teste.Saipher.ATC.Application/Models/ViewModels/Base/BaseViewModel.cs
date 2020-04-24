using System;

namespace Teste.Saipher.ATC.Application.Models.ViewModels.Base
{
    public class BaseViewModel
    {
        public int id { get; set; }
        public DateTime dataCadastro { get; set; }
        public DateTime? dataAlteracao { get; set; }
    }
}
