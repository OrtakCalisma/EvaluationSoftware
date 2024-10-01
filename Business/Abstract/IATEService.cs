using Core.Utilities.Results;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IATEService
    {
        IDataResult<ATE> GetById(int productId);
        IDataResult<List<ATE>> GetBySerialNumber(string serialNumber);
        IDataResult<List<ATE>> GetList();
        IDataResult<List<ATE>> GetListByCategory(int categoryId);
        IResult Add(ATE product);
        IResult Delete(ATE product);
        IResult Update(ATE product);

        IResult TransactionalOperation(ATE product);
    }
}
