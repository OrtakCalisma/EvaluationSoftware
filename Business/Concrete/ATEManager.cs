using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ATEManager : IATEService
    {
        private IATEDal _ateDal;

        public ATEManager(IATEDal ateDal)
        {
            _ateDal = ateDal;
        }
        public IResult Add(ATE ate)
        {
            _ateDal.Add(ate);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Delete(ATE ate)
        {
            _ateDal.Delete(ate);
            return new SuccessResult(Messages.ProductDeleted);
        }

        public IDataResult<ATE> GetById(int productId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<ATE>> GetBySerialNumber(string serialNumber)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<ATE>> GetList()
        {
            return new SuccessDataResult<List<ATE>>(_ateDal.GetList().ToList());
        }

        public IDataResult<List<ATE>> GetListByCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public IResult TransactionalOperation(ATE product)
        {
            throw new NotImplementedException();
        }

        public IResult Update(ATE product)
        {
            throw new NotImplementedException();
        }
    }
}
