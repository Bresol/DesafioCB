using DesafioCB.Application.DTO.DTO;
using DesafioCB.Application.Interfaces;
using DesafioCB.Application.Validations;
using DesafioCB.Domain.Core.Interfaces.Services;
using DesafioCB.Domain.Models;
using DesafioCB.Infrastruture.CrossCutting.Adapter.Interfaces;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioCB.Application.Services
{
    public class ApplicationServiceProduto : IDisposable, IApplicationServiceProduto
    {
        private readonly IServiceProduto _serviceProduto;
        private readonly IMapperProduto _mapperProduto;

        public ApplicationServiceProduto(IServiceProduto ServiceProduto
                                         , IMapperProduto MapperProduto)
        {
            _serviceProduto = ServiceProduto;
            _mapperProduto = MapperProduto;
        }

        public void Add(ProdutoDTO obj)
        {
            var objProduto = _mapperProduto.MapperToEntity(obj);

            var validator = new ProdutoValidator();
            ValidationResult result = validator.Validate(objProduto);

            if (result.IsValid)
                _serviceProduto.Add(objProduto);
        }

        public void Dispose()
        {
            _serviceProduto.Dispose();
        }

        public IEnumerable<ProdutoDTO> GetAll()
        {
            var objProdutos = _serviceProduto.GetAll();
            return _mapperProduto.MapperListProdutos(objProdutos);
        }

        public ProdutoDTO GetById(int id)
        {
            var objProduto = _serviceProduto.GetById(id);
            return _mapperProduto.MapperToDTO(objProduto);
        }

        public void Remove(ProdutoDTO obj)
        {
            var objProduto = _mapperProduto.MapperToEntity(obj);
            _serviceProduto.Remove(objProduto);
        }

        public void Update(ProdutoDTO obj)
        {
            var objProduto = _mapperProduto.MapperToEntity(obj);
            _serviceProduto.Update(objProduto);
        }
    }
}
