using Core.Utilities.Results;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IFileService
    {
        IResult Add(IFormFile file);
        IDataResult<HRS> Get(string fileName);
        IDataResult<List<HRS>> GetAll();
        IDataResult<int> GetCount();
        IDataResult<List<HRS>> GetByProjectName(string projectName);
        IDataResult<List<HRS>> GetByBaselineId(string baselineId);
        IDataResult<List<HRS>> GetBy(string? baselineId,string? projectName,string? mocLevel,string? revision);

    }
}
