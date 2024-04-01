using DesafioCB.Application.Validations;
using DesafioCB.Domain.Models;
using FluentValidation.TestHelper;

namespace DesafioCB.UnitTests
{
    [TestFixture]
    public class ProdutoValidatorTests
    {
        private ProdutoValidator _validator;

        [SetUp]
        public void Setup()
        {
            _validator = new ProdutoValidator();
        }

        [TestCase("Produto de Teste", 10.5, 5, "2022-01-01")] // Valores válidos
        [TestCase("", 0, 0, "2022-01-01")] // Nome vazio, Preco e Quantidade zero
        [TestCase("Produto com nome muito grande que ultrapassa o limite de cinquenta caracteres", 10.5, 5, "2022-01-01")] // Nome com mais de 50 caracteres
        public void Validate_ProdutoValido_ShouldNotHaveValidationErrors(string nome, decimal preco, int quantidade, string dataCadastro)
        {
            var produto = new Produto
            {
                Nome = nome,
                Preco = preco,
                Quantidade = quantidade,
                DataCadastro = DateTime.Parse(dataCadastro)
            };

            var result = _validator.TestValidate(produto);

            Assert.That(result.IsValid, Is.True);
            Assert.That(result.Errors, Is.Empty);
        }

        //[TestCase(null, 10.5, 5, "2022-01-01")] // Nome nulo
        //[TestCase("Produto de Teste", null, 5, "2022-01-01")] // Preço nulo
        //[TestCase("Produto de Teste", 10.5, null, "2022-01-01")] // Quantidade nula
        //[TestCase("Produto de Teste", 10.5, 5, null)] // DataCadastro nula
        //[TestCase("Produto de Teste", 10.5, 5, "2025-01-01")] // DataCadastro no futuro
        //public void Validate_ProdutoInvalido_ShouldHaveValidationErrors(string nome, decimal? preco, int? quantidade, string dataCadastro)
        //{
        //    var produto = new Produto
        //    {
        //        Nome = nome,
        //        Preco = preco ?? 0,
        //        Quantidade = quantidade ?? 0,
        //        DataCadastro = dataCadastro != null ? DateTime.Parse(dataCadastro) : (DateTime?)null
        //    };

        //    var result = _validator.TestValidate(produto);

        //    Assert.That(result.IsValid, Is.False);
        //    Assert.That(result.Errors, Is.Not.Empty);
        //}
    }
}