using DesafioCB.Application.DTO.DTO;
using DesafioCB.Domain.Models;
using DesafioCB.Infrastruture.CrossCutting.Adapter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioCB.Infrastruture.CrossCutting.Adapter.Map
{
    public class MapperProduto : IMapperProduto
    {

        #region Properties

        List<ProdutoDTO> produtoDTOs = new List<ProdutoDTO>();

        #endregion

        #region methods

        public Produto MapperToEntity(ProdutoDTO produtoDTO)
        {
            Produto produto = new Produto
            {

                IdProduto = produtoDTO.IdProduto,
                Nome = produtoDTO.Nome,
                Preco = produtoDTO.Preco,
                Quantidade = produtoDTO.Quantidade,
                DataCadastro = produtoDTO.DataCadastro,
                DataAlteracao = produtoDTO.DataAlteracao
            };

            return produto;

        }

        public IEnumerable<ProdutoDTO> MapperListProdutos(IEnumerable<Produto> produtos)
        {
            foreach (var item in produtos)
            {

                ProdutoDTO produtoDTO = new ProdutoDTO
                {
                    IdProduto = item.IdProduto,
                    Nome = item.Nome,
                    Preco = item.Preco,
                    Quantidade = item.Quantidade,
                    DataCadastro = item.DataCadastro,
                    DataAlteracao = item.DataAlteracao
                };

                produtoDTOs.Add(produtoDTO);
            }


            return produtoDTOs;

        }

        public ProdutoDTO MapperToDTO(Produto produto)
        {
            ProdutoDTO produtoDTO = new ProdutoDTO
            {
                IdProduto = produto.IdProduto,
                Nome = produto.Nome,
                Preco = produto.Preco,
                Quantidade = produto.Quantidade,
                DataCadastro = produto.DataCadastro,
                DataAlteracao = produto.DataAlteracao
            };

            return produtoDTO;

        }

        #endregion
    }
}
