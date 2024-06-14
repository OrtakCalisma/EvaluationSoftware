using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Transaction;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class FaultManager : IFaultService
    {
        private IFaultDal _faultDal;

        public FaultManager(IFaultDal faultDal)
        {
            _faultDal = faultDal;
        }
        public IDataResult<Faults> GetById(int productId)
        {
            return new SuccessDataResult<Faults>(_faultDal.Get(p => p.Id == productId));
        }
        public IDataResult<List<Faults>> GetBySerialNumber(string serialNumber)
        {
            return new SuccessDataResult<List<Faults>>(_faultDal.GetList().ToList());
        }

        public IDataResult<List<Faults>> GetList()
        {
            return new SuccessDataResult<List<Faults>>(_faultDal.GetList().ToList());
        }

        public IResult Add(Faults fault)
        {
            //IResult result = BusinessRules.Run(CheckIfProductNameExists(product.SerialNumber));

            //if (result != null)
            //{
            //    return result;
            //}
            _faultDal.Add(fault);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Delete(Faults fault)
        {
            _faultDal.Delete(fault);
            return new SuccessResult(Messages.ProductDeleted);
        }

        public IDataResult<List<Product>> GetListByCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        [TransactionScopeAspect]
        public IResult TransactionalOperation(Faults fault)
        {
            _faultDal.Update(fault);
            _faultDal.Add(fault);
            return new SuccessResult(Messages.ProductUpdated);
        }

        public IResult Update(Faults fault)
        {
            _faultDal.Update(fault);
            return new SuccessResult(Messages.ProductUpdated);
        }
        //private IResult CheckIfProductNameExists(string serialNumber)
        //{
        //    var result = _faultDal.GetList(p => p.SerialNumber == serialNumber).Any();
        //    if (result)
        //    {
        //        return new ErrorResult(Messages.ProductNameAlreadyExists);
        //    }
        //    return new SuccessResult();
        //}
    }
}
