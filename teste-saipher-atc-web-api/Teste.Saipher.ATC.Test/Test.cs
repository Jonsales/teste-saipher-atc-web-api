using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Teste.Saipher.ATC.Data.Repositories;
using Teste.Saipher.ATC.Domain.Class;
using Teste.Saipher.ATC.Domain.Class.Filters;
using Teste.Saipher.ATC.Domain.Class.Models;
using Teste.Saipher.ATC.Domain.Interfaces.Repositories;
using Teste.Saipher.ATC.Domain.Services;

namespace Teste.Saipher.ATC.Test
{
    public class Tests
    {
        PlanoVooService planoService;
        PlanoVooModel planoVooModel;

        [SetUp]
        public void Setup()
        {
            this.planoVooModel = new PlanoVooModel();
            var planoRepository = new PlanoVooRepositoryMock();
            this.planoService = new PlanoVooService(planoRepository);
        }

        [Category("Validação")]
        [Test( Description = "Valida informação vazia")]
        public async Task Test_valida_sem_preenchimento()
        {
            planoVooModel = null;
            Exception ex = Assert.ThrowsAsync<Exception>(async () => await planoService.Criar(planoVooModel));
            Assert.IsTrue(ex.Message.Equals("Preencha os campos para prosseguir"));
        }
        [Category("Validação")]
        [Test(Description = "Valida Numero do Voo")]
        public async Task Test_valida_sem_preenchimento_numero_voo()
        {
            planoVooModel = new PlanoVooModel();
            Exception ex = Assert.ThrowsAsync<Exception>(async () => await planoService.Criar(planoVooModel));
            Assert.IsTrue(ex.Message.Equals("Preencha o Número do Voo"));
        }

        [Category("Validação")]
        [Test(Description = "Valida Matricula aeronave")]
        [TestCase("ABC1234")]
        public async Task Test_valida_sem_preenchimento_matricula_aeronave(string numeroVoo)
        {
            planoVooModel = new PlanoVooModel(numeroVoo);
            Exception ex = Assert.ThrowsAsync<Exception>(async () => await planoService.Criar(planoVooModel));
            Assert.IsTrue(ex.Message.Equals("Preencha a Matrícula da Aeronave"));
        }

        [Category("Validação")]
        [Test(Description = "Valida Tipo Aeronave")]
        [TestCase("ABC1234", "AD-1234")]
        public async Task Test_valida_sem_preenchimento_tipo_aeronave(string numeroVoo, string matriculaAeronave)
        {
            planoVooModel = new PlanoVooModel(numeroVoo, matriculaAeronave, DateTime.Now);
            Exception ex = Assert.ThrowsAsync<Exception>(async () => await planoService.Criar(planoVooModel));
            Assert.IsTrue(ex.Message.Equals("Preencha o Tipo da Aeronave"));
        }

        [Category("Validação")]
        [Test(Description = "Valida Origem do Voo")]
        [TestCase("ABC1234", "AD-1234", "A320")]
        public async Task Test_valida_sem_preenchimento_origem_voo(string numeroVoo, string matriculaAeronave, string tipoAeronave)
        {
            planoVooModel = new PlanoVooModel(numeroVoo, matriculaAeronave, DateTime.Now, tipoAeronave);
            Exception ex = Assert.ThrowsAsync<Exception>(async () => await planoService.Criar(planoVooModel));
            Assert.IsTrue(ex.Message.Equals("Preencha a Origem do Voo"));
        }
        [Category("Validação")]
        [Test(Description = "Valida Destino do Voo")]
        [TestCase("ABC1234", "AD-1234", "A320", "SBGR")]
        public async Task Test_valida_sem_preenchimento_destino_voo(string numeroVoo, string matriculaAeronave, string tipoAeronave, string origem)
        {
            planoVooModel = new PlanoVooModel(numeroVoo, matriculaAeronave, DateTime.Now, tipoAeronave, origem);
            Exception ex = Assert.ThrowsAsync<Exception>(async () => await planoService.Criar(planoVooModel));
            Assert.IsTrue(ex.Message.Equals("Preencha a Destino do Voo"));
        }

        [Category("Validação")]
        [Test(Description = "Valida Destino e Origem do Voo iguais")]
        [TestCase("ABC1234", "AD-1234", "A320", "SBGR", "SBGR")]
        public async Task Test_valida_sem_preenchimento_origem_destino_voo_iguais(string numeroVoo, string matriculaAeronave, string tipoAeronave, string origem, string destino)
        {
            planoVooModel = new PlanoVooModel(numeroVoo, matriculaAeronave, DateTime.Now, tipoAeronave, origem, destino);
            Exception ex = Assert.ThrowsAsync<Exception>(async () => await planoService.Criar(planoVooModel));
            Assert.IsTrue(ex.Message.Equals("A Origem e o Destino não podem ser iguais"));
        }

