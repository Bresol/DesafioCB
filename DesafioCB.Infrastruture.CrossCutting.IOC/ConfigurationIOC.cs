using Autofac;
using DesafioCB.Application.Interfaces;
using DesafioCB.Application.Services;
using DesafioCB.Domain.Core.Interfaces.Repositorys;
using DesafioCB.Domain.Core.Interfaces.Services;
using DesafioCB.Domain.Services.Services;
using DesafioCB.Infrastructure.Repository.Repositorys;
using DesafioCB.Infrastruture.CrossCutting.Adapter.Interfaces;
using DesafioCB.Infrastruture.CrossCutting.Adapter.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioCB.Infrastruture.CrossCutting.IOC
{
    public class ConfigurationIOC
    {
        public static void Load(ContainerBuilder builder)
        {
            #region Registra IOC

            #region IOC Application
            builder.RegisterType<ApplicationServiceProduto>().As<IApplicationServiceProduto>();
            #endregion

            #region IOC Services
            builder.RegisterType<ServiceProduto>().As<IServiceProduto>();
            #endregion

            #region IOC Repositorys SQL
            builder.RegisterType<RepositoryProduto>().As<IRepositoryProduto>();
            #endregion

            #region IOC Mapper
            builder.RegisterType<MapperProduto>().As<IMapperProduto>();
            #endregion

            #endregion

        }
    }
}
