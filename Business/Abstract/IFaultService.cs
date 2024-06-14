using Core.Utilities.Results;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IFaultService
    {
        IDataResult<Faults> GetById(int productId);
        IDataResult<List<Faults>> GetBySerialNumber(string serialNumber);
        IDataResult<List<Faults>> GetList();
        //IDataResult<List<Faults>> GetListByCategory(int categoryId);
        IResult Add(Faults product);
        IResult Delete(Faults product);
        IResult Update(Faults product);

        IResult TransactionalOperation(Faults product);
    }
}
