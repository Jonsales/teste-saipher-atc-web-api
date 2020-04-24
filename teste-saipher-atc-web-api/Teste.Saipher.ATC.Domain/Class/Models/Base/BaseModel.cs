using System;

namespace Teste.Saipher.ATC.Domain.Class.Models.Base
{
    public class BaseModel
    {
        public int Id { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAlteracao { get; set; }
    }
}
