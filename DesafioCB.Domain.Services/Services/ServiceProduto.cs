using DesafioCB.Domain.Core.Interfaces.Repositorys;
using DesafioCB.Domain.Core.Interfaces.Services;
using DesafioCB.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioCB.Domain.Services.Services
{
    public class ServiceProduto : ServiceBase<Produto>, IServiceProduto
    {
        private readonly IRepositoryProduto _repositoryProduto;

        public ServiceProduto(IRepositoryProduto RepositoryProduto)
            : base(RepositoryProduto)
        {
            _repositoryProduto = RepositoryProduto;
        }
    }
}
