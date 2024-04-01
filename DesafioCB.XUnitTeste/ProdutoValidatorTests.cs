using DesafioCB.Application.Validations;
using DesafioCB.Domain.Models;
using FluentValidation.TestHelper;

namespace DesafioCB.XUnitTeste
{
    public class ProdutoValidatorTests
    {
        private readonly ProdutoValidator _validator;

        public ProdutoValidatorTests()
        {
            _validator = new ProdutoValidator();
        }

        [Theory]
        [InlineData("Produto de Teste", 10.5, 5, "2022-01-01")] // Valores válidos
        public void Validate_ProdutoValido(string nome, decimal preco, int quantidade, string dataCadastro)
        {
            var produto = new Produto
            {
                Nome = nome,
                Preco = preco,
                Quantidade = quantidade,
                DataCadastro = System.DateTime.Parse(dataCadastro)
            };

            var result = _validator.TestValidate(produto);

            Assert.Equal(result.IsValid, true);
        }

        [Theory]
        [InlineData("", 0, 0, "2022-01-01")] // Nome vazio, Preco e Quantidade zero
        public void Validate_ProdutoInValido_1(string nome, decimal preco, int quantidade, string dataCadastro)
        {
            var produto = new Produto
            {
                Nome = nome,
                Preco = preco,
                Quantidade = quantidade,
                DataCadastro = System.DateTime.Parse(dataCadastro)
            };

            var result = _validator.TestValidate(produto);

            Assert.Equal(result.ToString(), "O campo Nome é obrigatório.");
        }

        [Theory]
        [InlineData("Produto com nome muito grande que ultrapassa o limite de cinquenta caracteres", 10.5, 5, "2022-01-01")] // Nome com mais de 50 caracteres
        public void Validate_ProdutoInValido_2(string nome, decimal preco, int quantidade, string dataCadastro)
        {
            var produto = new Produto
            {
                Nome = nome,
                Preco = preco,
                Quantidade = quantidade,
                DataCadastro = System.DateTime.Parse(dataCadastro)
            };

            var result = _validator.TestValidate(produto);

            Assert.Equal(result.ToString(), "O campo Nome não pode ter mais de 50 caracteres.");
        }
    }
}