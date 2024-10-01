using Core.Utilities.Results;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IITAService
    {
        IDataResult<List<ITA>> GetByATEId(int id);
        IDataResult<ITA> GetById(int productId);
        IDataResult<List<ITA>> GetBySerialNumber(string serialNumber);
        IDataResult<List<ITA>> GetList();
        IDataResult<List<ITA>> GetListByCategory(int categoryId);
        IResult Add(ITA product);
        IResult Delete(ITA product);
        IResult Update(ITA product);

        IResult TransactionalOperation(ITA product);
    }
}