        [Category("Validação")]
        [Test(Description = "Valida Número do Voo preenchido")]
        [TestCase("ABC123", "AD-1234", "A320", "SBGR", "SBSP")]
        public async Task Test_valida_preenchimento_numero_voo(string numeroVoo, string matriculaAeronave, string tipoAeronave, string origem, string destino)
        {
            planoVooModel = new PlanoVooModel(numeroVoo, matriculaAeronave, DateTime.Now, tipoAeronave, origem, destino);
            Exception ex = Assert.ThrowsAsync<Exception>(async () => await planoService.Criar(planoVooModel));
            Assert.IsTrue(ex.Message.Equals("O Número do Voo deve conter 7 caracteres"));
        }

        [Category("Validação")]
        [Test(Description = "Valida matricula da Aeronave preenchido")]
        [TestCase("ABC1234", "AD-123", "A320", "SBGR", "SBSP")]
        public async Task Test_valida_preenchimento_matricula_aeronave(string numeroVoo, string matriculaAeronave, string tipoAeronave, string origem, string destino)
        {
            planoVooModel = new PlanoVooModel(numeroVoo, matriculaAeronave, DateTime.Now, tipoAeronave, origem, destino);
            Exception ex = Assert.ThrowsAsync<Exception>(async () => await planoService.Criar(planoVooModel));
            Assert.IsTrue(ex.Message.Equals("A Matrícula da Aeronave deve conter 7 caracteres"));
        }
        [Category("Validação")]
        [Test(Description = "Valida matricula da Aeronave preenchido")]
        [TestCase("ABC1234", "AD-1234", "A3203", "SBGR", "SBSP")]
        public async Task Test_valida_preenchimento_Tipo_aeronave(string numeroVoo, string matriculaAeronave, string tipoAeronave, string origem, string destino)
        {
            planoVooModel = new PlanoVooModel(numeroVoo, matriculaAeronave, DateTime.Now, tipoAeronave, origem, destino);
            Exception ex = Assert.ThrowsAsync<Exception>(async () => await planoService.Criar(planoVooModel));
            Assert.IsTrue(ex.Message.Equals("O Tipo da Aeronave deve conter 7 caracteres"));
        }

        [Category("Validação")]
        [Test(Description = "Valida origem preenchido")]
        [TestCase("ABC1234", "AD-1234", "A320", "ASBGR", "SBSP")]
        public async Task Test_valida_preenchimento_origem(string numeroVoo, string matriculaAeronave, string tipoAeronave, string origem, string destino)
        {
            planoVooModel = new PlanoVooModel(numeroVoo, matriculaAeronave, DateTime.Now, tipoAeronave, origem, destino);
            Exception ex = Assert.ThrowsAsync<Exception>(async () => await planoService.Criar(planoVooModel));
            Assert.IsTrue(ex.Message.Equals("A Origem deve conter 7 caracteres"));
        }
        [Category("Validação")]
        [Test(Description = "Valida destino preenchido")]
        [TestCase("ABC1234", "AD-1234", "A320", "SBGR", "SABSP")]
        public async Task Test_valida_preenchimento_destino(string numeroVoo, string matriculaAeronave, string tipoAeronave, string origem, string destino)
        {
            planoVooModel = new PlanoVooModel(numeroVoo, matriculaAeronave, DateTime.Now, tipoAeronave, origem, destino);
            Exception ex = Assert.ThrowsAsync<Exception>(async () => await planoService.Criar(planoVooModel));
            Assert.IsTrue(ex.Message.Equals("O Destino deve conter 7 caracteres"));
        }

        [Category("Validação")]
        [Test(Description = "Valida destino preenchido")]
        [TestCase("ABC1111", "AD-1234", "A320", "SBGR", "SABS")]
        public async Task Test_valida_preenchimento_numero_voo_existente(string numeroVoo, string matriculaAeronave, string tipoAeronave, string origem, string destino)
        {
            planoVooModel = new PlanoVooModel(numeroVoo, matriculaAeronave, DateTime.Now, tipoAeronave, origem, destino);
            Exception ex = Assert.ThrowsAsync<Exception>(async () => await planoService.Criar(planoVooModel));
            Assert.IsTrue(ex.Message.Equals("O Número do Voo que foi informado, já existe. Informe outro Número do Voo para continuar"));
        }

        [Category("Validação")]
        [Test(Description = "Cadastrar Plano de Voo")]
        [TestCase("ABC1234", "AD-1234", "A320", "SBGR", "SABS")]
        public async Task Test_valida_cadastro_plano_voo(string numeroVoo, string matriculaAeronave, string tipoAeronave, string origem, string destino)
        {
            planoVooModel = new PlanoVooModel(numeroVoo, matriculaAeronave, DateTime.Now, tipoAeronave, origem, destino);
            var resposta = await planoService.Criar(planoVooModel);
            Assert.AreEqual(3, resposta.Id);
        }

