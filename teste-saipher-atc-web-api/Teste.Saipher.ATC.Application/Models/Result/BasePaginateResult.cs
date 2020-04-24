using Teste.Saipher.ATC.Application.Models.ViewModels.Base;
using System;
using System.Collections.Generic;

namespace Teste.Saipher.ATC.Application.Models.Result
{
    public class BasePaginateResult<TViewModel>
        where TViewModel : BaseViewModel
    {
        public int paginaAtual { get; set; }

        public bool proximo { get; set; }

        public bool anterior { get; set; }

        public int totalPaginas { get; set; }

        public int quantidadeItens { get; set; }

        public int quantidadeItensPorPagina { get; set; }
        public List<TViewModel> Itens { get; set; }

        public BasePaginateResult(List<TViewModel> itens, int pagAtual, int qtdItens, int qtdeItensPorPagina)
        {
            paginaAtual = pagAtual;
            quantidadeItens = qtdItens;
            quantidadeItensPorPagina = qtdeItensPorPagina;
            totalPaginas = (int)Math.Ceiling((double)qtdItens / qtdeItensPorPagina);
            proximo = pagAtual < totalPaginas;
            anterior = pagAtual > 1 && totalPaginas > 1;
            Itens = itens;
        }
    }
}
