using DesafioCB.Application.DTO.DTO;
using DesafioCB.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioCB.Infrastruture.CrossCutting.Adapter.Interfaces
{
    public interface IMapperProduto
    {
        #region Interfaces Mappers
        Produto MapperToEntity(ProdutoDTO produtoDTO);

        IEnumerable<ProdutoDTO> MapperListProdutos(IEnumerable<Produto> produtos);

        ProdutoDTO MapperToDTO(Produto produto);

        #endregion

    }
}
