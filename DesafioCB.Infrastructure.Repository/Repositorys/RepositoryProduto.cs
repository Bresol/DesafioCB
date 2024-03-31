using DesafioCB.Domain.Core.Interfaces.Repositorys;
using DesafioCB.Domain.Models;
using DesafioCB.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioCB.Infrastructure.Repository.Repositorys
{
    public class RepositoryProduto : RepositoryBase<Produto>, IRepositoryProduto
    {
        private readonly SqlContext _context;
        public RepositoryProduto(SqlContext Context)
            : base(Context)
        {
            _context = Context;
        }
    }
}
