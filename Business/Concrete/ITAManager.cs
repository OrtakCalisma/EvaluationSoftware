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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Business.Concrete
{
    public class ITAManager : IITAService
    {
        private IITADal _itaDal;

        public ITAManager(IITADal itaDal)
        {
            _itaDal = itaDal;
        }
        public IResult Add(ITA product)
        {
            _itaDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Delete(ITA product)
        {
            _itaDal.Delete(product);
            return new SuccessResult(Messages.ProductDeleted);
        }

        public IDataResult<List<ITA>> GetByATEId(int id)
        {
            return new SuccessDataResult<List<ITA>>(_itaDal.GetList(x=>x.ATEId == id).ToList());
        }

        public IDataResult<ITA> GetById(int productId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<ITA>> GetBySerialNumber(string serialNumber)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<ITA>> GetList()
        {
            return new SuccessDataResult<List<ITA>>(_itaDal.GetList().ToList());
        }

        public IDataResult<List<ITA>> GetListByCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public IResult TransactionalOperation(ITA product)
        {
            throw new NotImplementedException();
        }

        public IResult Update(ITA product)
        {
            throw new NotImplementedException();
        }
    }
}
