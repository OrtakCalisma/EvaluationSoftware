using Core.Utilities.Results;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IFileService
    {
        IResult Add(IFormFile file);
        IDataResult<HRS> Get(string fileName);
        IDataResult<List<HRS>> GetAll(string fileName);

    }
}
