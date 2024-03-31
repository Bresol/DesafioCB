using DesafioCB.Application.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioCB.Application.Interfaces
{
    public interface IApplicationServiceProduto
    {
        void Add(ProdutoDTO obj);

        ProdutoDTO GetById(int id);

        IEnumerable<ProdutoDTO> GetAll();

        void Update(ProdutoDTO obj);

        void Remove(ProdutoDTO obj);

        void Dispose();
    }
}