        [Category("Validação")]
        [Test(Description = "Verificar Constador")]
        public async Task Test_valida_count()
        {
            var count = await planoService.Count(null);
            Assert.AreEqual(2, count);
        }

        [Category("Validação")]
        [Test(Description = "Cadastrar Plano de Voo")]
        [TestCase("ABC1234", "AD-1234", "A320", "SBGR", "SABS")]
        public async Task Test_valida_atualizar(string numeroVoo, string matriculaAeronave, string tipoAeronave, string origem, string destino)
        {
            planoVooModel = new PlanoVooModel(numeroVoo, matriculaAeronave, DateTime.Now, tipoAeronave, origem, destino);
            planoVooModel.Id = 1;
            planoVooModel.DataAlteracao = null;
            var resposta = await planoService.Atualizar(planoVooModel);
            Assert.IsTrue(planoVooModel.Id == resposta.Id && planoVooModel.DataAlteracao != resposta.DataAlteracao);
        }

        [Category("Validação")]
        [Test(Description = "Cadastrar Plano de Voo")]
        [TestCase("ABC1234", "AD-1234", "A320", "SBGR", "SABS")]
        public async Task Test_valida_atualizar_item_inexistente(string numeroVoo, string matriculaAeronave, string tipoAeronave, string origem, string destino)
        {
            planoVooModel = new PlanoVooModel(numeroVoo, matriculaAeronave, DateTime.Now, tipoAeronave, origem, destino);
            planoVooModel.Id = 5;
            planoVooModel.DataAlteracao = null;
            Exception ex = Assert.ThrowsAsync<Exception>(async () => await planoService.Atualizar(planoVooModel));
            Assert.IsTrue(ex.Message.Equals("O Plano do Voo não existe"));
        }

        [Category("Validação")]
        [Test(Description = "Buscar Plano de Voo")]
        public async Task Test_valida_buscar_item()
        {
            var resposta = await planoService.Buscar(1);
            Assert.IsTrue(resposta != null);
        }

        [Category("Validação")]
        [Test(Description = "Buscar Plano de Voo Inexistente")]
        public async Task Test_valida_buscar_item_inexistente()
        {
            var resposta = await planoService.Buscar(10);
            Assert.IsTrue(resposta == null);
        }


        private class PlanoVooRepositoryMock : IPlanoVooRepository
        {

            List<PlanoVooModel> listMock = new List<PlanoVooModel>()
            {
                new PlanoVooModel()
                {
                    Id = 1,
                    Destino = "ABCD",
                    Origem = "QWER",
                    NumeroVoo = "ABC1111",
                    TipoAeronave = "A320",
                    MatriculaAeronave = "AD-1234",
                    DataHoraVoo = DateTime.Parse("01/02/2020"),
                    DataCadastro = DateTime.Parse("01/01/2020"),
                    DataAlteracao = null
                },
                new PlanoVooModel()
                {
                    Id = 2,
                    Destino = "ABCD",
                    Origem = "QWER",
                    NumeroVoo = "ABC4589",
                    TipoAeronave = "B320",
                    MatriculaAeronave = "AB-1234",
                    DataHoraVoo = DateTime.Parse("10/03/2020"),
                    DataCadastro = DateTime.Parse("15/03/2020"),
                    DataAlteracao = null
                }
            };

            public async Task<int> Count(Expression<Func<PlanoVooModel, bool>> predicate = null)
            {
                return listMock.Count();
            }

            public async Task Delete(int id)
            {
                var delete = await Get(id);
                listMock.Remove(delete);
            }

            public List<PlanoVooModel> Filtrar(Expression<Func<PlanoVooModel, bool>> predicate, int pagAtual, int qtdItensPorPagina)
            {
                throw new NotImplementedException();
            }

            public async Task<List<PlanoVooModel>> Get(PaginateRequest<GenericFilter> paginate)
            {
                return listMock;
            }

            public async Task<PlanoVooModel> Get(int id)
            {
                return listMock.FirstOrDefault(x => x.Id == id);
            }

            public async Task<PlanoVooModel> Insert(PlanoVooModel model)
            {

                model.Id = listMock.Count + 1;
                listMock.Add(model);
                return model;
            }

            public async Task<PlanoVooModel> Update(PlanoVooModel model)
            {
                listMock.FirstOrDefault(x => x.Id == model.Id).DataAlteracao = DateTime.Now;
                return listMock.FirstOrDefault(x => x.Id == model.Id);
            }

            public async Task<bool> VerficarNumeroVoo(string numeroVoo)
            {
                return listMock.Any(x => x.NumeroVoo == numeroVoo);
            }
        }
    }
}